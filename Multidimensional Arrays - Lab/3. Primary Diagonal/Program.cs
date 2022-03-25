using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];
            var sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                }

            }

            for (int row = 0; row < matrix.Length; row++)
            {
                
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == row)
                    {
                        sum += matrix[row,col];
                    }

                }

            }
            Console.WriteLine(sum);
        }
    }
}
