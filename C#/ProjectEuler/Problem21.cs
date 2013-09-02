using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class Problem21
    {
        private static List<int> amicableNumbers = new List<int>();

        public int SolveIt()
        {
            for (var i = 1; i < 10000; i++)
            {
                var possibleMatch = this.FindSumOfProperDivisors(i);

                if (possibleMatch >= 10000) continue;

                if (this.FindSumOfProperDivisors(possibleMatch) != i || possibleMatch == i) continue;
                amicableNumbers.Add(i);
                amicableNumbers.Add(possibleMatch);
            }

            return amicableNumbers.Sum() / 2;
        }


        public int FindSumOfProperDivisors(int number)
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
