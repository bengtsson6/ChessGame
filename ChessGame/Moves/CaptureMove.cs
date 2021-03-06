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

        //Excluding the captured piece when creating the new board
        public override Board Execute()
        {
            Builder builder = new Builder();
            foreach (Piece piece in Board.CurrentPlayer.ActivePieces)
            {
                if (!piece.Equals(MovingPiece) && !piece.Equals(AttackedPiece))
                {
                    builder.SetPiece(piece);
                }
            }
            foreach (Piece piece in Board.CurrentPlayer.GetOpponent().ActivePieces)
            {
                if (!piece.Equals(MovingPiece) && !piece.Equals(AttackedPiece))
                {
                    builder.SetPiece(piece);
                }
            }

            builder.SetPiece(MovingPiece.MovePiece(this));
            builder.SetNextMoveMaker(Board.CurrentPlayer.GetOpponent().Alliance);

            return builder.Build();
        }
    }
}
