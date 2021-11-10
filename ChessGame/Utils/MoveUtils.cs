using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.GameBoard;

namespace ChessGame.Utils
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
                    upLeftCordinates.Add(upLeftCor);
                }
                //Calculate the UPRIGTH Path and only add inbounds cordinates
                Cordinate upRightCor = new Cordinate(currentXCordinate + i, currentYCordinate - i);
                if (BoardUtils.IsCordinateValid(upRightCor))
                {
                    upRightCordinates.Add(upRightCor);
                }
                //Calculate the DOWNRIGTH Path and only add inbounds cordinates
                Cordinate downRightCor = new Cordinate(currentXCordinate + i, currentYCordinate + i);
                if (BoardUtils.IsCordinateValid(downRightCor))
                {
                    downRightCordinates.Add(downRightCor);
                }
                //Calculate the DOWNLEFT path and only add inbounds cordinates
                Cordinate downLeftCor = new Cordinate(currentXCordinate - i, currentYCordinate + i);
                if (BoardUtils.IsCordinateValid(downLeftCor))
                {
                    downLeftCordinates.Add(downLeftCor);
                }
            }
            paths[0] = upLeftCordinates.ToArray();
            paths[1] = upRightCordinates.ToArray();
            paths[2] = downRightCordinates.ToArray();
            paths[3] = downLeftCordinates.ToArray();
            return paths;
        }

        public static Cordinate[][] CalculateStraigthLineMovement(Cordinate currentCordinate)
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
                Cordinate upCordinate = new Cordinate(currentXCordinate, currentYCordinate - i);
                if (BoardUtils.IsCordinateValid(upCordinate))
                {
                    upCordinates.Add(upCordinate);
                }

                //Calculate DOWN path and check if cordinate inbounds of board
                Cordinate downCordinate = new Cordinate(currentXCordinate, currentYCordinate + i);
                if (BoardUtils.IsCordinateValid(downCordinate))
                {
                    downCordinates.Add(downCordinate);
                }
                //Calculate RIGHT path and check if cordinate inbounds of board
                Cordinate rightCordinate = new Cordinate(currentXCordinate + i, currentYCordinate);
                if (BoardUtils.IsCordinateValid(rightCordinate))
                {
                    rightCordinates.Add(rightCordinate);
                }
                //Calculate LEFT path and check if cordinate inbounds of board
                Cordinate leftCordinate = new Cordinate(currentXCordinate - i, currentYCordinate);
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
