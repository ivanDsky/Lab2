using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Tools.Zodiac
{
    public class ChinaZodiac : Zodiac
    {
        private static string[] signs = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

        public ChinaZodiac(DateTime birthDate) : base(birthDate)
        {
            index = (_birthDate.Year + 8) % 12;
        }

        public override string GetSign()
        {
            return signs[index];
        }

        public override int CompareTo(object obj)
        {
            if (obj is ChinaZodiac zodiac)
            {
                return index - zodiac.index;
            }
            return 0;
        }
    }
}
