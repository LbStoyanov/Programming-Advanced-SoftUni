using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int biggestSquareRows = 2;
            int biggestSquareCols = 2;

            int[] matrixSize = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowInput = Console.ReadLine().Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = char.Parse(rowInput[col]);
                }
            }

            int squareMatrixCount = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    
                    if (row + biggestSquareRows - 1 < rows && col + biggestSquareCols - 1 < cols)
                    {
                        char firstChar = matrix[row, col];
                        char secondChar = matrix[row, col + 1];
                        char thirthChar = matrix[row + 1, col];
                        char fourtChar = matrix[row + 1, col + 1];

                        if (firstChar == secondChar && firstChar == thirthChar && firstChar == fourtChar)
                        {
                            squareMatrixCount++;
                        }

                        
                    }
                }
            }

            Console.WriteLine(squareMatrixCount);
        }
    }
}
