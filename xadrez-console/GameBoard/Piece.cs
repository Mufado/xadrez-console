﻿namespace GameBoard
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QuantityOfMovesMade { get; protected set; }
        public Gameboard Board { get; protected set; }

        public Piece(Color color, Gameboard board)
        {
            Position = null;
            Color = color;
            Board = board;
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

        public abstract bool[,] PossibleMoves();
    }
}
