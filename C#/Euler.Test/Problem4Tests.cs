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
    public class Problem4Tests
    {
        //A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
        //Find the largest palindrome made from the product of two 3-digit numbers.

        [TestMethod]
        public void Problem4CanSolve()
        {
            // Arrange
            var expected = 906609;
            //var expected = 9009;
            var target = new Problem4();

            // Act
            var result = target.Solve();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Problem4_IsPalindromeTest()
        {
            // Arrange
            var good = 906609;
            var bad = 906509;

            // Act
            var goodResult = this.IsPalindrome(good);
            var badResult = this.IsPalindrome(bad);

            // Assert
            Assert.IsTrue(goodResult);
            Assert.IsFalse(badResult);

        }

        [TestMethod]
        public void Problem4Functional()
        {
            // Arrange
            var expected = 906609;

            // Act
            var result = Enumerable
                .Range(100, 899)
                .SelectMany(x => Enumerable.Range(100, 899), (x, y) => x * y)
                .Where(p => this.FunctionalIsPalindrome(p)).Max();

            // Assert
            Assert.AreEqual(expected, result);
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

        private bool FunctionalIsPalindrome(int num) 
        {
            var reverse = ReverseNum(num);
            return reverse == num;
        }

        private int ReverseNum(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }
    }
}
