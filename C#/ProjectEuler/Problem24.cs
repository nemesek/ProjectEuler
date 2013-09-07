using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class Problem24
    {

        public double Solve(double[] set)
        {
            var list = this.GetLexographicOrder(set).OrderBy(n => n).ToList();
            return list[999999];
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
