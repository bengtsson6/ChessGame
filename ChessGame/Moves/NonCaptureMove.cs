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
    }
}
