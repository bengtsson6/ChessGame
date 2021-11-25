using ChessGame.GameBoard;
using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Moves
{
    //Class is needed to set jumpedPawn as possible enpassantcapturemove
    public class PawnJumpMove : Move
    {
        public PawnJumpMove(Piece movingPiece, Cordinate destination, Board board) : base(movingPiece, destination, board)
        {
        }

        public override Board Execute()
        {
            Builder builder = new Builder();
            foreach (Piece piece in Board.CurrentPlayer.ActivePieces)
            {
                if (!piece.Equals(MovingPiece))
                {
                    builder.SetPiece(piece);
                }
            }
            foreach (Piece piece in Board.CurrentPlayer.GetOpponent().ActivePieces)
            {
                if (!piece.Equals(MovingPiece))
                {
                    builder.SetPiece(piece);
                }
            }
            Piece movedPiece = MovingPiece.MovePiece(this);
            builder.SetPiece(movedPiece);
            builder.SetNextMoveMaker(Board.CurrentPlayer.GetOpponent().Alliance);
            builder.EnPassantPawn = movedPiece;
            return builder.Build();
        }
    }
}
