using System;
using System.Windows;
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
        public string Email  { get => _person.Email; set => _person.Email = value; }
        public DateTime? BirthDate { get => _person.DateOfBirth; set => _person.DateOfBirth = value; }
        public DateTime StartDate { get => DateTime.Today.AddYears(-135);}
        public DateTime EndDate { get => DateTime.Today;}

        #endregion

        #region Private methods


        public void OnDataChanged(DateTime? date)
        {
            _person.DateOfBirth = date;
        }
        public RelayCommand<object> ShowFullInfo
        {
            get
            {
                return _showFullInfo ??= new RelayCommand<object>(_ => GoToFullInfo(), Validate);
            }
        }

        private void GoToFullInfo()
        {
            if (!Validate(_person))
                MessageBox.Show("Incorrect input!");
            else
            {
                _window?.Close();
                _window = new ResultWindow(_person);
                _window.Show();
                // MessageBox.Show($"Correct input for {_person.Name} {_person.Surname}");
            }
        }

        private bool Validate(object obj)
        {
            return PersonValidation.Validate(_person);
        }
        #endregion
    }
}