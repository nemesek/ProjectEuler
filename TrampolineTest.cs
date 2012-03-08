using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class TrampolineTest
    {
        public static void Main()
        {
            foreach (var term in PrimeFactors(20))
            {
                Console.WriteLine(term);
                Console.ReadLine();
            }
        }

        public static IEnumerable<int> FibonacciTerms(int a, int b)
        {
            var recursiveFibonacciFunction = Trampoline.MakeLazyTrampoline((int x, int y) => Trampoline.YieldAndRecurse<int,int,int>(x + y, y, x + y));
            return recursiveFibonacciFunction(a, b);
        }

        private static IEnumerable<PrimeFactor> PrimeFactors(long prime)
        {
            var function = Trampoline.MakeLazyTrampoline((long previousPrime, long remainder) =>
                {
                    // find next factor of number
                    long nextFactor = (previousPrime + 1).To(remainder)
                        .SkipWhile(x => remainder % x > 0).FirstOrDefault();

                    if (nextFactor == remainder)
                    {
                        return Trampoline.YieldBreak<long, long, PrimeFactor>(new PrimeFactor { Prime = remainder, Multiplicity = 1 });
                    }
                    else
                    {
                        // find its multiplicity
                        long multiplicity = Enumerable.Range(1, Int32.MaxValue).TakeWhile(x => remainder % (long)Math.Pow(nextFactor, x) == 0).Last();
                        long quotient = remainder / (long)Math.Pow(nextFactor, multiplicity);

                        PrimeFactor nextPrimeFactor = new PrimeFactor { Prime = nextFactor, Multiplicity = multiplicity };

                        if (quotient == 1)
                        {
                            return Trampoline.YieldBreak<long, long, PrimeFactor>(nextPrimeFactor);
                        }
                        else
                        {
                            return Trampoline.YieldAndRecurse<long, long, PrimeFactor>(nextPrimeFactor, nextFactor, quotient);
                        }
                    }
                }
                );

            return function(1, prime);
        }
    }
}
