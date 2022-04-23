using System;
using System.Text.RegularExpressions;
using Lab2.Exceptions;

namespace Lab2.Tools.Validation
{
    public class EmailValidation
    {
        private static string EmailPattern =
            "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";

        private static Regex validation = new Regex(EmailPattern); 
        public static void Check(string email)
        {
            if (String.IsNullOrWhiteSpace(email) || !validation.IsMatch(email)) throw new IncorrectEmailException(email);
        }
    }
}