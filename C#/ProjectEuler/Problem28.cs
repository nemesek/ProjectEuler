using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class Problem28
    {
        public int Solve()
        {
            var left = GenerateLeftDiagonal(1001);
            var right = GenerateRightDiagonal(1001);
            return left.Sum() + right.Sum();
        }

        private static IEnumerable<int> GenerateLeftDiagonal(int spiral)
        {
            var acc = 1;
            var list = new List<int>() { acc };
            for (var i = 1; i < spiral; i++)
            {
                acc += 2 * i;
                list.Add(acc);
            }

            return list;
        }

        private static IEnumerable<int> GenerateRightDiagonal(int spiral)
        {
            var acc = 1;
            var list = new List<int>() { };
            for (var i = 2; i <= spiral; i++)
            {
                acc += 2 * i;
                list.Add(acc);
                acc += 2 * i;
                list.Add(acc);
                i++;
            }

            return list;
        }
    }
}
