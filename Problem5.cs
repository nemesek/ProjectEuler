using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    [EulerProblem(5, Title = "What is the smallest number divisible by each of the numbers 1 to 20?")]
    public class Problem5
    {
        public long Solve()
        {
            return 1.To(20)
            .Aggregate((product, factor)
                => product * (factor / product.Gcd(factor))
            );
        }


    }
}
