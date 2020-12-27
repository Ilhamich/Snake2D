using BLSnakeLibrary;
using System;
using System.Windows.Forms;

namespace Training_Snake
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
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
