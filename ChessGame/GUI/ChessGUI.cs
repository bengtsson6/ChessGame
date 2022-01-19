using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessGame.GameBoard;
using ChessGame.Pieces;
using ChessGame.Game;
using ChessGame.Moves;

namespace ChessGame.GUI
{
    public partial class ChessGUI : Form
    {
        private Board board;
        private Tile selectedTilePanel;
        public Board Board { get => board; set => board = value; }
        public Tile SelectedTilePanel { get => selectedTilePanel; set => selectedTilePanel = value; }

        public ChessGUI(Board board)
        {
            InitializeComponent();
            Board = board;
            PaintChessBoard(board);
            AddTileClickEvent();
        }

        private void PaintChessBoard(Board board)
        {
            this.ChessBoardPanel.PaintBoardGrid(board);
            this.ChessBoardPanel.SetStartColor();
        }

        private void AddTileClickEvent()
        {
            foreach (TilePanel tilePanel in ChessBoardPanel.TilePanels)
            {
                tilePanel.Click += TilePanel_Click;
            }
        }


        private void TilePanel_Click(object sender, EventArgs e)
        {
            ChessBoardPanel.SetStartColor();
            if (sender is TilePanel)
            {
                TilePanel clickedTile = (TilePanel)sender;
                Tile boardTile = clickedTile.Tile;
                if (boardTile.IsTileOccupied())
                {
                    this.SelectedTilePanel = boardTile;
                    Piece piece = boardTile.GetPiece();
                    List<Move> moves;
                    if (piece.Alliance == Alliance.BLACK)
                    {
                        moves = board.BlackPlayer.LegalMoves;
                    }
                    else
                    {
                        moves = board.WhitePlayer.LegalMoves;
                    }
                    HighligthTile(moves, boardTile);
                }
            } 
        }

        private void HighligthTile(List<Move> moves, Tile boardTile)
        {
            foreach (Move move in moves)
            {
                if (move.MovingPiece.Cordinate.Equals(boardTile.Cordinate))
                {
                    foreach (TilePanel tilePanel in ChessBoardPanel.TilePanels)
                    {
                        if (tilePanel.Tile.Cordinate.Equals(move.DestinationCordinate))
                        {
                            tilePanel.BackColor = Color.Cyan;
                        }
                    }
                }
            }
        }
    }
}
