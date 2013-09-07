using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem25
    {
        /*The Fibonacci sequence is defined by the recurrence relation:
        Fn = Fn-1 + Fn-2, where F1 = 1 and F2 = 1.
        Hence the first 12 terms will be:

        F1 = 1
        F2 = 1
        F3 = 2
        F4 = 3
        F5 = 5
        F6 = 8
        F7 = 13
        F8 = 21
        F9 = 34
        F10 = 55
        F11 = 89
        F12 = 144
         
        The 12th term, F12, is the first term to contain three digits.

        What is the first term in the Fibonacci sequence to contain 1000 digits?*/

        public int Solve()
        {
            var number = 0;
            //var number = 2;
            //BigInteger fib0 = 1;
            //BigInteger fib1 = 1;
            //BigInteger fib2 = 0;

            //var bigNumber = BigInteger.Pow(10, 999);

            //while (fib2 / bigNumber < 1)
            //{
            //    fib2 = fib0 + fib1;
            //    number++;
            //    fib0 = fib1;
            //    fib1 = fib2;

            //}

            //return number;

            // Use Binet's formula instead where k = number of digits

            var phi = ((Math.Pow(5, 0.5) + 1) / 2);
            var k = 1000;
            number = (int)((k - 1 + Math.Log10(Math.Pow(5, 0.5))) / Math.Log10(phi)) + 1;
            return number;
        }

    }
}
