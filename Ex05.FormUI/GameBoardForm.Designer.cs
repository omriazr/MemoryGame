namespace Ex05.FormUI
{
    public partial class GameBoardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void initializeComponent()
        {
            this.currentPlayerLabel = new System.Windows.Forms.Label();
            this.labelCurrentPlayer = new System.Windows.Forms.Label();
            this.firstPlayerNameLabel = new System.Windows.Forms.Label();
            this.firstPlayerPairsLabel = new System.Windows.Forms.Label();
            this.secondPlayerNameLabel = new System.Windows.Forms.Label();
            this.secondPlayerPairsLable = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.currentPlayerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentPlayerLabel.Name = "currentPlayerLabel";
            this.currentPlayerLabel.AutoSize = true;
            this.currentPlayerLabel.Location = new System.Drawing.Point(120, 600);
            this.currentPlayerLabel.Text = "Player Name";

            this.labelCurrentPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCurrentPlayer.Name = "labelCurrentPlayer:";
            this.labelCurrentPlayer.AutoSize = true;
            this.labelCurrentPlayer.Location = new System.Drawing.Point(18, 600);
            this.labelCurrentPlayer.Text = "Current Player: ";

            this.firstPlayerNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.firstPlayerNameLabel.Name = "firstPlayerNameLabel";
            this.firstPlayerNameLabel.AutoSize = true;
            this.firstPlayerNameLabel.BackColor = System.Drawing.Color.PaleGreen;
            this.firstPlayerNameLabel.ForeColor = System.Drawing.Color.Black;
            this.firstPlayerNameLabel.Location = new System.Drawing.Point(18, 630);
            this.firstPlayerNameLabel.Text = "Player Name:";
            this.firstPlayerNameLabel.Click += new System.EventHandler(this.labelFirstPlayerName_Click);

            this.firstPlayerPairsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.firstPlayerPairsLabel.Name = "firstPlayerPairsLabel";
            this.firstPlayerPairsLabel.AutoSize = true;
            this.firstPlayerPairsLabel.BackColor = System.Drawing.Color.PaleGreen;
            this.firstPlayerPairsLabel.Location = new System.Drawing.Point(110, 630);
            this.firstPlayerPairsLabel.Text = "0 Pairs";

            this.secondPlayerNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.secondPlayerNameLabel.Name = "secondPlayerNameLabel";
            this.secondPlayerNameLabel.AutoSize = true;
            this.secondPlayerNameLabel.BackColor = System.Drawing.Color.MediumPurple;
            this.secondPlayerNameLabel.Location = new System.Drawing.Point(18, 665);
            this.secondPlayerNameLabel.Text = "Player Name:";
            
            this.secondPlayerPairsLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.secondPlayerPairsLable.Name = "secondPlayerPairsLable";
            this.secondPlayerPairsLable.AutoSize = true;
            this.secondPlayerPairsLable.BackColor = System.Drawing.Color.MediumPurple;
            this.secondPlayerPairsLable.Location = new System.Drawing.Point(110, 665);
            this.secondPlayerPairsLable.Text = "0 Pairs";
               
            this.Controls.Add(this.currentPlayerLabel);
            this.Controls.Add(this.labelCurrentPlayer);
            this.Controls.Add(this.firstPlayerNameLabel);
            this.Controls.Add(this.firstPlayerPairsLabel);
            this.Controls.Add(this.secondPlayerNameLabel);
            this.Controls.Add(this.secondPlayerPairsLable);
            this.MaximizeBox = true;
            this.Name = "GameBoardForm";
            this.Text = "Memory Game";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F,18F);
            this.ClientSize = new System.Drawing.Size(620, 760);
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Load += new System.EventHandler(this.GameBoardForm_Load);
            this.ResumeLayout();
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label currentPlayerLabel;
        private System.Windows.Forms.Label labelCurrentPlayer;
        private System.Windows.Forms.Label firstPlayerNameLabel;
        private System.Windows.Forms.Label firstPlayerPairsLabel;
        private System.Windows.Forms.Label secondPlayerNameLabel;
        private System.Windows.Forms.Label secondPlayerPairsLable;
    }
}