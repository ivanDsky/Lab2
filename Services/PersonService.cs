using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lab2.Models;
using Lab2.Repository;

namespace Lab2.Services
{
    public class PersonService
    {
        private static FileRepository Repository = new FileRepository();
        private static ObservableCollection<Person> _persons;
        private static List<Person> _origin;
        private static int _filterField, _sortField;
        private static bool _isDescending;
        private static string _filter;
        private static IEnumerable<Person> _filtered;
        public void DeletePerson(Person person)
        {
            Repository.Delete(person.Email);
            _origin.Remove(person);
            _persons.Remove(person);
        }

        public void AddOrUpdate(Person prev, Person person)
        {
            Repository.AddOrUpdateAsync(
                new DBPerson(person.Name, person.Surname, person.Email, person.BirthDate)
            ).Wait();
            if (prev == null)
            {
                _origin.Add(person);
            }
            else
            {
                _origin.Remove(prev);
                _origin.Add(person);
            }
            Search();
        }

        public void FilterBy(int field, string filter)
        {
            _filter = filter;
            _filterField = field;
            if (field < 0 || string.IsNullOrWhiteSpace(filter))
            {
                _filtered = _origin;
            }
            else
            {
                _filtered = _origin.FindAll(Filter(field, new Regex(filter)));
            }
        }

        public void SortBy(int field, bool isDescending)
        {
            _isDescending = isDescending;
            _sortField = field;
            IEnumerable<Person> x = isDescending
                ? _filtered.OrderByDescending(Sort(field))
                : _filtered.OrderBy(Sort(field));
            _persons.Clear();
            foreach (var person in x) _persons.Add(person);
        }

        private void Search()
        {
            FilterBy(_filterField, _filter);
            SortBy(_sortField, _isDescending);
        }

        private Predicate<Person> Filter(int field, Regex regex) =>
            field switch
            {
                0 => item => regex.IsMatch(item.Name),
                1 => item => regex.IsMatch(item.Surname),
                2 => item => regex.IsMatch(item.Email),
                3 => item => regex.IsMatch(item.BirthDate),
                4 => item => regex.IsMatch(item.EuropeZodiac.GetSign()),
                _ => item => regex.IsMatch(item.ChinaZodiac.GetSign())
            };

        private Func<Person, IComparable> Sort(int field) =>
            field switch
            {
                0 => item => item.Name,
                1 => item => item.Surname,
                2 => item => item.Email,
                3 => item => item.DateOfBirth,
                4 => item => item.EuropeZodiac,
                5 => item => item.ChinaZodiac,
                6 => item => item.IsBirthday,
                _ => item => item.IsAdult
            };

        public ObservableCollection<Person> GetAllPersons()
        {
            _origin = Task.Run(() => Repository.GetAllAsync()).Result
                .ConvertAll(from => new Person(from.Name, from.Surname, from.Email, DateTime.Parse(from.DateOfBirth)));
            _persons = new ObservableCollection<Person>(_origin);
            return _persons;
        }
    }

}