using System;

namespace B20_Ex02
{
    public class InputValidation
    {
        private int m_NumberOfRows;
        public Board m_Board;

        internal string GetNameFromPlayer()
        {
            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine();

            while (!isplayerNameValid(playerName))
            {
                Console.WriteLine("Your name is invalid! Please enter your name again.");
                playerName = Console.ReadLine();
            }

            return playerName;
        }

        internal string GetNumberOfPlayers()
        {
            Console.WriteLine("Press 1 to play against the computer, 2 for a two-player game:");
            string numberOfPlayers = Console.ReadLine();

            while (!int.TryParse(numberOfPlayers, out int integerNumOfPlayers)
               || (!(integerNumOfPlayers == 1) && !(integerNumOfPlayers == 2)))
            {
                Console.WriteLine("Invalid number of players! The number of players can be 1 or 2, Please try again");
                numberOfPlayers = Console.ReadLine();
            }

            return numberOfPlayers;
        }

        internal string GetRowsSizeFromPlayer()
        {
            Console.WriteLine("Please enter the number of rows (4,5 or 6 rows):");
            string rowsSize = Console.ReadLine();

            while (!isRowsSizeValid(rowsSize))
            {
                rowsSize = Console.ReadLine();
            }

            return rowsSize;
        }

        internal string GetColumnsSizeFromPlayer()
        {
            Console.WriteLine("Please enter the number of columns 4,6 or, 5 if you enter an even number of rows:");
            string columnsSize = Console.ReadLine();

            while (!isColumnSizeValid(columnsSize))
            {
                columnsSize = Console.ReadLine();
            }

            return columnsSize;
        }

        private bool isColumnSizeValid(string i_ColumnsSize)
        {
            bool columnsSizeIsValid = true;

            if (!int.TryParse(i_ColumnsSize, out int integerColumnsSize))
            {
                columnsSizeIsValid = false;
            }
            else
            {
                if (integerColumnsSize < 4 || integerColumnsSize > 6)
                {
                    columnsSizeIsValid = false;
                    Console.WriteLine("Invalid number of columns! Please try again:");
                }
                else if ((integerColumnsSize * m_NumberOfRows) % 2 == 1)
                {
                    columnsSizeIsValid = false;
                    Console.WriteLine("Invalid number of columns! The number of cells is odd. Please try again:");
                }
            }

            return columnsSizeIsValid;
        }

        private bool isRowsSizeValid(string i_RowsSize)
        {
            bool rowsSizeIsValid = true;

            if (!int.TryParse(i_RowsSize, out int integerRowsSize))
            {
                rowsSizeIsValid = false;
            }
            else
            {
                m_NumberOfRows = integerRowsSize;
                if (integerRowsSize < 4 || integerRowsSize > 6)
                {
                    rowsSizeIsValid = false;
                    Console.WriteLine("Invalid number of rows! Please try again:");
                }
            }

            return rowsSizeIsValid;
        }

        private bool isplayerNameValid(string i_Name)
        {
            return i_Name.Length > 0;
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
                int[] rowAndColumn = m_Board.GetRowAndColumnFromString(i_InputRowAndcolumns);
                int cellColumn = rowAndColumn[0];
                int cellRow = rowAndColumn[1];

                if (cellRow < 0 || cellRow > m_Board.GetNumOfRows())
                {
                    Console.WriteLine("Invalid row, please try again");
                    validCell = false;
                }
                else if (cellColumn < 0 || cellColumn > m_Board.GetNumOfColumns())
                {
                    Console.WriteLine("Invalid column, please try again");
                    validCell = false;
                }
                else if (m_Board.IsCellRevealed(cellColumn, cellRow - 1))
                {
                    Console.WriteLine("This cell is revealed, please try again");
                    validCell = false;
                }
            }

            return validCell;
        }
    }
}
