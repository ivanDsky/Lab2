using System;

namespace Lab2.Exceptions
{
    public class AgeInFutureException : AgeException
    {
        public AgeInFutureException() : base("Age can't be less then zero"){}
    }
}