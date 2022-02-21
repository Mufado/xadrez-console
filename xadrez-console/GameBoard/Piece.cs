namespace GameBoard
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QuantityOfMovesMade { get; protected set; }
        public Gameboard Board { get; protected set; }
        public bool[,] PossibleMoves { get; private set; }

        public Piece(Color color, Gameboard board)
        {
            Position = null;
            Color = color;
            Board = board;
            PossibleMoves = null;
        }

        public void IncrementMovesQuantity()
        {
            QuantityOfMovesMade++;
        }

        protected bool canMoveToPosition(Position position)
        {
            Piece piece = Board.PiecePlace(position);
            return piece == null || piece.Color != Color;
        }

        public bool canMoveToPositionWithRules(Position position)
        {
            return PossibleMoves[position.Line, position.Column];
        }

        public bool canMakeAMove()
        {
            for (int line = 0; line < Board.Lines; line++)
            {
                for (int column = 0; column < Board.Columns; column++)
                {
                    if (PossibleMoves[line, column])
                        return true;
                }
            }
            return false;
        }

        public void UpdatePossibleMoves()
        {
            PossibleMoves = GetPossibleMoves();
        }

        public abstract bool[,] GetPossibleMoves();
    }
}
