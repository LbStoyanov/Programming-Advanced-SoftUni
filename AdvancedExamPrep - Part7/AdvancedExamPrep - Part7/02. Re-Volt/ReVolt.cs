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

            int[] playersPosition = new int[2];

            int finishMarkRow = 0;
            int finishMarkCol = 0;


            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];

                    if (matrix[row, col] == 'f')
                    {
                        playersPosition[0] = row;
                        playersPosition[1] = col;
                    }

                    if (matrix[row, col] == 'F')
                    {
                        finishMarkRow = row;
                        finishMarkCol = col;
                    }
                }
            }


            //bool isFinishMarkReached = matrix[finishMarkRow, finishMarkCol] == 'F';

            for (int i = 0; i < commandCount; i++)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    MoveUp(matrix,playersPosition);
                }
                if (command == "down")
                {
                    MoveDown(matrix, playersPosition);
                }
                if (command == "left")
                {
                    MoveLeft(matrix, playersPosition);
                }
                if (command == "right")
                {
                    MoveRight(matrix, playersPosition);
                }
                if (matrix[finishMarkRow, finishMarkCol] != 'F')
                {
                    Console.WriteLine("Player won!");
                    PrintResult(matrix);
                    return; 
                }
            }

            Console.WriteLine("Player lost!");
            PrintResult(matrix);
        }

        private static void MoveRight(char[,] matrix, int[] playersPosition)
        {
            int lastCol = 0;

            if (isInRange(matrix, playersPosition[0], playersPosition[1] + 1))
            {
                if (matrix[playersPosition[0], playersPosition[1] + 1] == 'F')
                {
                    matrix[playersPosition[0], playersPosition[1]] = '-';
                    matrix[playersPosition[0], playersPosition[1] + 1] = 'f';
                }
                else if (matrix[playersPosition[0], playersPosition[1] + 1] == '-')
                {
                    matrix[playersPosition[0], playersPosition[1]] = '-';
                    matrix[playersPosition[0], playersPosition[1] + 1] = 'f';
                    playersPosition[1]++;
                }
                else if (matrix[playersPosition[0], playersPosition[1] + 1] == 'B')
                {
                    matrix[playersPosition[0], playersPosition[1]] = '-';

                    if (isInRange(matrix, playersPosition[0], playersPosition[1] - 2))
                    {
                        matrix[playersPosition[0], playersPosition[1] - 2] = 'f';
                        playersPosition[1] += 2;
                    }
                    else
                    {
                        playersPosition[1] = lastCol;
                        matrix[playersPosition[0], playersPosition[1]] = 'f';
                    }
                }
            }
            else
            {

                if (matrix[lastCol, playersPosition[1]] == 'T')
                {
                    return;
                }

                matrix[playersPosition[0], playersPosition[1]] = '-';
                playersPosition[1] = lastCol;

                if (matrix[playersPosition[0], playersPosition[1]] == 'F')
                {
                    matrix[playersPosition[0], playersPosition[1]] = 'f';
                }
                else if (matrix[playersPosition[0], playersPosition[1]] == 'B')
                {
                    matrix[playersPosition[0], playersPosition[1] + 1] = 'f';
                }
                else
                {
                    matrix[playersPosition[0], playersPosition[1]] = 'f';
                }

            }
        }
        private static void MoveLeft(char[,] matrix, int[] playersPosition)
        {
            int lastCol = matrix.GetLength(1) - 1;

            if (isInRange(matrix, playersPosition[0], playersPosition[1] - 1))
            {
                if (matrix[playersPosition[0] , playersPosition[1] - 1] == 'F')
                {
                    matrix[playersPosition[0], playersPosition[1]] = '-';
                    matrix[playersPosition[0], playersPosition[1] - 1] = 'f';
                }
                else if (matrix[playersPosition[0], playersPosition[1] - 1] == '-')
                {
                    matrix[playersPosition[0], playersPosition[1]] = '-';
                    matrix[playersPosition[0], playersPosition[1] - 1] = 'f';
                    playersPosition[1]--;
                }
                else if (matrix[playersPosition[0], playersPosition[1] - 1] == 'B')
                {
                    matrix[playersPosition[0], playersPosition[1]] = '-';

                    if (isInRange(matrix, playersPosition[0], playersPosition[1] - 2))
                    {
                        matrix[playersPosition[0], playersPosition[1] - 2] = 'f';
                        playersPosition[1] -= 2;
                    }
                    else
                    {
                        playersPosition[1] = lastCol;
                        matrix[playersPosition[0], playersPosition[1]] = 'f';
                    }
                }
            }
            else
            {

                if (matrix[lastCol, playersPosition[1]] == 'T')
                {
                    return;
                }

                matrix[playersPosition[0], playersPosition[1]] = '-';
                playersPosition[1] = lastCol;

                if (matrix[playersPosition[0], playersPosition[1]] == 'F')
                {
                    matrix[playersPosition[0], playersPosition[1]] = 'f';
                }
                else if (matrix[playersPosition[0], playersPosition[1]] == 'B')
                {
                    matrix[playersPosition[0], playersPosition[1] - 1] = 'f';
                }
                else
                {
                    matrix[playersPosition[0], playersPosition[1]] = 'f';
                }

            }
        }

        private static void MoveUp(char[,] matrix, int[] playersPosition)
        {
            int lastRow = matrix.GetLength(0) - 1;

            if (isInRange(matrix, playersPosition[0] - 1, playersPosition[1]))
            {
                if (matrix[playersPosition[0] - 1, playersPosition[1]] == 'F')
                {
                    matrix[playersPosition[0], playersPosition[1]] = '-';
                    matrix[playersPosition[0] - 1, playersPosition[1]] = 'f';
                }
                else if (matrix[playersPosition[0] - 1, playersPosition[1]] == '-')
                {
                    matrix[playersPosition[0], playersPosition[1]] = '-';
                    matrix[playersPosition[0] - 1, playersPosition[1]] = 'f';
                    playersPosition[0]--;
                }
                else if (matrix[playersPosition[0] - 1, playersPosition[1]] == 'B')
                {
                    matrix[playersPosition[0], playersPosition[1]] = '-';

                    if (isInRange(matrix, playersPosition[0] - 2, playersPosition[1]))
                    {
                        matrix[playersPosition[0] - 2, playersPosition[1]] = 'f';
                        playersPosition[0] -= 2;
                    }
                    else
                    {
                        playersPosition[0] = lastRow;
                        matrix[playersPosition[0], playersPosition[1]] = 'f';
                    }
                }
            }
            else
            {

                if (matrix[lastRow, playersPosition[1]] == 'T')
                {
                    return;
                }

                matrix[playersPosition[0], playersPosition[1]] = '-';
                playersPosition[0] = lastRow;

                if (matrix[playersPosition[0], playersPosition[1]] == 'F')
                {
                    matrix[playersPosition[0], playersPosition[1]] = 'f';
                }
                else if (matrix[playersPosition[0], playersPosition[1]] == 'B')
                {
                    matrix[playersPosition[0] + 1, playersPosition[1]] = 'f';
                }
                else
                {
                    matrix[playersPosition[0], playersPosition[1]] = 'f';
                }

            }
        }

        private static void MoveDown(char[,] matrix, int[] playersPosition)
        {
            int lastRow = 0;

            if (isInRange(matrix, playersPosition[0] + 1, playersPosition[1]))
            {
                if (matrix[playersPosition[0] + 1, playersPosition[1]] == 'F')
                {
                    matrix[playersPosition[0], playersPosition[1]] = '-';
                    matrix[playersPosition[0] + 1, playersPosition[1]] = 'f';
                }
                else if (matrix[playersPosition[0] + 1, playersPosition[1]] == '-')
                {
                    matrix[playersPosition[0], playersPosition[1]] = '-';
                    matrix[playersPosition[0] + 1, playersPosition[1]] = 'f';
                    playersPosition[0]++;
                }
                else if (matrix[playersPosition[0] + 1, playersPosition[1]] == 'B')
                {
                    matrix[playersPosition[0], playersPosition[1]] = '-';

                    if (isInRange(matrix, playersPosition[0] + 2, playersPosition[1]))
                    {
                        matrix[playersPosition[0] + 2, playersPosition[1]] = 'f';
                        playersPosition[0] += 2;
                    }
                    else
                    {
                        playersPosition[0] = lastRow;
                        matrix[playersPosition[0], playersPosition[1]] = 'f';
                    }
                }
            }
            else
            {

                if (matrix[lastRow, playersPosition[1]] == 'T')
                {
                    return;
                }

                matrix[playersPosition[0], playersPosition[1]] = '-';
                playersPosition[0] = lastRow;
                
                if (matrix[playersPosition[0], playersPosition[1]] == 'F')
                {
                    matrix[playersPosition[0], playersPosition[1]] = 'f';
                }
                else if (matrix[playersPosition[0], playersPosition[1]] == 'B')
                {
                    matrix[playersPosition[0] + 1, playersPosition[1]] = 'f';
                }
                else
                {
                    matrix[playersPosition[0], playersPosition[1]] = 'f';
                }
                
            }
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
