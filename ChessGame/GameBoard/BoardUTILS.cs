using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.GameBoard
{
    public static class BoardUTILS
    {
        private static readonly int numOfTiles = 64;

        public static bool IsCordinateValid(Cordinate cordinate)
        {
            if (cordinate.XCordinate >= 0 && cordinate.XCordinate <= 8 && cordinate.YCordinate >= 0 && cordinate.YCordinate <= 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int NumOfTiles { get => numOfTiles;}
    }
}
