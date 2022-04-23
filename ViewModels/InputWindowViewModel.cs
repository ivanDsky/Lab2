using System;
using System.Windows;
using Lab2.Exceptions;
using Lab2.Models;
using Lab2.Tools;
using Lab2.Tools.Validation;
using Lab2.Views;

namespace Lab2.ViewModels
{
    public class InfoWindowViewModel
    {
        #region Private fields
        private Person _person = new Person("","");
        private RelayCommand<object> _showFullInfo;
        private Window? _window = null;

        #endregion

        #region Public fields

        public string Name  { get => _person.Name; set => _person.Name = value; }
        public string Surname  { get => _person.Surname; set => _person.Surname = value; }
        public string Email
        {
            get => _person.Email;
            set => _person.Email = value;
        }

        public DateTime? BirthDate
        {
            get => _person.DateOfBirth;
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
                        BirthDate = _person.DateOfBirth;
                        return;
                    }
                
                _person.DateOfBirth = value;
            }
        }

        #endregion

        #region Private methods
        
        public RelayCommand<object> ShowFullInfo
        {
            get
            {
                return _showFullInfo ??= new RelayCommand<object>(_ => GoToFullInfo(), Validate);
            }
        }

        private void GoToFullInfo()
        {
            try
            {
                EmailValidation.Check(_person.Email);
            }
            catch (IncorrectEmailException e)
            {
                ShowError(e.Message);
                return;
            }
            _window?.Close();
            _window = new ResultWindow(_person);
            _window.Show();
        }

        private bool Validate(object obj)
        {
            return PersonValidation.Validate(_person);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion
    }
}