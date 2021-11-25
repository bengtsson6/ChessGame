using ChessGame.Game;
using ChessGame.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Utils;
using ChessGame.Moves;

namespace ChessGame.Pieces
{
    public class Queen : Piece
    {
        public Queen(Cordinate cordinate, Alliance alliance, bool isFirstMove) : base(cordinate, alliance, PieceType.QUEEN, isFirstMove)
        {

        }

        //Queens move both diagonal and straigth lines which means a total of 8 directions, we found all the directions calling to methods in MoveUtils then
        //Concat them together to get all the CandidateCordinate for the Queen
        //Then the method determines if their is another piece occupying the a square in the direction and then detmine if that piece is capturable or not.
        public override List<Move> LegalMoves(Board board)
        {
            List<Move> legalMoves = new List<Move>();
            Cordinate[][] linearMovesCordinates = MoveUtils.CalculateStraigthLineMovement(this.Cordinate);
            Cordinate[][] diagonalMovesCordinates = MoveUtils.CalculateDiagonalMovement(this.Cordinate);
            Cordinate[][] candidateCordinates = linearMovesCordinates.Concat(diagonalMovesCordinates).ToArray();

            for (int i = 0; i < (MoveUtils.DiagonalMoveDirections + MoveUtils.LinearMoveDirections); i++)
            {
                foreach (Cordinate currentCandidateCordinate in candidateCordinates[i])
                {
                    Tile possibleDestinationTile = board.GetTile(currentCandidateCordinate);
                    if (!possibleDestinationTile.IsTileOccupied())
                    {
                        legalMoves.Add(new NonCaptureMove(this, currentCandidateCordinate, board));
                    }
                    else
                    {
                        Piece pieceAtDestionationTile = possibleDestinationTile.GetPiece();
                        if(pieceAtDestionationTile.Alliance != this.Alliance)
                        {
                            legalMoves.Add(new CaptureMove(this, currentCandidateCordinate, board, pieceAtDestionationTile));
                        }
                        break;
                    }
                }
            }
            return legalMoves;
        }

        public override Piece MovePiece(Move move)
        {
            return new Queen(move.DestinationCordinate, move.MovingPiece.Alliance, false);
        }
    }
}
