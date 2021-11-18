using ChessGame.GameBoard;
using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Moves
{
    public class CaptureMove : Move
    {
        private Piece attackedPiece;
        public CaptureMove(Piece movingPiece, Cordinate destination, Board board ,Piece attackedPiece) : base(movingPiece, destination, board)
        {
            this.attackedPiece = attackedPiece;
        }
        public Piece AttackedPiece { get => attackedPiece; set => attackedPiece = value; }

        public override Board Execute()
        {
            throw new NotImplementedException();
        }
    }
}
