using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.GameBoard;
using ChessGame.Pieces;

namespace ChessGame.Game
{
    public abstract class Move
    {
        private Piece movingPiece;
        private Cordinate destinationCordinate;

        public Move(Piece movingPiece, Cordinate destination)
        {
            this.movingPiece = movingPiece;
            this.destinationCordinate = destination;
        }
        
        public Cordinate DestinationCordinate { get => destinationCordinate; set => destinationCordinate = value; }
        public Piece MovingPiece { get => movingPiece; set => movingPiece = value; }
    }
}
