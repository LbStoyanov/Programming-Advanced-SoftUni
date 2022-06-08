using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    internal class Garden
    {
        static void Main(string[] args)
        {
            int[] gardenSize = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = gardenSize[0];
            int cols = gardenSize[1];

            int[,] garden = new int[rows, cols];
            List<int> flowersCoordinates = new List<int>();

            string commands;

            while ((commands = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] platedFlowersCoordinates = commands.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = platedFlowersCoordinates[0];
                int col = platedFlowersCoordinates[1];

                if (!isInRange(garden,row,col))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                flowersCoordinates.Add(row);
                flowersCoordinates.Add(col);
            }

            for (int i = 0; i < flowersCoordinates.Count; i+=2)
            {
                int row = flowersCoordinates[i];
                int col = flowersCoordinates[i+1];

                BloomTheFlowers(garden, row, col);

            }

            PrintTheFinalStateOfTheMatrix(garden);
            
        }

        private static void BloomTheFlowers(int[,] garden, int row, int col)
        {
            int startRow = row;
            int startCol = col;

            garden[startRow, col]++;
            startRow--;

            while (isInRange(garden, startRow, col))
            {
                garden[startRow, col]++;
                startRow--;
            }
            startRow = row;

            startRow++;

            while (isInRange(garden, startRow, col))
            {
                garden[startRow, col]++;
                startRow++;
            }
            startRow = row;

            startCol++;

            while (isInRange(garden,row,startCol))
            {
                garden[row, startCol]++;
                startCol++;
            }
            startCol = col;

            startCol--;

            while (isInRange(garden, row, startCol))
            {
                garden[row, startCol]++;
                startCol--;
            }

            startCol = col;
        }

        public static void PrintTheFinalStateOfTheMatrix(int[,] matrix)
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

        private static bool isInRange(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

    }
}
