using ChessGame.Game;
using ChessGame.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Pieces
{
    public class Bishop : Piece
    {

        public Bishop(Cordinate cordinate, Alliance alliance, PieceType pieceType) : base(cordinate, alliance, pieceType)
        {
        }
        //Bishops moves diagonal, to get the CandidateCordiantes for the bishops current position this method calls a method in MoveUtils that returns
        //an array of array with the cordinates in all four diagonal directions
        public override List<Move> LegalMoves(Board board)
        {
            Cordinate[][] CandidateCordinates = MoveUtils.CalculateDiagonalMovement(Cordinate);
            List<Move> legalMoves = new List<Move>();

            for (int i = 0; i < MoveUtils.DiagonalMoveDirections; i++)
            {
                foreach (Cordinate CurrentCandidateCordinate in CandidateCordinates[i])
                {
                    Tile possibleDestinationTile = board.GetTile(CurrentCandidateCordinate);
                    if (!possibleDestinationTile.IsTileOccupied())
                    {
                        legalMoves.Add(new NonCaptureMove(this, CurrentCandidateCordinate, board));
                    } else
                    {
                        Piece pieceAtDestinationTile = board.GetTile(CurrentCandidateCordinate).GetPiece();
                        if(pieceAtDestinationTile.PieceType != this.PieceType)
                        {
                            legalMoves.Add(new CaptureMove(this, CurrentCandidateCordinate, board, pieceAtDestinationTile));
                        }
                        break;
                    }
                }
            }
            return legalMoves;
        }
    }
}
