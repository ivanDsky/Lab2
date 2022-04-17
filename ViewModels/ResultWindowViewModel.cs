using System;
using System.Windows;
using Lab2.Models;
using Lab2.Tools;
using Lab2.Tools.Validation;

namespace Lab2.ViewModels
{
    public class ResultWindowViewModel
    {
        #region Private fields

        private RelayCommand<Window> _closeWindow;

        public ResultWindowViewModel(Person person)
        {
            Person = person;
        }

        #endregion

        #region Public fields

        public Person Person { get; }

        public RelayCommand<Window> CloseWindow => _closeWindow??=
            new RelayCommand<Window>((Window x)=>{x.Close();});
        #endregion
    }
}