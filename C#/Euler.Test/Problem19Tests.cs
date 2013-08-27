using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;

namespace Euler.Test
{
    [TestClass]
    public class Problem19Tests
    {
        [TestMethod]
        public void Probem19_Can_CalcForSpecificYear()
        {
            // Arrange
            var expected = 171;
            var year = 1901;
            var problem = new Problem19();

            // Act
            var result = problem.CalcForSpecificYear(year);

            // Assert
            Assert.AreEqual(expected, result);
            
        }
    }
}
