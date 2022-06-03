using System;

namespace SuperMario
{
    class Mario
    {
        public Mario(int marioLivesCount)
        {
            this.LivesCount = marioLivesCount;
            this.Row = 0;
            this.Col = 0;
        }

        public int LivesCount { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
    internal class SuperMario
    {
        static void Main(string[] args)
        {
            const char Up = 'W';
            const char Down = 'S';
            const char Left = 'A';
            const char Right = 'D';


            int marioLivesCount = int.Parse(Console.ReadLine());

            Mario mario = new Mario(marioLivesCount);

            int mazeSize = int.Parse(Console.ReadLine());

            

            char[,] theMaze = new char[mazeSize, mazeSize];

            for (int row = 0; row < theMaze.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    theMaze[row, col] = rowInput[col];

                    if (theMaze[row, col] == 'M')
                    {
                        mario.Row = row;
                        mario.Col = col;
                    }
                }
            }

            bool isMarioDied = false;

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                char direction = char.Parse(commands[0]);
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                theMaze[row, col] = 'B';

                mario.LivesCount--;

                if (direction == Up)
                {
                    MoveUp(theMaze,mario);
                }
                if (direction == Down)
                {
                    MoveDown(theMaze, mario);
                }
                if (direction == Left)
                {
                    MoveLeft(theMaze, mario);
                }
                if (direction == Right)
                {
                    MoveRight(theMaze, mario);
                }

                if (theMaze[mario.Row,mario.Col] == 'X')
                {
                    isMarioDied = true;
                    break;
                }

                if (theMaze[mario.Row, mario.Col] == '-')
                {
                    break;
                }
               
                if (mario.LivesCount <= 0)
                {
                    theMaze[mario.Row, mario.Col] = 'X';
                    isMarioDied = true;
                    break;
                }
            }

            if (isMarioDied)
            {
                Console.WriteLine($"Mario died at {mario.Row};{mario.Col}.");
            }
            else
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {mario.LivesCount}");
            }

            PrintResult(theMaze);

        }

        private static void MoveRight(char[,] theMaze, Mario mario)
        {
            mario.Col++;

            if (isInRange(theMaze, mario))
            {
                if (theMaze[mario.Row, mario.Col] == 'B')
                {
                    mario.LivesCount -= 2;
                    theMaze[mario.Row, mario.Col - 1] = '-';
                    theMaze[mario.Row, mario.Col] = 'M';
                    if (mario.LivesCount <= 0)
                    {
                        theMaze[mario.Row, mario.Col] = 'X';
                    }
                }
                else if (theMaze[mario.Row, mario.Col] == 'P')
                {
                    theMaze[mario.Row, mario.Col] = '-';
                    theMaze[mario.Row, mario.Col - 1] = '-';
                }
                else
                {
                    theMaze[mario.Row, mario.Col] = 'M';
                    theMaze[mario.Row, mario.Col - 1] = '-';
                }

                return;
            }

            mario.Col--;

        }

        private static void MoveLeft(char[,] theMaze, Mario mario)
        {
            mario.Col--;

            if (isInRange(theMaze, mario))
            {
                if (theMaze[mario.Row, mario.Col] == 'B')
                {
                    mario.LivesCount -= 2;
                    theMaze[mario.Row , mario.Col + 1] = '-';
                    theMaze[mario.Row, mario.Col] = 'M';
                    if (mario.LivesCount <= 0)
                    {
                        theMaze[mario.Row, mario.Col] = 'X';
                    }
                }
                else if (theMaze[mario.Row, mario.Col] == 'P')
                {
                    theMaze[mario.Row, mario.Col] = '-';
                    theMaze[mario.Row, mario.Col + 1] = '-';
                }
                else
                {
                    theMaze[mario.Row, mario.Col] = 'M';
                    theMaze[mario.Row, mario.Col + 1] = '-';
                }

                return;
            }

            mario.Col++; ;

        }

        private static void MoveDown(char[,] theMaze, Mario mario)
        {
            mario.Row++;

            if (isInRange(theMaze, mario))
            {
                if (theMaze[mario.Row, mario.Col] == 'B')
                {
                    mario.LivesCount -= 2;
                    theMaze[mario.Row - 1, mario.Col] = '-';
                    theMaze[mario.Row, mario.Col] = 'M';
                    if (mario.LivesCount <= 0)
                    {
                        theMaze[mario.Row, mario.Col] = 'X';
                    }
                }
                else if (theMaze[mario.Row, mario.Col] == 'P')
                {
                    theMaze[mario.Row, mario.Col] = '-';
                    theMaze[mario.Row - 1, mario.Col] = '-';
                }
                else
                {
                    theMaze[mario.Row, mario.Col] = 'M';
                    theMaze[mario.Row - 1, mario.Col] = '-';
                }

                return;
            }

            mario.Row--;

        }

        private static void MoveUp(char[,] theMaze, Mario mario)
        {
            mario.Row--;

            if (isInRange(theMaze,mario))
            {
                if (theMaze[mario.Row ,mario.Col] == 'B')
                {
                    mario.LivesCount-=2;
                    theMaze[mario.Row + 1, mario.Col] = '-';
                    theMaze[mario.Row, mario.Col] = 'M';
                    if (mario.LivesCount <=0)
                    {
                        theMaze[mario.Row, mario.Col] = 'X';
                    }
                }
                else if (theMaze[mario.Row , mario.Col] == 'P')
                {
                    theMaze[mario.Row, mario.Col] = '-';
                    theMaze[mario.Row + 1, mario.Col] = '-';
                }
                else
                {
                    theMaze[mario.Row, mario.Col] = 'M';
                    theMaze[mario.Row + 1, mario.Col] = '-';
                }

                return;
            }

            mario.Row++;
          
        }

        private static bool isInRange(char[,] theMaze, Mario mario)
        {
            int row = mario.Row;
            int col = mario.Col;

            return row >= 0 && row < theMaze.GetLength(0) && col >= 0 && col < theMaze.GetLength(1);
        }


        public static void PrintResult(char[,] theMaze)
        {
            for (int row = 0; row < theMaze.GetLength(0); row++)
            {
                for (int col = 0; col < theMaze.GetLength(1); col++)
                {
                    Console.Write(theMaze[row, col]);
                }
                Console.WriteLine();
            }

        }

    }
}
