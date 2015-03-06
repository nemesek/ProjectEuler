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
    public class Problem8Tests
    {
        [TestMethod]
        public void Problem8_Can_Solve()
        {
            // Arrange
            var expected = 40824;
            var target = new Problem8();

            // Act
            var result = target.SolveFast();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
