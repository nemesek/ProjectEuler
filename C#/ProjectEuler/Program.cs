using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = 0;
            var triangularNumber = 0;
            var numFactors = 0;
            var sw = Stopwatch.StartNew();

            while (numFactors <= 500)
            {
                number++;
                triangularNumber += number;
                numFactors = GetNumberOfFactors(triangularNumber);
            }

            sw.Stop();
            PrintTime(sw, triangularNumber);

        }

        public static int GetNumberOfFactors(int number)
        {
            return GetFactors(number).Count;
        }

        public static List<int> GetFactors(int number)
        {
            var factors = new List<int>();
            var square = Math.Sqrt(number);

            for (var i = 1; i <= square; i++)
            {
                if (number%i != 0) continue;
                factors.Add(i);
                var otherFactor = number/i;
                if (otherFactor != i) factors.Add(otherFactor);
            }

            return factors;
        }

        static void PrintTime(Stopwatch sw, long max)
        {
            Console.WriteLine("Elapsed Milliseconds " + sw.ElapsedMilliseconds);
            //Console.WriteLine("Elapsed Ticks " + sw.ElapsedTicks);
            Console.WriteLine("Max " + max);
        }
    }
}
