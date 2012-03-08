using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public static class TimeSpanExtensions
    {
        public static string ToMeaningfulString(this TimeSpan timeSpan)
        {
            if (timeSpan.TotalMilliseconds < 1)
            {
                return timeSpan.Ticks + " ticks (1 tick = 100 nanoseconds)";
            }

            if (timeSpan.TotalSeconds < 1)
            {
                return timeSpan.TotalMilliseconds + " milliseconds";
            }

            if (timeSpan.TotalMinutes < 1)
            {
               return timeSpan.TotalSeconds + " seconds";
            }

            if (timeSpan.TotalHours < 1)
            {
                return timeSpan.TotalMinutes + " minutes";
            }

            if (timeSpan.TotalDays < 1)
            {
                return timeSpan.TotalHours + " hours";
            }

            return timeSpan.TotalDays + " days";
        }
    }
}
