using System;
using System.ComponentModel;
using System.Windows;
using Lab2.Exceptions;
using Lab2.Models;
using Lab2.Repository;
using Lab2.Services;
using Lab2.Tools;
using Lab2.Tools.Validation;
using Lab2.Views;

namespace Lab2.ViewModels
{
    public class InfoWindowViewModel
    {
        #region Private fields

        private readonly PersonService _service;
        private readonly Person _person;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime? _dateOfBirth;
        private RelayCommand<Window> _save;

        #endregion

        public InfoWindowViewModel(Person person, PersonService service)
        {
            _person = person;
            _service = service;
            if (person == null) return;
            _name = person.Name;
            _surname = person.Surname;
            _email = person.Email;
            _dateOfBirth = person.DateOfBirth;
        }

        #region Public fields

        public string Name  { get => _name; set => _name = value; }
        public string Surname  { get => _surname; set => _surname = value; }
        public string Email { get => _email; set => _email = value; }

        public DateTime? BirthDate
        {
            get =>_dateOfBirth;
            set
            {
                if (value != null)
                    try
                    {
                        BirthDateValidation.Check(value);
                    }
                    catch (AgeException e)
                    {
                        ShowError(e.Message);
                        BirthDate =_dateOfBirth;
                        return;
                    }

               _dateOfBirth = value;
            }
        }
        #endregion

        public RelayCommand<Window> Save =>
            _save ??= new RelayCommand<Window>(RunSave, Validate);


        private void RunSave(Window window)
        {
            if (!Validate(null))
                MessageBox.Show("Incorrect input!");
            else
            {
                try
                {
                    EmailValidation.Check(Email);
                }
                catch (IncorrectEmailException e)
                {
                    ShowError(e.Message);
                    return;
                }

                _service.AddOrUpdate(_person, new Person(Name, Surname, Email, BirthDate.Value));
                window.Close();
            }
        }

        private bool Validate(object obj)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Name)) throw new EmptyFieldException("Name");
                if (string.IsNullOrWhiteSpace(Surname)) throw new EmptyFieldException("Surname");
                if (string.IsNullOrWhiteSpace(Email)) throw new EmptyFieldException("Email");
                BirthDateValidation.Check(BirthDate);
            }
            catch (Exception _)
            {
                return false;
            }

            return true;
        }

        #region Private methods

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion
    }
}