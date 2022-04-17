using System;
using Lab2.Models;

namespace Lab2.Tools.Validation
{
    public class PersonValidation
    {
        public bool Validate(Person person)
        {
            return
                !String.IsNullOrWhiteSpace(person.Name) &&
                !String.IsNullOrWhiteSpace(person.Surname) &&
                !String.IsNullOrWhiteSpace(person.Email) &&
                person.DateOfBirth != null;
        }
    }
}