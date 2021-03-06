using ChessGame.Game;
using ChessGame.GameBoard;
using ChessGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Moves;

namespace ChessGame.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Cordinate cordinate, Alliance alliance, bool isFirstMove) : base(cordinate, alliance, PieceType.PAWN, isFirstMove)
        {
        }


        //Check if enpassant move is possible (think that will be a new class also and we do a check possible method in that class or this)
        //Maybe the enpassant stuff will have a check in a move transition class
        //The enpassant imlementation will be a bit tricky
        public override List<Move> LegalMoves(Board board)
        {
            List<Move> legalMoves = new List<Move>();
            List<Cordinate> candidateCordinates = this.CandidateCordinates();
            foreach (Cordinate currentCandidateCordinate in candidateCordinates)
            {
                if (BoardUtils.IsCordinateValid(currentCandidateCordinate))
                {
                    Tile potentialDestinationTile = board.GetTile(currentCandidateCordinate);
                    //Check diagonal movement rule
                    if (currentCandidateCordinate.XCordinate != this.Cordinate.XCordinate)
                    {
                        if (potentialDestinationTile.IsTileOccupied())
                        {
                            Piece occupyingPiece = potentialDestinationTile.GetPiece();
                            if (this.Alliance != occupyingPiece.Alliance)
                            {
                                if (currentCandidateCordinate.YCordinate == BoardUtils.EigthRank || currentCandidateCordinate.YCordinate == BoardUtils.FirstRank)
                                {
                                    //Do something here to create a promotion move
                                }
                                legalMoves.Add(new CaptureMove(this, currentCandidateCordinate, board, occupyingPiece));
                            }
                        }
                    } 
                    //Check one move forward
                    if((currentCandidateCordinate.YCordinate == this.Cordinate.YCordinate + 1 ||
                       currentCandidateCordinate.YCordinate == this.Cordinate.YCordinate - 1) && 
                       currentCandidateCordinate.XCordinate == this.Cordinate.XCordinate)
                    {
                        if (!potentialDestinationTile.IsTileOccupied())
                        {
                            if (currentCandidateCordinate.YCordinate == BoardUtils.EigthRank || currentCandidateCordinate.YCordinate == BoardUtils.FirstRank)
                            {
                                //Do something here to create a promotion move                           
                            }
                            legalMoves.Add(new NonCaptureMove(this, currentCandidateCordinate, board));                            
                        } 
                    }
                    //Check pawn jump
                    if ((currentCandidateCordinate.YCordinate == this.Cordinate.YCordinate + 2 ||
                       currentCandidateCordinate.YCordinate == this.Cordinate.YCordinate - 2) &&
                       currentCandidateCordinate.XCordinate == this.Cordinate.XCordinate)
                    {
                        Tile jumpedOverTile;
                        if (this.Alliance == Alliance.BLACK) {
                            jumpedOverTile = board.GetTile(new Cordinate(currentCandidateCordinate.XCordinate, currentCandidateCordinate.YCordinate - 1));
                        } else
                        {
                            jumpedOverTile = board.GetTile(new Cordinate(currentCandidateCordinate.XCordinate, currentCandidateCordinate.YCordinate + 1));
                        }
                        if(!potentialDestinationTile.IsTileOccupied() && !jumpedOverTile.IsTileOccupied())
                        {
                            legalMoves.Add(new PawnJumpMove(this, currentCandidateCordinate, board));
                        }
                    }
                }
            }
            return legalMoves;
        }


        public override Piece MovePiece(Move move)
        {
            return new Pawn(move.DestinationCordinate, move.MovingPiece.Alliance, false);
        }


        //The calculation for candidate cordinates for the pawn differs since the movement direction is different depending if it's,
        //a black or white piece, if it is the pawns first move it will also be able to take to steps.
        public List<Cordinate> CandidateCordinates()
        {
            Cordinate currentCordinate = this.Cordinate;
            List<Cordinate> candidateCordinates = new List<Cordinate>();
            if (Alliance == Alliance.BLACK)
            {
                Cordinate oneTileForward = new Cordinate(currentCordinate.XCordinate, currentCordinate.YCordinate + 1);
                Cordinate leftDiagonal = new Cordinate(currentCordinate.XCordinate - 1, currentCordinate.YCordinate + 1);
                Cordinate rigthDiagonal = new Cordinate(currentCordinate.XCordinate + 1, currentCordinate.YCordinate + 1);
                candidateCordinates.Add(leftDiagonal);
                candidateCordinates.Add(rigthDiagonal);
                candidateCordinates.Add(oneTileForward);
                if (IsPawnOnSeventhRank())
                {
                    Cordinate twoTilesForward = new Cordinate(currentCordinate.XCordinate, currentCordinate.YCordinate + 2);
                    candidateCordinates.Add(twoTilesForward);
                }
            }
            if (Alliance == Alliance.WHITE)
            {
                Cordinate oneTileForward = new Cordinate(currentCordinate.XCordinate, currentCordinate.YCordinate - 1);
                Cordinate leftDiagonal = new Cordinate(currentCordinate.XCordinate - 1, currentCordinate.YCordinate - 1);
                Cordinate rigthDiagonal = new Cordinate(currentCordinate.XCordinate + 1, currentCordinate.YCordinate - 1);
                candidateCordinates.Add(leftDiagonal);
                candidateCordinates.Add(rigthDiagonal);
                candidateCordinates.Add(oneTileForward);
                if (IsPawnOnSecondRank())
                {
                    Cordinate twoTilesForward = new Cordinate(currentCordinate.XCordinate, currentCordinate.YCordinate - 2);
                    candidateCordinates.Add(twoTilesForward);
                }
            }
            return candidateCordinates;
        }
        public bool IsPawnOnSecondRank()
        {
            return this.Cordinate.YCordinate == BoardUtils.SecondRank;
 
        }
        public bool IsPawnOnSeventhRank()
        {
            return this.Cordinate.YCordinate == BoardUtils.SeventhRank;
        }
        public bool IsDiagonalTileOccupied(Cordinate diagonalCordinate)
        {
            return true;
        }
        public bool IsCordinateDiagonal(int currentYCordinate, int candidateYCordinate)
        {
            if (currentYCordinate != candidateYCordinate)
            {
                return true;
            }
            return false;
        }
    }
}
