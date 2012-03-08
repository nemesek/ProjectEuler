using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem16
    {
        //http://stackoverflow.com/questions/677579/project-euler-16-c-2-0
        //1366
        public void SolveIt()
        {
            double  total = 2;
            for (int i = 1; i < 26; i++)
            {
                total *= 2;
            }
            Console.WriteLine(total);

            int x = (int)total % 10;
            Console.WriteLine(x);
        }

    }
}
