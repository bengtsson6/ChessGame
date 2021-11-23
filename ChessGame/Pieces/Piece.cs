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
    public abstract class Piece
    {
        private Cordinate cordinate;
        private Alliance alliance;
        private PieceType pieceType;

        public Piece(Cordinate cordinate, Alliance alliance, PieceType pieceType)
        {
            this.Cordinate = cordinate;
            this.Alliance = alliance;
            this.PieceType = pieceType;
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
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if(!(obj is Piece))
            {
                return false;
            }
            Piece otherPiece = obj as Piece;
            return Cordinate.Equals(otherPiece.Cordinate) 
                    && PieceType == otherPiece.PieceType 
                    && Alliance == otherPiece.Alliance;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public abstract List<Move> LegalMoves(Board board);
        public abstract Piece MovePiece(Move move);  
        public Cordinate Cordinate { get => cordinate; set => cordinate = value; }
        public Alliance Alliance { get => alliance; set => alliance = value; }
        public PieceType PieceType { get => pieceType; set => pieceType = value; }
    }
}
