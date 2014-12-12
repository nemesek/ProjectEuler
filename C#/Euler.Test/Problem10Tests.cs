using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler.Test
{
    //    The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

    //Find the sum of all the primes below two million.
    [TestClass]
    public class Problem10Tests
    {
        [TestMethod]
        public void Problem10_Solve()
        {
            // Arrange
            var expected = 142913828922;

            // Act
            var actual = SolveIterative();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Problem10_SolveFunctional()
        {
            // Arrange
            var expected = 142913828922;

            // Act
            var actual = SolveFunctional();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        public static long SolveFunctional()
        {
            return FunctionalEratostenes(IsCrossedOff, ExcludeMultiples).Sum();
        }

        public static long SolveIterative()
        {
            return Eratostenes().Sum();
        }

        private static bool IsPrime(int primeNumber)
        {
            var squareRoot = (int)Math.Sqrt(primeNumber);
            return Enumerable.Range(2, squareRoot).All(x => primeNumber % x != 0);
        }

        private static IEnumerable<long> Eratostenes()
        {
            const int max = 2000000;
            var primes = new List<long>();
            var crossedOff = new HashSet<long>();

            long candidate = 1;

            while (candidate < max)
            {
                candidate++;

                if (crossedOff.Contains(candidate))
                {
                    continue;
                }

                primes.Add(candidate);

                // remove multiples of candidate
                for (var i = candidate; i < max + 1; i += candidate)
                {
                    crossedOff.Add(i);
                }
            }

            return primes.ToArray();
        }

        private static IEnumerable<long> FunctionalEratostenes(Func<HashSet<long>, long, bool> isCrossedOff, Action<ICollection<long>, long, int> crossOffMultiples)
        {
            const int max = 2000000;
            var primes = new List<long>();
            var crossedOff = new HashSet<long>();

            for (long i = 2; i < max; i++)
            {
                if (isCrossedOff(crossedOff, i)) continue;
                primes.Add(i);
                crossOffMultiples(crossedOff, i, max);
            }

            return primes.ToArray();
        }

        private static bool IsCrossedOff(ICollection<long> crossedOffList, long candidate)
        {
            return crossedOffList.Contains(candidate);
        }

        private static void ExcludeMultiples(ICollection<long> crossedOffList, long candidate, int max)
        {
            for (var i = candidate; i < max + 1; i += candidate)
            {
                crossedOffList.Add(i);
            }
        }
    }
}
