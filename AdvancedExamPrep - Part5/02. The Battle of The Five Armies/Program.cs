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

            char[,] middleWorldMap = new char[numberOfRows,numberOfRows];

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

               

                MoveArmy(middleWorldMap, army, direction);

            }
            
        }

        public static void MoveArmy(char[,] middleWorldMap, Army army,string direction)
        {
            if (direction == "up")
            {
                army.Row--;

                ApplyMove(middleWorldMap,army);
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

        private static void ApplyMove(char[,] middleWorldMap, Army army)
        {
            if (middleWorldMap[army.Row, army.Col] == 'O')
            {

            }
            else if (middleWorldMap[army.Row, army.Col] == 'M')
            {

            }
            else
            {

            }
        }

        private static bool isInRange(char[,] middleWorldMap, int row, int col)
        {
            return row >= 0 && row < middleWorldMap.GetLength(0) && col >= 0 && col < middleWorldMap.GetLength(1);
        }
    }
}