using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] action = command.Split(" ");
                string mainAction = action[0];

                if (mainAction == "swap" && action.Length == 5)
                {
                    int row1 = int.Parse(action[1]);
                    int col1 = int.Parse(action[2]);
                    int row2 = int.Parse(action[3]);
                    int col2 = int.Parse(action[4]);

                    if (row1 < 0 || row1 > matrix.GetLength(0) - 1 || row2 < 0 || row2 > matrix.GetLength(1) - 1)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        string currentRowCol = matrix[row1, col1];
                        

                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = currentRowCol;
                        PrintMatrix(matrix);
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine();
            }
        }
        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                   Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
