using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    //The sum of the squares of the first ten natural numbers is, 12 + 22 + ... + 102 = 385
    //The square of the sum of the first ten natural numbers is, (1 + 2 + ... + 10)2 = 552 = 3025
    //Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
    //Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    public class Problem6
    {
        public int SolveIt()
        {
            //var sumOfSquares = Enumerable.Range(1, 100).Select(x => x * x).Sum();
            var sumOfSquares = Enumerable.Range(1, 100).Sum(x => x * x);
            // var squareOfTheSum = (int) Math.Pow(Enumerable.Range(1, 100).Sum(), 2);
            var squareOfTheSum = (100 * 101) * (100 * 101) / 4;
            return squareOfTheSum - sumOfSquares;

        }
    }
}
