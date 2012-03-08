using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    [EulerProblem(14, Title = "Find the longest sequence using a starting number under one million.")]
    public class Problem14
    {
        public long Solve()
        {
            Func<long, long> findSequenceLength = null;
            findSequenceLength = (long n) =>
            {
                if (n == 1) { return 1; }
                var nextTerm = n.IsEven() ? n / 2 : 3 * n + 1;
                return findSequenceLength(nextTerm) + 1;
            };

            findSequenceLength = findSequenceLength.Memoize();

            return 1.To(1000000)
                .Select(n => new { n, Length = findSequenceLength(n) })
                .MaxItem(info => info.Length)
                .n;
        }
    }
}
