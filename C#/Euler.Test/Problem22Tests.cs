using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;

namespace Euler.Test
{
    [TestClass]
    public class Problem22Tests
    {
        /*
         * Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order.
         * Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.
         *  For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.
         * What is the total of all the name scores in the file?
         */

      [TestMethod]
      public void Problem22_Can_CalculateIndividualName()
      {
          // Arrange
          var expected = 53;
          var target = new Problem22();

          // Act
          var result = target.CalculateIndivualName("COLIN");

          // Assert
          Assert.AreEqual(expected, result);
      }

      [TestMethod]
      public void Problem22_Can_SolveIt()
      {
          // Arrange
          var expected = 871198282;
          var target = new Problem22();

          // Act
          var result = target.SolveIt();

          // Assert
          Assert.AreEqual(expected, result);
          
      }


    }

    //public class Problem22
    //{

    //    public int SolveIt()
    //    {
    //        var text = "";
    //        var total = 0;

    //        using (var reader = new StreamReader(@"..\..\names.txt"))
    //        {
    //            text = reader.ReadToEnd();
    //        }

    //        var names = text.Split(',').OrderBy(n => n).ToArray();

    //        for (var i = 0; i < names.Count(); i++)
    //        {
    //            var nameSum = this.CalculateIndivualName(names[i]);
    //            total += ((i + 1) * nameSum);
    //        }

    //        return total;
    //    }

    //    public int CalculateIndivualName(string name)
    //    {
    //        int total = 0;

    //        foreach (var letter in name)
    //        {
    //            if (letter < 65 || letter > 90) continue;
    //            total += letter % 64;
    //        }

    //        return total;
    //    }
    //}
}
