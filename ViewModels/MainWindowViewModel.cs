using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Lab2.Models;
using Lab2.Services;
using Lab2.Tools;
using Lab2.Views;

namespace Lab2.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private Window _window = null;
        private Person _person = null;
        private int _selectedFilter = 0;
        private int _selectedSort = -1;
        private bool _isDescending = false;
        private string _filter = String.Empty;
        private PersonService _service;
        private ObservableCollection<Person> _persons;
        private RelayCommand<object> _addPerson;
        private RelayCommand<object> _editPerson;
        private RelayCommand<object> _deletePerson;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Person> Persons
        {
            get => _persons;
            private set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }

        public Person CurrentPerson
        {
            get => _person;
            set
            {
                _person = value;
                CurrentPersonText =
                    value == null ? "" : $"Current person: {CurrentPerson.Name} {CurrentPerson.Surname}";
                OnPropertyChanged("CurrentPersonText");
            }
        }

        public string CurrentPersonText { get; private set; }

        public string Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                Search();
            }
        }

        public bool IsDescending
        {
            get => _isDescending;
            set
            {
                _isDescending = value;
                Search();
            }
        }

        public int SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                _selectedFilter = value;
                Search();
            }
        }

        public int SelectedSort
        {
            get => _selectedSort;
            set
            {
                _selectedSort = value;
                Search();
            }
        }

        public MainWindowViewModel()
        {
            _service = new PersonService();
            _persons = _service.GetAllPersons();
        }

        public RelayCommand<object> AddPerson =>
            _addPerson ??= new RelayCommand<object>(_ => OpenAddEditWindow());
        public RelayCommand<object> EditPerson =>
            _editPerson ??= new RelayCommand<object>(_ => OpenAddEditWindow(), _ => CurrentPerson != null);
        public RelayCommand<object> DeletePerson =>
            _deletePerson ??= new RelayCommand<object>(_ => RunDeletePerson(),_ => CurrentPerson != null);


        private void Search()
        {
            _service.FilterBy(SelectedFilter - 1, Filter);
            _service.SortBy(SelectedSort, IsDescending);
        }

        private void OpenAddEditWindow()
        {
            if (_window != null)_window.Close();
            _window = new InfoWindow(_person, _service);
            _window.Show();
        }

        private void RunDeletePerson()
        {
            _service.DeletePerson(CurrentPerson);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}