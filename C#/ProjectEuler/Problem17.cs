using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class Problem17
    {
        static Dictionary<int, string> oneToNineteenDictionary = new Dictionary<int, string>() 
            {
                {0, ""}, {1, "one"}, {2, "two"}, {3, "three"}, {4, "four"},
                {5, "five"}, {6, "six"}, {7, "seven"}, {8, "eight"}, {9, "nine"},
                {10, "ten"}, {11, "eleven"}, {12, "twelve"}, {13, "thirteen"},
                {14, "fourteen"}, {15, "fifteen"}, {16, "sixteen"}, {17, "seventeen"},
                {18, "eighteen"}, {19, "nineteen"}
            };

        static Dictionary<int, string> hundredsDictionary = new Dictionary<int, string>()
        {
            {1, "onehundred"}, {2, "twohundred"}, {3, "threehundred"}, {4, "fourhundred"},
            {5, "fivehundred"}, {6, "sixhundred"}, {7, "sevenhundred"}, {8, "eighthundred"},
            {9, "ninehundred"}
        };


        public void SolveIt()
        {      
            var numbers = new string[1000];

            for (var i = 1; i < 1001; i++)
            {
                var builder = new StringBuilder();

                // Check for the hundreds place
                if (i >= 100 && i < 1000)
                {
                    var number = i / 100;
                    builder.Append(hundredsDictionary[number]);
               
                    // Check to see if we need to add 'and' to the string
                    if (i % 100 != 0)
                        builder.Append("and");
                }

                // Check for a thousand and just hard code
                if (i == 1000)
                {
                    builder.Append("onethousand");
                }
                else  // Grab the tens place
                {
                    MapOneToNinetyNine(i % 100, builder);
                }

                numbers[i - 1] = builder.ToString();
            }       
            
            var sum = 0;
            sum += numbers.Sum(n => n.Length);
            Console.WriteLine(sum);           

        }

        private void MapOneToNinetyNine(int i, StringBuilder builder)
        {
            if (Enumerable.Range(1, 19).Contains(i))
            {
                builder.Append(oneToNineteenDictionary[i]);
            }
            else if (Enumerable.Range(20, 10).Contains(i))
            {
                builder.Append("twenty");
                builder.Append(oneToNineteenDictionary[i % 20]);
            }
            else if (Enumerable.Range(30, 10).Contains(i))
            {
                builder.Append("thirty");
                builder.Append(oneToNineteenDictionary[i % 30]);
            }
            else if (Enumerable.Range(40, 10).Contains(i))
            {
                builder.Append("forty");
                builder.Append(oneToNineteenDictionary[i % 40]);
            }
            else if (Enumerable.Range(50, 10).Contains(i))
            {
                builder.Append("fifty");
                builder.Append(oneToNineteenDictionary[i % 50]);
            }
            else if (Enumerable.Range(60, 10).Contains(i))
            {
                builder.Append("sixty");
                builder.Append(oneToNineteenDictionary[i % 60]);
            }
            else if (Enumerable.Range(70, 10).Contains(i))
            {
                builder.Append("seventy");
                builder.Append(oneToNineteenDictionary[i % 70]);
            }
            else if (Enumerable.Range(80, 10).Contains(i))
            {
                builder.Append("eighty");
                builder.Append(oneToNineteenDictionary[i % 80]);
            }
            else if (Enumerable.Range(90, 10).Contains(i))
            {
                builder.Append("ninety");
                builder.Append(oneToNineteenDictionary[i % 90]);
            }
        }    
    }
}
