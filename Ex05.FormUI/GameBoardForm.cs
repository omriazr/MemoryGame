using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05.FormUI
{
    public partial class GameBoardForm : Form
    {
        private List<Button> m_GameButtons = new List<Button>();
        private Color m_FirstPlayerColor;
        private Color m_SecondPlayerColor;

        public GameBoardForm()
        {
            initializeComponent();
        }

        public List<Button> BoardButtons
        {
            get { return m_GameButtons; }
        }

        internal void InitializeGameBoard(
            int i_NumberOfRows,
            int i_NumberOfColums,
            EventHandler i_ClickHandler,
            List<string> i_PlayersName)
        {
            const int k_WidthBetweenButtons = 5;
            const int k_WidthBetweenBoarderToBottun = 15;

            this.Size = new Size(
                (k_WidthBetweenBoarderToBottun * 2) + (i_NumberOfColums * 70) + ((i_NumberOfColums * 2 * k_WidthBetweenButtons) + 5),
                k_WidthBetweenBoarderToBottun + (i_NumberOfRows * 70) + (i_NumberOfRows * (2 * k_WidthBetweenButtons)) + 115);

            for (int row = 0; row < i_NumberOfRows; row++)
            {
                for (int col = 0; col < i_NumberOfColums; col++)
                {
                    Button newButton = new Button();
                    newButton.Name = "button" + (col + 1) + "x" + (row + 1);
                    newButton.Size = new Size(70, 70);
                    newButton.Left = this.Left + (col * 80) + k_WidthBetweenBoarderToBottun;
                    newButton.Top = this.Top + (row * 80) + k_WidthBetweenBoarderToBottun;
                    newButton.BackColor = SystemColors.Control;
                    newButton.Click += i_ClickHandler;
                    this.Controls.Add(newButton);
                    m_GameButtons.Add(newButton);
                }
            }

            currentPlayerLabel.Text = firstPlayerNameLabel.Text = i_PlayersName[0];
            secondPlayerNameLabel.Text = i_PlayersName[1];
            m_FirstPlayerColor = labelCurrentPlayer.BackColor = currentPlayerLabel.BackColor = firstPlayerNameLabel.BackColor;
            m_SecondPlayerColor = secondPlayerNameLabel.BackColor;
        }

        internal void UpdateButton(BoardProperties i_DataOfMove, GameLogic.eCurrentPlayer i_CurrentPlayer)
        {
            i_DataOfMove.Button.Text = i_DataOfMove.ValueOfCell.ToString();
            i_DataOfMove.Button.BackColor = getPlayerColor(i_CurrentPlayer);
        }

        internal void UpdateButtons(
            BoardProperties i_FirstMoveData,
            BoardProperties i_SecondMoveData,
            bool i_StoreData,
            GameLogic.eCurrentPlayer i_CurrentPlayer,
            int i_UsersScore)
        {
            string cellValue = i_StoreData ? i_FirstMoveData.ValueOfCell.ToString() : string.Empty;
            string playrScore = string.Format("{0} Pair{1}", i_UsersScore, i_UsersScore != 1 ? "s" : "(s)");
            Color color = i_StoreData ? getPlayerColor(i_CurrentPlayer) : SystemColors.Control;
            i_FirstMoveData.Button.BackColor = i_SecondMoveData.Button.BackColor = color;
            i_FirstMoveData.Button.Text = i_SecondMoveData.Button.Text = cellValue;
            updatePlayer(playrScore, i_CurrentPlayer);
        }

        private Color getPlayerColor(GameLogic.eCurrentPlayer i_CurrentPlayer)
        {
            Color color;
            switch (i_CurrentPlayer)
            {
                case GameLogic.eCurrentPlayer.FirstPlayer:
                    color = m_FirstPlayerColor;
                    break;
                case GameLogic.eCurrentPlayer.SecondPlayer:
                    color = m_SecondPlayerColor;
                    break;
                default:
                    color = m_FirstPlayerColor;
                    break;
            }

            return color;
        }

        private void updatePlayer(string i_PlayerScore, GameLogic.eCurrentPlayer i_CurrentPlayer)
        {
            switch (i_CurrentPlayer)
            {
                case GameLogic.eCurrentPlayer.FirstPlayer:
                    firstPlayerPairsLabel.Text = i_PlayerScore;
                    break;
                case GameLogic.eCurrentPlayer.SecondPlayer:
                    secondPlayerPairsLable.Text = i_PlayerScore;
                    break;
                default:
                    break;
            }
        }

        internal void SwitchPlayer(GameLogic.eCurrentPlayer i_CurrentPlayer, string i_UserName)
        {
            currentPlayerLabel.Text = i_UserName;
            labelCurrentPlayer.BackColor = currentPlayerLabel.BackColor = getPlayerColor(i_CurrentPlayer);
        }

        internal void ResetUI()
        {
            currentPlayerLabel.Text = firstPlayerNameLabel.Text;
            currentPlayerLabel.BackColor = labelCurrentPlayer.BackColor = m_FirstPlayerColor;
            updatePlayer("0 Pairs", GameLogic.eCurrentPlayer.FirstPlayer);
            updatePlayer("0 Pairs", GameLogic.eCurrentPlayer.SecondPlayer);
            foreach (Button button in m_GameButtons)
            {
                button.BackColor = SystemColors.Control;
                button.Text = string.Empty;
            }

            m_GameButtons[0].Select();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
        }

        private void labelFirstPlayerName_Click(object sender, EventArgs e)
        {
        }

        private void GameBoardForm_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "GameBoardForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GameBoardForm_Load_1);
            this.ResumeLayout(false);
        }

        private void GameBoardForm_Load_1(object sender, EventArgs e)
        {
        }
    }
}
