using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem20
    {
        public BigInteger SolveIt()
        {
            var num = Factorial(100);
            var sum = FindSum(num);
            return sum;
        }

        private BigInteger Factorial(int number)
        {
            if (number == 0) return 1;                    
            return number * Factorial(number - 1);        
        }

        private BigInteger FindSum(BigInteger num)
        {
            if (num < 1) return 0;
            return num % 10 + FindSum(num / 10);
        }
    }
}
