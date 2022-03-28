using System;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] stairsSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = stairsSize[0];
            int cols = stairsSize[1];

            string snake = Console.ReadLine();

            char[,] snakeCondition = new char[rows, cols];

            int counter = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (counter == snake.Length)
                    {
                        counter = 0;
                    }
                    char currentChar = snake[counter];
                    snakeCondition[row, col] = currentChar;
                    counter++;
                }
            }

            for (int row = 0; row < snakeCondition.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < snakeCondition.GetLength(1); col++)
                    {

                        Console.Write(snakeCondition[row, col]);
                    }
                    Console.WriteLine();
                }
                else
                {
                    for (int col = snakeCondition.GetLength(1) - 1; col >= 0; col--)
                    {
                        Console.Write(snakeCondition[row, col]);
                    }
                    Console.WriteLine();
                }
            }


        }
    }
}
