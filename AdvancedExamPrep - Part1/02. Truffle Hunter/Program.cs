using System;
using System.Linq;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int forestSize = int.Parse(Console.ReadLine());

            string[,] forest = new string[forestSize,forestSize];

            for (int row = 0; row < forest.GetLength(0); row++)
            {
                string[] rowInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < rowInput.Length; col++)
                {
                    forest[row, col] = rowInput[col];
                }
            }

            int blackTruffles = 0;
            int summerTruffles = 0;
            int whiteTruffles = 0;

            string commands;

            while ((commands = Console.ReadLine()) != "Stop the hunt")
            {
                string[] actions = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string mainAction = actions[0];

                if (mainAction == "Collect")
                {
                    int row = int.Parse(actions[1]);
                    int col = int.Parse(actions[2]);

                    Collect(forest,row,col);
                }
                else if (mainAction == "Wild_Boar")
                {

                }
                
            }

        }

        private static void Collect(string[,] forest,int row, int col)
        {
            
        }

        private static bool isInRange(string[,] forest, int row, int col)
        {
            return row >= 0 && row < forest.GetLength(0) && col >= 0 && col < forest.GetLength(1);
        }

    }
}
