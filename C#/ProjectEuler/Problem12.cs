using System;

namespace ProjectEuler
{
    class Problem12
    {

        public void SolveIt()
        {
            var foundIt = false;
            var i = 1;
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

                    if (numDiv > 500)
                    {
                        foundIt = true;
                        num = n;
                    }
                }
                ++i;

            }
            Console.WriteLine("The number is: " + num);
        }

        public int SolveIt2()
        {
            var number = 0;
            var triangularNumber = 0;
            var numFactors = 0;

            while (numFactors <= 500)
            {
                number++;
                triangularNumber += number;
                numFactors = GetNumberOfFactors(triangularNumber);
            }

            Console.WriteLine("The number is: " + triangularNumber);
            return triangularNumber;
            
        }

        public static int GetNumberOfFactors(int number)
        {
            //double result = ;
            var isSquare = Math.Abs(Math.Sqrt(number) % 1) < Double.Epsilon;
            return isSquare ? GetFactors(number) - 1 : GetFactors(number);
        }

        public static int GetFactors(int number)
        {
            //var factors = new List<int>();
            var square = Math.Sqrt(number);
            var count = 2;
            for (var i = 2; i <= square; i++)
            {
                if (number % i != 0) continue;
                count += 2;
                //factors.Add(i);
                //var otherFactor = number/i;
                //if (otherFactor != i) factors.Add(otherFactor);
            }

            return count;
        }



    }
}
