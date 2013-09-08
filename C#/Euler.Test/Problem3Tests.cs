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

            // Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void Problem3_IsPrime_ShouldReturnTrueFor29()
        {
            // Arrange
            var primeNumber = 29;

            // Act
            var result = this.IsPrime(primeNumber);

            // Assert
            Assert.IsTrue(result);
        }

        private bool IsPrime(int primeNumber)
        {
            var squareRoot = (int)Math.Sqrt(primeNumber);
            return !Enumerable.Range(2, squareRoot).Where(x => primeNumber % x == 0).Any();            
        }

    }
}
