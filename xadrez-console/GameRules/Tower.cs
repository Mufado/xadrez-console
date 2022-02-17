using GameBoard;
using System;

namespace GameRules
{
    class Tower : Piece
    {
        public Tower(Color color, Gameboard board) : base(color, board)
        {
        }

        public override bool[,] PossibleMoves()
        {
            throw new NotImplementedException();
        }

        public override string ToString() { return "T"; }
    }
}
