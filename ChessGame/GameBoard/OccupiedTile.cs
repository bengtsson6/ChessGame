using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Pieces;

namespace ChessGame.GameBoard
{
    public class OccupiedTile : Tile
    {
        private Piece piece;

        public OccupiedTile(Cordinate cordinate, Piece piece) : base(cordinate)
        {
            this.Piece = piece;
        }

        public Piece Piece { get => piece; set => piece = value; }

        public override Piece GetPiece()
        {
            return piece;
        }

        public override bool IsTileOccupied()
        {
            return true;
        }
    }
}
