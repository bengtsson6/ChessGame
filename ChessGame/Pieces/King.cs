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
    public class King : Piece
    {
        public King(Cordinate cordinate, Alliance alliance, bool isFirstMove) : base(cordinate, alliance , PieceType.KING, isFirstMove)
        {

        }
        //The Castle move contains move logic for two pieces and therefore i will impement it in the Player class since the player contain
        //has both thoose pieces
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
            return legalMoves;
        }

        public override Piece MovePiece(Move move)
        {
            return new King(move.DestinationCordinate, move.MovingPiece.Alliance, false);
        }
    }
}
