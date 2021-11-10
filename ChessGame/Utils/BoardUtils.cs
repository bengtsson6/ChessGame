﻿using System;
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
    }
}