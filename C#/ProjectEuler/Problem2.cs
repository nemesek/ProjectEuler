﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem2
    {
        //Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
        //1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        //By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.

        public int Solve()
        {
            var total = 0;
            var fibTerm = 0;
            var index = 1;

            while (fibTerm < 4000000)
            {
                fibTerm = this.GetFibTerm(index);
                if (fibTerm % 2 == 0) total += fibTerm;
                index++;
            }
 
            return total;
        }

        private int GetFibTerm(int term)
        {
            if (term == 1 || term == 2) return 1;
            else return GetFibTerm(term - 2) + GetFibTerm(term - 1);
        }
    }
}
