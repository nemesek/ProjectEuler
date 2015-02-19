using System;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {

            var p = new Problem8();
            p.SolveFast();
            p.SolveSlow();
            var sw = Stopwatch.StartNew();
            var max = p.SolveFast();
            sw.Stop();
            PrintTime(sw, max);
            var sw2 = Stopwatch.StartNew();
            var max2 = p.SolveSlow();
            sw2.Stop();
            PrintTime(sw2, max2);

            //for(var i = 0; i < 5; i++)
            //{
            //    var sw = System.Diagnostics.Stopwatch.StartNew();
            //    p.Solve();
            //    sw.Stop();
            //    Console.WriteLine("Linq Time taken: " + sw.ElapsedMilliseconds);


            //    var sw2 = System.Diagnostics.Stopwatch.StartNew();
            //    p.SolveImperative();
            //    sw2.Stop();
            //    Console.WriteLine("Imperative Time taken: " + sw2.ElapsedMilliseconds);
            //    Console.WriteLine("=============================================");
            //}        

        }

        static void PrintTime(Stopwatch sw, long max)
        {
            Console.WriteLine("Elapsed Milliseconds " + sw.ElapsedMilliseconds);
            Console.WriteLine("Elapsed Ticks " + sw.ElapsedTicks);
            Console.WriteLine(max);
        }
    }
}
