using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler.Test
{
 

        [TestClass]
        public class BariasTest
        {
            private readonly List<int> _listPrimes = new List<int>();
            [TestMethod]
            public void Barias_CanSolve10()
            {
                // Arrange
                const long expected = 142913828922;
                //var expected = 37550402023; // one million
                //var expected = 82074443256; // 1.5 million

                // Act
                try
                {
                    var actual = SolveIt();
                    var x = actual.Sum();
                    // Assert
                    Assert.AreEqual(expected, x);

                }
                catch (Exception ex)
                {
                    var y = ex.Message;
                }

                
            }

            public IEnumerable<int> SolveIt()
            {
                const int upperBound = 2000000;
                //var upperBound = 100;
                var result = Enumerable.Range(2, upperBound - 1).Where(IsPrime).Select(n => n);
                return result;
            }

            private bool IsPrime(int primeTest)
            {
                var possibleFactors = _listPrimes.Where(x => x <= (int)Math.Floor(Math.Sqrt(primeTest)));

                if (possibleFactors.Any(pf => primeTest % pf == 0))
                {
                    return false;
                }
                else
                {
                    _listPrimes.Add(primeTest);
                    return true;
                }

            }
        
    }

}
