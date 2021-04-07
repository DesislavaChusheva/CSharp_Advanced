using System;
using System.Collections.Generic;
using System.Text;

namespace _05.DateModifier
{
    public static class DateModifier
    {
        public static int GetDifferenceBetweenDatesInDays (string dateOneString, string dateTwoString)
        {
            DateTime dateOne = DateTime.Parse(dateOneString);
            DateTime dateTwo = DateTime.Parse(dateTwoString);

            TimeSpan difference = dateOne - dateTwo;
            return Math.Abs(difference.Days);
        }
    }
}
