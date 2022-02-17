using System;

namespace GameBoard
{
    class GameBoardException : Exception
    {
        public GameBoardException(string message) : base(message)
        {
        }
    }
}
