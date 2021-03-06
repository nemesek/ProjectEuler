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
    public class Problem5Tests
    {
        //2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
        //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

        [TestMethod]
        public void Problem5_Can_Solve()
        {
            // Arrange
            var expected = 232792560;
            var target = new Problem5();

            // Act
            var result = target.Solve();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Problem5_Functional()
        {
            // Arrange
            const int expected = 232792560;
            var range = Enumerable.Range(1, 19);
            var found = false;
            var number = 2520;

            // Act
            while (!found)
            {
                number += 20;
                found = range.All(n => number % n == 0);
                
            }

            // Assert
            Assert.AreEqual(expected, number);
        }


    }
}
