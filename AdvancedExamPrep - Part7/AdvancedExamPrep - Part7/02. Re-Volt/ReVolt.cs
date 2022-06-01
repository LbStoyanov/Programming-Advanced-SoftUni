using System;
using System.Linq;

namespace ReVolt
{
    public class ReVolt
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int commandCount = int.Parse(Console.ReadLine());

            int playerRow = 0;
            int playerCol = 0;

            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < commandCount; i++)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {

                }
                if (command == "down")
                {

                }
                if (command == "left")
                {

                }
                if (command == "right")
                {

                }
            }


            PrintResult(matrix);

        }
        private static bool isInRange(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }


        public static void PrintResult(char[,] matrix)
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
    }
}
