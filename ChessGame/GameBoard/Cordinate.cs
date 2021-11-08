using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.GameBoard
{
    public class Cordinate
    {
        private int xCordinate;
        private int yCordinate;
        private int[] cordinatePair;

        public Cordinate(int x, int y)
        {
            XCordinate = x;
            YCordinate = y;
            cordinatePair = new int[]{x,y};
        }

        public int XCordinate { get => xCordinate; set => xCordinate = value; }
        public int YCordinate { get => yCordinate; set => yCordinate = value; }
        public int[] CordinatePair { get => cordinatePair; set => cordinatePair = value; }
    }
}
