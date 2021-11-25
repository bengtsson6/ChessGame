using ChessGame.GameBoard;
using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Moves
{
    public abstract class CastleMove : Move
    {
        private Piece castleRock;
        private Cordinate castleRockDestinationCordinate;
        public CastleMove(Piece movingPiece, Cordinate destination, Board board, 
                          Piece castleRock, Cordinate castleRockDestinationCordinte) : 
                          base(movingPiece, destination, board)
        {
            CastleRock = castleRock;
            CastleRockDestinationCordinate = castleRockDestinationCordinte;
        }

        public Piece CastleRock { get => castleRock; set => castleRock = value; }
        public Cordinate CastleRockDestinationCordinate { get => castleRockDestinationCordinate; set => castleRockDestinationCordinate = value; }

        public override Board Execute()
        {
            Builder builder = new Builder();
            foreach (Piece piece in Board.CurrentPlayer.ActivePieces)
            {
                if (!piece.Equals(MovingPiece) && !piece.Equals(CastleRock))
                {
                    builder.SetPiece(piece);
                }
            }
            foreach (Piece piece in Board.CurrentPlayer.GetOpponent().ActivePieces)
            {
                if (!piece.Equals(MovingPiece) && !piece.Equals(CastleRock))
                {
                    builder.SetPiece(piece);
                }
            }
            builder.SetNextMoveMaker(Board.CurrentPlayer.GetOpponent().Alliance);
            builder.SetPiece(MovingPiece.MovePiece(this));
            builder.SetPiece(new Rock(CastleRockDestinationCordinate, CastleRock.Alliance, false));
            return builder.Build();
        }

        public override bool IsCastleMove()
        {
            return true;
        }
    }
}
