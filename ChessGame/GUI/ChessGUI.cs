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
    public partial class Controller : Form
    {
        private Board board;
        private Cordinate selectedStartTileCordinate;
        private Cordinate selectedDestinationTileCordinate;
        public Board Board { get => board; set => board = value; }
        public Cordinate SelectedStartTileCordinate { get => selectedStartTileCordinate; set => selectedStartTileCordinate = value; }
        public Cordinate SelectedDestinationTileCordinate { get => selectedDestinationTileCordinate; set => selectedDestinationTileCordinate = value; }

        public Controller(Board board)
        {
            InitializeComponent();
            Board = board;
            PaintChessBoard();
        }

        private void PaintChessBoard()
        {
            ChessBoardPanel.PaintBoardGrid(this);
        }
        public void TilePanel_Click(object sender, EventArgs e)
        {
            ChessBoardPanel.SetStartColor();
            TilePanel clickedTile = (TilePanel)sender;
            Tile boardTile = Board.GetTile(clickedTile.Cordinate);
            if (selectedStartTileCordinate != null)
            {
                selectedDestinationTileCordinate = clickedTile.Cordinate;
                Move move = Board.GetLegalMove(SelectedStartTileCordinate, SelectedDestinationTileCordinate);
                MoveTransition moveTransition = Board.CurrentPlayer.MakeMove(move);
                MessageBox.Show(moveTransition.MoveStatus.ToString());
                if (moveTransition.MoveStatus == MoveStatus.DONE)
                {
                    selectedDestinationTileCordinate = null;
                    selectedStartTileCordinate = null;
                    Board = moveTransition.TransitionBoard;
                    ChessBoardPanel.PaintBoardGrid(this);
                }
            }
            if (boardTile.IsTileOccupied())
            {
                if (boardTile.GetPiece().Alliance == Board.CurrentPlayer.Alliance)
                {
                    SelectedStartTileCordinate = boardTile.Cordinate;
                    List<Move> moves = Board.CurrentPlayer.LegalMoves;
                    HighligthTile(moves, boardTile);
                }
            }            
        }
        private void HighligthTile(List<Move> moves, Tile boardTile)
        {
            //Something need to be done to highligth castle move
            foreach (Move move in moves)
            {
                if (move.MovingPiece.Cordinate.Equals(boardTile.Cordinate))
                {
                    foreach (TilePanel tilePanel in ChessBoardPanel.TilePanels)
                    {
                        if (tilePanel.Cordinate.Equals(move.DestinationCordinate))
                        {
                            tilePanel.BackColor = Color.Cyan;

                        }
                    }
                }
            }
        }
    }
}
