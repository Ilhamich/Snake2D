using BLSnakeLibrary;
using System;
using System.Windows.Forms;

namespace WFormsSnake
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GameSnake snakeGame = new GameSnake();
            Application.Run(new FormGameSnake(snakeGame));
        }
    }
}
