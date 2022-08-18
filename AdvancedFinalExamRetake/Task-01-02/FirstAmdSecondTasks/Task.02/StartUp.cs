using System;
using System.IO;

namespace Task._02
{
    public class Mole
    {
        public Mole()
        {
            this.Points = 0;
            this.IsGameWon = false;
        }
        public int Row { get; set; }
        public int Col { get; set; }
        public int Points { get; set; }

        public bool IsGameWon { get; set; }
    }
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Mole mole = new Mole();

            int matrixSize = int.Parse(Console.ReadLine());
            
            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                   
                    matrix[row, col] = rowInput[col];
                    if (matrix[row, col] == 'M')
                    {
                        mole.Row = row;
                        mole.Col = col;
                    }
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                if (mole.Points >= 25)
                {
                    mole.IsGameWon = true;
                    break;
                }

                if (command == "up")
                {
                    mole.Row--;

                }
                else if (command == "down")
                {
                    mole.Row++;
                }
                else if (command == "left")
                {
                    mole.Col--;
                }
                else if (command == "right")
                {
                    mole.Col++;
                }

                if (isInRange(matrix,mole.Row,mole.Col))
                {
                    
                }

            }


            if (mole.Points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
            }

            if (mole.IsGameWon)
            {
                Console.WriteLine($"The Mole managed to survive with a total of {mole.Points} points.");
            }
            else
            {
                Console.WriteLine($"The Mole lost the game with a total of {mole.Points} points.");
            }
            PrintMatrix(matrix);
        }

        private static void MoveTheMole(char[,] matrix, Mole mole, string direction)
        {
            if (isInRange(matrix, moleRow, moleCol + 1))
            {
                if (matrix[moleRow, moleCol + 1] == '-')
                {
                    matrix[moleRow, moleCol] = '-';
                    matrix[moleRow, moleCol + 1] = 'M';
                    mole.Col++;

                }
                else if (matrix[moleRow, moleCol + 1] == 'S')
                {
                    matrix[moleRow, moleCol + 1] = '-';
                    mole.Points -= 3;
                    int[] sPosition = FindOtherSpecialPosition(matrix);

                    matrix[sPosition[0], sPosition[1]] = 'M';
                    mole.Row = sPosition[0];
                    mole.Col = sPosition[1];
                }
                else
                {
                    var points = Convert.ToInt32(matrix[moleRow, moleCol - 1]) - 48;
                    mole.Points += points;
                    matrix[moleRow, moleCol + 1] = 'M';
                    matrix[moleRow, moleCol] = '-';
                    mole.Col++;

                }
            }
            else
            {
                Console.WriteLine("Don't try to escape the playing field!");
            }
        }

        

       

        

        
        

        private static int[] FindOtherSpecialPosition(char[,] matrix)
        {
            int[] sPosition = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {

                        sPosition[0] = row;
                        sPosition[1] = col;
                        return sPosition;
                        
                    }
                }
            }

            return null;
        }

        private static void PrintMatrix(char[,] matrix)
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

        private static bool isInRange(char[,] forest, int row, int col)
        {
            return row >= 0 && row < forest.GetLength(0) && col >= 0 && col < forest.GetLength(1);
        }

       
    }
}
