using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.GameBoard;
using ChessGame.Game;

namespace ChessGame.Pieces
{
    public abstract class Piece
    {
        private Cordinate cordinate;
        private Alliance alliance;

        public Piece(Cordinate cordinate, Alliance alliance)
        {
            this.cordinate = cordinate;
            this.alliance = alliance;
        }

        public abstract List<Move> LegalMoves(Board board);
       
        public Cordinate Cordinate { get => cordinate; set => cordinate = value; }
        public Alliance Alliance { get => alliance; set => alliance = value; }
    }
}
