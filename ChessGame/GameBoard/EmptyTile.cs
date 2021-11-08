using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessGame.GameBoard
{
    public class EmptyTile : Tile
    {

        public EmptyTile(Cordinate cordinate) : base(cordinate)
        {    
            
        }

        public override Piece GetPiece()
        {
            return null;
        }

        public override bool IsTileOccupied()
        {
            return false;
        }
    }
}
