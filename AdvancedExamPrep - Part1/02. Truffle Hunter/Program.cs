using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Truffle_Hunter
{
    public class Program
    {
       public const string BlackTruffle = "B";
       public const string WhiteTruffle = "W";
       public const string SummerTruffle = "S";
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
                string[] commandParameters = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string mainAction = commandParameters[0];
                int row = int.Parse(commandParameters[1]);
                int col = int.Parse(commandParameters[2]);

                if (mainAction == "Collect")
                {
                    CollectTruffles(forest, row, col, trufflesDict);
                }
                else if (mainAction == "Wild_Boar")
                {
                    string direction = commandParameters[3];

                    MoveWildBoar(forest, row, col, direction, trufflesDict);
                }
            }

            int black = trufflesDict["black"];
            int summer = trufflesDict["summer"];
            int white = trufflesDict["white"];
            int eaten = trufflesDict["eaten"];

            Console.WriteLine($"Peter manages to harvest {black} black, {summer} summer, and {white} white truffles.");

            Console.WriteLine($"The wild boar has eaten {eaten} truffles.");

            PrintForest(forest);

        }

        private static void PrintForest(string[,] forest)
        {
            for (int row = 0; row < forest.GetLength(0); row++)
            {
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    Console.Write(forest[row, col] + " ");
                }
                Console.WriteLine();
            }

        }

        private static void MoveWildBoar(string[,] forest, int row, int col, string direction, Dictionary<string, int> trufflesDict)
        {
            if (direction == "up")
            {
                MoveUp(forest, row, col, trufflesDict);
            }
            if (direction == "down")
            {
                MoveDown(forest, row, col, trufflesDict);
            }
            if (direction == "left")
            {
                MoveLeft(forest, row, col, trufflesDict);
            }
            if (direction == "right")
            {
                MoveRight(forest, row, col, trufflesDict);
            }
        }
        private static void MoveRight(string[,] forest, int startRow, int startCol, Dictionary<string, int> trufflesDict)
        {
            for (int col = startCol; col < forest.GetLength(1); col += 2)
            {
                if (col > forest.Length)
                {
                    break;
                }
                if (forest[startRow, col] == BlackTruffle)
                {
                    trufflesDict["eaten"]++;
                    forest[startRow, col] = "-";
                }
                if (forest[startRow, col] == SummerTruffle)
                {
                    trufflesDict["eaten"]++;
                    forest[startRow, col] = "-";
                }
                if (forest[startRow, col] == WhiteTruffle)
                {
                    trufflesDict["eaten"]++;
                    forest[startRow, col] = "-";
                }
            }
        }

        private static void MoveLeft(string[,] forest, int startRow, int startCol, Dictionary<string, int> trufflesDict)
        {
            for (int col = startCol; col < forest.GetLength(1); col -= 2)
            {
                if (col < 0)
                {
                    break;
                }
                if (forest[startRow, col] == "B")
                {

                    trufflesDict["eaten"]++;
                    forest[startRow, col] = "-";
                }
                if (forest[startRow, col] == "S")
                {

                    trufflesDict["eaten"]++;
                    forest[startRow, col] = "-";
                }
                if (forest[startRow, col] == "W")
                {

                    trufflesDict["eaten"]++;
                    forest[startRow, col] = "-";
                }
            }
        }

        private static void MoveDown(string[,] forest, int startRow, int startCol, Dictionary<string, int> trufflesDict)
        {
            for (int row = startRow; row < forest.GetLength(0); row += 2)
            {
                if (row > forest.Length)
                {
                    break;
                }
                if (forest[row, startCol] == "B")
                {
                    trufflesDict["eaten"]++;
                    forest[row, startCol] = "-";
                }
                if (forest[row, startCol] == "S")
                {
                    trufflesDict["eaten"]++;
                    forest[row, startCol] = "-";
                }
                if (forest[row, startCol] == "W")
                {
                    trufflesDict["eaten"]++;
                    forest[row, startCol] = "-";
                }
            }
        }

        private static void MoveUp(string[,] forest, int startRow, int startCol, Dictionary<string, int> trufflesDict)
        {
            for (int row = startRow; row < forest.GetLength(0); row -= 2)
            {
                if (row < 0)
                {
                    break;
                }
                if (forest[row, startCol] == "B")
                {
                    trufflesDict["eaten"]++;
                    forest[row, startCol] = "-";
                }
                if (forest[row, startCol] == "S")
                {
                    trufflesDict["eaten"]++;
                    forest[row, startCol] = "-";
                }
                if (forest[row, startCol] == "W")
                {
                    trufflesDict["eaten"]++;
                    forest[row, startCol] = "-";
                }
                
            }
        }

        private static void CollectTruffles(string[,] forest, int truffleRow, int truffleCol, Dictionary<string, int> trufflesDict)
        {
            if (isInRange(forest, truffleRow, truffleCol))
            {
                if (forest[truffleRow, truffleCol] == "B")
                {
                    trufflesDict["black"]++;
                    forest[truffleRow, truffleCol] = "-";
                }
                if (forest[truffleRow, truffleCol] == "S")
                {
                    trufflesDict["summer"]++;
                    forest[truffleRow, truffleCol] = "-";
                }
                if (forest[truffleRow, truffleCol] == "W")
                {
                    trufflesDict["white"]++;
                    forest[truffleRow, truffleCol] = "-";
                }
            }
        }

        private static bool isInRange(string[,] forest, int row, int col)
        {
            return row >= 0 && row < forest.GetLength(0) && col >= 0 && col < forest.GetLength(1);
        }

    }
}
