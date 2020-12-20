using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLSnakeLibrary;

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
