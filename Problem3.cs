using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    [EulerProblem(3, Title="Find the largest prime factor of a composite number.")]
    public class Problem3
    {
        public long Solve()
        {
            return FindGreatestPrimeFactor(1, 600851475143);
        }

        public long FindGreatestPrimeFactor(long factorGreaterThan, long number)
        {
            long upperBound = (long)Math.Ceiling(Math.Sqrt(number));

            // find next factor of number
            long nextFactor = (factorGreaterThan + 1).To(upperBound)
                .SkipWhile(x => number % x > 0).FirstOrDefault();

            // if no other factor was found, then the number must be prime
            if (nextFactor == 0)
            {
                return number;
            }
            else
            {
                // find the multiplicity of the factor
                long multiplicity = Enumerable.Range(1, Int32.MaxValue)
                    .TakeWhile(x => number % (long)Math.Pow(nextFactor, x) == 0)
                    .Last();

                long quotient = number / (long)Math.Pow(nextFactor, multiplicity);

                if (quotient == 1)
                {
                    return nextFactor;
                }
                else
                {
                    return FindGreatestPrimeFactor(nextFactor, quotient);
                }
            }
        }   
    }
}
