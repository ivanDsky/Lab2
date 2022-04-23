using System;

namespace Lab2.Exceptions
{
    public class EmptyFieldException : ArgumentException
    {
        public EmptyFieldException(string field) : base($"Empty {field}"){}
    }
}