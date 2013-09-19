using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    //By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    //What is the 10 001st prime number?
    public class Problem7
    {
        public int SolveIt()
        {
            var count = 1;
            var number = 2;

            while (count < 10001)
            {
                if (IsPrime(number)) count++;
                number++;
            }
            return number - 1;
        }

        private bool IsPrime(int n)
        {
            var squareRoot = (int)Math.Floor(Math.Sqrt(n));

            // if (Enumerable.Range(2, squareRoot).Count(x => n % x == 0) > 0) return false;  // 677 ms
            if (Enumerable.Range(2, squareRoot).Any(x => n % x == 0)) return false; // 122 ms
            return true;

        }
    }
}
