using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;

namespace Euler.Test
{
    [TestClass]
    public class Problem1Tests
    {
        
        /*
         * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
         *  Find the sum of all the multiples of 3 or 5 below 1000.
         */

        [TestMethod]
        public void Problem1_Can_Solve()
        {
            // Arrange
            const int expected = 233168;
            var target = new Problem1();
            
            // Act
            var result = target.Solve();
            var iterativeResult = ImperativeSolution();
            var functionalResult = FunctionalSolution();
            

            // Assert
            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected, iterativeResult);
            Assert.AreEqual(expected, functionalResult);
        }

        private static int ImperativeSolution()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var sum = 0;
            for (var i = 1; i < 1000; i++)
            {
                if (i%3 == 0 || i%5 == 0)
                {
                    sum += i;
                }
            }
            stopWatch.Stop();
            Trace.WriteLine("Iterative Time elapsed: " + stopWatch.Elapsed);
            return sum;
        }

        private static int FunctionalSolution()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = Enumerable.Range(1, 999).Where(i => i%3 == 0 || i%5 == 0).Sum();
            stopWatch.Stop();
            Trace.WriteLine("Functional Time elapsed: " + stopWatch.Elapsed);
            return result;
        }
    }
}
