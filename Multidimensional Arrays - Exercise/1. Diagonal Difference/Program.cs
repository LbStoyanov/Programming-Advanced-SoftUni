﻿using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];
            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            Console.WriteLine(matrix.GetLength(0) - 1);
            Console.WriteLine(matrix.GetLength(1));
            //for (int row = 0; row < matrixSize; row++)
            //{
            //    for (int col = 0; col < matrixSize; col++)
            //    {
            //        if (col == row)
            //        {
            //            primaryDiagonalSum += matrix[row, col];
            //        }
            //        if ((row + col) == (matrixSize - 1))
            //        {
            //            secondaryDiagonalSum += matrix[row, col];
            //        }
            //    }
            //}

            
            //int result = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
            //Console.WriteLine(result);

        }
    }
}
