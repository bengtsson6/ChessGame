using ChessGame.GameBoard;
using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Moves
{
    public class NonCaptureMove : Move
    {
        public NonCaptureMove(Piece movingPiece, Cordinate destination, Board board) : base(movingPiece, destination, board)
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
            foreach(Piece piece in Board.CurrentPlayer.GetOpponent().ActivePieces)
            {
                if (!piece.Equals(MovingPiece))
                {
                    builder.SetPiece(piece);
                }
            }        
            builder.SetPiece(MovingPiece.MovePiece(this));
            builder.SetNextMoveMaker(Board.CurrentPlayer.GetOpponent().Alliance);
            return new Board(builder);
        }
    }
}
