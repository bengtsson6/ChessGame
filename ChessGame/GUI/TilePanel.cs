using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessGame.GameBoard;
using ChessGame.Moves;
using ChessGame.Pieces;

namespace ChessGame.GUI
{
    public class TilePanel : Panel
    {
        private Cordinate cordinate;
        private Label textLabel;
        private Controller controller;
        private Board board;
        public TilePanel(Cordinate cordinate, Controller controller) : base()
        {
            Cordinate = cordinate;
            Controller = controller;
            this.Height = 50;
            this.Width = 50;
            this.BorderStyle = BorderStyle.Fixed3D;            
            CreateLabel(Cordinate);
            this.Click += controller.TilePanel_Click;
            DoubleBuffered = true;

        }
        private void CreateLabel(Cordinate cordinate)
        {
            if (Controller.Board.GetTile(cordinate).IsTileOccupied())
            {
                Label label = new Label();
                label.Text = Controller.Board.GetTile(cordinate).GetPiece().ToString();
                //label.Click += Label_Click;
                this.Controls.Add(label);
            }
        }

        /*private void Label_Click(object sender, EventArgs e)
        {
            TilePanel_Click(sender, e);
        }

        private void TilePanel_Click(object sender, EventArgs e)
        {
            if (tile.IsTileOccupied()) {
            }
        }*/

        public Label TextLabel { get => textLabel; set => textLabel = value; }
        public Cordinate Cordinate { get => cordinate; set => cordinate = value; }
        public Controller Controller { get => controller; set => controller = value; }
        public Board Board { get => board; set => board = value; }
    }
}
