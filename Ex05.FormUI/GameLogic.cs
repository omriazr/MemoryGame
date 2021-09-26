using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ex05.FormUI
{

    public class GameLogic
    {
        private GameSettingsForm m_GameSettings = new GameSettingsForm();
        private B20_Ex02.GameManager m_MemoryGame = new B20_Ex02.GameManager();
        private GameBoardForm m_GameBoard = new GameBoardForm();
        private eCurrentStep m_CurrentMove = eCurrentStep.FirstMove;
        private eCurrentPlayer m_CurrentPlayer = eCurrentPlayer.FirstPlayer;
        private B20_Ex02.Player m_CurrentPlayr;
        private B20_Ex02.Board m_Board;
        private int[] m_firstRowAndCol;
        private BoardProperties m_FirstMove = new BoardProperties(), m_SecondMove = new BoardProperties(), m_DataOfCurrentMove;

        internal void InitializeGameForm()
        {
            m_GameSettings.ShowDialog();

            if (m_GameSettings.DialogResult == DialogResult.OK)
            {
                InitializeGame();
                m_GameBoard.InitializeGameBoard(
                m_GameSettings.BoardProperties.Rows,
                m_GameSettings.BoardProperties.Columns,
                new EventHandler(button_Click),
                m_GameSettings.Players);
            }
        }

        internal void InitializeGame()
        {
            B20_Ex02.Player firstPlayer = new B20_Ex02.Player(m_GameSettings.FirstPlayer);
            m_MemoryGame.m_FirstPlayer = firstPlayer;
            B20_Ex02.Player SecondPlayer;
            if (m_GameSettings.AgainstComputer)
            {
                SecondPlayer = new B20_Ex02.Player();
            }
            else
            {
                SecondPlayer = new B20_Ex02.Player(m_GameSettings.SecondPlayer);
            }

            m_MemoryGame.m_SecondPlayer = SecondPlayer;
            B20_Ex02.Board board = new B20_Ex02.Board(m_GameSettings.BoardProperties.Rows, m_GameSettings.BoardProperties.Columns);
            m_Board = board;
            m_CurrentPlayr = m_MemoryGame.m_FirstPlayer;
            m_DataOfCurrentMove = m_FirstMove;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button currentButton = sender as Button;
            playerMove(currentButton);
        }

        internal void RunDialog()
        {
            m_GameBoard.ShowDialog();
        }

        private void playerMove(Button i_PressedButton)
        {
            string clickedCell = string.Format("{0}{1}", (char)(i_PressedButton.Name[6] + ('A' - '1')), i_PressedButton.Name[8]);
            bool isValidMove = m_Board.ValidCell(clickedCell);
            int[] firstRowAndCol = new int[3];
            char letterOfTheMove;
            bool equalLetters;

            if (isValidMove)
            {
                switch (m_CurrentMove)
                {
                    case eCurrentStep.FirstMove:
                        m_DataOfCurrentMove = m_FirstMove;
                        break;
                    case eCurrentStep.SecondMove:
                        m_DataOfCurrentMove = m_SecondMove;
                        break;
                    default:
                        break;
                }

                if (m_DataOfCurrentMove == m_FirstMove)
                {
                    m_firstRowAndCol = m_Board.FirstChoise(clickedCell);
                    letterOfTheMove = m_Board.WhichLetterInCell(clickedCell);
                }
                else
                {
                    equalLetters = m_Board.SecondChoise(clickedCell, m_firstRowAndCol, m_FirstMove.ValueOfCell);
                    letterOfTheMove = m_Board.WhichLetterInCell(clickedCell);
                }

                m_DataOfCurrentMove.Position = clickedCell;
                m_DataOfCurrentMove.ValueOfCell = letterOfTheMove;
                m_DataOfCurrentMove.Button = i_PressedButton;
                m_GameBoard.UpdateButton(m_DataOfCurrentMove, m_CurrentPlayer);

                m_GameBoard.Update();
                System.Threading.Thread.Sleep(500);

                if (m_CurrentMove == eCurrentStep.FirstMove)
                {
                    m_CurrentMove = eCurrentStep.SecondMove;
                }
                else
                {
                    handleEndOfRound();
                    m_CurrentMove = eCurrentStep.FirstMove;

                    if (m_CurrentPlayer == eCurrentPlayer.SecondPlayer && m_MemoryGame.m_SecondPlayer.Name.Equals("Computer"))
                    {
                        computerPlayer();
                    }
                }
            }
        }

        private void computerPlayer()
        {
            while (m_CurrentPlayer == eCurrentPlayer.SecondPlayer && !m_Board.IsFullBoard())
            {
                m_FirstMove.Position = m_Board.RandomValidCell();
                m_firstRowAndCol = m_Board.FirstChoise(m_FirstMove.Position);
                m_FirstMove.ValueOfCell = m_Board.WhichLetterInCell(m_FirstMove.Position);
                m_FirstMove.Button = findButtonFromBoardPos(m_FirstMove.Position);
                m_GameBoard.UpdateButton(m_FirstMove, m_CurrentPlayer);
                m_GameBoard.Update();
                System.Threading.Thread.Sleep(500);

                m_SecondMove.Position = m_Board.RandomValidCell();
                bool equalLetters = m_Board.SecondChoise(m_SecondMove.Position, m_firstRowAndCol, m_FirstMove.ValueOfCell);
                m_SecondMove.ValueOfCell = m_Board.WhichLetterInCell(m_SecondMove.Position);
                m_SecondMove.Button = findButtonFromBoardPos(m_SecondMove.Position);
                m_GameBoard.UpdateButton(m_SecondMove, m_CurrentPlayer);
                m_GameBoard.Update();
                System.Threading.Thread.Sleep(1000);
                handleEndOfRound();
            }      
        }

        private void handleEndOfRound()
        {
            const bool k_IsMatchPairs = true;

            if (m_FirstMove.ValueOfCell == m_SecondMove.ValueOfCell)
            {
                m_GameBoard.UpdateButtons(m_FirstMove, m_SecondMove, k_IsMatchPairs, m_CurrentPlayer, ++m_CurrentPlayr.NumberOfPoints);
            }
            else
            {
                m_GameBoard.UpdateButtons(m_FirstMove, m_SecondMove, !k_IsMatchPairs, m_CurrentPlayer, m_CurrentPlayr.NumberOfPoints);
                switchPlayer();
            }

            if (m_Board.IsFullBoard())
            {
                StringBuilder message = new StringBuilder();

                message.Append(m_MemoryGame.handleFullBoard());
                message.Append("\n\n\nDo you want to play another round?");

                if (MessageBox.Show(message.ToString(), "Game Results", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    m_MemoryGame.m_GameOver = true;
                    m_GameBoard.Close();
                }
                else
                {
                    m_MemoryGame = new B20_Ex02.GameManager();
                    InitializeGame();
                    m_GameBoard.ResetUI();
                }
            }
        }

        private void switchPlayer()
        {
            switch (m_CurrentPlayer)
            {
                case eCurrentPlayer.FirstPlayer:
                    m_CurrentPlayer = eCurrentPlayer.SecondPlayer;
                    m_CurrentPlayr = m_MemoryGame.m_SecondPlayer;
                    break;
                case eCurrentPlayer.SecondPlayer:
                    m_CurrentPlayer = eCurrentPlayer.FirstPlayer;
                    m_CurrentPlayr = m_MemoryGame.m_FirstPlayer;
                    break;
            }

            m_GameBoard.SwitchPlayer(m_CurrentPlayer, m_CurrentPlayr.Name);
        }

        private Button findButtonFromBoardPos(string i_ButtonPosition)
        {
            Button foundButton = null;
            string buttonName = string.Format("button{0}x{1}", (char)(i_ButtonPosition[0] - ('A' - '1')), i_ButtonPosition[1]);
            foreach (Button button in m_GameBoard.BoardButtons)
            {
                if (button.Name == buttonName)
                {
                    foundButton = button;
                    break;
                }
            }

            return foundButton;
        }

        private enum eCurrentStep
        {
            FirstMove = 1,
            SecondMove
        }

        internal enum eCurrentPlayer
        {
            FirstPlayer = 1,
            SecondPlayer
        }
    }
}
