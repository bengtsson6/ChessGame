using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.GameBoard;
using ChessGame.Game;
using ChessGame.Utils;
using ChessGame.Pieces;
using ChessGame.Moves;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = Board.SetPiecesStartPosition();
            Console.WriteLine(board.ToString());
            Console.ReadLine();

            /*Tile[,] tiles = board.GameBoard;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.WriteLine(tiles[i, j].Cordinate.XCordinate + " = " + i + "     " + tiles[i, j].Cordinate.YCordinate + " = " + j);
                    Console.WriteLine(tiles[i, j].GetType());
                }       
            }
        Console.ReadLine();

            Cordinate c = new Cordinate(1, 0);
            Piece k = board.GetTile(c).GetPiece();
            List<Move> moves = k.LegalMoves(board);
            Console.WriteLine(k.GetType());
            Console.WriteLine(moves.Count);
            foreach (Move move in moves)
            {
                Console.WriteLine(move.DestinationCordinate.XCordinate + "," + move.DestinationCordinate.YCordinate);
            }

            Pawn p1 = (Pawn) board.GetTile(new Cordinate(6, 6)).GetPiece();
            List<Move> moves1 = p1.LegalMoves(board);
            List<Cordinate> cords = p1.CandidateCordinates();
            Console.WriteLine(p1 + " " + moves1.Count + " " + cords.Count);
            foreach(Move move in moves1)
            {
                Console.WriteLine(move.DestinationCordinate.XCordinate + "," + move.DestinationCordinate.YCordinate);
            }
            Console.ReadLine();*/
        

            //Do some test for the player class
            //Get opponent is workning
            //Legal moves seem to work
            //IsInCheck to
            Player blackPlayer = board.BlackPlayer;
            Player whitePlayer = board.WhitePlayer;
            List<Move> blackMoves = blackPlayer.LegalMoves;
            List<Move> whiteMoves = whitePlayer.LegalMoves;
            Piece piece = board.GetTile(new Cordinate(0, 1)).GetPiece();
            Move move = whitePlayer.LegalMoves[0];
            Console.WriteLine(whitePlayer.IsMoveLegal(move));
            Board newBoard = whitePlayer.MakeMove(move).TransitionBoard;

            Console.WriteLine(newBoard.ToString());
            Console.ReadLine();
        }
    }
}