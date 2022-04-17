using System;
using System.Windows;
using Lab2.Models;
using Lab2.Tools;
using Lab2.Tools.Validation;

namespace Lab2.ViewModels
{
    public class InfoWindowViewModel
    {
        #region Private fields

        private readonly PersonValidation _validation = new PersonValidation();
        private Person _person = new Person("","");
        private RelayCommand<object> _showFullInfo;

        #endregion

        #region Public fields

        public string Name  { get => _person.Name; set => _person.Name = value; }
        public string Surname  { get => _person.Surname; set => _person.Surname = value; }
        public string Email  { get => _person.Email; set => _person.Email = value; }

        #endregion

        #region Private methods
        private String AgeToString(DateTime age)
        {
            return String.Format("{0} year{1}, {2} month{3}, {4} day{5}",
                age.Year - 1, (age.Year - 1 > 1) ? "s" : "",
                age.Month - 1, (age.Month - 1 > 1) ? "s" : "",
                age.Day - 1, (age.Day - 1 > 1) ? "s" : "");
        }
        public RelayCommand<object> ShowFullInfo
        {
            get
            {
                return _showFullInfo ??= new RelayCommand<object>(_ => GoToFullInfo(), Validate);
            }
        }

        private async void GoToFullInfo()
        {
            if (!Validate(_person))
                MessageBox.Show("Incorrect input!");
            else
            {
                MessageBox.Show($"Correct input for {_person.Name} {_person.Surname}");
            }
        }

        private bool Validate(object obj)
        {
            return _validation.Validate(_person);
        }
        #endregion
    }
}