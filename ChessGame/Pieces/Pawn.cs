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


        public List<Cordinate> CandidateCordinate()
        {
            Cordinate currentCordinate = this.Cordinate;
            List<Cordinate> candidateCordinates = new List<Cordinate>();
            if (Alliance == Alliance.BLACK)
            {
                Cordinate oneMoveForward = new Cordinate(currentCordinate.XCordinate, currentCordinate.YCordinate + 1);
                Cordinate leftDiagonal = new Cordinate(currentCordinate.XCordinate - 1, currentCordinate.YCordinate + 1);
                Cordinate rigthDiagonal = new Cordinate(currentCordinate.XCordinate + 1, currentCordinate.YCordinate + 1);
                candidateCordinates.Add(oneMoveForward);
                candidateCordinates.Add(leftDiagonal);
                candidateCordinates.Add(rigthDiagonal);

            }


            //Move direction dependent on ALLIANCE if BLACK y+, White y-
            //IF SECOND or SEVENTH RANK then 2 squares jumps are possilbe
            //Is Capture possible - another method

            return candidateCordinates;
        }
        public bool IsPawnOnSecondRank()
        {
            return this.Cordinate.XCordinate == BoardUtils.SecondRank ? true : false;
 
        }
        public bool IsPawnOnSeventhRank()
        {
            return this.Cordinate.XCordinate == BoardUtils.SeventhRank ? true : false;
        }
        public bool IsDiagonalTileOccupied(Cordinate diagonalCordinate)
        {
            return true;
        }
    }
}
