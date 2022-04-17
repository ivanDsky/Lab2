using System;
using Lab2.Models;

namespace Lab2.Tools.Validation
{
    public class BirthDateValidation
    {
        public static bool Validate(DateTime? dateOfBirth)
        {
            if (!dateOfBirth.HasValue) return false;
            if (dateOfBirth.Value > DateTime.Now) return false;
            if (dateOfBirth.Value < DateTime.Today.AddYears(-135)) return false;
            return true;
        }
    }
}