using System;
using System.Text.RegularExpressions;
using Lab2.Exceptions;

namespace Lab2.Tools.Validation
{
    public static class EmailValidation
    {
        private const string EmailPattern = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";

        private static readonly Regex Validation = new Regex(EmailPattern);
        public static void Check(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !Validation.IsMatch(email)) throw new IncorrectEmailException(email);
        }
    }
}