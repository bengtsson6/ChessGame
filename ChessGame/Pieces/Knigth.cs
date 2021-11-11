using ChessGame.Game;
using ChessGame.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Utils;

namespace ChessGame.Pieces
{
    public class Knigth : Piece
    {
        public Knigth(Cordinate cordinate, Alliance alliance, PieceType pieceType) : base(cordinate, alliance, pieceType)
        {
        }

        public override List<Move> LegalMoves(Board board)
        {
            List<Move> moves = new List<Move>();
            foreach(Cordinate cordinate in CandidateDestinationCordinates())
            {
                if (BoardUtils.IsCordinateValid(cordinate))
                {
                    Tile tile = board.GetTile(cordinate);
                    if (!tile.IsTileOccupied())
                    {
                        moves.Add(new NonCaptureMove(this, cordinate, board));
                    } else
                    {
                       Piece pieceAtDestination = tile.GetPiece();
                       if(pieceAtDestination.Alliance != this.Alliance)
                        {
                            moves.Add(new CaptureMove(this, cordinate, board,tile.GetPiece()));
                        }                  
                    }
                }      
            }
            return moves;
        }


        //Lists a Knight possible movements in chess
        //This could possible be cleaned up a bit since x and y cordinates is reused in multiple "full" cordinates.
        public List<Cordinate> CandidateDestinationCordinates()
        {
            List<Cordinate> candidateCordinates = new List<Cordinate>();
            Cordinate currentCordinate = this.Cordinate;
            int x = currentCordinate.XCordinate;
            int y = currentCordinate.YCordinate;
            candidateCordinates.Add(new Cordinate(x + 2, y - 1));
            candidateCordinates.Add(new Cordinate(x + 2, y + 1));
            candidateCordinates.Add(new Cordinate(x - 2, y - 1));
            candidateCordinates.Add(new Cordinate(x - 2, y + 1));
            candidateCordinates.Add(new Cordinate(x + 1, y + 2));
            candidateCordinates.Add(new Cordinate(x - 1, y + 2));
            candidateCordinates.Add(new Cordinate(x + 1, y - 2));
            candidateCordinates.Add(new Cordinate(x - 1, y - 2));
            return candidateCordinates;
        }

        public override Piece MovePiece(Move move)
        {
            throw new NotImplementedException();
        }
    }
}
