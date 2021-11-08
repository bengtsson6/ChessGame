using ChessGame.Game;
using ChessGame.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Pieces
{
    public class King : Piece
    {
        public King(Cordinate cordinate, Alliance alliance) : base(cordinate, alliance)
        {

        }
        public override List<Move> LegalMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
