using System;
using System.Text;

namespace B20_Ex02
{
    public class GameManager
    {
        private const string k_QuitGame = "Q";
        private int m_NumOfRows;
        private int m_NumOfColumns;
        public bool m_GameOver;
        private bool m_IsTwoPlayers;
        private bool m_IsFirstPlayerTurn;
        public Player m_FirstPlayer;
        public Player m_SecondPlayer;
        private Player m_CurrentPlayer;
        public Board m_BoardGame;
        private InputValidation m_InputValidation;
        public string m_FirstChoiseComputer;
        public string m_SecondChoiseComputer;

        public void FirstGame()
        {
            m_InputValidation = new InputValidation();
            m_FirstPlayer = new Player(m_InputValidation.GetNameFromPlayer());
            string numOfPlayers = m_InputValidation.GetNumberOfPlayers();

            if (int.Parse(numOfPlayers) == 2)
            {
                m_SecondPlayer = new Player(m_InputValidation.GetNameFromPlayer());
                m_IsTwoPlayers = true;
            }
            else
            {
                m_SecondPlayer = new Player();
                m_IsTwoPlayers = false;
            }

            Playgame();
        }
        
        internal void Playgame()
        {
            m_FirstPlayer.NumberOfPoints = 0;
            m_SecondPlayer.NumberOfPoints = 0;
            m_NumOfRows = int.Parse(m_InputValidation.GetRowsSizeFromPlayer());
            m_NumOfColumns = int.Parse(m_InputValidation.GetColumnsSizeFromPlayer());
            m_BoardGame = new Board(m_NumOfRows, m_NumOfColumns);
            m_CurrentPlayer = m_FirstPlayer;
            m_BoardGame.PrintGameBoard();
            m_IsFirstPlayerTurn = true;
            m_GameOver = false;
            bool successMatch = false;

            while (!m_GameOver)
            {
                m_BoardGame.PrintGameBoard();
                if (m_BoardGame.IsFullBoard())
                {
                    handleFullBoard();
                    m_GameOver = true;
                }
                else
                {
                    string firstCell;
                    m_CurrentPlayer = m_IsFirstPlayerTurn ? m_FirstPlayer : m_SecondPlayer;
                    if (m_IsFirstPlayerTurn || m_IsTwoPlayers)
                    {
                        Console.WriteLine(m_CurrentPlayer.Name + " Please choose the first cell i.g (B4,E1,A1...) to be revealed or press Q to quit");
                        firstCell = Console.ReadLine();
                        if (firstCell == k_QuitGame)
                        {
                            Environment.Exit(0);
                        }

                        while (!m_InputValidation.ValidCell(firstCell))
                        {
                            firstCell = Console.ReadLine();
                        }

                        if (m_InputValidation.ValidCell(firstCell))
                        {
                            int[] firstRowAndCol = m_BoardGame.FirstChoise(firstCell);
                            char firstLetter = m_BoardGame.WhichLetterInCell(firstCell);
                            successMatch = chooseSecondCell(firstRowAndCol, firstLetter);
                            if (successMatch)
                            {
                                m_CurrentPlayer.NumberOfPoints += 1;
                            }
                            else
                            {
                                m_IsFirstPlayerTurn = !m_IsFirstPlayerTurn;
                            }
                        }
                    }
                    else
                    {
                        successMatch = getComputerPlay();
                        if (successMatch)
                        {
                            m_CurrentPlayer.NumberOfPoints += 1;
                        }
                        else
                        {
                            m_IsFirstPlayerTurn = !m_IsFirstPlayerTurn;
                        }
                    }
                }
            }
        }
        
        private bool chooseSecondCell(int[] i_FirstChoise, char i_FirstLetter)
        {
            bool theLettersMatch = false;
            string secondCell;

            if (m_IsFirstPlayerTurn || m_IsTwoPlayers)
            {
                Console.WriteLine(m_CurrentPlayer.Name + " please choose a possibel maching cell or press Q to quit:");
                secondCell = Console.ReadLine();

                if (secondCell == k_QuitGame)
                {
                    Environment.Exit(0);
                }

                while (!m_InputValidation.ValidCell(secondCell))
                {
                    secondCell = Console.ReadLine();
                }

                if (m_InputValidation.ValidCell(secondCell))
                {
                    theLettersMatch = m_BoardGame.SecondChoise(secondCell, i_FirstChoise, i_FirstLetter);
                }
            }

            return theLettersMatch;
        }

        public bool getComputerPlay()
        {
            bool computerMatch = false;
            Random randomNumber = new Random();
            int randomCellRow = randomNumber.Next(0, m_NumOfRows) + 1;
            int randomCellColumn = randomNumber.Next(0, m_NumOfColumns);
            string firstCell = m_BoardGame.getStringRowAndColumn(randomCellColumn, randomCellRow);

            while (!m_InputValidation.ValidCell(firstCell))
            {
                randomCellRow = randomNumber.Next(0, m_NumOfRows) + 1;
                randomCellColumn = randomNumber.Next(0, m_NumOfColumns);

                firstCell = m_BoardGame.getStringRowAndColumn(randomCellColumn, randomCellRow);
            }

            m_FirstChoiseComputer = firstCell;

            int[] firstRowAndCol = m_BoardGame.FirstChoise(firstCell);
            char firstLetter = m_BoardGame.WhichLetterInCell(firstCell);

            randomCellRow = randomNumber.Next(0, m_NumOfRows) + 1;
            randomCellColumn = randomNumber.Next(0, m_NumOfColumns);
            string secondCell = m_BoardGame.getStringRowAndColumn(randomCellColumn, randomCellRow);

            while (!m_InputValidation.ValidCell(secondCell))
            {
                randomCellRow = randomNumber.Next(0, m_NumOfRows) + 1;
                randomCellColumn = randomNumber.Next(0, m_NumOfColumns);

                secondCell = m_BoardGame.getStringRowAndColumn(randomCellColumn, randomCellRow);
            }

            m_SecondChoiseComputer = secondCell;

            if (m_InputValidation.ValidCell(secondCell))
            {
                computerMatch = m_BoardGame.SecondChoise(secondCell, firstRowAndCol, firstLetter);
            }

            return computerMatch;
        }
       
        public string handleFullBoard()
        {
            string message = @"The game is over! {0}

Final points:
{1}: {2}
{3}: {4}";
            string messageWinner = string.Empty;

            if (m_FirstPlayer.NumberOfPoints > m_SecondPlayer.NumberOfPoints)
            {
                messageWinner = string.Format("\nThe Winner is: {0}", m_FirstPlayer.Name);
            }

            if (m_FirstPlayer.NumberOfPoints < m_SecondPlayer.NumberOfPoints)
            {
                messageWinner = string.Format("\nThe Winner is: {0}", m_SecondPlayer.Name);
            }

            if (m_FirstPlayer.NumberOfPoints == m_SecondPlayer.NumberOfPoints)
            {
                messageWinner = string.Format("\nIt is a draw!!");
            }

            return string.Format(message, messageWinner, m_FirstPlayer.Name, m_FirstPlayer.NumberOfPoints, m_SecondPlayer.Name, m_SecondPlayer.NumberOfPoints);
        }
    }
}
