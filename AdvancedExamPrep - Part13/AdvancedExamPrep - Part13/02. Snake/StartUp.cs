using System;
using System.Linq;
using System.Collections.Generic;


namespace Snake
{
    internal class StartUp
    {
        public class Snake
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int foodEaten { get; set; }
        }

        static void Main(string[] args)
        {
            const int foodRequiredToBeEaten = 10;
            Snake snake = new Snake();

            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            ReadingMatrix(matrix,snake);

            while (true)
            {
                string direction = Console.ReadLine();

                matrix[snake.Row, snake.Col] = '.';

                if (direction == "up")
                {
                    snake.Row--;
                }
                if (direction == "down")
                {
                    snake.Row++;
                }
                if (direction == "left")
                {
                    snake.Col--;
                }
                if (direction == "right")
                {
                    snake.Col++;
                }

                if (isInRange(matrix,snake.Row,snake.Col))
                {
                    MoveTheSnake(matrix, snake);
                }
                else
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (snake.foodEaten >= foodRequiredToBeEaten)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }

            }

            Console.WriteLine($"Food eaten: {snake.foodEaten}");
            PrintTheFinalStateOfTheMatrix(matrix);
        }

        private static void MoveTheSnake(char[,] matrix, Snake snake)
        {
            if (matrix[snake.Row,snake.Col] == 'B')
            {
                //May should be '.' instead of dash!!!!
                matrix[snake.Row, snake.Col] = '.';
                FindAnotherBurrow(matrix, snake);
            }
            if (matrix[snake.Row, snake.Col] == '-')
            {
                matrix[snake.Row, snake.Col] = 'S';
            }
            if (matrix[snake.Row, snake.Col] == '*')
            {
                matrix[snake.Row, snake.Col] = 'S';
                snake.foodEaten++;
            }
        }

        private static void FindAnotherBurrow(char[,] matrix, Snake snake)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        matrix[row, col] = 'S';
                        snake.Row = row;
                        snake.Col = col;
                        return;
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
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }

        }

        public static void ReadingMatrix(char[,] matrix,Snake snake)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();
                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];

                    if (matrix[row, col] == 'S')
                    {
                        snake.Row = row;
                        snake.Col = col;
                    }
                }
            }

        }

        private static bool isInRange(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
