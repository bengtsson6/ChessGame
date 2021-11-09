using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.GameBoard;
using ChessGame.Game;

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

        public abstract List<Move> LegalMoves(Board board);
       
        public Cordinate Cordinate { get => cordinate; set => cordinate = value; }
        public Alliance Alliance { get => alliance; set => alliance = value; }
        public PieceType PieceType { get => pieceType; set => pieceType = value; }
    }
}
