using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];
            int sum = 0;

            int[,] matrix = new int[rows, cols];


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < rowInput.Length; col++)
                {
                    //Console.WriteLine($"Reading: Matrix[{row},{col}]=?");
                    matrix[row, col] = rowInput[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    //Console.WriteLine($"Reading: Matrix[{row},{col}]=?");
                    //Console.Write(matrix[row,col] + " ");
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
                sum = 0;
            }
        }
    }
}
