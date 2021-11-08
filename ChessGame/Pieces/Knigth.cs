using ChessGame.Game;
using ChessGame.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Pieces
{
    public class Knigth : Piece
    {
        public Knigth(Cordinate cordinate, Alliance alliance) : base(cordinate, alliance)
        {
        }

        public override List<Move> LegalMoves(Board board)
        {
            List<Move> moves = new List<Move>();

            foreach(Cordinate cordinate in CandidateCordinates())
            {
                if (BoardUTILS.IsCordinateValid(cordinate))
                {
                    Tile tile = board.GetTile(cordinate);
                    if (!tile.IsTileOccupied())
                    {
                        moves.Add(new NonCaptureMove(this, cordinate));
                    } else
                    {
                        Piece pieceAtDestination = tile.GetPiece();
                       if(pieceAtDestination.Alliance != this.Alliance)
                        {
                            moves.Add(new CaptureMove(this, cordinate, tile.GetPiece()));
                        }                  
                    }
                }      
            }
            return moves;
        }


        //Lists a Knight possible movements in chess
        //This could possible be cleaned up a bit since x and y cordinates is reused in multiple "full" cordinates.
        public List<Cordinate> CandidateCordinates()
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
    }
}
