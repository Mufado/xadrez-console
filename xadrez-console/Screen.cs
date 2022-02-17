using System;
using GameBoard;
using GameRules;

namespace xadrez_console
{
    static class Screen
    {
        public static void PrintGameboard(Gameboard board)
        {
            for (int line = 0; line < board.Lines; line++)
            {
                ConsoleColor bgcolor = Console.BackgroundColor;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{8 - line} ");
                for (int column = 0; column < board.Columns; column++)
                {
                    if (column == 0)
                    {
                        Console.BackgroundColor = bgcolor;

                        if (line == 0)
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                    }
                    else if (bgcolor == ConsoleColor.DarkGray || bgcolor == ConsoleColor.Black)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    bgcolor = Console.BackgroundColor;

                    if (board.PiecePlace(line, column) == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("  ");
                    }
                    else
                    {
                        PrintPiece(board.PiecePlace(line, column));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("  A B C D E F G H");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(piece);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(piece);
            }
        }

        public static BoardPosition ReadInsertedPosition()
        {
            string position = Console.ReadLine();
            char column = position[0];
            int line = int.Parse(position[1].ToString());
            return new BoardPosition(column, line);
        }
    }
}
