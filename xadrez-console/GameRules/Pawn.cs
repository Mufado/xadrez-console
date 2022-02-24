using GameBoard;

namespace GameRules
{
    class Pawn : Piece
    {
        public Pawn(Color color, Gameboard board) : base(color, board)
        {
        }

        public override bool[,] GetPossibleMoves()
        {
            bool[,] movesMatrix = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                #region One ahead
                position.SetPosition(Position.Line - 1, Position.Column);
                if (Board.isValidPosition(position) && Board.PiecePlace(position) == null)
                {
                    movesMatrix[position.Line, position.Column] = true;
                }
                #endregion

                #region Two ahead
                position.SetPosition(Position.Line - 2, Position.Column);
                if (Board.isValidPosition(position) && Board.PiecePlace(position) == null && QuantityOfMovesMade == 0)
                {
                    movesMatrix[position.Line, position.Column] = true;
                }
                #endregion

                #region Left diagonal
                position.SetPosition(Position.Line - 1, Position.Column - 1);
                if (Board.isValidPosition(position) && canMoveToPosition(position) && Board.PiecePlace(position) != null)
                {
                    movesMatrix[position.Line, position.Column] = true;
                }
                #endregion

                #region Right diagonal
                position.SetPosition(Position.Line - 1, Position.Column + 1);
                if (Board.isValidPosition(position) && canMoveToPosition(position) && Board.PiecePlace(position) != null)
                {
                    movesMatrix[position.Line, position.Column] = true;
                }
                #endregion
            }
            else
            {
                #region One ahead
                position.SetPosition(Position.Line + 1, Position.Column);
                if (Board.isValidPosition(position) && Board.PiecePlace(position) == null)
                {
                    movesMatrix[position.Line, position.Column] = true;
                }
                #endregion

                #region Two ahead
                position.SetPosition(Position.Line + 2, Position.Column);
                if (Board.isValidPosition(position) && Board.PiecePlace(position) == null && QuantityOfMovesMade == 0)
                {
                    movesMatrix[position.Line, position.Column] = true;
                }
                #endregion

                #region Left diagonal
                position.SetPosition(Position.Line + 1, Position.Column - 1);
                if (Board.isValidPosition(position) && canMoveToPosition(position) && Board.PiecePlace(position) != null)
                {
                    movesMatrix[position.Line, position.Column] = true;
                }
                #endregion

                #region Right diagonal
                position.SetPosition(Position.Line + 1, Position.Column + 1);
                if (Board.isValidPosition(position) && canMoveToPosition(position) && Board.PiecePlace(position) != null)
                {
                    movesMatrix[position.Line, position.Column] = true;
                }
                #endregion
            }

            return movesMatrix;
        }

        public override string ToString() => "P";
    }
}
