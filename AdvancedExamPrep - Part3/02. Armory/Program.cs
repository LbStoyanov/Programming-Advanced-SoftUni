using System;
using System.Linq;

namespace _02._Armory
{
    public  class Officer
    {
        public Officer()
        {
            Row = 0;
            Col = 0;
            Coins = 0;
        }
        public int Row { get; set; }
        public int Col { get; set; }
        public int Coins { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int armorySize = int.Parse(Console.ReadLine());

            char[,] armory = new char[armorySize,armorySize];

            Officer officer = new Officer();

            

            for (int row = 0; row < armory.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().Replace(" ","").ToCharArray();
                for (int col = 0; col < rowInput.Length; col++)
                {
                    armory[row, col] = rowInput[col];

                    if (armory[row, col] == 'A')
                    {
                        officer.Row = row;
                        officer.Col = col;
                    }
                }
            }

            string direction = Console.ReadLine();

            while (true)
            {
                if (!isInArmory(armory, officer,direction))
                {
                    armory[officer.Row,officer.Col] = '-';
                    Console.WriteLine("I do not need more swords!");
                    break;
                }
                 
                Move(armory, officer, direction);

                if (officer.Coins >= 65)
                {
                    break;
                }

                direction = Console.ReadLine();
            }

            if (officer.Coins >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {officer.Coins} gold coins.");

            PrintResult(armory);
        }

        private static void PrintResult(char[,] armory)
        {
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    Console.Write(armory[row,col]);
                }
                Console.WriteLine();
            }

        }

        public static  void Move(char[,] armory, Officer officer,string direction)
        {
            var currentRow = officer.Row;
            var currentCol = officer.Col;

            if (direction == "up")
            {
                currentRow--;
            }
            if (direction == "down")
            {
                currentRow++;
            }
            if (direction == "left")
            {
                currentCol--;
            }
            if (direction == "right")
            {
                currentCol++;
            }
            armory[officer.Row, officer.Col] = '-';

            if (armory[currentRow,currentCol] == '-')
            {
                armory[currentRow, currentCol] = 'A';
            }
            if (char.IsDigit(armory[currentRow,currentCol]))
            {
                var armorPrice = Convert.ToInt32(armory[currentRow, currentCol] - 48);
                armory[currentRow, currentCol] = 'A';
                officer.Coins += armorPrice;
            }
            if (armory[currentRow, currentCol] == 'M')
            {
                armory[currentRow, currentCol] = '-';
                FindSecondMirror(armory,officer);
                return;
            }

            officer.Row = currentRow;
            officer.Col = currentCol;
        }

        private static void FindSecondMirror(char[,] armory,Officer officer)
        {
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    if (armory[row,col] == 'M')
                    {
                        armory[row, col] = 'A';
                        officer.Row = row;
                        officer.Col = col;
                        return;
                    }
                }
            }
        }

        private static bool isInArmory(char[,] armory, Officer officer, string direction)
        {
            var row = officer.Row;
            var col = officer.Col;
            if (direction == "up")
            {
                row = officer.Row - 1;
            }
            if (direction == "down")
            {
                row = officer.Row + 1;
            }
            if (direction == "left")
            {
                col = officer.Col - 1;
            }
            if (direction == "right")
            {
                col = officer.Col + 1;
            }

            return row >= 0 && row < armory.GetLength(0) && col >= 0 && col < armory.GetLength(1);
        }

    }
}
