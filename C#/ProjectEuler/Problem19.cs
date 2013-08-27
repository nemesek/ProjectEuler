using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class Problem19
    {
        static Dictionary<int, int> monthsDictionary = new Dictionary<int, int> 
        {
            {1,31}, {2, 28}, {3, 31}, {4,30}, {5, 31}, 
            {6, 30}, {7, 31}, {8, 31}, {9, 30}, {10, 31},
            {11, 30}, {12,31}
        };
        public int CalcForSpecificYear(int year)
        {
            var count = 0;

            // First Sunday in 1901 falls on Jan 6th
            var startDay = 6;

            while (year < 2001)
            {
                for (var i = 1; i < 13; i++)
                {
                    if (startDay == 1)
                        count++;

                    var day = startDay;
                    var daysInMonth = monthsDictionary[i];

                    // Check for leap year
                    if (i == 2 && year % 4 == 0)
                    {
                        daysInMonth = 29;
                    }

                    while (day <= daysInMonth)
                    {
                        day += 7;
                    }

                    // Grab next months starting day
                    startDay = day - daysInMonth;
                }

                year++;
            }

            return count;
        }
    }
}
