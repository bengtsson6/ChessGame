using ChessGame.GameBoard;
using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Moves
{
    public class KingSideCastleMove : CastleMove
    {
        public KingSideCastleMove(Piece movingKing, Cordinate destination, Board board, 
                                  Piece kingSideRock, Cordinate kingSideRockDestinationTile) : 
                                  base(movingKing, destination, board, kingSideRock, kingSideRockDestinationTile)
        {

        }
        public override string ToString()
        {
            return "0-0";
        }
    }
}
