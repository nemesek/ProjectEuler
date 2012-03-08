using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    [EulerProblem(9, Title="Find the only Pythagorean triplet, {a, b, c}, for which a + b + c = 1000.")]
    public class Problem9
    {
        public long Solve()
        {
            return (
             from a in 1.To(999)
             from b in a.To(999 - a)
             let c = 1000 - a - b
             where a * a + b * b == c * c
             select new { a, b, c, product = a * b * c }
            )
            .Single().product;
        }
    }

}
