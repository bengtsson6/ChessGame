using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessGame.GameBoard;
using ChessGame.Moves;

namespace ChessGame.GUI
{
    public class TilePanel:Panel
    {
        private Tile tile;
        private Label textLabel;
        public TilePanel(Tile tile) : base()
        {
            this.Height = 50;
            this.Width = 50;
            this.BorderStyle = BorderStyle.Fixed3D;
            Tile = tile;
            CreateLabel(Tile);
           // this.Click += TilePanel_Click;
            
        }

        private void CreateLabel(Tile tile)
        {
            if (tile.IsTileOccupied())
            {
                Label label = new Label();
                label.Text = tile.GetPiece().ToString();
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

        public Tile Tile { get => tile; set => tile = value; }
        public Label TextLabel { get => textLabel; set => textLabel = value; }
    }
}
