using System;
using System.Linq;

namespace _02._Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armorySize = int.Parse(Console.ReadLine());

            char[,] armory = new char[armorySize,armorySize];

            int armyOfficerRowPosition = 0;
            int armyOfficerColPosition = 0;

            int[] officerCoordinates = new int[2];

            for (int row = 0; row < armory.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().Replace(" ","").ToCharArray();
                for (int col = 0; col < rowInput.Length; col++)
                {
                    armory[row, col] = rowInput[col];

                    if (armory[row, col] == 'A')
                    {
                        armyOfficerRowPosition = row;
                        armyOfficerColPosition = col;

                        officerCoordinates[0] = row;
                        officerCoordinates[1] = col;
                    }
                }
            }

            string direction = Console.ReadLine();

            while (true)
            {
                if (direction == "up")
                {
                    Move(armory,officerCoordinates);
                }
                if (direction == "down")
                {
                    
                }
                if (direction == "left")
                {
                    
                }
                if (direction == "right")
                {
                    
                }

                direction = Console.ReadLine();
            }

        }

        public static  void Move(char[,] armory, int[] officerCoordinates)
        {

        }
    }
}
