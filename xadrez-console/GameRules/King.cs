﻿using GameBoard;

namespace GameRules
{
    class King : Piece
    {
        public King(Color color, Gameboard board) : base(color, board)
        {
        }

        public override bool[,] GetPossibleMoves()
        {
            bool[,] movesMatrix = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);

            #region Up
            position.SetPosition(Position.Line - 1, Position.Column);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            #region UpRight
            position.SetPosition(Position.Line - 1, Position.Column + 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            #region Right
            position.SetPosition(Position.Line, Position.Column + 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            #region DownRight
            position.SetPosition(Position.Line + 1, Position.Column + 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            #region Down
            position.SetPosition(Position.Line + 1, Position.Column);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            #region DownLeft
            position.SetPosition(Position.Line + 1, Position.Column - 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            #region Left
            position.SetPosition(Position.Line, Position.Column - 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            #region UpLeft
            position.SetPosition(Position.Line - 1, Position.Column - 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            return movesMatrix;
        }
        public override string ToString() => "K";
    }
}
