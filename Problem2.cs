using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    [EulerProblem(2, Title="Find the sum of all the even-valued terms in the Fibonacci sequence which do not exceed four million.")]
    public class Problem2
    {
        public long Solve()
        {
            return FibonacciTerms(1, 2)
                .TakeWhile(x => (x <= 4000000))
                .Where(x => x % 2 == 0)
                .Sum();
        }

        private static IEnumerable<int> FibonacciTerms(int firstTerm, int secondTerm)
        {
            yield return firstTerm;
            yield return secondTerm;
            int previous = firstTerm;
            int current = secondTerm;
            while (true)
            {
                int next = previous + current;
                previous = current; current = next;
                yield return current;
            }
        }
    }
}
