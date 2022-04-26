using System;
using Lab2.Exceptions;
using Lab2.Models;

namespace Lab2.Tools.Validation
{
    public static class BirthDateValidation
    {
        public static void Check(DateTime? dateOfBirth)
        {
            if (!dateOfBirth.HasValue) throw new ArgumentNullException();
            if (dateOfBirth.Value > DateTime.Now) throw new AgeInFutureException();
            if (dateOfBirth.Value < DateTime.Today.AddYears(-135)) throw new AgeTooOldException(135);
        }
    }
}