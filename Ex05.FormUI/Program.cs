using System;
using System.Windows.Forms;

namespace Ex05.FormUI
{
    public class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            GameLogic game = new GameLogic();
            game.InitializeGameForm();
            game.RunDialog();
        }
    }
}
