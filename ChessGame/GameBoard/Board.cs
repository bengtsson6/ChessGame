using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.GameBoard
{
    public class Board
    {
        private Tile[,] tiles;

        public Board()
        {
            IntilizeBoard();
        }

        public void IntilizeBoard()
        {
            CreateTiles();
            SetPiecesStartPosition();
        }

        public Tile[,] CreateTiles()
        {
            Tile[,] tiles = new Tile[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Cordinate cor = new Cordinate(i, j);
                    Tile tile = new EmptyTile(cor);
                    tiles[i, j] = tile;
                }
            }
            return tiles;
        }

        public void SetPiecesStartPosition()
        {

        }

        public Tile GetTile(Cordinate cordinate)
        {
            return tiles[cordinate.XCordinate, cordinate.YCordinate]; 
        }
    }
}
