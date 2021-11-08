using ChessGame.Game;
using ChessGame.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Cordinate cordinate, Alliance alliance) : base(cordinate, alliance)
        {
        }

        public override List<Move> LegalMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
