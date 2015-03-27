using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            var problem = new Problem21();
            var num = problem.SolveIt2();
            sw.Stop();
            PrintTime(sw, num);

        }

        static void PrintTime(Stopwatch sw, int max)
        {
            Console.WriteLine("Elapsed Milliseconds " + sw.ElapsedMilliseconds);
            //Console.WriteLine("Elapsed Ticks " + sw.ElapsedTicks);
            Console.WriteLine("Max " + max);
        }
    }
}
