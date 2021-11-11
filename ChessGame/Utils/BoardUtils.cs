using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.GameBoard;

namespace ChessGame.Utils
{
    public class BoardUtils
    {
        private static readonly int numOfTiles = 64;
        private static readonly int firstRank = 7;
        private static readonly int secondRank = 6;
        private static readonly int seventhRank = 1;
        private static readonly int eigthRank = 0;


        public static bool IsCordinateValid(Cordinate cordinate)
        {
            if (cordinate.XCordinate >= 0 && cordinate.XCordinate <= 7 && cordinate.YCordinate >= 0 && cordinate.YCordinate <= 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int NumOfTiles { get => numOfTiles;}
        public static int FirstRank => firstRank;
        public static int SecondRank => secondRank;
        public static int SeventhRank => seventhRank;
        public static int EigthRank => eigthRank;
    }
}
