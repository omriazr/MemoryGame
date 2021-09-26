namespace Ex05.FormUI
{
    public partial class GameSettingsForm
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
            this.firstPlayerName = new System.Windows.Forms.Label();
            this.secondPlayerName = new System.Windows.Forms.Label();
            this.boardSize = new System.Windows.Forms.Label();
            this.textBoxFirstPlayer = new System.Windows.Forms.TextBox();
            this.textBoxSecondPlayer = new System.Windows.Forms.TextBox();
            this.buttonSecondPlayerSelection = new System.Windows.Forms.Button();
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstPlayerName
            // 
            this.firstPlayerName.AutoSize = true;
            this.firstPlayerName.Location = new System.Drawing.Point(19, 20);
            this.firstPlayerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firstPlayerName.Name = "firstPlayerName";
            this.firstPlayerName.Size = new System.Drawing.Size(137, 20);
            this.firstPlayerName.TabIndex = 0;
            this.firstPlayerName.Text = "First Player Name:";
            // 
            // secondPlayerName
            // 
            this.secondPlayerName.AutoSize = true;
            this.secondPlayerName.Location = new System.Drawing.Point(18, 60);
            this.secondPlayerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.secondPlayerName.Name = "secondPlayerName";
            this.secondPlayerName.Size = new System.Drawing.Size(161, 20);
            this.secondPlayerName.TabIndex = 2;
            this.secondPlayerName.Text = "Second Player Name:";
            this.secondPlayerName.Click += new System.EventHandler(this.label2_Click);
            // 
            // boardSize
            // 
            this.boardSize.AutoSize = true;
            this.boardSize.Location = new System.Drawing.Point(18, 109);
            this.boardSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.boardSize.Name = "boardSize";
            this.boardSize.Size = new System.Drawing.Size(91, 20);
            this.boardSize.TabIndex = 5;
            this.boardSize.Text = "Board Size:";
            // 
            // textBoxFirstPlayer
            // 
            this.textBoxFirstPlayer.Location = new System.Drawing.Point(205, 16);
            this.textBoxFirstPlayer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxFirstPlayer.Name = "textBoxFirstPlayer";
            this.textBoxFirstPlayer.Size = new System.Drawing.Size(134, 26);
            this.textBoxFirstPlayer.TabIndex = 1;
            // 
            // textBoxSecondPlayer
            // 
            this.textBoxSecondPlayer.Enabled = false;
            this.textBoxSecondPlayer.Location = new System.Drawing.Point(205, 56);
            this.textBoxSecondPlayer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxSecondPlayer.Name = "textBoxSecondPlayer";
            this.textBoxSecondPlayer.Size = new System.Drawing.Size(134, 26);
            this.textBoxSecondPlayer.TabIndex = 3;
            this.textBoxSecondPlayer.Text = "-computer-";
            // 
            // buttonSecondPlayerSelection
            // 
            this.buttonSecondPlayerSelection.Location = new System.Drawing.Point(369, 52);
            this.buttonSecondPlayerSelection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSecondPlayerSelection.Name = "buttonSecondPlayerSelection";
            this.buttonSecondPlayerSelection.Size = new System.Drawing.Size(145, 31);
            this.buttonSecondPlayerSelection.TabIndex = 4;
            this.buttonSecondPlayerSelection.Text = "Against a Friend";
            this.buttonSecondPlayerSelection.UseVisualStyleBackColor = true;
            this.buttonSecondPlayerSelection.Click += new System.EventHandler(this.buttonSecondPlayerChoose_Click);
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonBoardSize.Location = new System.Drawing.Point(14, 135);
            this.buttonBoardSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(168, 104);
            this.buttonBoardSize.TabIndex = 6;
            this.buttonBoardSize.Text = "4 x 4";
            this.buttonBoardSize.UseVisualStyleBackColor = false;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonStartGame.Location = new System.Drawing.Point(385, 196);
            this.buttonStartGame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(129, 42);
            this.buttonStartGame.TabIndex = 7;
            this.buttonStartGame.Text = "Start!";
            this.buttonStartGame.UseVisualStyleBackColor = false;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // GameSettingsForm
            // 
            this.AcceptButton = this.buttonStartGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 255);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.buttonBoardSize);
            this.Controls.Add(this.boardSize);
            this.Controls.Add(this.buttonSecondPlayerSelection);
            this.Controls.Add(this.textBoxSecondPlayer);
            this.Controls.Add(this.textBoxFirstPlayer);
            this.Controls.Add(this.secondPlayerName);
            this.Controls.Add(this.firstPlayerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Memory Game - Settings";
            this.Load += new System.EventHandler(this.GameSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstPlayerName;
        private System.Windows.Forms.Label secondPlayerName;
        private System.Windows.Forms.TextBox textBoxFirstPlayer;
        private System.Windows.Forms.TextBox textBoxSecondPlayer;
        private System.Windows.Forms.Button buttonSecondPlayerSelection;
        private System.Windows.Forms.Label boardSize;
        private System.Windows.Forms.Button buttonBoardSize;
        private System.Windows.Forms.Button buttonStartGame;
    }
}