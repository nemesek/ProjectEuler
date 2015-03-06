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
            //double result = ;
            var isSquare = Math.Abs(Math.Sqrt(number) % 1) < Double.Epsilon;
            return isSquare ? GetFactors(number) - 1 : GetFactors(number);
        }

        public static int GetFactors(int number)
        {
            //var factors = new List<int>();
            var square = Math.Sqrt(number);
            var count = 2;
            for (var i = 2; i <= square; i++)
            {
                if (number%i != 0) continue;
                count += 2;
                //factors.Add(i);
                //var otherFactor = number/i;
                //if (otherFactor != i) factors.Add(otherFactor);
            }

            return count;
        }

        static void PrintTime(Stopwatch sw, long max)
        {
            Console.WriteLine("Elapsed Milliseconds " + sw.ElapsedMilliseconds);
            //Console.WriteLine("Elapsed Ticks " + sw.ElapsedTicks);
            Console.WriteLine("Max " + max);
        }
    }
}
