using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.GameBoard;
using ChessGame.Game;
using ChessGame.Moves;

namespace ChessGame.Pieces
{
    public abstract class Piece : IEquatable<Piece>
    {
        private Cordinate cordinate;
        private Alliance alliance;
        private PieceType pieceType;
        private bool isFirstMove;

        public Piece(Cordinate cordinate, Alliance alliance, PieceType pieceType, bool isFirstMove)
        {
            this.Cordinate = cordinate;
            this.Alliance = alliance;
            this.PieceType = pieceType;
            this.IsFirstMove = isFirstMove;
        }
        public override string ToString()
        {
            if (this.Alliance == Alliance.BLACK)
            {
                char c = (char)PieceType;
                string returnString = c.ToString().ToLower();
                return returnString;
            }
            else
            {
                char c = (char)PieceType;
                string returnString = c.ToString();
                return returnString;
            }
        }
        public abstract List<Move> LegalMoves(Board board);
        public abstract Piece MovePiece(Move move);
        public override bool Equals(object obj)
        {
            return Equals(obj as Piece);
        }
        public bool Equals(Piece other)
        {
            return other != null &&
                   Cordinate.Equals(other.Cordinate) &&
                   alliance == other.alliance &&
                   pieceType == other.pieceType;
        }
        public override int GetHashCode()
        {
            int hashCode = 1072848307;
            hashCode = hashCode * -1521134295 + EqualityComparer<Cordinate>.Default.GetHashCode(cordinate);
            hashCode = hashCode * -1521134295 + alliance.GetHashCode();
            hashCode = hashCode * -1521134295 + pieceType.GetHashCode();
            return hashCode;
        }
        public Cordinate Cordinate { get => cordinate; set => cordinate = value; }
        public Alliance Alliance { get => alliance; set => alliance = value; }
        public PieceType PieceType { get => pieceType; set => pieceType = value; }
        public bool IsFirstMove { get => isFirstMove; set => isFirstMove = value; }
    }
}
