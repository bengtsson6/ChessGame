using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.GameBoard
{
    public class Cordinate : IEquatable<Cordinate>
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

        /*public override bool Equals(object obj)
        {
            if(obj.GetType() == this.GetType())
            {
                Cordinate cordinate = (Cordinate)obj;
                if (cordinate.XCordinate == this.XCordinate && cordinate.YCordinate == this.YCordinate)
                {
                    return true;
                }
            }
            return false;
        }*/

        public override string ToString()
        {
            string returnString = XCordinate.ToString() + ", " + YCordinate.ToString();
            return returnString;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Cordinate);
        }

        public bool Equals(Cordinate other)
        {
            return other != null &&
                   XCordinate == other.XCordinate &&
                   YCordinate == other.YCordinate;
        }

        public override int GetHashCode()
        {
            int hashCode = 909658841;
            hashCode = hashCode * -1521134295 + XCordinate.GetHashCode();
            hashCode = hashCode * -1521134295 + YCordinate.GetHashCode();
            return hashCode;
        }

        /* public override int GetHashCode()
         {
             return xCordinate.GetHashCode();
         }*/

        public int XCordinate { get => xCordinate; set => xCordinate = value; }
        public int YCordinate { get => yCordinate; set => yCordinate = value; }
        public int[] CordinatePair { get => cordinatePair; set => cordinatePair = value; }
    }
}
