using System;
using System.Collections.Generic;
using System.Linq;


namespace _02._Pawn_Wars
{
    public class Pawn
    {
        public Pawn(int row, int col)
        {
            this.RowPosition = row;
            this.ColPosition = col;
        }
        public int RowPosition { get; set; }
        public int ColPosition { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', };
            char[] numbers = new char[] { '8', '7', '6', '5', '4', '3', '2', '1', };

            Pawn whitePawn = new Pawn(0, 0);
            Pawn blackPawn = new Pawn(0, 0);

            char[,] chessBoard = new char[8, 8];

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    chessBoard[row, col] = rowInput[col];

                    if (rowInput[col] == 'w')
                    {
                        whitePawn.RowPosition = row;
                        whitePawn.ColPosition = col;
                    }

                    if (rowInput[col] == 'b')
                    {
                        blackPawn.RowPosition = row;
                        blackPawn.ColPosition = col;
                    }
                }
            }

            while (true)
            {
                MoveWhitePawn(chessBoard, whitePawn);

                if (chessBoard[blackPawn.RowPosition,blackPawn.ColPosition] == 'w')
                {
                    char row = numbers[whitePawn.RowPosition];
                    char col = letters[whitePawn.ColPosition];

                    Console.WriteLine($"Game over! White capture on {col}{row}.");
                    break;
                }

                if (whitePawn.RowPosition == 0)
                {

                    char row = numbers[whitePawn.RowPosition];
                    char col = letters[whitePawn.ColPosition];

                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {col}{row}.");
                    break;
                }

                MoveBlackPawn(chessBoard, blackPawn);

                if (chessBoard[whitePawn.RowPosition, whitePawn.ColPosition] == 'b')
                {
                    char row = numbers[blackPawn.RowPosition];
                    char col = letters[blackPawn.ColPosition];

                    Console.WriteLine($"Game over! Black capture on {col}{row}.");
                    break;
                }

                if (blackPawn.RowPosition == 7)
                {
                    char row = numbers[blackPawn.RowPosition];
                    char col = letters[blackPawn.ColPosition];

                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {col}{row}.");
                    break;
                }
            }
        }
        

        public static void MoveBlackPawn(char[,] chessBoard, Pawn blackPawn)
        {
            
            int row = blackPawn.RowPosition;
            int col = blackPawn.ColPosition;

            if (isInTheChessBoard(chessBoard, row + 1, col - 1))
            {
                if (chessBoard[row + 1, col - 1] == 'w')
                {
                    chessBoard[row + 1, col - 1] = 'b';
                    chessBoard[row, col] = '-';
                    blackPawn.RowPosition = row + 1;
                    blackPawn.ColPosition = col - 1;
                    return;
                }
            }

            if (isInTheChessBoard(chessBoard, row + 1, col + 1))
            {
                if (chessBoard[row + 1, col + 1] == 'w')
                {
                    chessBoard[row + 1, col + 1] = 'b';
                    chessBoard[row, col] = '-';
                    blackPawn.RowPosition = row + 1;
                    blackPawn.ColPosition = col + 1;
                    return;
                }
            }

            if (isInTheChessBoard(chessBoard, row + 1, col))
            {
                if (chessBoard[row + 1, col] != 'w')
                {
                    chessBoard[row + 1, col] = 'b';
                    chessBoard[row, col] = '-';
                    blackPawn.RowPosition = row + 1;
                }
            }
        }

        private static void MoveWhitePawn(char[,] chessBoard, Pawn whitePawn)
        {
            int row = whitePawn.RowPosition;
            int col = whitePawn.ColPosition;

            if (isInTheChessBoard(chessBoard, row - 1, col - 1))
            {
                if (chessBoard[row - 1, col - 1] == 'b')
                {
                    chessBoard[row - 1, col - 1] = 'w';
                    chessBoard[row, col] = '-';
                    whitePawn.RowPosition = row - 1;
                    whitePawn.ColPosition = col - 1;
                    return;
                }
            }

            if (isInTheChessBoard(chessBoard, row - 1, col + 1))
            {
                if (chessBoard[row - 1, col + 1] == 'b')
                {
                    chessBoard[row - 1, col + 1] = 'w';
                    chessBoard[row, col] = '-';
                    whitePawn.RowPosition = row - 1;
                    whitePawn.ColPosition = col + 1;
                    return;
                }
            }

            if (isInTheChessBoard(chessBoard, row - 1, col))
            {
                if (chessBoard[row - 1, col] != 'b')
                {
                    chessBoard[row - 1, col] = 'w';
                    chessBoard[row, col] = '-';
                    whitePawn.RowPosition = row - 1;
                    whitePawn.ColPosition = col;
                }
            }
        }

        public static void PrintResult(char[,] chessBoard)
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    Console.Write(chessBoard[row, col]);
                }
                Console.WriteLine();
            }

        }
        private static bool isInTheChessBoard(char[,] chessBoard, int row, int col)
        {

            return row >= 0 && row < chessBoard.GetLength(0) && col >= 0 && col < chessBoard.GetLength(1);
        }

    }
}
