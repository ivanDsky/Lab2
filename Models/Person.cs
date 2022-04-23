using System;
using Lab2.Exceptions;
using Lab2.Tools;
using Lab2.Tools.Validation;
using Lab2.Tools.Zodiac;

namespace Lab2.Models
{
    public class Person
    {
        public Person(string name, string surname, string? email = null, DateTime? dateOfBirth = null)
        {
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        private DateTime? _dateTime;
        private ChinaZodiac? _chinaZodiac;
        private EuropeZodiac? _europeZodiac;
        private AgeCalculator? _calculator;

        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Email { get; set; }

        public DateTime? DateOfBirth
        {
            get => _dateTime;
            set
            {
                if (value == null)
                {
                    _dateTime = null;
                    _chinaZodiac = null;
                    _europeZodiac = null;
                    _calculator = null;
                    return;
                }
                
                
                try
                {
                    BirthDateValidation.Check(value);
                }
                catch (AgeException e)
                {
                    Console.WriteLine(e);
                    return;
                }
                
                _dateTime = value;
                _chinaZodiac = new ChinaZodiac(_dateTime.Value);
                _europeZodiac = new EuropeZodiac(_dateTime.Value);
                _calculator = new AgeCalculator(_dateTime.Value);
            }
        }

        public string BirthDate
        {
            get
            {
                CheckBirthNotNull();
                return DateOfBirth.Value.ToShortDateString();
            }
        }
        public bool IsAdult
        {
            get
            {
                CheckBirthNotNull();
                return _calculator?.CurrentAge.Year >= 18;
            }
        }

        public bool IsBirthday
        {
            get
            {
                CheckBirthNotNull();
                return _calculator?.CurrentAge.DayOfYear == 1;
            }
        }

        public ChinaZodiac ChinaZodiac
        {
            get
            {
                CheckBirthNotNull();
                return _chinaZodiac;
            }
        }

        public EuropeZodiac EuropeZodiac
        {
            get
            {
                CheckBirthNotNull();
                return _europeZodiac;
            }
        }

        private void CheckBirthNotNull()
        {
            if (DateOfBirth == null)
            {
                throw new MissingFieldException("No date birth detected");
            }
        }

        public override string ToString()
        {
            string ret = $"Name = {Name}\nSurname = {Surname}\nEmail = {Email}\nDate of birth = {BirthDate}\n"+
                   $"IsAdult = {IsAdult}\nIsBirthday = {IsBirthday}\nChinese zodiac = {ChinaZodiac.GetSign()}\nEurope zodiac = {EuropeZodiac.GetSign()}";

            if (IsBirthday)
            {
                ret += "\n\n\nHAPPY BIRTHDAY!!!\n\n\n";
            }

            return ret;
        }
    }
}