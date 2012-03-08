using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    [EulerProblem(10, Title="Calculate the sum of all the primes below two million.")]
    public class Problem10
    {
        public long Solve()
        {
            var firstPrimes = new long[] { 2, 3, 5, 7, 11 };

            var primes = firstPrimes.Unfold(priorPrimes =>
                                        priorPrimes.Last()
                                            .OddNumbersGreaterThan()
                                            .SkipWhile(
                                                candidate => priorPrimes
                                                              .TakeWhile(prime => prime * prime <= candidate)
                                                              .Any(prime => candidate.IsDivisibleBy(prime)))
                                            .First()
                                            );

            var sum = primes.TakeWhile(prime => prime < 2000000).Sum();
            return sum;
        }
    }

}
