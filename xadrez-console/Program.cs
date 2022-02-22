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
                        Screen.PrintMatch(match);

                        Console.Write("\nInform the piece atual position: ");
                        Position origin = Screen. ReadInsertedPosition().toPosition();
                        match.ValidOriginPosition(match.Board.PiecePlace(origin));

                        Console.Clear();

                        Screen.PrintMatch(match, match.Board.PiecePlace(origin).PossibleMoves);

                        Console.Write("\nInform the piece destination position: ");
                        Position destination = Screen.ReadInsertedPosition().toPosition();
                        match.ValidDestinationPosition(origin, destination);

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
