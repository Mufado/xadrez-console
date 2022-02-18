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
                    Console.Clear();
                    Screen.PrintGameboard(match.Board);

                    Console.WriteLine($"\nTurn {match.Turn}");
                    Console.WriteLine($"{match.TurnPlayer} pieces player turn!");

                    Console.Write("\nInform the piece atual position: ");
                    Position origin = Screen.ReadInsertedPosition().toPosition();

                    Console.Clear();
                    Screen.PrintGameboard(match.Board, match.Board.PiecePlace(origin).PossibleMoves());

                    Console.Write("\nInform the piece destination position: ");
                    Position destination = Screen.ReadInsertedPosition().toPosition();
                    
                    match.MakeAMove(origin, destination);
                }
            }
            catch (GameBoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
