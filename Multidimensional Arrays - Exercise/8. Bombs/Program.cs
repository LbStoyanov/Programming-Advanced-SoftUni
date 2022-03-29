using System;
using System.Linq;

namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int[] bombsCordinates = Console.ReadLine().Split(',', ' ').Select(int.Parse).ToArray();


            for (int i = 1; i <= bombsCordinates.Length; i+=2)
            {
                var currentBombRow = bombsCordinates[i - 1];
                var currentBombCol = bombsCordinates[i];
                var explosionPower = matrix[currentBombRow, currentBombCol];
                if (matrix[currentBombRow, currentBombCol] <= 0)
                {
                    continue;
                }

                if (isInRange(matrix, currentBombRow - 1, currentBombCol) && matrix[currentBombRow - 1, currentBombCol] > 0)
                {
                    matrix[currentBombRow - 1, currentBombCol] -= explosionPower;
                }

                if (isInRange(matrix, currentBombRow - 1, currentBombCol - 1) && matrix[currentBombRow - 1, currentBombCol - 1] > 0)
                {
                    matrix[currentBombRow - 1, currentBombCol - 1] -= explosionPower;
                }

                if (isInRange(matrix, currentBombRow - 1, currentBombCol + 1) && matrix[currentBombRow - 1, currentBombCol + 1] > 0)
                {
                    matrix[currentBombRow - 1, currentBombCol + 1] -= explosionPower;
                }

                if (isInRange(matrix, currentBombRow, currentBombCol - 1) && matrix[currentBombRow, currentBombCol - 1] > 0)
                {
                    matrix[currentBombRow, currentBombCol - 1] -= explosionPower;
                }

                if (isInRange(matrix, currentBombRow, currentBombCol + 1) && matrix[currentBombRow, currentBombCol + 1] > 0)
                {
                    matrix[currentBombRow, currentBombCol + 1] -= explosionPower;
                }

                if (isInRange(matrix, currentBombRow + 1, currentBombCol) && matrix[currentBombRow + 1, currentBombCol] > 0)
                {
                    matrix[currentBombRow + 1, currentBombCol] -= explosionPower;
                }

                if (isInRange(matrix, currentBombRow + 1, currentBombCol + 1) && matrix[currentBombRow + 1, currentBombCol + 1] > 0)
                {
                    matrix[currentBombRow + 1, currentBombCol + 1] -= explosionPower;
                }

                if (isInRange(matrix, currentBombRow + 1, currentBombCol - 1) && matrix[currentBombRow + 1, currentBombCol - 1] > 0)
                {
                    matrix[currentBombRow + 1, currentBombCol - 1] -= explosionPower;
                }

                matrix[currentBombRow, currentBombCol] = 0;
            }

            int aliveCellsCounter = 0;
            int aliveCellsSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int currentCell = matrix[row,col];

                    if (currentCell > 0)
                    {
                        aliveCellsCounter++;
                        aliveCellsSum += currentCell;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCellsCounter}");

            Console.WriteLine($"Sum: {aliveCellsSum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }

        }
        private static bool isInRange(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
