using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Problem14
    {

        public void SolveIt()
        {
            Hashtable ht = new Hashtable();
            int largest = 0;
            int counter = 1;
            long originalNum  = 0;
            for (int i = 2; i < 1000000; i++)
            {

                originalNum = 0;
                int tempCounter = 0;
                long num = i;
                if (ht.ContainsKey(i))
                    num = 1;
                while (num != 1)
                {
                    tempCounter++;
                    int check = (int)num % 2;
                    switch (check)
                    {
                        case 1:
                            num = (3 * num) + 1;
                            break;
                        default:
                            num = num / 2;
                            break;

                    }
                    if (ht.ContainsKey(num))
                    {
                        int x = (int)ht[num];
                        tempCounter += x;
                        num = 1;

                    }
                    else
                    {

                        if (originalNum == 0)
                        {
                            originalNum = num;
                        }
                            
                        //while (num % 2 == 0)
                        //{
                        //    tempCounter++;
                        //    num = num / 2;
                        //    if(ht.ContainsKey(num))
                        //    {
                        //        int x = (int)ht[num];
                        //        tempCounter += x;
                        //        num = 1;
                        //    }
                        //}
                    }

                }
                if (!ht.ContainsKey(i))
                {
                    ht.Add(i, tempCounter);
                }

                 if(!ht.ContainsKey(originalNum))
                {
                    ht.Add(originalNum, tempCounter - 1);
                }

                if (tempCounter > counter)
                {
                    counter = tempCounter;
                    largest = i;
                }
                
            }
            int y = (int)ht[largest];
            Console.WriteLine("THe largest is: " + largest);
            Console.WriteLine("The value is: " + y);

        }

    }
}
