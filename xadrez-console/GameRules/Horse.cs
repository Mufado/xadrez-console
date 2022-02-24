using GameBoard;

namespace GameRules
{
    class Horse : Piece
    {
        public Horse(Color color, Gameboard board) : base(color, board)
        {
        }

        public override bool[,] GetPossibleMoves()
        {
            bool[,] movesMatrix = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);

            #region Upper right
            position.SetPosition(Position.Line - 2, Position.Column + 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            #region Right up
            position.SetPosition(Position.Line - 1, Position.Column + 2);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            #region Right down
            position.SetPosition(Position.Line + 1, Position.Column + 2);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            #region Lower right
            position.SetPosition(Position.Line + 2, Position.Column + 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            #region Lower left
            position.SetPosition(Position.Line + 2, Position.Column - 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            #region Left down
            position.SetPosition(Position.Line + 1, Position.Column - 2);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            #region Left up
            position.SetPosition(Position.Line - 1, Position.Column - 2);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            #region Upper left
            position.SetPosition(Position.Line - 2, Position.Column - 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }
            #endregion

            return movesMatrix;
        }

        public override string ToString() => "H";
    }
}
