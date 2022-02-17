using GameBoard;

namespace GameRules
{
    class GameMatch
    {
        public Gameboard Board { get; private set; }
        private int Turn { get; set; }
        private Color TurnPlayer { get; set; }
        public bool Finished { get; private set; }

        public GameMatch()
        {
            Board = new Gameboard(8, 8) ;
            Turn = 1;
            TurnPlayer = Color.White;
            Finished = false;
            InitializatePieces();
        }

        private void InitializatePieces()
        {
            Board.PlacePieceInPosition(new Tower(Color.White, Board), new BoardPosition('a', 1).toPosition());
            Board.PlacePieceInPosition(new Tower(Color.White, Board), new BoardPosition('h', 1).toPosition());

            Board.PlacePieceInPosition(new Tower(Color.Black, Board), new BoardPosition('a', 8).toPosition());
            Board.PlacePieceInPosition(new Tower(Color.Black, Board), new BoardPosition('h', 8).toPosition());
        }

        public void MakeAMove(Position origin, Position destination)
        {
            Piece originPiece = Board.RemovePieceFromPosition(origin);
            originPiece.IncrementMovesQuantity();
            Piece destinationPiece = Board.RemovePieceFromPosition(destination);
            Board.PlacePieceInPosition(originPiece, destination);
        }
    }
}
