using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler.Test
{
    //    A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

    //a2 + b2 = c2
    //For example, 32 + 42 = 9 + 16 = 25 = 52.

    //There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    //Find the product abc.

    [TestClass]
    public class Problem9Tests
    {
        [TestMethod]
        public void Problem9_CanSolve()
        {
            // arrange
            const int expected = 31875000;

            // act
            var actual = SolveInterative();

            // assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Problem9_CanSolveFunctional()
        {
            // arrange
            const int expected = 31875000;

            // act
            var actual = SolveFunctional(NotATriplet, Produce, 1000);

            // assert
            Assert.AreEqual(expected, actual);

        }

        public int SolveInterative()
        {
            for (var a = 1; a < 500; a++)
            {
                for (var b = 1; b < 500; b++)
                {
                    if (a*a + b*b != (1000 - a - b)*(1000 - a - b)) continue;
                    var result = (a * b * (1000 - a - b));
                    return result;
                }
            }
            return 0;
        }
        
        public int SolveFunctional(Func<int,int, int, bool> filterOut, Func<int,int,int,int> producer, int match)
        {
            var result = (from a in Enumerable.Range(1, 500)
                              select(from b in Enumerable.Range(1,500)
                                         where(!filterOut(a,b, match))
                                         select producer(a,b,match)
                                         ).FirstOrDefault()).Max();


            return result;
        }


        private static bool NotATriplet(int a, int b, int c)
        {
            return a*a + b*b != (c - a - b)*(c - a - b);
        }

        private static int Produce(int a, int b, int c)
        {
            return (a*b*(c - a - b));
        }


    }

    
}
