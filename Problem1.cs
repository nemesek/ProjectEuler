using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    [EulerProblem(1, Title="Add all the natural numbers below one thousand that are multiples of 3 or 5.")]
    public class Problem1
    {
        public long Solve()
        {
            return Enumerable.Range(1, 999)
                .Where(x => x % 5 == 0 || x % 3 == 0)
                .Sum();
        }
    }
}
