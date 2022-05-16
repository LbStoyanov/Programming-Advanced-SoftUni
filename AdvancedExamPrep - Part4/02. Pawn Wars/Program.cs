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
                    int coordinates = chessBoard[whitePawn.RowPosition,whitePawn.ColPosition];
                    Console.WriteLine($"Game over! white capture on {coordinates}.");
                    break;
                }

                if (whitePawn.RowPosition == 0)
                {
                    int coordinates = chessBoard[whitePawn.RowPosition, whitePawn.ColPosition];
                    Console.WriteLine($"Game over! white pawn is promoted to a queen at {coordinates}.");
                    break;
                }

                chessBoard = MoveBlackPawn(chessBoard, blackPawn);

                if (chessBoard[whitePawn.RowPosition, whitePawn.ColPosition] == 'b')
                {
                    int coordinates = chessBoard[whitePawn.RowPosition, whitePawn.ColPosition];
                    Console.WriteLine($"Game over! black capture on {coordinates}.");
                    break;
                }

                if (blackPawn.RowPosition == 7)
                {
                    int coordinates = chessBoard[whitePawn.RowPosition, whitePawn.ColPosition];
                    Console.WriteLine($"Game over! white pawn is promoted to a queen at {coordinates}.");
                    break;
                }

            }

            PrintResult(chessBoard);
        }

        public static char[,] MoveBlackPawn(char[,] chessBoard, Pawn blackPawn)
        {
            char[,] result = chessBoard;
            int row = blackPawn.RowPosition;
            int col = blackPawn.ColPosition;

            if (isInTheChessBoard(chessBoard, row + 1, col - 1))
            {
                if (chessBoard[row + 1, col - 1] == 'w')
                {
                    chessBoard[row + 1, col - 1] = 'b';
                    chessBoard[row, col] = '-';
                }
            }

            if (isInTheChessBoard(chessBoard, row + 1, col + 1))
            {
                if (chessBoard[row + 1, col + 1] == 'w')
                {
                    chessBoard[row + 1, col + 1] = 'b';
                    chessBoard[row, col] = '-';
                }
            }

            if (isInTheChessBoard(chessBoard, row + 1, col))
            {
                if (chessBoard[row + 1, col] != 'w')
                {
                    chessBoard[row + 1, col] = 'b';
                    chessBoard[row, col] = '-';
                    
                }
            }

            return result;
        }

        private static char[,] MoveWhitePawn(char[,] chessBoard, Pawn whitePawn)
        {
            int row = whitePawn.RowPosition;
            int col = whitePawn.ColPosition;

            if (isInTheChessBoard(chessBoard, row - 1, col - 1))
            {
                if (chessBoard[row - 1, col - 1] == 'b')
                {
                    chessBoard[row - 1, col - 1] = 'w';
                    chessBoard[row, col] = '-';
                }
            }

            if (isInTheChessBoard(chessBoard, row - 1, col + 1))
            {
                if (chessBoard[row - 1, col + 1] == 'b')
                {
                    chessBoard[row - 1, col + 1] = 'w';
                    chessBoard[row, col] = '-';
                }
            }

            if (isInTheChessBoard(chessBoard, row - 1, col))
            {
                if (chessBoard[row - 1, col] != 'b')
                {
                    chessBoard[row - 1, col] = 'w';
                    chessBoard[row, col] = '-';
                }
            }

            return chessBoard;
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
        private static bool IsThereAnotherPawn(char[,] chessBoard, int row, int col)
        {
            return chessBoard[row, col] != '-';
        }

        private static bool isInTheChessBoard(char[,] chessBoard, int row, int col)
        {

            return row >= 0 && row < chessBoard.GetLength(0) && col >= 0 && col < chessBoard.GetLength(1);
        }

    }
}
