﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;

namespace Euler.Test
{
    [TestClass]
    public class Problem23Tests
    {
      /*
       * A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
       * For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
       * A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
       * As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24.
       * By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers.
       * However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number
       * that cannot be expressed as the sum of two abundant numbers is less than this limit.
       * Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
       */


        [TestMethod]
        public void Problem23_Can_SolveIt()
        {
            // Arrange
            var expected = 4179871;
            var target = new Problem23();

            // Act
            var result = target.SolveIt();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Problem23_Can_GetAbundantNumbers()
        {
            // Arrange
            var target = new Problem23();

            // Act
            //var result = target.GetAbundantNumbers();
            var result = this.GetAbundantNumbers();

            // Assert
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void Problem23_Can_DetermineIfPairExists()
        {
            // Arrange
            var number = 24;

            // Act
            var result = this.DoesPairExist(number);

            // Assert
            Assert.IsTrue(result);
        }

        private bool DoesPairExist(int number)
        {
            var abundantNumbers = this.GetAbundantNumbers().ToArray();

            // since list is sorted can just reduce the array in linear time
            var result = false;
            var lowIndex = 0;
            var highIndex = abundantNumbers.Length - 1;

            while (lowIndex <= highIndex)
            {
                var sum = abundantNumbers[lowIndex] + abundantNumbers[highIndex];

                if (sum == number)
                {
                    result = true;
                    lowIndex = highIndex + 1;
                }
                else if (sum > number)
                {
                    highIndex--;
                }
                else
                {
                    lowIndex++;
                }
            }

            return result;
        }

        private List<int> GetAbundantNumbers()
        {
            var numbers = new List<int>();
            for (var i = 1; i < 28124; i++)
            {
                var sum = this.FindSumOfProperDivisors(i);
                if (sum <= i) continue;
                numbers.Add(i);
            }


            return numbers;
        }

        private int FindSumOfProperDivisors(int number)
        {
            var divisors = new List<int>();

            for (var i = 1; i <= (number / 2); i++)
            {
                if (number % i == 0)
                    divisors.Add(i);
            }

            return divisors.Sum();
        }        
    }
}
