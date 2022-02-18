using GameBoard;
using System;

namespace GameRules
{
    class GameMatch
    {
        public Gameboard Board { get; private set; }
        public int Turn { get; private set; }
        public Color TurnPlayer { get; private set; }
        public bool Finished { get; private set; }

        public GameMatch()
        {
            Board = new Gameboard(8, 8);
            Turn = 1;
            TurnPlayer = Color.White;
            Finished = false;
            InitializatePieces();
        }

        private void InitializatePieces()
        {
            Board.PlacePieceInPosition(new King(Color.White, Board), new BoardPosition('d', 1).toPosition());
            Board.PlacePieceInPosition(new Tower(Color.White, Board), new BoardPosition('c', 1).toPosition());
            Board.PlacePieceInPosition(new Tower(Color.White, Board), new BoardPosition('c', 2).toPosition());
            Board.PlacePieceInPosition(new Tower(Color.White, Board), new BoardPosition('d', 2).toPosition());
            Board.PlacePieceInPosition(new Tower(Color.White, Board), new BoardPosition('e', 2).toPosition());
            Board.PlacePieceInPosition(new Tower(Color.White, Board), new BoardPosition('e', 1).toPosition());

            Board.PlacePieceInPosition(new King(Color.Black, Board), new BoardPosition('d', 8).toPosition());
            Board.PlacePieceInPosition(new Tower(Color.Black, Board), new BoardPosition('c', 8).toPosition());
            Board.PlacePieceInPosition(new Tower(Color.Black, Board), new BoardPosition('c', 7).toPosition());
            Board.PlacePieceInPosition(new Tower(Color.Black, Board), new BoardPosition('d', 7).toPosition());
            Board.PlacePieceInPosition(new Tower(Color.Black, Board), new BoardPosition('e', 7).toPosition());
            Board.PlacePieceInPosition(new Tower(Color.Black, Board), new BoardPosition('e', 8).toPosition());
        }

        public void MakeAMove(Position origin, Position destination)
        {
            Piece originPiece = Board.RemovePieceFromPosition(origin);
            originPiece.IncrementMovesQuantity();
            Piece destinationPiece = Board.RemovePieceFromPosition(destination);
            Board.PlacePieceInPosition(originPiece, destination);
        }

        public void MakeAPlay(Position origin, Position destination)
        {
            MakeAMove(origin, destination);
            Turn++;
            ChangeTurnPlayer();
        }

        private void ChangeTurnPlayer()
        {
            if (TurnPlayer == Color.White)
                TurnPlayer = Color.Black;
            else
                TurnPlayer = Color.White;
        }
    }
}
