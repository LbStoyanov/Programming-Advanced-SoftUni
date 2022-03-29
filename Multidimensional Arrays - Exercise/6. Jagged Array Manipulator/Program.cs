using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());

            if (matrixRows == 0)
            {
                return;
            }

            double[][] matrix = new double[matrixRows][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                double[] colsInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                matrix[row] = new double[colsInput.Length];

                for (int col = 0; col < colsInput.Length; col++)
                {
                    matrix[row][col] = colsInput[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length /*&& row + 1 < matrix.GetLength(0) - 1*/)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else if(row + 1 <= matrix.GetLength(0) - 1)
                {
                    int maxLengh = 0;
                    if (matrix[row].Length > matrix[row + 1].Length)
                    {
                        maxLengh = matrix[row].Length;
                    }
                    else
                    {
                        maxLengh = matrix[row + 1].Length;
                    }

                    for (int col = 0; col < maxLengh; col++)
                    {
                        if (matrix[row].Length > col)
                        {
                            matrix[row ][col] /= 2;
                        }
                        if (matrix[row + 1].Length > col)
                        {
                            matrix[row + 1][col] /= 2;
                        }
                    }
                }
            }

            string commands = Console.ReadLine();

            while (commands != "End")
            {
                string[] operations = commands.Split(" ");
                string mainOperation = operations[0];

                if (mainOperation == "Add")
                {
                    int row = int.Parse(operations[1]);
                    int col = int.Parse(operations[2]);
                    double value = int.Parse(operations[3]);
                    if (row < 0 || row > matrix.GetLength(0) || col < 0 || col > matrix[row].Length)
                    {
                        commands = Console.ReadLine();
                        continue;
                    }

                    matrix[row][col] += value;

                }
                else if(mainOperation == "Subtract")
                {
                    int row = int.Parse(operations[1]);
                    int col = int.Parse(operations[2]);
                    double value = int.Parse(operations[3]);

                    if (row < 0 || row > matrix.GetLength(0) || col < 0 || col > matrix[row].Length)
                    {
                        commands = Console.ReadLine();
                        continue;
                    }

                    matrix[row][col] -= value;
                }

                commands = Console.ReadLine();
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
