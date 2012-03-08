using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    [EulerProblem(7, Title="Find the 10001st prime.")]
    public class Problem7
    {
        public long Solve()
        {
            var firstPrimes = new long[] { 2, 3, 5, 7, 11 };
           
            var primes = firstPrimes.Unfold(priorPrimes =>
                            priorPrimes
                                .Last()
                                .OddNumbersGreaterThan()
                                .SkipWhile(
                                    candidate => priorPrimes
                                      .TakeWhile(prime => prime * prime <= candidate)
                                      .Any(prime => candidate.IsDivisibleBy(prime)))
                                .First()
                                );

            return primes.Skip(10000).First();
        }
    }
}
