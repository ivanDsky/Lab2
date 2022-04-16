using System;
using System.ComponentModel;
using System.Windows;
using Lab2.Models;
using Lab2.Tools;
using Lab2.Tools.Zodiac;

namespace Lab2.ViewModels
{
    public class InfoWindowViewModel: INotifyPropertyChanged
    {
        #region Private fields
        private Person _person;
        #endregion
        #region Fields

        public string Name { get; set; }

        // public DateTime Date
        // {
        //     get => _date;
        //     set
        //     {
        //         SetDate(value);
        //         PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Date"));
        //     }
        // }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Private methods
        private String AgeToString(DateTime age)
        {
            return String.Format("{0} year{1}, {2} month{3}, {4} day{5}",
                age.Year - 1, (age.Year - 1 > 1) ? "s" : "",
                age.Month - 1, (age.Month - 1 > 1) ? "s" : "",
                age.Day - 1, (age.Day - 1 > 1) ? "s" : "");
        }
        #endregion
    }
}