using System;
using System.Collections.Generic;
using System.Linq;


namespace _02._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] chessBoard = new char[8,8];

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    chessBoard[row, col] = rowInput[col];
                }
            }

        }
    }
}
