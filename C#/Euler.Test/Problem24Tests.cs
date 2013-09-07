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
    public class Problem24Tests
    {
        /*
         * A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4.
         * If all of the permutations are listed numerically or alphabetically, we call it lexicographic order.
         * The lexicographic permutations of 0, 1 and 2 are: 012   021   102   120   201   210 
         * What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
         */

          [TestMethod]
          public void Problem24_Can_Solve()
          {
              // Arrange
              var expected = 2783915460;
              var set = new double[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
              var target = new Problem24();

               // Act
              var result = target.Solve(set);

              // Assert
              Assert.AreEqual(result, expected);
              
          }          
    }
}
