using ChessGame.Game;
using ChessGame.GameBoard;
using ChessGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Cordinate cordinate, Alliance alliance, PieceType pieceType) : base(cordinate, alliance, pieceType)
        {
        }

        public override List<Move> LegalMoves(Board board)
        {
            throw new NotImplementedException();
        }


        public override Piece MovePiece(Move move)
        {
            throw new NotImplementedException();
        }


        //The calculation for candidate cordinates for the pawn differs since the movement direction is different depending if it's,
        //a black or white piece, also 
        public List<Cordinate> CandidateCordinates()
        {
            Cordinate currentCordinate = this.Cordinate;
            List<Cordinate> candidateCordinates = new List<Cordinate>();
            if (Alliance == Alliance.BLACK)
            {
                Cordinate oneTileForward = new Cordinate(currentCordinate.XCordinate, currentCordinate.YCordinate + 1);
                Cordinate leftDiagonal = new Cordinate(currentCordinate.XCordinate - 1, currentCordinate.YCordinate + 1);
                Cordinate rigthDiagonal = new Cordinate(currentCordinate.XCordinate + 1, currentCordinate.YCordinate + 1);
                candidateCordinates.Add(oneTileForward);
                candidateCordinates.Add(leftDiagonal);
                candidateCordinates.Add(rigthDiagonal);
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
                candidateCordinates.Add(oneTileForward);
                candidateCordinates.Add(leftDiagonal);
                candidateCordinates.Add(rigthDiagonal);
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
