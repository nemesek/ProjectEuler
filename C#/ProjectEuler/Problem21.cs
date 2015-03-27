using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class Problem21
    {
        private static readonly List<int> AmicableNumbers = new List<int>();
        private int[] cache = new int[10000];

        public int SolveIt()
        {
            // 31626
            for (var i = 1; i < 10000; i++)
            {
                var possibleMatch = FindSumOfProperDivisors(i);
                if (possibleMatch == i) continue;
                if (possibleMatch >= 10000) continue;

                if (FindSumOfProperDivisors(possibleMatch) != i) continue;
                AmicableNumbers.Add(i);
                AmicableNumbers.Add(possibleMatch);
            }

            return AmicableNumbers.Sum() / 2;
        }

        public int SolveIt2()
        {
            var amicableNumbers = new int[10000];
            // 31626
            for (var i = 1; i < 10000; i++)
            {
                if (amicableNumbers[i] != 0) continue;
                var possibleMatch = FindSumOfProperDivisorsWithCache(i);
                if (possibleMatch == i) continue;
                if (possibleMatch >= 10000) continue;

                if (FindSumOfProperDivisorsWithCache(possibleMatch) != i) continue;
                amicableNumbers[i] = i;
                amicableNumbers[possibleMatch] = possibleMatch;
            }

            return amicableNumbers.Sum();
        }

        public int FindSumOfProperDivisors(int number)
        {
            var divisors = new List<int>();

            for (var i = 1; i <= Math.Sqrt(number); i++)
            {
                if (number % i != 0) continue;
                divisors.Add(i);
                var otherFactor = number / i;
                if (otherFactor == i) continue;
                if (otherFactor == number) continue;
                divisors.Add(otherFactor);
            }

            return divisors.Sum();

        }


        public int FindSumOfProperDivisorsWithCache(int number)
        {
            if (cache[number] != 0) return cache[number];

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

            var sum = divisors.Sum();
            cache[number] = sum;
            return sum;
        }
    }
}
