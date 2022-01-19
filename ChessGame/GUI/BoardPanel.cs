using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessGame.GameBoard;

namespace ChessGame.GUI
{
    public class BoardPanel: Panel
    {
        private TilePanel[,] tilePanels;

        public BoardPanel() : base()
        {
            tilePanels = new TilePanel[8, 8];
            DoubleBuffered = true;
        }

        public void PaintBoardGrid(Controller controller)
        {
            Update();
            SuspendLayout();
            Controls.Clear();
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Cordinate cordinate = new Cordinate(i, j);
                    TilePanel gridTile = new TilePanel(cordinate, controller);
                    Point point = new Point(i * 50, j*50);
                    gridTile.Location = (point);
                    tilePanels[i, j] = gridTile;
                    this.Controls.Add(gridTile);
                }
            }
            SetStartColor();
            ResumeLayout();
        }
        public void SetStartColor()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    if ((i % 2 == 0 && j % 2 == 0) ||
                        (i % 2 != 0 && j % 2 != 0))
                    {
                        tilePanels[i, j].BackColor = Color.LightGray;
                    }
                    else
                    {
                        tilePanels[i, j].BackColor = Color.DarkGray;
                    }

                }
            }
        }
        public TilePanel[,] TilePanels { get => tilePanels; set => tilePanels = value; }
    }
}
