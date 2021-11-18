using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.GameBoard;
using ChessGame.Pieces;
using ChessGame.Moves;

namespace ChessGame.GameBoard
{
    public abstract class Tile
    {
        private Cordinate cordinate;

        public Tile(Cordinate cordinate)
        {
            this.cordinate = cordinate;
        }

        public static Tile CreateTile(Cordinate cordinate, Piece piece)
        {
            if (piece == null)
            {
                return new EmptyTile(cordinate);
            }
            else
            {
                return new OccupiedTile(cordinate, piece);
            }
        }
        public List<Move> AttacksOnTile(List<Move> moves)
        {
            List<Move> attackMovesOnTile = new List<Move>();
            foreach (Move move in moves) 
            {
                if (move.DestinationCordinate.Equals(this.Cordinate))
                {
                    attackMovesOnTile.Add(move);
                }
            }
            return attackMovesOnTile;
        }

        public abstract bool IsTileOccupied();

        public abstract Piece GetPiece();

        public Cordinate Cordinate { get => cordinate; set => cordinate = value; }
    }
}
