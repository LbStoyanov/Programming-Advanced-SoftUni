namespace TheBattleOfFiveArmies
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Army
    {
        public Army()
        {
            Row = 0;
            Col = 0;
            Armor = 0;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Armor { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Army army = new Army();

            int armyArmorValue = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());

            army.Armor = armyArmorValue;

            char[,] middleWorldMap = new char[numberOfRows, numberOfRows];

            for (int row = 0; row < middleWorldMap.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    middleWorldMap[row, col] = rowInput[col];

                    if (middleWorldMap[row, col] == 'A')
                    {
                        army.Row = row;
                        army.Col = col;
                    }
                }
            }


            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string direction = commands[0];

                int currentRow = int.Parse(commands[1]);
                int currentCol = int.Parse(commands[2]);

                middleWorldMap[currentRow, currentCol] = 'O';
                army.Armor--;

                if (direction == "up")
                {
                    MoveArmyUp(middleWorldMap, army, direction);
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

            }

        }

        public static void MoveArmyUp(char[,] middleWorldMap, Army army, string direction)
        {
            if (isInRange(middleWorldMap, army))
            {
                if (middleWorldMap[army.Row, army.Col] == 'O')
                {
                    army.Armor -= 2;

                    if (army.Armor <= 0)
                    {
                        middleWorldMap[army.Row, army.Col] = 'X';
                    }
                    else
                    {
                        middleWorldMap[army.Row, army.Col] = 'M';
                    }

                    middleWorldMap[army.Row + 1, army.Col] = '-';

                }
                else if (middleWorldMap[army.Row, army.Col] == 'M')
                {
                    middleWorldMap[army.Row, army.Col] = '-';
                    middleWorldMap[army.Row + 1, army.Col] = '-';
                    return;
                }
                else
                {
                    middleWorldMap[army.Row, army.Col] = 'M';
                    middleWorldMap[army.Row + 1, army.Col] = '-';
                }
            }
            else
            {
                army.Row++;
            }
        }

        private static void ApplyMove(char[,] middleWorldMap, Army army)
        {
            

        }

        private static bool isInRange(char[,] middleWorldMap, Army army)
        {
            int row = army.Row;
            int col = army.Col;

            return row >= 0 && row < middleWorldMap.GetLength(0) && col >= 0 && col < middleWorldMap.GetLength(1);
        }
    }
}