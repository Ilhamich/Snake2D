using BLSnakeLibrary;
using System.Windows.Forms;

namespace WFormsSnake
{
    class FormController
    {
        public static void GiveDirectionInputKey
              (GameSnake game, Keys key, ref InputUser direction)
        {
            switch (key)
            {
                case Keys.Left:
                    if (game.SnakeObj.Head.Coord.X - game.StepDisplay
                            != game.SnakeObj[0].Coord.X)
                    {
                        direction = InputUser.LeftArrow;
                    }
                    break;

                case Keys.Right:
                    if ( game.SnakeObj.Head.Coord.X + game.StepDisplay
                            != game.SnakeObj[0].Coord.X)
                    {
                        direction = InputUser.RightArrow;
                    }
                    break;

                case Keys.Up:
                    if (game.SnakeObj.Head.Coord.Y - game.StepDisplay
                            != game.SnakeObj[0].Coord.Y)
                    {
                        direction = InputUser.UpArrow;
                    }
                    break;

                case Keys.Down:
                    if (game.SnakeObj.Head.Coord.Y + game.StepDisplay
                            != game.SnakeObj[0].Coord.Y)
                    {
                        direction = InputUser.DownArrow;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
