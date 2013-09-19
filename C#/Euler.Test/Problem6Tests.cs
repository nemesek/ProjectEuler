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
    public class Problem6Tests
    {
        [TestMethod]
        public void Problem6_CanSolve()
        {
            // Arrange
            var expected = 25164150;
            var target = new Problem6();

            // Act
            var result = target.SolveIt();

            // Assert
            Assert.AreEqual(expected, result);

        }
    }
}
