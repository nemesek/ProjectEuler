using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem12
    {

        public void SolveIt()
        {
            bool foundIt = false;
            int i = 1;
            long num = 0;
             while (!foundIt)
            {
                int numDiv = 0;
                long n = i * (i + 1) / 2;
                if (n % 2 == 0)
                {
                    double sr = Math.Sqrt(n);
                    double tempSR = Math.Floor(sr);
                    for (int j = 1; j <= tempSR; ++j)
                    {
                        if (n % j == 0)
                        {
                            numDiv++;
                        }
                    }
                    numDiv *= 2;

                    if (numDiv > 6)
                    {
                        foundIt = true;
                        num = n;
                    }
                }
                ++i;

            }
            System.Console.WriteLine("The number is: " + num);
        }

    }
}
