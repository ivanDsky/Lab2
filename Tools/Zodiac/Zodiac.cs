using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Tools.Zodiac
{
    public abstract class Zodiac: IComparable
    {
        protected DateTime _birthDate;
        protected int index;
        private IComparable _comparableImplementation;

        public Zodiac(DateTime birthDate)
        {
            _birthDate = birthDate;
        }

        public abstract String GetSign();


        public override string ToString()
        {
            return GetSign();
        }

        public abstract int CompareTo(object obj);
    }
}