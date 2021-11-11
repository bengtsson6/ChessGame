using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.GameBoard;
using ChessGame.Game;
using ChessGame.Utils;
using ChessGame.Pieces;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = Board.SetPiecesStartPosition();
            Console.WriteLine(board.ToString());
            Console.ReadLine();


            Pawn p1 = new Pawn(new Cordinate(3, 3), Alliance.BLACK, PieceType.PAWN);
            Pawn p2 = new Pawn(new Cordinate(6, 3), Alliance.BLACK, PieceType.PAWN);

            Console.WriteLine(p1.IsPawnOnSecondRank().ToString());
            Console.WriteLine(p2.IsPawnOnSecondRank().ToString());
        }
    }
}
