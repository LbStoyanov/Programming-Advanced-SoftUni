namespace TheBattleOfFiveArmies
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int armyArmorValue = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());

            int armyRow = 0;
            int armyCol = 0;

            char[,] middleWorldMap = new char[numberOfRows,numberOfRows];

            for (int row = 0; row < middleWorldMap.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    middleWorldMap[row, col] = rowInput[col];

                    if (middleWorldMap[row, col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            Console.WriteLine();
        }

    }
}