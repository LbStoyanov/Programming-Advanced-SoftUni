using System;
using System.Collections.Generic;
using System.Linq;

namespace Bee
{
    class Bee
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public int PollinatedFlowers { get; set; }
    }
    internal class TheBee
    {
        
        static void Main(string[] args)
        {
            const int requieredFlowers = 5;

            Bee bee = new Bee();

            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            ReadingMatrix(matrix,bee);

            string direction;

            while ((direction = Console.ReadLine()) != "End")
            {
                matrix[bee.Row, bee.Col] = '.';

                if (direction == "right")
                {
                    bee.Col++;
                }
                if (direction == "left")
                {
                    bee.Col--;
                }
                if (direction == "up")
                {
                    bee.Row--;
                }
                if (direction == "down")
                {
                    bee.Row++;
                }

                if (isInRange(matrix,bee.Row,bee.Col))
                {
                    MoveTheBee(matrix, bee,direction);
                }
                else
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

            }


            if (bee.PollinatedFlowers >= requieredFlowers)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {bee.PollinatedFlowers} flowers!");
            }
            else
            {
                int neededFlowers = requieredFlowers - bee.PollinatedFlowers;

                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {neededFlowers} flowers more");
            }

            PrintTheFinalStateOfTheMatrix(matrix);

        }

        private static void MoveTheBee(char[,] matrix, Bee bee,string direction)
        {
            if (matrix[bee.Row,bee.Col] == 'f')
            {
                matrix[bee.Row, bee.Col] = 'B';
                bee.PollinatedFlowers++;
            }
            if (matrix[bee.Row, bee.Col] == 'O')
            {
                matrix[bee.Row, bee.Col] = '.';
                if (direction == "left")
                {
                    bee.Col--;
                }
                if (direction == "rigth")
                {
                    bee.Col++;
                }
                if (direction == "up")
                {
                    bee.Row--;
                }
                if (direction == "down")
                {
                    bee.Row++;
                }

                if (matrix[bee.Row, bee.Col] == 'f')
                {
                    bee.PollinatedFlowers++;
                }
                matrix[bee.Row, bee.Col] = 'B';

            }
            if (matrix[bee.Row, bee.Col] == '.')
            {
                matrix[bee.Row, bee.Col] = 'B';
            }
        }

        public static void ReadingMatrix(char[,] matrix,Bee bee)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();
                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];
                    if (matrix[row,col] == 'B')
                    {
                        bee.Row = row;
                        bee.Col = col;
                    }
                }
            }

        }

        public static void PrintTheFinalStateOfTheMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

        }

        private static bool isInRange(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
