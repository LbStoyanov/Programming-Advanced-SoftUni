using System;
using System.Linq;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            string[,] field = new string[fieldSize, fieldSize];

            string[] moveDirections = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];
                }
            }

            int minerStartRowPosition = 0;
            int minerStartColPosition = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row,col] == "s")
                    {
                        minerStartRowPosition = row;
                        minerStartColPosition = col;
                    }
                }
            }

          

            for (int i = 0; i < moveDirections.Length; i++)
            {
                string currentDirection = moveDirections[i];

                if (currentDirection == "up" )
                {

                }
                if (currentDirection == "down")
                {

                }
                if (currentDirection == "right")
                {

                }
                if (currentDirection == "left")
                {

                }


            }
        }
        private static bool isInRange(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
