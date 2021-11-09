using ChessGame.Game;
using ChessGame.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Pieces
{
    public class Rock : Piece
    {
        public Rock(Cordinate cordinate, Alliance alliance, PieceType pieceType) : base(cordinate, alliance, pieceType)
        {

        }
        public override List<Move> LegalMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
