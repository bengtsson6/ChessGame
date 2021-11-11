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
    public class Rock : Piece
    {
        public Rock(Cordinate cordinate, Alliance alliance, PieceType pieceType) : base(cordinate, alliance, pieceType)
        {

        }
        //Rocks moves in straigth line, to get the CandidateCordiantes for the Rocks current position this method calls a method in MoveUtils that returns
        //an array of array with the cordinates in all four straigth directions
        //The methods then test if the tiles in the different paths is occupied,
        //and creates moves according to the occupied status and the alliance of possible occupied tile's piece,
        //if tile is occupied the loop for that "direction" is aborted since a Rock can't walk "through" other pieces.
        public override List<Move> LegalMoves(Board board)
        {
            List<Move> legalMoves = new List<Move>();
            Cordinate[][] candidateCordinates = MoveUtils.CalculateStraigthLineMovement(Cordinate);

            for(int i = 0; i < MoveUtils.LinearMoveDirections; i++)
            {
                foreach(Cordinate currentCandidateCordinate in candidateCordinates[i])
                {
                    Tile possibleDestinationTile = board.GetTile(currentCandidateCordinate);
                    if (!possibleDestinationTile.IsTileOccupied())
                    {
                        legalMoves.Add(new NonCaptureMove(this, currentCandidateCordinate, board));
                    }
                    else
                    {
                        Piece pieceOnOccipiedTile = possibleDestinationTile.GetPiece();
                        if(pieceOnOccipiedTile.Alliance != this.Alliance)
                        {
                            legalMoves.Add(new CaptureMove(this, currentCandidateCordinate, board, pieceOnOccipiedTile));
                        }
                        break;
                    }
                }
            }
            return legalMoves;
        }

        public override Piece MovePiece(Move move)
        {
            throw new NotImplementedException();
        }
    }
}
