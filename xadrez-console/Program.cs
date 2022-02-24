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

                        #region Get place of the piece that will be moved
                        Console.Write("\nInform the piece atual position: ");
                        Position origin = Screen. ReadInsertedPosition().toPosition();
                        match.ValidOriginPosition(match.Board.PiecePlace(origin));
                        #endregion

                        Screen.PrintMatch(match, match.Board.PiecePlace(origin).PossibleMoves);

                        #region Get the destination of the geted piece
                        Console.Write("\nInform the piece destination position: ");
                        Position destination = Screen.ReadInsertedPosition().toPosition();
                        match.ValidDestinationPosition(origin, destination);
                        #endregion

                        match.MakeAPlay(origin, destination);
                    }
                    catch (GameBoardException e)
                    {
                        Console.WriteLine($"\n{e.Message}");
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintMatch(match);
            }
            catch (GameBoardException e)
            {
                Console.WriteLine($"\n{e.Message}");
            }
        }
    }
}
