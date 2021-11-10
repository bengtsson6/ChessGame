using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.GameBoard;

namespace ChessGame.Game
{
    class MoveUtils
    {
        private static readonly int diagonalMoveDirections = 4;
        private static readonly int linearMoveDirections = 4;
        private static readonly int queenMoveDirections = 8;
        private static readonly int maxMoveLength = 7;


        public static Cordinate[][] CalculateDiagonalMovement(Cordinate currentCordinate)
        {
            Cordinate[][] paths = new Cordinate[DiagonalMoveDirections][];
            int currentXCordinate = currentCordinate.XCordinate;
            int currentYCordinate = currentCordinate.YCordinate;

            List<Cordinate> upLeftCordinates = new List<Cordinate>();
            List<Cordinate> upRightCordinates = new List<Cordinate>();
            List<Cordinate> downRightCordinates = new List<Cordinate>();
            List<Cordinate> downLeftCordinates = new List<Cordinate>();
            for (int i = 1; i < MaxMoveLength + 1; i++)
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

        public static Cordinate[][] CalculateLinearMovement(Cordinate currentCordinate)
        {
            Cordinate[][] paths = new Cordinate[MoveUtils.LinearMoveDirections][];
            int currentXCordinate = currentCordinate.XCordinate;
            int currentYCordinate = currentCordinate.YCordinate;

            List<Cordinate> upCordinates = new List<Cordinate>();
            List<Cordinate> downCordinates = new List<Cordinate>();
            List<Cordinate> rightCordinates = new List<Cordinate>();
            List<Cordinate> leftCordinates = new List<Cordinate>();

            for (int i = 1; i < MoveUtils.MaxMoveLength + 1; i++)
            {
                //Calculate UP path and check if cordinate inbounds of board
                Cordinate upCordinate = new Cordinate(currentXCordinate, currentYCordinate - 1);
                if (BoardUtils.IsCordinateValid(upCordinate))
                {
                    upCordinates.Add(upCordinate);
                }

                //Calculate DOWN path and check if cordinate inbounds of board
                Cordinate downCordinate = new Cordinate(currentXCordinate, currentYCordinate + 1);
                if (BoardUtils.IsCordinateValid(downCordinate))
                {
                    downCordinates.Add(downCordinate);
                }
                //Calculate RIGHT path and check if cordinate inbounds of board
                Cordinate rightCordinate = new Cordinate(currentXCordinate + 1, currentYCordinate);
                if (BoardUtils.IsCordinateValid(rightCordinate))
                {
                    rightCordinates.Add(rightCordinate);
                }
                //Calculate LEFT path and check if cordinate inbounds of board
                Cordinate leftCordinate = new Cordinate(currentXCordinate - 1, currentYCordinate);
                if (BoardUtils.IsCordinateValid(leftCordinate))
                {
                    leftCordinates.Add(leftCordinate);
                }
            }
            paths[0] = upCordinates.ToArray();
            paths[1] = downCordinates.ToArray();
            paths[2] = rightCordinates.ToArray();
            paths[3] = leftCordinates.ToArray();
            return paths;
        }
    
        public static int DiagonalMoveDirections => diagonalMoveDirections;
        public static int LinearMoveDirections => linearMoveDirections;
        public static int QueenMoveDirections => queenMoveDirections;
        public static int MaxMoveLength => maxMoveLength;
    }
}
