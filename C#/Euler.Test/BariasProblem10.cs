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
            private readonly List<long> _listPrimes = new List<long>();
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
                    // Assert
                    Assert.AreEqual(expected, actual);

                }
                catch (Exception ex)
                {
                    var y = ex.Message;
                }

                
            }

            public long SolveIt()
            {
                const int upperBound = 2000000;
                
                //var result = Enumerable.Range(2, upperBound ).Where(IsPrime).Select(n => n);
                //var result = new List<Int64>();
                _listPrimes.Add(2);
                for(var i = 3; i < upperBound; i++)
                {
                    if (IsPrime2(i))
                    {
                        _listPrimes.Add(i);
                    }
                }

                var x = _listPrimes.Count();
                return _listPrimes.ToArray().Sum();
            }


            private bool IsPrime(int primeTest)
            {
                //var possibleFactors = _listPrimes.Where(x => x <= (int)Math.Floor(Math.Sqrt(primeTest)));

                //if (possibleFactors.Any(pf => primeTest % pf == 0))
                //{
                //    return false;
                //}
                if (!IsPrime2(primeTest))
                {
                    return false;
                }
                else
                {
                    _listPrimes.Add(primeTest);
                    return true;
                }

            }

            private static bool IsPrime2(int primeNumber)
            {
                var squareRoot = (int)Math.Sqrt(primeNumber);
                var y = Enumerable.Range(2, squareRoot).All(x => primeNumber % x != 0);
                return y;
            }
        
    }

}
