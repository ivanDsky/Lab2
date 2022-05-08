using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Tools.Zodiac
{
    public class EuropeZodiac : Zodiac
    {
        private static string[] signs = { "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn" };
        private static int[] fromDate = { 21, 20, 21, 21, 22, 22, 23, 23, 22, 23, 22, 22 };

        public EuropeZodiac(DateTime birthDate) : base(birthDate)
        {
            if (_birthDate.Day < fromDate[_birthDate.Month - 1])
                index = _birthDate.Month - 1;
            else
                index = _birthDate.Month;
        }

        public override string GetSign()
        {
            return signs[index];
        }

        public override int CompareTo(object obj)
        {
            if (obj is EuropeZodiac zodiac)
            {
                return index - zodiac.index;
            }
            return 0;
        }
    }
}
