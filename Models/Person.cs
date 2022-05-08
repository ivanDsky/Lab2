using System;
using System.Threading.Tasks;
using Lab2.Tools;
using Lab2.Tools.Zodiac;

namespace Lab2.Models
{
    public class Person
    {
        public Person(string name, string surname, string email, DateTime dateOfBirth)
        {
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
            Task.Run(() => InitDateFields(dateOfBirth)).Wait();
        }

        private ChinaZodiac _chinaZodiac;
        private EuropeZodiac _europeZodiac;
        private AgeCalculator _calculator;

        public string Name { get; }

        public string Surname { get; }

        public string Email { get; }

        public DateTime DateOfBirth { get; }

        public string BirthDate => DateOfBirth.ToShortDateString();

        public bool IsAdult => _calculator.CurrentAge.Year >= 18;

        public bool IsBirthday => _calculator.CurrentAge.DayOfYear == 1;

        public ChinaZodiac ChinaZodiac => _chinaZodiac;

        public EuropeZodiac EuropeZodiac => _europeZodiac;

        private async Task InitDateFields(DateTime date)
        {
            await Task.Run(() => { _chinaZodiac = new ChinaZodiac(date); });
            await Task.Run(() => { _europeZodiac = new EuropeZodiac(date);});
            await Task.Run(() => { _calculator = new AgeCalculator(date); });
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