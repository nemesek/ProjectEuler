using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem4
    {
        public int Solve() // ~75 ms
        {
            var result = Enumerable.Range(100, 899)
                .SelectMany(x => Enumerable.Range(100, 899), (x, y) => x * y)
                .Where(p => p == ReverseNum(p)).Max();

            return result;
        }

        public int SolveImperative() // ~50ms
        {
            var max = 0;
            for(var i = 100; i < 1000; ++i)
            {
                for (var j = 100; j < 1000; ++j)
                {
                    var candidate = i * j;
                    if(candidate == ReverseNum(candidate))
                    {
                        if (candidate > max) max = candidate;
                    }
                }
            }
            return max;
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
