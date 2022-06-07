using System;
using System.Linq;

namespace Warships
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] shipsInformation = new int[3];

            

            int warZonedSize = int.Parse(Console.ReadLine());

            string[] coordinatesForAttack = Console.ReadLine().Split(",");

            char[,] warZone = new char[warZonedSize, warZonedSize];

            for (int row = 0; row < warZone.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().Replace(" ","").ToCharArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    warZone[row, col] = rowInput[col];

                    if (warZone[row, col] == '<')
                    {
                        shipsInformation[1]++;
                    }
                    if (warZone[row, col] == '>')
                    {
                        shipsInformation[2]++;
                    }
                }
            }

            for (int i = 0; i < coordinatesForAttack.Length - 1; i++)
            {
                int[] firstPlayerCoordinates = 
                    coordinatesForAttack[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int firstPlayerRow = firstPlayerCoordinates[0];
                int firstPlayerCol = firstPlayerCoordinates[1];

                MoveFirstPlayer(warZone, shipsInformation, firstPlayerRow, firstPlayerCol);

                int[] secondPlayerCoordinates =
                  coordinatesForAttack[i + 1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int secondPlayerRow = secondPlayerCoordinates[0];
                int secondPlayerCol = secondPlayerCoordinates[1];


                MoveSecondPlayer(warZone,shipsInformation,secondPlayerRow,secondPlayerCol);

                if (shipsInformation[1] == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {shipsInformation[0]} ships have been sunk in the battle.");
                    //PrintFinalStateOfTheWarZone(warZone);
                    return;
                }
                if (shipsInformation[2]== 0)
                {
                    Console.WriteLine($"Player One has won the game! {shipsInformation[0]} ships have been sunk in the battle.");
                   // PrintFinalStateOfTheWarZone(warZone);
                    return;
                }

            }
            //PrintFinalStateOfTheWarZone(warZone);
            Console.WriteLine($"It's a draw! Player One has {shipsInformation[1]} ships left. Player Two has {shipsInformation[2]} ships left.");

        }

        private static void MoveSecondPlayer(char[,] warZone, int[] shipsInformation, int secondPlayerRow, int secondPlayerCol)
        {
            if (isInRange(warZone, secondPlayerRow, secondPlayerCol))
            {
                if (warZone[secondPlayerRow, secondPlayerCol] == '<')
                {
                    warZone[secondPlayerRow, secondPlayerCol] = 'X';
                    shipsInformation[0]++;
                    shipsInformation[1]--;
                }
                else if (warZone[secondPlayerRow, secondPlayerCol] == '#')
                {
                    ApplyMineExplosion(warZone, secondPlayerRow, secondPlayerCol, shipsInformation);
                }
            }
        }

        private static void MoveFirstPlayer(char[,] warZone, int[] shipsInformation, int firstPlayerRow, int firstPlayerCol)
        {
            if (isInRange(warZone, firstPlayerRow, firstPlayerCol))
            {
                if (warZone[firstPlayerRow,firstPlayerCol] == '>')
                {
                    shipsInformation[0]++;
                    shipsInformation[2]--;
                    warZone[firstPlayerRow, firstPlayerCol] = 'X';

                }
                else if(warZone[firstPlayerRow,firstPlayerCol] == '#')
                {
                    ApplyMineExplosion(warZone,firstPlayerRow,firstPlayerCol,shipsInformation);
                    warZone[firstPlayerRow, firstPlayerCol] = 'X';
                }

                
            }
        }

        private static void ApplyMineExplosion(char[,] warZone, int playerRow, int playerCol, int[] shipsInformation)
        {
            if (isInRange(warZone,playerRow - 1,playerCol))
            {
                playerRow--;
                ApplyChangesAfterExplosion(warZone, playerRow, playerCol, shipsInformation);
                playerRow++;
            }
            if (isInRange(warZone, playerRow -1, playerCol + 1))
            {
                ApplyChangesAfterExplosion(warZone, playerRow--, playerCol++, shipsInformation);
                playerRow++;
                playerCol--;
            }
            if (isInRange(warZone, playerRow, playerCol + 1))
            {
                playerCol++;
                ApplyChangesAfterExplosion(warZone, playerRow, playerCol, shipsInformation);
                playerCol--;
            }
            if (isInRange(warZone, playerRow + 1, playerCol + 1))
            {
                playerRow++;
                playerCol++;
                ApplyChangesAfterExplosion(warZone, playerRow, playerCol, shipsInformation);
                playerRow--;
                playerCol--;
            }
            if (isInRange(warZone, playerRow + 1, playerCol))
            {
                playerRow++;
                ApplyChangesAfterExplosion(warZone, playerRow, playerCol, shipsInformation);
                playerRow--;
            }
            if (isInRange(warZone, playerRow + 1, playerCol - 1))
            {
                playerRow++;
                playerCol--;
                ApplyChangesAfterExplosion(warZone, playerRow, playerCol, shipsInformation);
                playerRow--;
                playerCol++;
            }
            else if (isInRange(warZone, playerRow , playerCol - 1))
            {
                playerCol--;
                ApplyChangesAfterExplosion(warZone, playerRow, playerCol, shipsInformation);
                playerCol++;
            }
        }

        private static void ApplyChangesAfterExplosion(char[,] warZone, int playerRow, int playerCol, int[] shipsInformation)
        {
            if (warZone[playerRow , playerCol] == '>')
            {
                shipsInformation[0]++;
                shipsInformation[2]--;
                warZone[playerRow, playerCol] = 'X';
            }
            if (warZone[playerRow , playerCol] == '<')
            {
                shipsInformation[0]++;
                shipsInformation[1]--;
                warZone[playerRow , playerCol] = 'X';
            }
        }

        public static void PrintFinalStateOfTheWarZone(char[,] warZone)
        {
            for (int row = 0; row < warZone.GetLength(0); row++)
            {
                for (int col = 0; col < warZone.GetLength(1); col++)
                {
                    Console.Write(warZone[row,col]);
                }
                Console.WriteLine();
            }

        }

        private static bool isInRange(char[,] warZone, int row, int col)
        {
            return row >= 0 && row < warZone.GetLength(0) && col >= 0 && col < warZone.GetLength(1);
        }

    }
}
