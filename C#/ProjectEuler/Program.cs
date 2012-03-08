using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            Problem16 p = new Problem16();
            p.SolveIt();
            sw.Stop();
            Console.WriteLine("Time taken: " + sw.ElapsedMilliseconds);
            


            
            //double sum = 0;
            ////Problem 10
            ////for (int i = 1; i < 2000000; ++i)
            //for (double i = 2; i < 2000000; ++i)
            //{
            //    double sr = Math.Sqrt(i);
            //    bool isPrime = true;
            //    double tempSR = Math.Floor(sr);
            //    for (double j = 2; j <= tempSR; ++j)
            //    {
            //        if (i % j == 0)
            //        {
            //            isPrime = false;
            //            j = sr;
            //        }

            //    }
            //    if (isPrime)
            //    {
            //        sum += i;
            //    }

            //}
            //Console.WriteLine("The sum is: " + sum);
            ////DateTime end = DateTime.Now;
            //sw.Stop();
            ////TimeSpan timeTaken = end.Subtract(start);
           
        }
    }
}
