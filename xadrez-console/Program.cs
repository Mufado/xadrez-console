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

                    Console.Write("Inform the piece atual position: ");
                    Position origin = Screen.ReadInsertedPosition().toPosition();
                    Console.Write("Inform the piece destination position: ");
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
