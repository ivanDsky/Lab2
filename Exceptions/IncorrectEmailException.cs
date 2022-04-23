using System;

namespace Lab2.Exceptions
{
    public class IncorrectEmailException : ArgumentException
    {
        public string Value { get;}

        public IncorrectEmailException(string incorrectEmail) : base($"Incorrect email [{incorrectEmail}]")
        {
            Value = incorrectEmail;
        }
    }
}