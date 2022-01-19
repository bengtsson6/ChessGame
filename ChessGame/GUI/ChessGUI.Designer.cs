
namespace ChessGame.GUI
{
    partial class Controller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChessBoardPanel = new BoardPanel();
            this.SuspendLayout();
            // 
            // ChessBoardPanel
            // 
            this.ChessBoardPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ChessBoardPanel.Location = new System.Drawing.Point(367, 21);
            this.ChessBoardPanel.Name = "ChessBoardPanel";
            this.ChessBoardPanel.Size = new System.Drawing.Size(400, 400);
            this.ChessBoardPanel.TabIndex = 0;
            // 
            // ChessGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChessBoardPanel);
            this.Name = "ChessGUI";
            this.Text = "ChessGUI";
            this.ResumeLayout(false);

        }

        #endregion

        private BoardPanel ChessBoardPanel;
    }
}