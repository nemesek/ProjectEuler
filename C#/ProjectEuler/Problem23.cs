using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class Problem23
    {
        /*
         * A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
         * For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
         * A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
         * As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24.
         * By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers.
         * However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number
         * that cannot be expressed as the sum of two abundant numbers is less than this limit.
         * Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
         */
        private int _upperBound = 28124;
        private int[] cache = new int[100000];
        //private int _upperBound = 10000;

        private static List<int> _abundantNumbers = new List<int>();

        public int SolveIt()
        {
            var numbers = new List<int>();
            _abundantNumbers = this.GetAbundantNumbers();

            for (var i = 1; i < _upperBound; i++)
            {
                if (!DoesPairExist(i)) numbers.Add(i);
            }

            return numbers.Sum();
        }

        private static bool DoesPairExist(int number)
        {
            

            // since list is sorted can just reduce the array in linear time
            var result = false;
            var lowIndex = 0;
            var highIndex = _abundantNumbers.Count() - 1;

            while (lowIndex <= highIndex)
            {
                var sum = _abundantNumbers[lowIndex] + _abundantNumbers[highIndex];

                if (sum == number)
                {
                    result = true;
                    lowIndex = highIndex + 1;
                }
                else if (sum > number)
                {
                    highIndex--;
                }
                else
                {
                    lowIndex++;
                }
            }

            return result;
        }

        private List<int> GetAbundantNumbers()
        {
            var numbers = new List<int>();
            for (var i = 1; i < _upperBound; i++)
            {
                var sum = FindSumOfProperDivisorsWithCache(i);
                if (sum <= i) continue;
                numbers.Add(i);
            }


            return numbers;
        }

        private int FindSumOfProperDivisorsWithCache(int number)
        {
            if (cache[number] != 0) return cache[number];

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

            var sum = divisors.Sum();
            cache[number] = sum;
            return sum;
        }

        private static int FindSumOfProperDivisors(int number)
        {
            var divisors = new List<int>();

            for (var i = 1; i <= (number / 2); i++)
            {
                if (number % i == 0)
                    divisors.Add(i);
            }

            return divisors.Sum();
        }

    }
}
