using System.Linq;

namespace ProjectEuler
{

    //2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    public class Problem5
    {
        private int[] _divisors = {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};
        private int[] _limitedDivisors = {11, 12, 13, 14, 15, 16, 17, 18, 19, 20};
        
        public int Solve()
        {
            bool found = false;
            var number = 0;

            while (!found)
            {
                number += 20;
                found = IsSmallestMultiple4(number);
               
            }

            return number;
        }

        private bool IsSmallestMultiple(int number)
        {
            foreach (var num in _divisors)
            {
                if (number % num != 0) return false;
            }

            return true;
        }

        private bool IsSmallestMultiple2(int number)
        {
            var range = Enumerable.Range(2, 19);
            foreach (var num in range)
            {
                if (number % num != 0) return false;
            }

            return true;
        }

        private bool IsSmallestMultiple3(int number)
        {
            for (var i = _divisors.Length - 1; i >= 0; --i)
            {
                if (number % _divisors[i] != 0) return false;
            }

            return true;
        }

        private bool IsSmallestMultiple4(int number)
        {
            for (var i = _limitedDivisors.Length - 1; i >= 0; --i)
            {
                if (number % _limitedDivisors[i] != 0) return false;
            }

            return true;
        }

        private bool IsSmallestMultipleFunctional(int number)
        {
            return Enumerable.Range(2, 19).All(num => number%num == 0);
        }
    }
}
