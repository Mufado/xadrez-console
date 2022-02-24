using GameBoard;

namespace GameRules
{
    class Queen : Piece
    {
        public Queen(Color color, Gameboard board) : base(color, board)
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

            #region Upper rigth diagonal
            position.SetPosition(Position.Line - 1, Position.Column + 1);
            while (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
                if (Board.PiecePlace(position) != null)
                {
                    break;
                }
                position.SetPosition(position.Line - 1, position.Column + 1);
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

            #region Lower right diagonal
            position.SetPosition(Position.Line + 1, Position.Column + 1);
            while (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
                if (Board.PiecePlace(position) != null)
                {
                    break;
                }
                position.SetPosition(position.Line + 1, position.Column + 1);
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

            #region Lower left diagonal
            position.SetPosition(Position.Line + 1, Position.Column - 1);
            while (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
                if (Board.PiecePlace(position) != null)
                {
                    break;
                }
                position.SetPosition(position.Line + 1, position.Column - 1);
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

            #region Upper left diagonal
            position.SetPosition(Position.Line - 1, Position.Column - 1);
            while (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
                if (Board.PiecePlace(position) != null)
                {
                    break;
                }
                position.SetPosition(position.Line - 1, position.Column - 1);
            }
            #endregion

            return movesMatrix;
        }

        public override string ToString() => "Q";
    }
}
