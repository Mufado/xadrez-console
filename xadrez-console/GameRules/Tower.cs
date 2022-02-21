using GameBoard;
using System;

namespace GameRules
{
    class Tower : Piece
    {
        public Tower(Color color, Gameboard board) : base(color, board)
        {
        }

        public override bool[,] GetPossibleMoves()
        {
            bool[,] movesMatrix = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);

            // Up
            position.SetPosition(Position.Line - 1, Position.Column);
            while (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
                if (Board.PiecePlace(position) != null)
                {
                    break;
                }
                position.Line -= 1;
            }

            // Right
            position.SetPosition(Position.Line, Position.Column + 1);
            while (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
                if (Board.PiecePlace(position) != null)
                {
                    break;
                }
                position.Column += 1;
            }

            // Down
            position.SetPosition(Position.Line + 1, Position.Column);
            while (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
                if (Board.PiecePlace(position) != null)
                {
                    break;
                }
                position.Line += 1;
            }

            // Left
            position.SetPosition(Position.Line, Position.Column - 1);
            while (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
                if (Board.PiecePlace(position) != null)
                {
                    break;
                }
                position.Column -= 1;
            }

            return movesMatrix;
        }

        public override string ToString() { return "T"; }
    }
}
