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
    public class Problem7Tests
    {
        [TestMethod]
        public void Problem7_Can_Solve()
        {
            // Arrange
            var expected = 104743;
            var target = new Problem7();

            // Act
            var result = target.SolveIt();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
