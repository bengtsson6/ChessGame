using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Pieces;

namespace ChessGame.GameBoard
{
    public class Builder
    {
        private Dictionary<Cordinate, Piece> boardConfig;
        private Alliance nextMoveMaker;
        private Piece enPassantPawn;

        public Builder()
        {
            this.boardConfig = new Dictionary<Cordinate, Piece>();
        }

        public Builder SetPiece(Piece piece)
        {
            this.boardConfig[piece.Cordinate] = piece;
            return this;
        }

        public Builder SetNextMoveMaker(Alliance alliance)
        {
            this.NextMoveMaker = alliance;
            return this;
        }

        public Board Build()
        {
            return new Board(this);
        }


        public Dictionary<Cordinate, Piece> BoardConfig { get => boardConfig; set => boardConfig = value; }
        public Alliance NextMoveMaker { get => nextMoveMaker; set => nextMoveMaker = value; }
        public Piece EnPassantPawn { get => enPassantPawn; set => enPassantPawn = value; }
    }
}
