using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class Problem18
    {
        public void SolveIt()
        {
            var triangle = @"75
                             95 64
                             17 47 82
                             18 35 87 10
                             20 04 82 47 65
                             19 01 23 75 03 34
                             88 02 77 73 07 63 67
                             99 65 04 28 06 16 70 92
                             41 41 26 56 83 40 80 70 33
                             41 48 72 33 47 32 37 16 94 29
                             53 71 44 65 25 43 91 52 97 51 14
                             70 11 33 28 77 73 17 78 39 68 17 57
                             91 71 52 38 17 14 91 43 58 50 27 29 48
                             63 66 04 68 89 53 67 30 73 16 69 87 40 31
                             04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

            var levels = triangle.Split('\n');
            var rowsArray = new string[levels.Length][];

            // Populate the rows with the numbers in each level 
            for (var i = 0; i < levels.Length; i++)
            {
                var level = levels[i].Split(' ').Where(n => n != string.Empty);
                rowsArray[i] = level.ToArray();
            }

            var prevRow = rowsArray[rowsArray.Length - 1];

            for (var i = rowsArray.Length - 2; i >= 0; i--)
            {
                // Find the max values of both possible paths for the current element in the row
                // Store in prevRow and use prevRow to continue walking up the triangle to determine the max paths
                for (var j = 0; j < rowsArray[i].Length; j++)
                {
                    rowsArray[i][j] = (Math.Max(int.Parse(rowsArray[i][j]) + int.Parse(prevRow[j]), int.Parse(rowsArray[i][j]) + int.Parse(prevRow[j + 1])))
                        .ToString();
                }

                // Store the Max of the two possible paths for each item in the row
                // For example the first iteration should have 125 in the first element
                // as 63 + 62 > 63 + 04 and should have 54 as the last element as 31 + 23 > 31 + 04
                prevRow = rowsArray[i]; 
            }

            // rowArray[0] will only have one element -- the max value 
            Console.WriteLine(rowsArray[0][0]);
        }
    }
}
