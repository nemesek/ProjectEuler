using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            // var expected = 2783915460;
            var sw = Stopwatch.StartNew();
            var answer = Problem28();
            sw.Stop();
            PrintTime(sw, answer);

        }

        static void PrintTime(Stopwatch sw, double max)
        {
            Console.WriteLine("Elapsed Milliseconds " + sw.ElapsedMilliseconds);
            //Console.WriteLine("Elapsed Ticks " + sw.ElapsedTicks);
            Console.WriteLine("Sum " + max);
        }

        static double Problem24()
        {
            var problem = new Problem24();
            var set = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var num = problem.Solve(set);
            
            Console.WriteLine(num);
            return num;
        }

        static int Problem28()
        {
            var problem = new Problem28();
            return problem.Solve();
        }
    }
}
