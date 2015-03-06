using System.Linq;

namespace ProjectEuler
{
    public class Problem4
    {
        public int Solve() // ~60 ms
        {
            var result = Enumerable.Range(100, 899)
                .SelectMany(x => Enumerable.Range(100, 899), (x, y) => x * y)
                .Where(p => p == ReverseNum(p)).Max();

            return result;
        }

        public int SolveImperative() // ~5ms
        {
            var max = 0;
            for(var i = 100; i < 1000; ++i)
            {
                for (var j = 100; j < 1000; ++j)
                {
                    var candidate = i * j;
                    if (candidate <= max) continue;
                    if (candidate != ReverseNum(candidate)) continue;
                    if (candidate > max) max = candidate;
                }
            }
            return max;
        }

        private static int ReverseNum(int num)
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
