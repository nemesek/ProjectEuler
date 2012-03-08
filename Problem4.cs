using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    [EulerProblem(4, Title="Find the largest palindrome made from the product of two 3-digit numbers.")]
    public class Problem4
    {
        public long Solve()
        {
            const long smallestFactor = 100;
            const long largestFactor = 999;

             return (
              from x in largestFactor.To(smallestFactor)
              from y in largestFactor.To(smallestFactor)
              let product = x * y
              where product.IsPalindromic()
              orderby product descending
              select product
              )
              .First();
        }
    }
}
