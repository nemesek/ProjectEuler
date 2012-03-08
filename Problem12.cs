using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    [EulerProblem(12, Title="What is the value of the first triangle number to have over five hundred divisors?")]
    public class Problem12
    {
        public long Solve()
        {
            var triangleNumbers = 2.To(int.MaxValue)
                                  .LazilyAggregate(
                                    1, 
                                    (item, accumulatedValue) => accumulatedValue + item);

            var result = (
                         from n in triangleNumbers
                         where 
                                (from factor in 1.To((int)Math.Sqrt(n))
                                where n.IsDivisibleBy(factor)
                                select new int[] { factor, n / factor } )
                                .Concat()
                                .Count() > 500
                         select n
                         )
                         .First();

            return result;
        }
    }
}
