using GameBoard;

namespace GameRules
{
    class King : Piece
    {
        public King(Color color, Gameboard board) : base(color, board)
        {
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] movesMatrix = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);

            // Up
            position.SetPosition(Position.Line - 1, Position.Column);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            // UpRight
            position.SetPosition(Position.Line - 1, Position.Column + 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            // Right
            position.SetPosition(Position.Line, Position.Column + 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            // DownRight
            position.SetPosition(Position.Line + 1, Position.Column + 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            // Down
            position.SetPosition(Position.Line + 1, Position.Column);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            // DownLeft
            position.SetPosition(Position.Line + 1, Position.Column - 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            // Left
            position.SetPosition(Position.Line, Position.Column - 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            // UpLeft
            position.SetPosition(Position.Line - 1, Position.Column - 1);
            if (Board.isValidPosition(position) && canMoveToPosition(position))
            {
                movesMatrix[position.Line, position.Column] = true;
            }

            return movesMatrix;
        }
        public override string ToString() { return "K"; }
    }
}
