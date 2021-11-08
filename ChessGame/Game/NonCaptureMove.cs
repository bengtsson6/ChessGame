using ChessGame.GameBoard;
using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Game
{
    public class NonCaptureMove : Move
    {
        public NonCaptureMove(Piece movingPiece, Cordinate destination) : base(movingPiece, destination)
        {
        }
    }
}
