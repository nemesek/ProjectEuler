using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem4
    {
        public int Solve()
        {
            var result = Enumerable.Range(100, 899)
                .SelectMany(x => Enumerable.Range(100, 899), (x, y) => x * y)
                .Where(p => p == ReverseNum(p)).Max();

            return result;
        }

        private int ReverseNum(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }
    }
}
