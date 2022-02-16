using System;
using GameBoard;

namespace xadrez_console
{
    class Screen
    {
        public static void PrintGameboard(Gameboard board)
        {
            for (int line = 0; line < board.Lines; line++)
            {
                for (int column = 0; column < board.Columns; column++)
                {
                    if (board.PiecePlace(line, column) == null)
                        Console.Write("- ");
                    else
                        Console.Write($"{board.PiecePlace(line, column)} ");
                }
                Console.WriteLine();
            }
        }
    }
}
