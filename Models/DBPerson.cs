using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Lab2.Tools;
using Lab2.Tools.Zodiac;

namespace Lab2.Models
{
    public class DBPerson
    {
        public DBPerson(string name, string surname, string email, string dateOfBirth)
        {
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public string Name { get; }

        public string Surname { get; }

        public string Email { get; }

        public string DateOfBirth { get; }
    }
}