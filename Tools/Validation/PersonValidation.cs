using System;
using Lab2.Exceptions;
using Lab2.Models;

namespace Lab2.Tools.Validation
{
    public static class PersonValidation
    {
        public static void Check(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.Name)) throw new EmptyFieldException("Name");
            if (string.IsNullOrWhiteSpace(person.Surname)) throw new EmptyFieldException("Surname");
            if (string.IsNullOrWhiteSpace(person.Email)) throw new EmptyFieldException("Email");
            if (person.DateOfBirth == null) throw new EmptyFieldException("DateOfBirth");
         
            BirthDateValidation.Check(person.DateOfBirth);
        }
        public static bool Validate(Person person)
        {
            try
            {
                Check(person);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }
    }
}