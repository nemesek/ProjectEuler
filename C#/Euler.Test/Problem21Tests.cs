using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;

namespace Euler.Test
{
    [TestClass]
    public class Problem21Tests
    {
        /*  Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
            If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
            For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
            Evaluate the sum of all the amicable numbers under 10000.
         */

        [TestMethod]
        public void Problem21_Can_SolveIt()
        {
            // Arrange
            var expected = 31626;
            var target = new Problem21();

            // Act
            var result = target.SolveIt();
            
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Problem21_Can_FindSumOfProperDivisors()
        {
            // Arrange
            var number = 284;
            var expected = 220;
            var target = new Problem21();

            // Act
            var result = target.FindSumOfProperDivisors(number);

            // Assert
            Assert.AreEqual(expected, result);
        }

    }

    //public class Problem21
    //{
    //    private static List<int> amicableNumbers = new List<int>();

    //    public int SolveIt()
    //    {
    //        for (var i = 1; i < 10000; i++)
    //        {
    //            var possibleMatch = this.FindSumOfProperDivisors(i);

    //            if (possibleMatch >= 10000) continue;

    //            if (this.FindSumOfProperDivisors(possibleMatch) != i || possibleMatch == i) continue;
    //            amicableNumbers.Add(i);
    //            amicableNumbers.Add(possibleMatch);
    //        }

    //        return amicableNumbers.Sum()/2;
    //    }


    //    public int FindSumOfProperDivisors(int number)
    //    {
    //        var divisors = new List<int>();

    //        for (var i = 1; i <= (number / 2); i++)
    //        {
    //            if (number % i == 0)
    //                divisors.Add(i);
    //        }

    //        return divisors.Sum();
    //    }
    //}
}
