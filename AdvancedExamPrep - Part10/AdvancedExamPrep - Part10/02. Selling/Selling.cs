using System;
using System.Linq;

namespace Selling
{
    class Player
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int CollectedMoney { get; set; }
    }
    internal class Selling
    {
        static void Main(string[] args)
        {
            Player player = new Player();


            int matrixSize = int.Parse(Console.ReadLine());
;

            char[,] matrix = new char[matrixSize, matrixSize];

            ReadingMatrix(matrix,player);

            string direction = Console.ReadLine();

            bool isOutOfTheBaker = false;

            while (true)
            {
                matrix[player.Row, player.Col] = '-';

                if (direction == "up")
                {
                    player.Row--;
                }
                if (direction == "down")
                {
                    player.Row++;
                }
                if (direction == "left")
                {
                    player.Col--;
                }
                if (direction == "right")
                {
                    player.Col++;
                }

                if (isInRange(matrix,player.Row,player.Col))
                {
                    MovePlayer(matrix, player);
                }
                else
                {
                    isOutOfTheBaker = true;
                    break;
                }

                if (player.CollectedMoney >= 50)
                {
                    break;
                }

                direction = Console.ReadLine();
            }

            if (isOutOfTheBaker)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {player.CollectedMoney}");

            PrintTheFinalStateOfTheMatrix(matrix);
        }

        private static void MovePlayer(char[,] matrix, Player player)
        {
            if (matrix[player.Row,player.Col] == '-')
            {
                matrix[player.Row, player.Col] = 'S';
            }
            else if (matrix[player.Row, player.Col] == 'O')
            {
                matrix[player.Row, player.Col] = '-';
                SearchingForSecondPillar(matrix,player);
            }
            else
            {
                int moneyForCollection = Convert.ToInt32(matrix[player.Row, player.Col] - 48);
                player.CollectedMoney += moneyForCollection;
                matrix[player.Row, player.Col] = 'S';
            }
            
        }

        private static void SearchingForSecondPillar(char[,] matrix,Player player)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'O')
                    {
                        matrix[row, col] = 'S';
                        player.Row = row;
                        player.Col = col;
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
        public static void ReadingMatrix(char[,] matrix,Player player)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();
                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];
                    if (matrix[row, col] == 'S')
                    {
                        player.Row = row;
                        player.Col = col;
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
