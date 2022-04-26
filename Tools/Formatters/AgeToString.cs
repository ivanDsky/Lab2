using System;

namespace Lab2.Tools.Formatters
{
    public class AgeToString
    {
        public static string Format(DateTime age)
        {
            return string.Format("{0} year{1}, {2} month{3}, {4} day{5}",
                age.Year - 1, (age.Year - 1 > 1) ? "s" : "",
                age.Month - 1, (age.Month - 1 > 1) ? "s" : "",
                age.Day - 1, (age.Day - 1 > 1) ? "s" : "");
        }
    }
}