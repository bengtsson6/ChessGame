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
        private static readonly int moveDirections = 4;

        public static int MoveDirections => moveDirections;

        public Bishop(Cordinate cordinate, Alliance alliance, PieceType pieceType) : base(cordinate, alliance, pieceType)
        {
        }

        //Methods gets gets the CandidateCordinates from the CalculateMovementPaths Method and then checks if the movement paths is occupied by other
        //pieces given the Board parameter, returns a list with valid moves.
        public override List<Move> LegalMoves(Board board)
        {
            Cordinate[][] CandidateCordinates = CalculateMovementPaths(this.Cordinate);
            List<Move> legalMoves = new List<Move>();

            for (int i = 0; i < MoveDirections; i++)
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


        //A Bishop can move diagonal in four different directions, UPLEFT, UPRIGHT, DOWNLEFT and DOWNRIGHT
        //Method returns cordinates for each of these directions given the current Piece Position
        //Note this method is private since other classes don't need the move paths, just the legal moves which is available in LegalMoves() method
        private Cordinate[][] CalculateMovementPaths(Cordinate currentCordinate)
        {
            Cordinate[][] paths = new Cordinate[4][];
            int currentXCordinate = currentCordinate.XCordinate;
            int currentYCordinate = currentCordinate.YCordinate;

            List<Cordinate> upLeftCordinates = new List<Cordinate>();
            List<Cordinate> upRightCordinates = new List<Cordinate>();
            List<Cordinate> downRightCordinates = new List<Cordinate>();
            List<Cordinate> downLeftCordinates = new List<Cordinate>();
            for (int i = 1; i < 8; i++)
            {
                //Calculate the UPLEFT Path and only add inbounds cordinates
                Cordinate upLeftCor = new Cordinate(currentXCordinate - i, currentYCordinate - i);
                if (BoardUtils.IsCordinateValid(upLeftCor))
                {
                    upLeftCordinates.Append(upLeftCor);
                }
                //Calculate the UPRIGTH Path and only add inbounds cordinates
                Cordinate upRightCor = new Cordinate(currentXCordinate + i, currentYCordinate - i);
                if (BoardUtils.IsCordinateValid(upRightCor))
                {
                    upRightCordinates.Append(upRightCor);
                }
                //Calculate the DOWNRIGTH Path and only add inbounds cordinates
                Cordinate downRightCor = new Cordinate(currentXCordinate + i, currentYCordinate + i);
                if (BoardUtils.IsCordinateValid(downRightCor))
                {
                    downRightCordinates.Append(downRightCor);
                }
                //Calculate the DOWNLEFT path and only add inbounds cordinates
                Cordinate downLeftCor = new Cordinate(currentXCordinate - 1, currentYCordinate + 1);
                if (BoardUtils.IsCordinateValid(downLeftCor))
                {
                    downLeftCordinates.Append(downLeftCor);
                }
            }
            paths[0] = upLeftCordinates.ToArray();
            paths[1] = upRightCordinates.ToArray();
            paths[2] = downLeftCordinates.ToArray();
            paths[3] = downRightCordinates.ToArray();
            return paths;
        }
    }
}
