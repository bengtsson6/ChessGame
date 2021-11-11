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
    public class King : Piece
    {
        public King(Cordinate cordinate, Alliance alliance, PieceType pieceType) : base(cordinate, alliance ,pieceType)
        {

        }

        public override List<Move> LegalMoves(Board board)
        {
            List<Move> legalMoves = new List<Move>();
            Cordinate[][] straigthLineCordinates = MoveUtils.CalculateStraigthLineMovement(this.Cordinate);
            Cordinate[][] diagonalMovementCordinates = MoveUtils.CalculateDiagonalMovement(this.Cordinate);
            Cordinate[][] candidateCordinates = straigthLineCordinates.Concat(diagonalMovementCordinates).ToArray();

            for (int i = 0; i < (MoveUtils.DiagonalMoveDirections + MoveUtils.LinearMoveDirections); i++)
            {
                if (candidateCordinates[i].Length != 0)
                {
                    Cordinate currentCandidateCordinate = candidateCordinates[i][0];
                    Tile possibleDestinationTile = board.GetTile(currentCandidateCordinate);
                    if (!possibleDestinationTile.IsTileOccupied())
                    {
                        legalMoves.Add(new NonCaptureMove(this, currentCandidateCordinate, board));
                    } 
                    else
                    {
                        Piece pieceOnOccupiedTile = possibleDestinationTile.GetPiece();
                        if(pieceOnOccupiedTile.Alliance != this.Alliance)
                        {
                            legalMoves.Add(new CaptureMove(this, currentCandidateCordinate, board, pieceOnOccupiedTile));
                        }
                    }
                }
            }
            if (IsCastlePossilbe())
            {

            }
            
            return legalMoves;
        }

        public override Piece MovePiece(Move move)
        {
            throw new NotImplementedException();
        }

        private bool IsCastlePossilbe()
        {
            throw new NotImplementedException();
        }
    }
}
