using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class Problem21
    {
        private static readonly List<int> AmicableNumbers = new List<int>();

        public int SolveIt()
        {
            // 31626
            for (var i = 1; i < 10000; i++)
            {
                var possibleMatch = FindSumOfProperDivisors(i);

                if (possibleMatch >= 10000) continue;

                if (FindSumOfProperDivisors(possibleMatch) != i || possibleMatch == i) continue;
                AmicableNumbers.Add(i);
                AmicableNumbers.Add(possibleMatch);
            }

            return AmicableNumbers.Sum() / 2;
        }


        public int FindSumOfProperDivisors(int number)
        {
            var divisors = new List<int>();

            for (var i = 1; i <= Math.Sqrt(number); i++)
            {
                if (number%i != 0) continue;
                divisors.Add(i);
                var otherFactor = number / i;
                if (otherFactor == i) continue;
                if (otherFactor == number) continue;
                divisors.Add(otherFactor);
            }

            return divisors.Sum();
        }
    }
}
