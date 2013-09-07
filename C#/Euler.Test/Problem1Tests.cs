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
            var expected = 233168;
            var target = new Problem1();

            // Act
            var result = target.Solve();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
