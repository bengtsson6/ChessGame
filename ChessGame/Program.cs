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

            Cordinate c = new Cordinate(0, 1);
            Piece k = board.GetTile(c).GetPiece();
            List<Move> moves = k.LegalMoves(board);
            foreach (Move move in moves)
            {
                Console.WriteLine(move.DestinationCordinate.XCordinate + "," + move.DestinationCordinate.YCordinate);
            }

            Pawn p1 = new Pawn(new Cordinate(6, 6), Alliance.WHITE, PieceType.PAWN);
            Pawn p2 = new Pawn(new Cordinate(5, 1), Alliance.WHITE, PieceType.PAWN);
            List<Cordinate> cords = p1.CandidateCordinate();
            foreach(Cordinate cor in cords)
            {
                Console.WriteLine(cor.XCordinate + ", " + cor.YCordinate);
            }
            Console.WriteLine(p1.IsPawnOnSecondRank());
            Console.WriteLine(p2.IsPawnOnSecondRank());
            Console.ReadLine();

        }
    }
}
