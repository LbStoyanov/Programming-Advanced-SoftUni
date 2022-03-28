using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixRows][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[row] = new int[colsInput.Length];

                for (int col = 0; col < colsInput.Length; col++)
                {
                    matrix[row][col] = colsInput[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] actions = command.Split();
                string mainAction = actions[0];
                int row = int.Parse(actions[1]);
                int col = int.Parse(actions[2]);
                int value = int.Parse(actions[3]);

                if (mainAction == "Add")
                {
                    if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        matrix[row][col] += value;
                    }
                }
                else if (mainAction == "Subtract")
                {
                    

                    if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        matrix[row][col] -= value;
                    }
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
