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
    public class Problem20Test
    {
        [TestMethod]
        public void Problem20_Can_SolveIt()
        {
            // Arrange
            var solver = new Problem20();

            // Act
            var result = solver.SolveIt();

            // Assert
            //Assert.IsTrue(result == 3628800);
            Assert.AreEqual(648, result);

        }
    }
}
