using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int forestSize = int.Parse(Console.ReadLine());

            string[,] forest = new string[forestSize, forestSize];

            for (int row = 0; row < forest.GetLength(0); row++)
            {
                string[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < rowInput.Length; col++)
                {
                    forest[row, col] = rowInput[col];
                }
            }

            var trufflesDict = new Dictionary<string, int>
            {
                {"black",0 },
                {"summer",0 },
                {"white",0 },
                {"eaten",0 },
            };


            string commands;

            while ((commands = Console.ReadLine()) != "Stop the hunt")
            {
                string[] actions = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string mainAction = actions[0];

                if (mainAction == "Collect")
                {
                    int row = int.Parse(actions[1]);
                    int col = int.Parse(actions[2]);

                    Collect(forest, row, col, trufflesDict);
                }
                else if (mainAction == "Wild_Boar")
                {
                    int row = int.Parse(actions[1]);
                    int col = int.Parse(actions[2]);
                    string direction = actions[3];

                    WildBoar(forest, row, col, direction,trufflesDict);
                }

            }

        }

        private static void WildBoar(string[,] forest, int row, int col, string direction, Dictionary<string, int> trufflesDict)
        {
            if (direction == "up")
            {
                Up(forest, row, col, trufflesDict);
            }
            if (direction == "down")
            {

            }
            if (direction == "left")
            {

            }
            if (direction == "right")
            {

            }
        }

        private static void Up(string[,] forest, int startRow, int startCol, Dictionary<string, int> trufflesDict)
        {
            forest[startRow, startCol] = "-";

            for (int row = startRow; row < forest.GetLength(0); row-=2)
            {
                for (int col = startCol; col < forest.GetLength(1); col++)
                {
                    if (row - 2 < 0)
                    {
                        return;
                    }
                    row -= 2;

                    if (forest[row,col] == "B")
                    {
                        trufflesDict["black"]--;
                        trufflesDict["eaten"]++;
                        forest[row, col] = "-";
                    }
                    if (forest[row, col] == "S")
                    {
                        trufflesDict["summer"]--;
                        trufflesDict["eaten"]++;
                        forest[row, col] = "-";
                    }
                    if (forest[row, col] == "W")
                    {
                        trufflesDict["white"]--;
                        trufflesDict["eaten"]++;
                        forest[row, col] = "-";
                    }

                    
                }
            }
        }

        private static void Collect(string[,] forest, int row, int col, Dictionary<string, int> trufflesDict)
        {
            if (isInRange(forest, row, col))
            {
                if (forest[row, col] == "B")
                {
                    trufflesDict["black"]++;
                    forest[row, col] = "-";
                }
                if (forest[row, col] == "S")
                {
                    trufflesDict["summer"]++;
                    forest[row, col] = "-";
                }
                if (forest[row, col] == "W")
                {
                    trufflesDict["white"]++;
                    forest[row, col] = "-";
                }
            }
        }

        private static bool isInRange(string[,] forest, int row, int col)
        {
            return row >= 0 && row < forest.GetLength(0) && col >= 0 && col < forest.GetLength(1);
        }

    }
}
