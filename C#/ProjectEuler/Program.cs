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
            var start = DateTime.Now;
            var p = new Problem4();
            for(var i = 0; i < 5; i++)
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                p.Solve();
                sw.Stop();
                Console.WriteLine("Linq Time taken: " + sw.ElapsedMilliseconds);


                var sw2 = System.Diagnostics.Stopwatch.StartNew();
                p.SolveImperative();
                sw2.Stop();
                Console.WriteLine("Imperative Time taken: " + sw2.ElapsedMilliseconds);
                Console.WriteLine("=============================================");
            }        
                 
        }
    }
}
