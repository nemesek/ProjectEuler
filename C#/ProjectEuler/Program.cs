using System;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Problem5();
            var sw = System.Diagnostics.Stopwatch.StartNew();
            p.Solve();
            sw.Stop();
            Console.WriteLine("Time taken " + sw.ElapsedMilliseconds);

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
    }
}
