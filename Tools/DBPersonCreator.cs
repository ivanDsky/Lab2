using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab2.Models;

namespace Lab2.Tools
{
    public static class DBPersonCreator
    {
        private static Random _random = new Random();
        public static List<DBPerson> create(int number)
        {
            List<DBPerson> ret = new List<DBPerson>();
            for (int i = 0; i < number; i++)
            {
                ret.Add(createDBPerson());
            }
            return ret;
        }

        public static DBPerson createDBPerson()
        {
            return new DBPerson(createName(), createSurname(), createEmail(), createDateOfBirth());
        }

        static string createName()
        {
            return "Name_" + _random.Next(1000);
        }

        static string createSurname()
        {
            return "Surname_" + _random.Next(1000);
        }

        static string createEmail()
        {
            return $"email{_random.Next(100000)}@gmail.com";
        }

        static string createDateOfBirth()
        {
            return DateTime.Today.AddDays(-_random.Next(5,365*130)).ToString();
        }
    }
}