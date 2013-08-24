using System;
using System.Numerics;

namespace ProjectEuler
{
    class Problem16
    {

        public void SolveIt()
        {
            BigInteger power = 1;
            //BigInteger sum = 0;


            for (var i = 1; i < 1001; i++)
            {
                power *= 2;
            }

            // works
            //while (power > 0)
            //{
            //     sum += power%10;
            //    power = power/10;
            //}

            var sum = Recursive(power);
            Console.WriteLine(sum);
        }

        // slower just wanted to do it Recursively as well
        private static BigInteger Recursive(BigInteger num)
        {
            BigInteger sum = 0;

            if (num < 1)
                return 0;

            return sum += ((num%10) + Recursive(num/10));
        }


    }
}
