using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    //The prime factors of 13195 are 5, 7, 13 and 29.
    //What is the largest prime factor of the number 600851475143 ?

    public class Problem3
    {
        public long Solve()
        {
            long max = 600851475143;

            for (var i = 2; max > 0; i++)
            {
                if (max % i == 0)
                {
                    // Grab other factor since it will be larger and check to see if prime
                    max /= i;
                    if (IsPrime(max)) return max;
                }
            }

            // If we are here then the original number must be prime...Thus it is the largest prime factor
            return max;
        }

        private bool IsPrime(long candidate)
        {
            var squareRoot = (int)Math.Sqrt(candidate);
            return !Enumerable.Range(2, squareRoot).Where(x => candidate % x == 0).Any();   

        }
    }
}
