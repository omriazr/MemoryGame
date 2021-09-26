using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ex05.FormUI
{
    public partial class GameSettingsForm : Form
    {
        private bool m_TextBoxFriend = false;
        private BoardProperties m_BoardProperties = new BoardProperties();

        public GameSettingsForm()
        {
            InitializeComponent();
            buttonBoardSize.Text = m_BoardProperties.ToString();
        }

        private void buttonSecondPlayerChoose_Click(object sender, EventArgs e)
        {
            const bool v_ButtonEnabled = true;

            if (m_TextBoxFriend)
            {
                buttonSecondPlayerSelection.Text = "Against a Friend";
                textBoxSecondPlayer.Enabled = !v_ButtonEnabled;
                textBoxSecondPlayer.Text = "-computer-";
            }
            else
            {
                buttonSecondPlayerSelection.Text = "Against Computer";
                textBoxSecondPlayer.Enabled = v_ButtonEnabled;
                textBoxSecondPlayer.Text = string.Empty;
            }

            m_TextBoxFriend = !m_TextBoxFriend;
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            if (textBoxFirstPlayer.Text != string.Empty && textBoxSecondPlayer.Text != string.Empty)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                string message, caption = "Error!";

                if (textBoxFirstPlayer.Text == string.Empty && textBoxSecondPlayer.Text == string.Empty)
                {
                    message = "Please enter your name.";
                }
                else if (textBoxFirstPlayer.Text == string.Empty)
                {
                    message = "First player name was not entered.";
                }
                else
                {
                    message = "Second player name was not entered.";
                }

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            m_BoardProperties.NextSizeOfBoard();
            buttonBoardSize.Text = m_BoardProperties.ToString();
        }

        public string FirstPlayer
        {
            get { return textBoxFirstPlayer.Text; }
        }

        public string SecondPlayer
        {
            get { return textBoxSecondPlayer.Text; }
        }

        public List<string> Players
        {
            get
            {
                List<string> players = new List<string>();
                players.Add(textBoxFirstPlayer.Text);
                players.Add(textBoxSecondPlayer.Text);
                return players;
            }
        }

        public bool AgainstComputer
        {
            get { return !m_TextBoxFriend; }
        }

        internal BoardProperties BoardProperties
        {
            get { return m_BoardProperties; }
        }

        private void GameSettingsForm_Load(object sender, EventArgs e)
        {
        }

        private void textBoxFirstPlayer_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}
