using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem13
    {
        public void SolveIt()
        {
            double total = 0;
            int counter = 0;
            double[] numbers = new double[150];
            System.IO.StreamReader myFile = new System.IO.StreamReader(@"C:\Users\Socrates\Desktop\Problem13.txt");
            string line;
            while ((line = myFile.ReadLine()) != null)
            {
                //System.Console.WriteLine(line);
                numbers[counter] = Convert.ToDouble(line);
                total += numbers[counter];
                counter++;
            }
            Console.WriteLine(total);


        }
        
    }
}
