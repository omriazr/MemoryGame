using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ex05.FormUI
{
    public class BoardProperties
    {
        private string m_Position;
        private char m_ValueOfCell;
        private Button m_RelatedButtom;
        
        internal Button Button
        {
            get { return m_RelatedButtom; }
            set { m_RelatedButtom = value; }
        }

        internal char ValueOfCell
        {
            get { return m_ValueOfCell; }
            set { m_ValueOfCell = value; }
        }

        internal string Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }

        public int Columns
        {
            get { return this.ToString()[0] - '0'; }
        }

        internal int Rows
        {
            get { return this.ToString()[4] - '0'; }
        }
    
        internal void NextSizeOfBoard()
        {
            if (m_BoardSize == eBoardSize.Size6x6)
            {
                m_BoardSize = eBoardSize.Size4x4;
            }
            else
            {
                m_BoardSize++;
            }
        }

        private eBoardSize m_BoardSize = eBoardSize.Size4x4;

        public override string ToString()
        {
            string bordSizeAsString;

            switch (m_BoardSize)
            {
                case eBoardSize.Size4x4:
                    bordSizeAsString = "4 x 4";
                    break;
                case eBoardSize.Size4x5:
                    bordSizeAsString = "4 x 5";
                    break;
                case eBoardSize.Size4x6:
                    bordSizeAsString = "4 x 6";
                    break;
                case eBoardSize.Size5x4:
                    bordSizeAsString = "5 x 4";
                    break;
                case eBoardSize.Size5x6:
                    bordSizeAsString = "5 x 6";
                    break;
                case eBoardSize.Size6x4:
                    bordSizeAsString = "6 x 4";
                    break;
                case eBoardSize.Size6x5:
                    bordSizeAsString = "6 x 5";
                    break;
                case eBoardSize.Size6x6:
                    bordSizeAsString = "6 x 6";
                    break;
                default:
                    bordSizeAsString = string.Empty;
                    break;
            }

            return bordSizeAsString;
        }

        private enum eBoardSize
        {
            Size4x4,
            Size4x5,
            Size4x6,
            Size5x4,
            Size5x6,
            Size6x4,
            Size6x5,
            Size6x6,
        }
    }
}
