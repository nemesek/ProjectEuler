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
            return Enumerable.Range(100,899).SelectMany(x => Enumerable.Range(100,899), (x,y) => x*y).Where(p => this.IsPalindrome(p)).Max();
        }

        private bool IsPalindrome(int number)
        {

            var numDigits = Math.Floor(Math.Log10(number) + 1);
            var half = numDigits / 2;
            var count = 0;
            double pre = 0;
            double post = 0;

            while (count < half)
            {
                var digit = number % 10;
                number /= 10;
                post += (Math.Pow(10, count) * digit);
                count++;
            }

            if (numDigits % 2 == 1)
            {
                number /= 10;
            }

            count--;

            while (count >= 0)
            {
                var digit = number % 10;
                number /= 10;
                pre += (Math.Pow(10, count) * digit);
                count--;
            }

            if (pre == post) return true;

            return false;
        }
    }
}
