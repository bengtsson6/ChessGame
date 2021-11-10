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
 
        }
    }
}
