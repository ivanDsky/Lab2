using System;

namespace Lab2.Exceptions
{
    public class AgeTooOldException : AgeException
    {
        public AgeTooOldException(int maxYears) : base($"Age can't be bigger then {maxYears} years") {}
    }
}