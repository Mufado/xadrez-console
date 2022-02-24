﻿using GameBoard;
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

            #region Up
            position.SetPosition(Position.Line - 1, Position.Column);
            while (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
                if (Board.PiecePlace(position) != null)
                {
                    break;
                }
                position.SetPosition(position.Line - 1, position.Column);
            }
            #endregion

            #region Right
            position.SetPosition(Position.Line, Position.Column + 1);
            while (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
                if (Board.PiecePlace(position) != null)
                {
                    break;
                }
                position.SetPosition(position.Line, position.Column + 1);
            }
            #endregion

            #region Down
            position.SetPosition(Position.Line + 1, Position.Column);
            while (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
                if (Board.PiecePlace(position) != null)
                {
                    break;
                }
                position.SetPosition(position.Line + 1, position.Column);
            }
            #endregion

            #region Left
            position.SetPosition(Position.Line, Position.Column - 1);
            while (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
                if (Board.PiecePlace(position) != null)
                {
                    break;
                }
                position.SetPosition(position.Line, position.Column - 1);
            }
            #endregion

            return movesMatrix;
        }

        public override string ToString() => "T";
    }
}
