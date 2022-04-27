using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var woodBranches = new Dictionary<string, int>();

            int pondSize = int.Parse(Console.ReadLine());

            string[,] pond = new string[pondSize, pondSize];

            int beaverRowPosition = 0;
            int beaverColPosition = 0;

            int totalCountOfWoodBranches = 0;

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                string[] rowInput = Console.ReadLine().Split(" ");

                for (int col = 0; col < rowInput.Length; col++)
                {
                    pond[row, col] = rowInput[col];
                    if (pond[row,col] == "B")
                    {
                        beaverRowPosition = row;
                        beaverColPosition = col;
                    }

                    if (pond[row,col] != "B" && pond[row,col] != "-" && pond[row,col] != "F")
                    {
                        totalCountOfWoodBranches++;
                    }
                }
            }

            string directionToMoveTheBeaver;

            Stack<string> lastCollectedWood = new Stack<string>();

            while ((directionToMoveTheBeaver = Console.ReadLine()) != "end")
            {
                if (directionToMoveTheBeaver == "up")
                {

                }
                if (directionToMoveTheBeaver == "down")
                {

                }
                if (directionToMoveTheBeaver == "left")
                {

                }
                if (directionToMoveTheBeaver == "right")
                {

                }

            }


        }
        static void MoveTheBeaverUp(string[,] pond, int beaverRowPosition, int beaverColPosition, Stack<string> lastCollectedWood)
        {
            if (!isInPond(pond,beaverRowPosition - 1,beaverColPosition))
            {
                if (lastCollectedWood.Count > 0)
                {
                    lastCollectedWood.Pop();
                }
                 
                return;
            }
            else
            {
                if (pond[beaverRowPosition - 1, beaverColPosition] == "-")
                {
                    pond[beaverRowPosition, beaverColPosition] = "-";
                    pond[beaverRowPosition - 1, beaverColPosition] = "B";
                    beaverRowPosition = beaverRowPosition - 1;
                }
                else if (pond[beaverRowPosition - 1, beaverColPosition] != "F")
                {

                }
            }

        }

        private static bool isInPond(string[,] pond, int row, int col)
        {
            return row >= 0 && row < pond.GetLength(0) && col >= 0 && col < pond.GetLength(1);
        }

    }
}
