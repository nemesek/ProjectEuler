using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjectEuler
{
    class Problem15
    {
        public int Count = 0;
        public Node[] nodeArray = new Node[16];
        public void SolveIt()
        {
            //Ended up being 40 Choose 20///Pascal's Triangle
            double numerator = 1;
            double denominator = 1;
            for (int i = 40; i > 0; i--)
            {
                numerator *= i;
            }
            for (int i = 20; i > 0; i--)
            {
                denominator *= i;
            }
            Console.WriteLine(numerator);
            Console.WriteLine(denominator);
            double total = numerator / denominator;
            total /= denominator;
            Console.WriteLine(total);
            //Everything below works for 3 X 3 Grid but not neccessary for the solution
            
            for (int i = 0; i < 16; i++)
            {
                nodeArray[i] = new Node(i);
               
            }
            //for (int i = 0; i < 16; i++)
            //{

            //    System.Console.WriteLine("Neigbors for " + i);
            //    for (int j = 0; j < nodeArray[i].count; ++j)
            //    {
            //        System.Console.WriteLine(nodeArray[i].neighbors[j]);
            //    }
            //}
            WalkPath(0);
            System.Console.WriteLine("Total Number: " + Count);

        }
        public void WalkPath(int startNode)
        {
            if (nodeArray[startNode].count != 0)
            {
                for (int i = 0; i < nodeArray[startNode].count; i++)
                {
                    WalkPath(nodeArray[startNode].neighbors[i]);
                }
            }
            else
            {
                Count++;
            }

        }
    }
    class Node
    {
        public int nodeNumber = 0;
        public int count = 0;
        public int[] neighbors = new int[3];
        public Node()
        {

        }
        public Node(int i)
        {
            nodeNumber = i;
            LoadNeigbors(nodeNumber);
        }
        private void LoadNeigbors(int index)
        {
 
            switch (index)
            {
                case 0:
                    neighbors[0] = 1;
                    neighbors[1] = 4;
                    count = 2;
                    break;
                case 1:
                    neighbors[0] = 2;
                    neighbors[1] = 5;
                    count = 2;
                    break;
                case 2:
                    neighbors[0] = 3;
                    neighbors[1] = 6;
                    count = 2;
                    break;
                case 3:
                    neighbors[0] = 7;
                    count = 1;
                    break;
                case 4:
                    neighbors[0] = 5;
                    neighbors[1] = 8;
                    count = 2;
                    break;
                case 5:
                    neighbors[0] = 6;
                    neighbors[1] = 9;
                    count = 2;
                    break;
                case 6:
                    neighbors[0] = 7;
                    neighbors[1] = 10;
                    count = 2;
                    break;
                case 7:
                    neighbors[0] = 11;
                    count = 1;
                    break;
                case 8:
                    neighbors[0] = 9;
                    neighbors[1] = 12;
                    count = 2;
                    break;
                case 9:
                    neighbors[0] = 10;
                    neighbors[1] = 13;
                    count = 2;
                    break;
                case 10:
                    neighbors[0] = 11;
                    neighbors[1] = 14;
                    count = 2;
                    break;
                case 11:
                    neighbors[0] = 15;
                    count = 1;
                    break;
                case 12:
                    neighbors[0] = 13;
                    count = 1;
                    break;
                case 13:
                    neighbors[0] = 14;
                    count = 1;
                    break;
                case 14:
                    neighbors[0] = 15;
                    count = 1;
                    break;
                default:
                    count = 0;
                    break;
            }


        }
    }

}
