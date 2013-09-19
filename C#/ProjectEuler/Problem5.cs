using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{

    //2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    public class Problem5
    {
        public int Solve()
        {
            bool found = false;
            var number = 0;

            while (!found)
            {
                number += 20;
                found = IsSmallestMultiple(number);
               
            }

            return number;
        }

        private bool IsSmallestMultiple(int number)
        {
            var range = Enumerable.Range(1, 20);

            foreach (var num in range)
            {
                if (number % num != 0) return false;
            }

            return true;
        }
    }
}
