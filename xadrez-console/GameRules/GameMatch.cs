using GameBoard;
using System.Collections.Generic;

namespace GameRules
{
    class GameMatch
    {
        public Gameboard Board { get; private set; }
        public int Turn { get; private set; }
        public Color TurnPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> PiecesSet { get; set; }
        private HashSet<Piece> CollectedWhitePiecesSet { get; set; }
        private HashSet<Piece> CollectedBlackPiecesSet { get; set; }

        public GameMatch()
        {
            Board = new Gameboard(8, 8);
            Turn = 1;
            TurnPlayer = Color.White;
            Finished = false;
            PiecesSet = new HashSet<Piece>();
            CollectedWhitePiecesSet = new HashSet<Piece>();
            CollectedBlackPiecesSet = new HashSet<Piece>();
            InitializatePieces();
        }

        private void CreatePiece(char column, int line, Piece piece)
        {
            Board.PlacePieceInPosition(piece, new BoardPosition(column, line).toPosition());
            PiecesSet.Add(piece);
        }

        private void InitializatePieces()
        {
            CreatePiece('d', 1, new King(Color.White, Board));
            CreatePiece('c', 1, new Tower(Color.White, Board));
            CreatePiece('c', 2, new Tower(Color.White, Board));
            CreatePiece('d', 2, new Tower(Color.White, Board));
            CreatePiece('e', 2, new Tower(Color.White, Board));
            CreatePiece('e', 1, new Tower(Color.White, Board));

            CreatePiece('d', 8, new King(Color.Black, Board));
            CreatePiece('c', 8, new Tower(Color.Black, Board));
            CreatePiece('c', 7, new Tower(Color.Black, Board));
            CreatePiece('d', 7, new Tower(Color.Black, Board));
            CreatePiece('e', 7, new Tower(Color.Black, Board));
            CreatePiece('e', 8, new Tower(Color.Black, Board));
        }

        public void MakeAMove(Position origin, Position destination)
        {
            Piece originPiece = Board.RemovePieceFromPosition(origin);
            originPiece.IncrementMovesQuantity();
            Piece destinationPiece = Board.RemovePieceFromPosition(destination);
            if (destinationPiece != null)
            {
                if (destinationPiece.Color == Color.White)
                    CollectedWhitePiecesSet.Add(destinationPiece);
                else
                    CollectedBlackPiecesSet.Add(destinationPiece);
                PiecesSet.Remove(destinationPiece);
            }
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

        public HashSet<Piece> GetAllCollectedPiecesSet()
        {
            HashSet<Piece> allCollectedPiecesSet = new HashSet<Piece>();
            allCollectedPiecesSet.UnionWith(CollectedBlackPiecesSet);
            allCollectedPiecesSet.UnionWith(CollectedWhitePiecesSet);
            return allCollectedPiecesSet;
        }

        public void validOriginPosition(Piece piece)
        {
            if (piece == null)
            {
                throw new GameBoardException("There are no pieces in origin position!");
            }
            if (piece.Color != TurnPlayer)
            {
                throw new GameBoardException("This piece is not yours!");
            }
            piece.UpdatePossibleMoves();
            if (!piece.canMakeAMove())
            {
                throw new GameBoardException("This piece cannot move!");
            }
        }

        public void validDestinationPosition(Position origin, Position destination)
        {
            if (!Board.PiecePlace(origin).canMoveToPositionWithRules(destination))
            {
                throw new GameBoardException("This piece cannot move to this position!");
            }
        }
    }
}
