using GameBoard;

namespace GameRules
{
    class King : Piece
    {
        public King(Color color, Gameboard board) : base(color, board)
        {
        }


        private bool canMove(Position position)
        {
            Piece piece = Board.PiecePlace(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] movesMatrix = new bool[Board.Lines, Board.Columns];

            Position position = new Position(Position.Line - 1, Position.Column);
            if (Board.isValidPosition(position) && canMove(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            position.SetPosition(Position.Line - 1, Position.Column + 1);
            if (Board.isValidPosition(position) && canMove(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            position.SetPosition(Position.Line, Position.Column + 1);
            if (Board.isValidPosition(position) && canMove(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            position.SetPosition(Position.Line + 1, Position.Column + 1);
            if (Board.isValidPosition(position) && canMove(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            position.SetPosition(Position.Line + 1, Position.Column);
            if (Board.isValidPosition(position) && canMove(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            position.SetPosition(Position.Line + 1, Position.Column - 1);
            if (Board.isValidPosition(position) && canMove(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            position.SetPosition(Position.Line, Position.Column -1);
            if (Board.isValidPosition(position) && canMove(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            position.SetPosition(Position.Line - 1, Position.Column -1);
            if (Board.isValidPosition(position) && canMove(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            return movesMatrix;
        }
        public override string ToString() { return "K"; }
    }
}
