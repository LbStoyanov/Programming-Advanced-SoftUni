using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Beaver_at_Work
{
    public class Beaver
    {
        public Beaver()
        {
            RowPosition = 0;
            ColPosition = 0;
            CollectedWoods = new Stack<string>();
            TotalCountOfBranches = 0;
        }
        public int RowPosition { get; set; }
        public int ColPosition { get; set; }
        public Stack<string> CollectedWoods { get; set; }
        public int TotalCountOfBranches { get; set; }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            int pondSize = int.Parse(Console.ReadLine());
            if (pondSize < 1)
            {
                return;
            }

            string[,] pond = new string[pondSize, pondSize];

            Beaver beaver = new Beaver();

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                string[] rowInput = Console.ReadLine().Split(" ");

                for (int col = 0; col < rowInput.Length; col++)
                {
                    pond[row, col] = rowInput[col];
                    if (pond[row, col] == "B")
                    {
                        beaver.RowPosition = row;
                        beaver.ColPosition = col;
                    }

                    if (pond[row, col] != "B" && pond[row, col] != "-" && pond[row, col] != "F")
                    {
                        beaver.TotalCountOfBranches++;
                    }
                }
            }

            string directionToMoveTheBeaver;

            while ((directionToMoveTheBeaver = Console.ReadLine()) != "end" || beaver.TotalCountOfBranches == 0)
            {
                if (directionToMoveTheBeaver == "up")
                {
                    MoveTheBeaverUp(pond, beaver);
                }
                if (directionToMoveTheBeaver == "down")
                {
                    MoveTheBeaverDown(pond, beaver);
                }
                if (directionToMoveTheBeaver == "left")
                {
                    MoveTheBeaverLeft(pond, beaver);
                }
                if (directionToMoveTheBeaver == "right")
                {
                    MoveTheBeaverRight(pond, beaver);
                }

            }

            if (beaver.TotalCountOfBranches == 0)
            {
                Console.Write($"The Beaver successfully collect {beaver.CollectedWoods.Count} wood branches: ");

                while (beaver.CollectedWoods.Count > 0)
                {
                    Console.Write($"{beaver.CollectedWoods.Pop()}, ");
                }
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {beaver.TotalCountOfBranches} branches left.");
            }

            PrintThePondState(pond);

        }

        private static void PrintThePondState(string[,] pond)
        {
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    Console.Write(pond[row,col] + " ");
                }
                Console.WriteLine();
            }

        }

        static void MoveTheBeaverRight(string[,] pond, Beaver beaver)
        {
            if (!isInPond(pond, beaver.RowPosition, beaver.ColPosition + 1))
            {
                if (beaver.CollectedWoods.Count > 0)
                {
                    beaver.CollectedWoods.Pop();
                }

                return;
            }
            else
            {
                if (pond[beaver.RowPosition, beaver.ColPosition + 1] == "-")
                {
                    pond[beaver.RowPosition, beaver.ColPosition] = "-";
                    pond[beaver.RowPosition, beaver.ColPosition + 1] = "B";
                    beaver.ColPosition++;
                }
                else if (pond[beaver.RowPosition, beaver.ColPosition + 1] == "F")
                {
                    if (beaver.ColPosition + 1 < pond.GetLength(0) - 1)
                    {
                        pond[beaver.RowPosition, beaver.ColPosition] = "-";
                        pond[beaver.RowPosition, beaver.ColPosition + 1] = "-";
                        beaver.ColPosition = pond.GetLength(1) - 1;
                        pond[beaver.RowPosition, beaver.ColPosition] = "B";
                    }
                    else
                    {
                        pond[beaver.RowPosition, beaver.ColPosition] = "-";
                        pond[beaver.RowPosition, beaver.ColPosition + 1] = "-";
                        beaver.ColPosition = 0;
                        if (pond[beaver.RowPosition, beaver.ColPosition] != "-")
                        {
                            string currentWood = pond[beaver.RowPosition, beaver.ColPosition];

                            beaver.CollectedWoods.Push(currentWood);
                            beaver.TotalCountOfBranches--;
                        }
                        pond[beaver.RowPosition, beaver.ColPosition] = "B";
                    }
                }
                else
                {
                    string currentWood = pond[beaver.RowPosition, beaver.ColPosition + 1];
                    beaver.CollectedWoods.Push(currentWood);
                    beaver.TotalCountOfBranches--;
                    pond[beaver.RowPosition, beaver.ColPosition] = "-";
                    pond[beaver.RowPosition, beaver.ColPosition + 1] = "B";
                    beaver.ColPosition++;
                }
            }
        }
        static void MoveTheBeaverLeft(string[,] pond, Beaver beaver)
        {
            if (!isInPond(pond, beaver.RowPosition, beaver.ColPosition - 1))
            {
                if (beaver.CollectedWoods.Count > 0)
                {
                    beaver.CollectedWoods.Pop();
                }

                return;
            }
            else
            {
                if (pond[beaver.RowPosition, beaver.ColPosition - 1] == "-")
                {
                    pond[beaver.RowPosition, beaver.ColPosition] = "-";
                    pond[beaver.RowPosition, beaver.ColPosition - 1] = "B";
                    beaver.ColPosition--;
                }
                else if (pond[beaver.RowPosition, beaver.ColPosition - 1] == "F")
                {
                    if (beaver.ColPosition - 1 > 0)
                    {
                        pond[beaver.RowPosition, beaver.ColPosition] = "-";
                        pond[beaver.RowPosition, beaver.ColPosition - 1] = "-";
                        beaver.ColPosition = 0;
                        pond[beaver.RowPosition, beaver.ColPosition] = "B";
                    }
                    else
                    {
                        pond[beaver.RowPosition, beaver.ColPosition] = "-";
                        pond[beaver.RowPosition, beaver.ColPosition - 1] = "-";
                        beaver.ColPosition = pond.GetLength(1) - 1;
                        if (pond[beaver.RowPosition, beaver.ColPosition] != "-")
                        {
                            string currentWood = pond[beaver.RowPosition, beaver.ColPosition];

                            beaver.CollectedWoods.Push(currentWood);
                            beaver.TotalCountOfBranches--;
                        }
                        pond[beaver.RowPosition, beaver.ColPosition] = "B";
                    }
                }
                else
                {
                    string currentWood = pond[beaver.RowPosition, beaver.ColPosition - 1];
                    beaver.CollectedWoods.Push(currentWood);
                    beaver.TotalCountOfBranches--;
                    pond[beaver.RowPosition, beaver.ColPosition] = "-";
                    pond[beaver.RowPosition, beaver.ColPosition - 1] = "B";
                    beaver.ColPosition--;
                }
            }
        }
        static void MoveTheBeaverDown(string[,] pond, Beaver beaver)
        {
            if (!isInPond(pond, beaver.RowPosition + 1, beaver.ColPosition))
            {
                if (beaver.CollectedWoods.Count > 0)
                {
                    beaver.CollectedWoods.Pop();
                }

                return;
            }
            else
            {
                if (pond[beaver.RowPosition + 1, beaver.ColPosition] == "-")
                {
                    pond[beaver.RowPosition, beaver.ColPosition] = "-";
                    pond[beaver.RowPosition + 1, beaver.ColPosition] = "B";
                    beaver.RowPosition++;
                }
                else if (pond[beaver.RowPosition + 1, beaver.ColPosition] == "F")
                {
                    if (beaver.RowPosition + 2 > pond.GetLength(0) - 1)
                    {
                        pond[beaver.RowPosition, beaver.ColPosition] = "-";
                        pond[beaver.RowPosition + 1, beaver.ColPosition] = "-";
                        beaver.RowPosition = 0;
                        pond[beaver.RowPosition, beaver.ColPosition] = "B";
                    }
                    else
                    {
                        pond[beaver.RowPosition, beaver.ColPosition] = "-";
                        pond[beaver.RowPosition + 1, beaver.ColPosition] = "-";
                        beaver.RowPosition = pond.GetLength(0) - 1;
                        if (pond[beaver.RowPosition, beaver.ColPosition] != "-")
                        {
                            string currentWood = pond[beaver.RowPosition, beaver.ColPosition];

                            beaver.CollectedWoods.Push(currentWood);
                            beaver.TotalCountOfBranches--;
                        }
                        pond[beaver.RowPosition, beaver.ColPosition] = "B";
                    }
                }
                else
                {
                    string currentWood = pond[beaver.RowPosition + 1, beaver.ColPosition];
                    beaver.CollectedWoods.Push(currentWood);
                    beaver.TotalCountOfBranches--;
                    pond[beaver.RowPosition, beaver.ColPosition] = "-";
                    pond[beaver.RowPosition + 1, beaver.ColPosition] = "B";
                    beaver.RowPosition++;
                }
            }
        }
        static void MoveTheBeaverUp(string[,] pond, Beaver beaver)
        {
            if (!isInPond(pond, beaver.RowPosition - 1, beaver.ColPosition))
            {
                if (beaver.CollectedWoods.Count > 0)
                {
                    beaver.CollectedWoods.Pop();
                }

                return;
            }
            else
            {
                if (pond[beaver.RowPosition - 1, beaver.ColPosition] == "-")
                {
                    pond[beaver.RowPosition, beaver.ColPosition] = "-";
                    pond[beaver.RowPosition - 1, beaver.ColPosition] = "B";
                    beaver.RowPosition--;
                }
                else if (pond[beaver.RowPosition - 1, beaver.ColPosition] == "F")
                {
                    if (beaver.RowPosition - 2 > 0)
                    {
                        pond[beaver.RowPosition, beaver.ColPosition] = "-";
                        pond[beaver.RowPosition - 1, beaver.ColPosition] = "-";
                        beaver.RowPosition = 0;
                        pond[beaver.RowPosition, beaver.ColPosition] = "B";
                    }
                    else
                    {
                        pond[beaver.RowPosition, beaver.ColPosition] = "-";
                        pond[beaver.RowPosition - 1, beaver.ColPosition] = "-";
                        beaver.RowPosition = pond.GetLength(0) - 1;
                        if (pond[beaver.RowPosition, beaver.ColPosition] != "-")
                        {
                            string currentWood = pond[beaver.RowPosition, beaver.ColPosition];

                            beaver.CollectedWoods.Push(currentWood);
                            beaver.TotalCountOfBranches--;
                        }
                        pond[beaver.RowPosition, beaver.ColPosition] = "B";
                    }
                }
                else
                {
                    string currentWood = pond[beaver.RowPosition - 1, beaver.ColPosition];
                    beaver.CollectedWoods.Push(currentWood);
                    beaver.TotalCountOfBranches--;
                    pond[beaver.RowPosition, beaver.ColPosition] = "-";
                    pond[beaver.RowPosition - 1, beaver.ColPosition] = "B";
                    beaver.RowPosition--;
                }
            }
        }

        private static bool isInPond(string[,] pond, int row, int col)
        {
            return row >= 0 && row < pond.GetLength(0) && col >= 0 && col < pond.GetLength(1);
        }

    }
}
