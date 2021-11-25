using ChessGame.GameBoard;
using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Moves
{
    public class QueenSideCastleMove : CastleMove
    {

        public QueenSideCastleMove(Piece movingKing, Cordinate destination, Board board,
                                  Piece queenSideRock, Cordinate queenSideRockDestinationTile) :
                                  base(movingKing, destination, board, queenSideRock, queenSideRockDestinationTile)
        {
        }
        public override string ToString()
        {
            return "0-0-0";
        }
    }
}
