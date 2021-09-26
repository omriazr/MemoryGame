using System;
using System.Text;

namespace B20_Ex02
{
    public class Board
    {
        private readonly int r_NumOfRows;
        private readonly int r_NumOfColumns;
        private char[,] m_Board;
        private char[,] m_ManageBoard;
        private int[,] m_IndexOfEmptyCells;

        public Board(int i_NumOfRows, int i_NumOfColumns)
        {
            r_NumOfRows = i_NumOfRows;
            r_NumOfColumns = i_NumOfColumns;
            m_Board = new char[i_NumOfRows, i_NumOfColumns];
            m_ManageBoard = new char[i_NumOfRows, i_NumOfColumns];
            m_IndexOfEmptyCells = new int[i_NumOfRows, i_NumOfColumns];
            StartNewGame();
        }

        private void buildTheManageBoard()
        {
            char[] lettersRandom = new char[(r_NumOfRows * r_NumOfColumns) / 2];
            int lettersRandomLength = lettersRandom.Length;
            Random randomNumber = new Random();
            bool validRandomChar = true;

            for (int i = 0; i < lettersRandomLength; i++)
            {
                int num = randomNumber.Next(0, 26);
                char randomChar = (char)('A' + num);
                validRandomChar = ifThisCharInArray(lettersRandom, randomChar);
                while (!validRandomChar)
                {
                    num = randomNumber.Next(0, 26);
                    randomChar = (char)('A' + num);
                    validRandomChar = ifThisCharInArray(lettersRandom, randomChar);
                }

                if (validRandomChar)
                {
                    lettersRandom[i] = randomChar;
                }
            }

            int randomCellRow = randomNumber.Next(0, r_NumOfRows);
            int randomCellColumn = randomNumber.Next(0, r_NumOfColumns);
            int randomCellRowSecond = randomNumber.Next(0, r_NumOfRows);
            int randomCellColumnSecond = randomNumber.Next(0, r_NumOfColumns);

            for (int j = 0; j < lettersRandomLength; j++)
            {
                while (m_ManageBoard[randomCellRow, randomCellColumn] != default(char))
                {
                    randomCellRow = randomNumber.Next(0, r_NumOfRows);
                    randomCellColumn = randomNumber.Next(0, r_NumOfColumns);
                }

                m_ManageBoard[randomCellRow, randomCellColumn] = lettersRandom[j];

                while (m_ManageBoard[randomCellRowSecond, randomCellColumnSecond] != default(char))
                {
                    randomCellRowSecond = randomNumber.Next(0, r_NumOfRows);
                    randomCellColumnSecond = randomNumber.Next(0, r_NumOfColumns);
                }

                m_ManageBoard[randomCellRowSecond, randomCellColumnSecond] = lettersRandom[j];
            }
        }

        private bool ifThisCharInArray(char[] i_ArrayChar, char i_CharToCheck)
        {
            bool validRandomChar = true;
            for (int i = 0; i < i_ArrayChar.Length; i++)
            {
                if (i_ArrayChar[i].Equals(i_CharToCheck))
                {
                    validRandomChar = false;
                }
            }

            return validRandomChar;
        }

        public int GetNumOfRows()
        {
            return r_NumOfRows;
        }

        public int GetNumOfColumns()
        {
            return r_NumOfColumns;
        }

        private void initializeIndexOfEmptyCells()
        {
            for (int i = 0; i < r_NumOfRows; i++)
            {
                for (int j = 0; j < r_NumOfColumns; j++)
                {
                    m_IndexOfEmptyCells[i, j] = 0;
                }
            }
        }

        private void initializeBoard()
        {
            for (int i = 0; i < r_NumOfRows; i++)
            {
                for (int j = 0; j < r_NumOfColumns; j++)
                {
                    m_Board[i, j] = ' ';
                }
            }
        }

        internal char GetCellOfBoard(int i_Row, int i_Column)
        {
            return m_Board[i_Row, i_Column];
        }

        internal bool IsCellRevealed(int i_Column, int i_Row)
        {
            bool isCellRevealed = m_IndexOfEmptyCells[i_Row, i_Column] != 0;

            return isCellRevealed;
        }

        public bool IsFullBoard()
        {
            bool isFullBoard = true;

            for (int i = 0; i < r_NumOfRows; i++)
            {
                for (int j = 0; j < r_NumOfColumns; j++)
                {
                    if (!IsCellRevealed(j, i))
                    {
                        isFullBoard = false;
                    }
                }
            }

            return isFullBoard;
        }

        public char WhichLetterInCell(string i_InputRowAndcolumns)
        {
            int[] rowAndColumn = GetRowAndColumnFromString(i_InputRowAndcolumns);
            int inputColumn = rowAndColumn[0];
            int inputRow = rowAndColumn[1] - 1;

            return m_ManageBoard[inputRow, inputColumn];
        }

        public int[] FirstChoise(string i_InputRowAndcolumns)
        {
            int[] rowAndColumn = GetRowAndColumnFromString(i_InputRowAndcolumns);
            int firstChoosecolumn = rowAndColumn[0];
            int firstChooseRow = rowAndColumn[1];

            m_Board[firstChooseRow - 1, firstChoosecolumn] = m_ManageBoard[firstChooseRow - 1, firstChoosecolumn];
            m_IndexOfEmptyCells[firstChooseRow - 1, firstChoosecolumn] = 1;
            PrintGameBoard();

            return rowAndColumn;
        }

