using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem8
    {
        // Find the greatest product of five consecutive digits in the 1000-digit number.
        const string NumberAsString = @"73167176531330624919225119674426574742355349194934"
                            + "96983520312774506326239578318016984801869478851843"
                            + "85861560789112949495459501737958331952853208805511"
                            + "12540698747158523863050715693290963295227443043557"
                            + "66896648950445244523161731856403098711121722383113"
                            + "62229893423380308135336276614282806444486645238749"
                            + "30358907296290491560440772390713810515859307960866"
                            + "70172427121883998797908792274921901699720888093776"
                            + "65727333001053367881220235421809751254540594752243"
                            + "52584907711670556013604839586446706324415722155397"
                            + "53697817977846174064955149290862569321978468622482"
                            + "83972241375657056057490261407972968652414535100474"
                            + "82166370484403199890008895243450658541227588666881"
                            + "16427171479924442928230863465674813919123162824586"
                            + "17866458359124566529476545682848912883142607690042"
                            + "24219022671055626321111109370544217506941658960408"
                            + "07198403850962455444362981230987879927244284909188"
                            + "84580156166097919133875499200524063689912560717606"
                            + "05886116467109405077541002256983155200055935729725"
                            + "71636269561882670428252483600823257530420752963450";
        public long SolveFast()
        {
            var length = NumberAsString.Length;
            long max = 0;

            for (var i = 0; i < length - 13; i++)
            {
                var digits = NumberAsString.Substring(i, 13);
                if (digits.Contains('0'))
                {
                    i += 12;
                    continue;
                }

                var numericDigits = long.Parse(digits);
                long total = 1;
                for (var j = 0; j < 13; j++)
                {
                    var digit = numericDigits % 10;
                    total *= digit;
                    numericDigits /= 10;
                }

                if (total > max) max = total;
            }

            return max;
        }



        public long SolveSlow()
        {
            long max = 0;
            var length = NumberAsString.Length;

            for (var i = 0; i < length - 13; i++)
            {
                var digits = NumberAsString.Substring(i, 13);
                var numericDigits = long.Parse(digits);
                long total = 1;
                for (var j = 0; j < 13; j++)
                {
                    var digit = numericDigits % 10;
                    total *= digit;
                    numericDigits /= 10;
                }

                if (total > max) max = total;
            }

            return max;
        }

        public long SolveParallel()
        {
            long max = 0;
            var length = NumberAsString.Length;
            var i = 0;
            foreach (var digits in NumberAsString.Select(c => NumberAsString.Substring(i, 13)).AsParallel())
            {
                if (i < length - 13)
                {
                    i++;    
                }
                //Console.WriteLine("Processing {0} on thread {1}", i, Thread.CurrentThread.ManagedThreadId);
                
                var product = ComputeProduct(digits);
                if (product > max) max = product;
            }

            return max;
            
        }

        public long SolveParallelFor()
        {
            //long max = 0;
            var length = NumberAsString.Length;
            var i = 0;
            var values = new long[1000];
            Parallel.For(i, length - 13, n =>
            {
                var number = NumberAsString.Substring(i, 13);
                i++;
                var total = ComputeProduct(number);
                //Console.WriteLine("Processing {0} on thread {1}", i, Thread.CurrentThread.ManagedThreadId);
                //if (total > max) max = total;
                values[i] = total;
                
            });

            return values.Max();

        }

        public long SolveParallelForSafe()
        {
            //long max = 0;
            var length = NumberAsString.Length;
            var i = 0;
            var values = new long[1000];
            Parallel.For(i, length - 13, n =>
            {
                var number = NumberAsString.Substring(i, 13);
                var total = ComputeProduct(number);
                //Console.WriteLine("Processing {0} on thread {1}", i, Thread.CurrentThread.ManagedThreadId);
                //if (total > max) max = total;
                values[i] = total;
                Interlocked.Increment(ref i);

            });

            return values.Max();

        }

        public long SolveParallelForEach()
        {
            long max = 0;
            var length = NumberAsString.Length;
            var i = 0;
            //var range = new int[1000];
            Parallel.ForEach(NumberAsString, n =>
            {
                if (i > length - 13) return;
                var number = NumberAsString.Substring(i, 13);
                i++;
                //i = Interlocked.Increment(ref i);
                var total = ComputeProduct(number);
                //Console.WriteLine("Processing {0} on thread {1}", i, Thread.CurrentThread.ManagedThreadId);
                if (total > max) max = total;

            });

            return max;

        }

        public long SolveParallelForEachSafe()
        {
            long max = 0;
            var length = NumberAsString.Length;
            var i = 0;
            //var range = new int[1000];
            Parallel.ForEach(NumberAsString, n =>
            {
                if (i > length - 13) return;
                var number = NumberAsString.Substring(i, 13);
                //i++;
                var total = ComputeProduct(number);
                //Console.WriteLine("Processing {0} on thread {1}", i, Thread.CurrentThread.ManagedThreadId);
                Interlocked.Increment(ref i);
                if (total > max) max = total;

            });

            return max;

        }

        private static long ComputeProduct(string number)
        {
            if (number.Contains('0')) return 0;
            var numericDigits = long.Parse(number);
            
            long total = 1;
            for (var j = 0; j < 13; j++)
            {
                var digit = numericDigits % 10;
                total *= digit;
                numericDigits /= 10;
            }

            return total;
        }
    }
}
