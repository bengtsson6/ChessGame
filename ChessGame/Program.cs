using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.GameBoard;
using ChessGame.Game;
using ChessGame.Utils;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = Board.SetPiecesStartPosition();
            Console.WriteLine(board.ToString());
            Console.ReadLine();
           
            Cordinate[][] linearMovesCordinates = MoveUtils.CalculateStraigthLineMovement(new Cordinate(3,3));
            Cordinate[][] diagonalMovesCordinates = MoveUtils.CalculateDiagonalMovement(new Cordinate(3, 3));

            Cordinate[][] candidateCordinates = linearMovesCordinates.Concat(diagonalMovesCordinates).ToArray();

            for (int i = 0; i < candidateCordinates.Length; i++)
            {
                foreach (Cordinate cor in candidateCordinates[i])
                {
                    Console.WriteLine(cor.XCordinate + ", " + cor.YCordinate);
                }
            }

            Console.ReadLine();
        }
    }
}
