using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
          public void Problem24_Should_ReturnLexographicOrder()
          {
              // Arrange
              var expected = 2783915460;
              var set = new double[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

              // Act
              var result = this.GetLexographicOrder(set).OrderBy(n => n).ToList();

              // Assert
              Assert.AreEqual(result[999999], expected);
              
          }
          
          // Recursion slowed it down a bit but I like the solution
          // Could check if List gets to one million rather than find all perms but maybe another day
          private List<double> GetLexographicOrder(double[] set)
          {
              var orders = new List<double>();
         
              // Check if we have two and if so return a list with both permutations
              if (set.Length < 3)
              {
                  var firstNum = set[0] * 10 + set[1];
                  var secondNum = set[1] * 10 + set[0];
                  orders.Add(firstNum);
                  orders.Add(secondNum);
                  return orders;
              }
              else
              {
                  for (var i = 0; i < set.Length; i++)
                  {
                      if (orders.Count() < 1000001)  // Checking so we don't do unceccessary computations
                      {
                          var num = set[i];
                          var firstNum = num * Math.Pow(10, (set.Length - 1));

                          // Generate the perms of the set not including i
                          var subArray = set.Where(n => n != num).ToArray();
                          var subPerms = this.GetLexographicOrder(subArray);

                          foreach (var number in subPerms)
                          {
                              orders.Add(firstNum + number);
                          }
                      }                      
                  }
              }
                
              return orders;
          }
    }
}
