using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
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
