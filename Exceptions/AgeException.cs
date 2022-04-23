using System;

namespace Lab2.Exceptions
{
    public abstract class AgeException : ArgumentException
    {
        protected AgeException(string message) : base(message){}
    }
}