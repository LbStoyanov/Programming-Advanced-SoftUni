using System;
using System.Collections.Generic;

namespace Survivor
{
    internal class Survivor
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> opponentsDict = new Dictionary<string, int>
            {
                {"playerTokens",0 },
                {"opponentTokens",0 },
            };


            int beachsRows = int.Parse(Console.ReadLine());

            char[][] beach = new char[beachsRows][];

            for (int row = 0; row < beach.GetLength(0); row++)
            {
                char[] colsInput = Console.ReadLine().Replace(" ","").ToCharArray();

                beach[row] = new char[colsInput.Length];

                for (int col = 0; col < colsInput.Length; col++)
                {
                    beach[row][col] = colsInput[col];
                }
            }

            string commands;

            while ((commands = Console.ReadLine()) != "Gong")
            {
                string[] splittedCommands = commands.Split();

                int currentRow = int.Parse(splittedCommands[1]);
                int currentCol = int.Parse(splittedCommands[2]);

                if (splittedCommands[0] == "Find")
                {
                    FindToken(beach, currentRow, currentCol, opponentsDict);
                }
                if (splittedCommands[0] == "Opponent")
                {
                    string direction = splittedCommands[3];
                    OpponentSearchingForTokens(beach,currentRow,currentCol,opponentsDict,direction);
                }
            }

            PrintTheFinalStateOfTheBeach(beach);

            Console.WriteLine($"Collected tokens: {opponentsDict["playerTokens"]}");
            Console.WriteLine($"Opponent's tokens: {opponentsDict["opponentTokens"]}");
        }

        private static void OpponentSearchingForTokens(char[][] beach, int currentRow, int currentCol, Dictionary<string, int> opponentsDict, string direction)
        {
            int turnsCounter = 0;

            if (isInRange(beach,currentRow,currentCol))
            {
                while (turnsCounter < 4)
                {
                    if (beach[currentRow][currentCol] == 'T')
                    {
                        beach[currentRow][currentCol] = '-';
                        opponentsDict["opponentTokens"]++;
                    }
                    

                    if (direction == "up" && isInRange(beach,currentRow - 1,currentCol))
                    {
                        currentRow--;
                    }
                    else if (direction == "down" && isInRange(beach, currentRow + 1, currentCol))
                    {
                        currentRow++;
                    }
                    else if (direction == "left" && isInRange(beach, currentRow, currentCol - 1))
                    {
                        currentCol--;
                    }
                    else if (direction == "right" && isInRange(beach, currentRow, currentCol + 1))
                    {
                        currentCol++;
                    }
                    else
                    {
                        break;
                    }

                    turnsCounter++;
                }
            }
        }

        private static void FindToken(char[][] beach, int currentRow, int currentCol, Dictionary<string, int> opponentsDict)
        {
            if (isInRange(beach,currentRow,currentCol))
            {
                if (beach[currentRow][currentCol] == 'T')
                {
                    beach[currentRow][currentCol] = '-';
                    opponentsDict["playerTokens"]++;
                }
            }
        }

        public static void PrintTheFinalStateOfTheBeach(char[][] beach)
        {
            foreach (var row in beach)
            {
                Console.WriteLine(String.Join(" ",row));
            }
        }

        private static bool isInRange(char[][] beach, int row, int col)
        {
            return row >= 0 && row < beach.GetLength(0) && col >= 0 && col < beach[row].Length;
        }

    }
}
