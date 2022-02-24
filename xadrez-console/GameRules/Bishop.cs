using GameBoard;

namespace GameRules
{
    class Bishop : Piece
    {
        public Bishop(Color color, Gameboard board) : base(color, board)
        {
        }

        public override bool[,] GetPossibleMoves()
        {
            bool[,] movesMatrix = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);

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

        public override string ToString() => "B";
    }
}
