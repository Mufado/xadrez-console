using System;
using GameBoard;
using GameRules;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GameMatch match = new GameMatch();

                while (!match.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintGameboard(match.Board);

                        Console.WriteLine($"\nTurn {match.Turn}");
                        Console.WriteLine($"{match.TurnPlayer} pieces player turn!");

                        Console.Write("\nInform the piece atual position: ");
                        Position origin = Screen.ReadInsertedPosition().toPosition();
                        match.validOriginPosition(match.Board.PiecePlace(origin));

                        Console.Clear();
                        Screen.PrintGameboard(match.Board, match.Board.PiecePlace(origin).PossibleMoves);

                        Console.Write("\nInform the piece destination position: ");
                        Position destination = Screen.ReadInsertedPosition().toPosition();
                        match.validDestinationPosition(origin, destination);

                        match.MakeAPlay(origin, destination);
                    }
                    catch (GameBoardException e)
                    {
                        Console.WriteLine($"\n{e.Message}");
                        Console.ReadLine();
                    }
                }
            }
            catch (GameBoardException e)
            {
                Console.WriteLine($"\n{e.Message}");
            }
        }
    }
}
