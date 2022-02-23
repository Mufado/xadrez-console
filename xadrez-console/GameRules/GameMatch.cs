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
        public bool Checked { get; private set; }
        private HashSet<Piece> PiecesSet { get; set; }
        public HashSet<Piece> CollectedWhitePiecesSet { get; private set; }
        public HashSet<Piece> CollectedBlackPiecesSet { get; private set; }

        public GameMatch()
        {
            Board = new Gameboard(8, 8);
            Turn = 1;
            TurnPlayer = Color.White;
            Finished = false;
            Checked = false;
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

            UpdatePiecesPossibleMoves();
        }

        public Piece MakeAMove(Position origin, Position destination)
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
            UpdatePiecesPossibleMoves();
            return destinationPiece;
        }

        public void MakeAPlay(Position origin, Position destination)
        {
            Piece collectedPiece = MakeAMove(origin, destination);

            if (isCheckmate(TurnPlayer))
            {
                RollbackPlay(origin, destination, collectedPiece);
                throw new GameBoardException("You cannot put yourself in check!");
            }
            if (isCheckmate(GetEnemyColor(TurnPlayer)))
                Checked = true;
            else
                Checked = false;

            Turn++;
            ChangeTurnPlayer();
        }

        private void RollbackPlay(Position origin, Position destination, Piece collectedPiece)
        {
            Piece initialPiece = Board.RemovePieceFromPosition(destination);
            Board.PlacePieceInPosition(initialPiece, origin);
            if (collectedPiece != null)
            {
                Board.PlacePieceInPosition(collectedPiece, destination);
                if (collectedPiece.Color == Color.White)
                    CollectedWhitePiecesSet.Remove(collectedPiece);
                else
                    CollectedBlackPiecesSet.Remove(collectedPiece);
            }
            initialPiece.DecrementMovesQuantity();
            UpdatePiecesPossibleMoves();
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

        private Color GetEnemyColor(Color player)
        {
            if (player == Color.White)
                return Color.Black;
            else
                return Color.White;
        }

        private Piece GetKingPiece(Color playerColor)
        {
            foreach (var piece in PiecesSet)
            {
                if (piece.Color == playerColor && piece is King)
                    return piece;
            }

            throw new GameBoardException($"There is an king missing in {playerColor} pieces!");
        }

        private bool isCheckmate(Color player)
        {
            Piece king = GetKingPiece(player);
            Color enemy = GetEnemyColor(player);
            foreach (var piece in PiecesSet)
            {
                if (piece.Color == enemy && piece.PossibleMoves[king.Position.Line, king.Position.Column] == true)
                    return true;
            }
            return false;
        }

        public void ValidOriginPosition(Piece piece)
        {
            if (piece == null)
            {
                throw new GameBoardException("There are no pieces in origin position!");
            }
            if (piece.Color != TurnPlayer)
            {
                throw new GameBoardException("This piece is not yours!");
            }
            if (!piece.canMakeAMove())
            {
                throw new GameBoardException("This piece cannot move!");
            }
        }

        public void ValidDestinationPosition(Position origin, Position destination)
        {
            if (!Board.PiecePlace(origin).canMoveToPositionWithRules(destination))
            {
                throw new GameBoardException("This piece cannot move to this position!");
            }
        }

        private void UpdatePiecesPossibleMoves()
        {
            foreach (var piece in PiecesSet)
            {
                piece.UpdatePossibleMoves();
            }
        }
    }
}
