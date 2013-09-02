using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Problem22
    {
        public int SolveIt()
        {
            var text = "";
            var total = 0;

            using (var reader = new StreamReader(@"..\..\names.txt"))
            {
                text = reader.ReadToEnd();
            }

            var names = text.Split(',').OrderBy(n => n).ToArray();

            for (var i = 0; i < names.Count(); i++)
            {
                var nameSum = this.CalculateIndivualName(names[i]);
                total += ((i + 1) * nameSum);
            }

            return total;
        }

        public int CalculateIndivualName(string name)
        {
            int total = 0;

            foreach (var letter in name)
            {
                if (letter < 65 || letter > 90) continue;
                total += letter % 64;
            }

            return total;
        }
    }
}
