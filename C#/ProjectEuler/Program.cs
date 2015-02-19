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
            p.SolveParallel();
            p.SolveParallelFor();
            p.SolveParallelForSafe();
            p.SolveParallelForEach();
            p.SolveParallelForEachSafe();
            var sw = Stopwatch.StartNew();


            var max = p.SolveFast();
            sw.Stop();
            Console.WriteLine("==========================FAST==========================");
            PrintTime(sw, max);


            sw.Restart();
            max = p.SolveSlow();
            Console.WriteLine("==========================SLOW=========================");
            PrintTime(sw, max);


            sw.Restart();
            max = p.SolveParallel();
            Console.WriteLine("==========================ASPARALLEL====================");
            PrintTime(sw, max);

            sw.Restart();
            max = p.SolveParallelFor();
            Console.WriteLine("==========================PARALLELFOR====================");
            PrintTime(sw, max);

            sw.Restart();
            max = p.SolveParallelForSafe();
            Console.WriteLine("==========================PARALLELFORSafe====================");
            PrintTime(sw, max);
            
            sw.Restart();
            max = p.SolveParallelForEach();
            Console.WriteLine("==========================PARALLELFOREACH====================");
            PrintTime(sw, max);

            sw.Restart();
            max = p.SolveParallelForEachSafe();
            Console.WriteLine("==========================PARALLELFOREACHSafe====================");
            PrintTime(sw, max);


            Console.WriteLine("++++++++++++++++++++++++++++");
            Console.WriteLine("Done");
            

        }

        static void PrintTime(Stopwatch sw, long max)
        {
            //Console.WriteLine("Elapsed Milliseconds " + sw.ElapsedMilliseconds);
            Console.WriteLine("Elapsed Ticks " + sw.ElapsedTicks);
            Console.WriteLine("Max " + max);
        }
    }
}
