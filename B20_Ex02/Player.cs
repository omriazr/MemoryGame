using System;

namespace B20_Ex02
{
    public class Player
    {
        private string m_Name;
        private int m_NumberOfPoints;

        public Player(string i_UserName)
        {
            m_Name = i_UserName;
            m_NumberOfPoints = 0;
        }

        public Player()
        {
            m_Name = "Computer";
            m_NumberOfPoints = 0;
        }

        public int NumberOfPoints
        {
            get
            {
                return m_NumberOfPoints;
            }

            set
            {
                m_NumberOfPoints = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }
    }
}