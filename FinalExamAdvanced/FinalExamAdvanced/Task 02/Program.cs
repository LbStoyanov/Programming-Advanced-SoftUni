using System;
using System.Linq;

namespace Task_02_
{
    public class Vanko
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int CountOfHoles { get; set; }
        public int CountOfRodes { get; set; }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
             Vanko vanko = new Vanko();
           

            char[,] matrix = new char[matrixSize, matrixSize];

            ReadingMatrix(matrix,vanko);
            string direction;

            while ((direction = Console.ReadLine()) != "End")
            {
              
                if (direction == "up")
                {
                    MoveVankoUp(matrix, vanko);
                }
                else if (direction == "down")
                {
                    MoveVankoDown(matrix, vanko);
                    
                }
                else if (direction == "left")
                {
                    MoveVankoLeft(matrix,vanko);
                }
                else if (direction == "right")
                {
                    MoveVankoRight(matrix, vanko);
                }

                if (matrix[vanko.Row,vanko.Col] == 'E')
                {
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {vanko.CountOfHoles} hole(s).");
                    break;
                }

              
            }

            if (matrix[vanko.Row,vanko.Col] != 'E')
            {
                Console.WriteLine($"Vanko managed to make {vanko.CountOfHoles} hole(s) and he hit only {vanko.CountOfRodes} rod(s).");
            }

            PrintTheFinalStateOfTheMatrix(matrix);
        }

        private static void MoveVankoRight(char[,] matrix, Vanko vanko)
        {
            vanko.Col++;
            if (!isInRange(matrix, vanko.Row, vanko.Col))
            {
                vanko.Col--;
                return;
            }
            else
            {
                if (matrix[vanko.Row, vanko.Col] == 'C')
                {
                    matrix[vanko.Row, vanko.Col] = 'E';
                    matrix[vanko.Row, vanko.Col - 1] = '*';
                    vanko.CountOfHoles++;
                }
                else if (matrix[vanko.Row, vanko.Col] == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");
                    vanko.CountOfRodes++;
                    vanko.Col++;
                    return;
                }
                else if (matrix[vanko.Row, vanko.Col] == '-')
                {
                    vanko.CountOfHoles++;
                    matrix[vanko.Row, vanko.Col] = 'V';
                    matrix[vanko.Row, vanko.Col - 1] = '*';

                }
                else if (matrix[vanko.Row, vanko.Col] == '*')
                {
                    vanko.CountOfHoles++;
                    Console.WriteLine($"The wall is already destroyed at position [{vanko.Row}, {vanko.Col}]!");
                    matrix[vanko.Row, vanko.Col] = 'V';
                    matrix[vanko.Row, vanko.Col - 1] = '*';
                    return;
                }
            }
        }

        private static void MoveVankoLeft(char[,] matrix,Vanko vanko)
        {
            vanko.Col--;
            if (!isInRange(matrix, vanko.Row, vanko.Col))
            {
                vanko.Col++;
                return;
            }
            else
            {
                if (matrix[vanko.Row, vanko.Col] == 'C')
                {
                    matrix[vanko.Row, vanko.Col] = 'E';
                    matrix[vanko.Row, vanko.Col + 1] = '*';
                    vanko.CountOfHoles++;
                }
                else if (matrix[vanko.Row, vanko.Col] == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");
                    vanko.CountOfRodes++;
                    vanko.Col++;
                    return;
                }
                else if (matrix[vanko.Row, vanko.Col] == '-')
                {
                    vanko.CountOfHoles++;
                    matrix[vanko.Row, vanko.Col] = 'V';
                    matrix[vanko.Row, vanko.Col + 1] = '*';

                }
                else if (matrix[vanko.Row, vanko.Col] == '*')
                {
                    vanko.CountOfHoles++;
                    Console.WriteLine($"The wall is already destroyed at position [{vanko.Row}, {vanko.Col}]!");
                    matrix[vanko.Row, vanko.Col] = 'V';
                    matrix[vanko.Row, vanko.Col + 1] = '*';
                    return;
                }
            }
        }

        private static void MoveVankoDown(char[,] matrix, Vanko vanko)
        {
            
            vanko.Row++;

            if (!isInRange(matrix, vanko.Row, vanko.Col))
            {
                vanko.Row--;
                return;
            }
            else
            {
                if (matrix[vanko.Row, vanko.Col] == 'C')
                {
                    matrix[vanko.Row, vanko.Col] = 'E';
                    matrix[vanko.Row - 1, vanko.Col] = '*';
                    vanko.CountOfHoles++;
                }
                else if (matrix[vanko.Row, vanko.Col] == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");
                    vanko.CountOfRodes++;
                    vanko.Row--;
                    return;
                }
                else if (matrix[vanko.Row, vanko.Col] == '-')
                {
                    vanko.CountOfHoles++;
                    matrix[vanko.Row, vanko.Col] = 'V';
                    if (!isInRange(matrix,vanko.Row - 1, vanko.Col))
                    {
                        continue;
                    }
                    matrix[vanko.Row - 1, vanko.Col] = '*';
                    

                }
                else if (matrix[vanko.Row, vanko.Col] == '*')
                {
                    vanko.CountOfHoles++;
                    Console.WriteLine($"The wall is already destroyed at position [{vanko.Row}, {vanko.Col}]!");
                    matrix[vanko.Row, vanko.Col] = 'V';
                    matrix[vanko.Row - 1, vanko.Col] = '*';
                    return;
                }
            }
        }

        private static void MoveVankoUp(char[,] matrix, Vanko vanko)
        {
            vanko.Row--;
            if (!isInRange(matrix,vanko.Row,vanko.Col))
            {
                vanko.Row++;
                return;
            }
            else
            {
                if (matrix[vanko.Row,vanko.Col] == 'C')
                {
                    matrix[vanko.Row, vanko.Col] = 'E';
                    matrix[vanko.Row + 1, vanko.Col] = '*';
                    vanko.CountOfHoles++;
                }
                else if(matrix[vanko.Row, vanko.Col] == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");
                    vanko.CountOfRodes++;
                    vanko.Row++;
                    return;
                }
                else if (matrix[vanko.Row, vanko.Col] == '-')
                {
                    vanko.CountOfHoles++;
                    matrix[vanko.Row, vanko.Col] = 'V';
                    matrix[vanko.Row + 1, vanko.Col] = '*';

                }
                else if (matrix[vanko.Row, vanko.Col] == '*')
                {
                    vanko.CountOfHoles++;
                    Console.WriteLine($"The wall is already destroyed at position [{vanko.Row}, {vanko.Col}]!");
                    matrix[vanko.Row, vanko.Col] = 'V';
                    matrix[vanko.Row + 1, vanko.Col] = '*';
                    return ;
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

        public static void ReadingMatrix(char[,] matrix,Vanko vanko)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();
                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];

                    if (matrix[row, col] == 'V')
                    {
                        vanko.Row = row;
                        vanko.Col = col;
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