        public bool SecondChoise(string i_InputRowAndcolumns, int[] i_TheFirstChoiseOfCell, char i_TheFirstchoiseLetter)
        {
            int[] rowAndColumn = GetRowAndColumnFromString(i_InputRowAndcolumns);
            int secondChooseColumn = rowAndColumn[0];
            int secondChooseRow = rowAndColumn[1];
            bool equalLetters = false;

            if (ValidCell(i_InputRowAndcolumns))
            {
                m_Board[secondChooseRow - 1, secondChooseColumn] = m_ManageBoard[secondChooseRow - 1, secondChooseColumn];
                if (m_Board[secondChooseRow - 1, secondChooseColumn].Equals(i_TheFirstchoiseLetter))
                {
                    PrintGameBoard();
                    equalLetters = true;
                    m_IndexOfEmptyCells[secondChooseRow - 1, secondChooseColumn] = 1;
                }
                else
                {
                    equalLetters = false;
                    m_Board[secondChooseRow - 1, secondChooseColumn] = ' ';
                    m_Board[i_TheFirstChoiseOfCell[1] - 1, i_TheFirstChoiseOfCell[0]] = ' ';
                    m_IndexOfEmptyCells[i_TheFirstChoiseOfCell[1] - 1, i_TheFirstChoiseOfCell[0]] = 0;
                }
            }

            return equalLetters;
        }

        internal int[] GetRowAndColumnFromString(string i_InputRowAndcolumns)
        {
            string inputRowAndcolumns = i_InputRowAndcolumns;
            char[] stringToCharArray = inputRowAndcolumns.ToCharArray();
            int[] rowAndColumn = new int[2];
            rowAndColumn[0] = charToIntColumn(stringToCharArray[0]);
            rowAndColumn[1] = charToIntRow(stringToCharArray[1]);
            return rowAndColumn;
        }

        private int charToIntColumn(char i_Inputletter)
        {
            return (int)(i_Inputletter - 'A');
        }

        private int charToIntRow(char i_Inputletter)
        {
            return (int)(i_Inputletter - '0');
        }

        internal void PrintGameBoard()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("    ");
            for (int i = 0; i < r_NumOfColumns; i++)
            {
                stringBuilder.Append(string.Format(" {0}   ", (char)(i + 65)));
            }

            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("  =");
            for (int j = 0; j < r_NumOfColumns; j++)
            {
                stringBuilder.Append("=====");
            }

            stringBuilder.Append(Environment.NewLine);

            for (int i = 0; i < r_NumOfRows; i++)
            {
                stringBuilder.Append(i + 1 + " ");
                for (int j = 0; j < r_NumOfColumns; j++)
                {
                    stringBuilder.Append(string.Format("| {0}  ", GetCellOfBoard(i, j)));
                }

                stringBuilder.Append("|");
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append("  ");
                for (int j = 0; j < r_NumOfColumns; j++)
                {
                    stringBuilder.Append("=====");
                }

                stringBuilder.Append("=");
                if (i != r_NumOfRows - 1)
                {
                    stringBuilder.Append(Environment.NewLine);
                }
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        internal void StartNewGame()
        {
            initializeBoard();
            initializeIndexOfEmptyCells();
            PrintGameBoard();
            buildTheManageBoard();
        }

        public bool ValidCell(string i_InputRowAndcolumns)
        {
            bool validCell = true;
            if (i_InputRowAndcolumns.Length != 2)
            {
                Console.WriteLine("Invalid input, please try again");
                validCell = false;
            }
            else
            {
                int[] rowAndColumn = GetRowAndColumnFromString(i_InputRowAndcolumns);
                int cellColumn = rowAndColumn[0];
                int cellRow = rowAndColumn[1];

                if (cellRow < 0 || cellRow > GetNumOfRows())
                {
                    Console.WriteLine("Invalid row, please try again");
                    validCell = false;
                }
                else if (cellColumn < 0 || cellColumn > GetNumOfColumns())
                {
                    Console.WriteLine("Invalid column, please try again");
                    validCell = false;
                }
                else if (IsCellRevealed(cellColumn, cellRow - 1))
                {
                    Console.WriteLine("This cell is revealed, please try again");
                    validCell = false;
                }
            }

            return validCell;
        }

        public string RandomValidCell()
        {
            Random randomNumber = new Random();
            int randomCellRow = randomNumber.Next(0, r_NumOfRows) + 1;
            int randomCellColumn = randomNumber.Next(0, r_NumOfColumns);
            string firstCell = getStringRowAndColumn(randomCellColumn, randomCellRow);

            while (!ValidCell(firstCell))
            {
                randomCellRow = randomNumber.Next(0, r_NumOfRows) + 1;
                randomCellColumn = randomNumber.Next(0, r_NumOfRows);

                firstCell = getStringRowAndColumn(randomCellColumn, randomCellRow);
            }

            return firstCell;
        }

        internal string getStringRowAndColumn(int i_CellColumn, int i_CellRow)
        {
            char charCellColumn = (char)('A' + i_CellColumn);
            string stringCellRow = i_CellRow.ToString();
            char charCellRow = stringCellRow[0];
            StringBuilder stringRowAndColumn = new StringBuilder(string.Empty);
            stringRowAndColumn.Append(charCellColumn);
            stringRowAndColumn.Append(charCellRow);
            string RowAndColumn = stringRowAndColumn.ToString();

            return RowAndColumn;
        }
    }
}
