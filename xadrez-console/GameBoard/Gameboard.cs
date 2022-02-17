namespace GameBoard
{
    class Gameboard
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] _pieces;

        public Gameboard(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            _pieces = new Piece[lines, columns];
        }

        public Piece PiecePlace(int line, int column)
        {
            return _pieces[line, column];
        }

        public Piece PiecePlace(Position position)
        {
            return _pieces[position.Line, position.Column];
        }

        public void PlacePieceInPosition(Piece piece, Position position)
        {
            if(isOccupiedPosition(position))
                throw new GameBoardException("Position occupied by another piece!");

            _pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePieceFromPosition(Position position)
        {
            Piece piece = PiecePlace(position);
            if (piece != null)
            {
                piece.Position = null;
                _pieces[position.Line, position.Column] = null;
            }
            return piece;
        }

        public bool isOccupiedPosition(Position position)
        {
            ThrowExceptionIfInvalidPosition(position);
            return PiecePlace(position) != null;
        }

        public bool isValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line > Lines || position.Column < 0 || position.Column > Columns)
            {
                return false;
            }
            return true;
        }

        public void ThrowExceptionIfInvalidPosition(Position position)
        {
            if (!isValidPosition(position))
            {
                throw new GameBoardException("Invalid position!");
            }
        }
    }
}
