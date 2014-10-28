using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;

namespace Euler.Test
{
    [TestClass]
    public class Problem3Tests
    {
        //The prime factors of 13195 are 5, 7, 13 and 29.
        //What is the largest prime factor of the number 600851475143 ?

        [TestMethod]
        public void Problem3_Can_Solve()
        {
            // Arrange
            var expected = 6857;
            var target = new Problem3();
            
            // Act
            var result = target.Solve();
            var imperativeResult = ImperativeSolution();
            var functionalResult = FunctionalSolution();

            // Assert
            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected, imperativeResult);
            Assert.AreEqual(expected, functionalResult);
        }


        [TestMethod]
        public void Problem3_IsPrime_ShouldReturnTrueFor29()
        {
            // Arrange
            var primeNumber = 29;

            // Act
            var result = IsPrime(primeNumber);

            // Assert
            Assert.IsTrue(result);
        }

        private static int ImperativeSolution()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            const long bigNum = 600851475143;
            var max = (int) Math.Sqrt(bigNum);
            for (var i = max; i > 2; i--)
            {
                if (bigNum%i != 0) continue;
                if (!ImperativeIsPrime(i)) continue;
                stopWatch.Stop();
                Trace.WriteLine("Imperative: " + stopWatch.Elapsed);
                return i;
            }

            stopWatch.Stop();
            Trace.WriteLine("Imperative: " + stopWatch.Elapsed);
            return 2;
        }

        private static int FunctionalSolution()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            const long bigNum = 600851475143;
            var max = (int)Math.Sqrt(bigNum);
            //for (var i = max; i > 2; i--)
            //{
            //    if (bigNum % i != 0) continue;
            //    if (IsPrime(i))
            //    {
            //        return i;
            //    }
            //}
            var result = Enumerable.Range(2, max).Where(n => bigNum % n == 0 && IsPrime(n)).Max();
            stopWatch.Stop();
            Trace.WriteLine("Functional: " + stopWatch.Elapsed);
            return result;
        }

        private static bool ImperativeIsPrime(int num)
        {
            var square = (int) Math.Sqrt(num);

            for (var i = 2; i <= square; i++)
            {
                if (num % i == 0) return false;
            }

            return true;
        }

        private static bool IsPrime(int primeNumber)
        {
            var squareRoot = (int)Math.Sqrt(primeNumber);
            return Enumerable.Range(2, squareRoot).All(x => primeNumber % x != 0);            
        }

    }
}
