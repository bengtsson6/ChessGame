using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.GameBoard;
using ChessGame.Pieces;

namespace ChessGame.GameBoard
{
    public abstract class Tile
    {
        private Cordinate cordinate;

        public Tile(Cordinate cordinate)
        {
            this.cordinate = cordinate;
        }

        public abstract bool IsTileOccupied();

        public abstract Piece GetPiece();

        public Cordinate Cordinate { get => cordinate; set => cordinate = value; }
    }
}
