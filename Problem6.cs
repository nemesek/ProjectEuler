using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    [EulerProblem(6, Title = "What is the difference between the sum of the squares and the square of the sums?")]
    public class Problem6
    {
        public long Solve()
        {
            int sumOfNumbers = 1.To(100).Sum();
            int squareOfSum = sumOfNumbers * sumOfNumbers;
            int sumOfSquares = 1.To(100).Select(x => x * x).Sum();
            int difference = squareOfSum - sumOfSquares;
            
            return difference;
        }
    }
}
