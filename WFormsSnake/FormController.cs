using BLSnakeLibrary;
using System.Windows.Forms;

namespace Training_Snake
{
    class FormController
    {
        public static void GiveDirectionInputKey
              (GameSnake game, Keys key, ref InputUser direction)
        {
            switch (key)
            {
                case Keys.Left:
                    if (direction != InputUser.RightArrow
                            && game.SnakeObj.Head.Coord.X - game.StepDisplay
                            != game.SnakeObj[0].Coord.X)
                    {
                        direction = InputUser.LeftArrow;
                    }
                    break;

                case Keys.Right:
                    if (direction != InputUser.LeftArrow
                            && game.SnakeObj.Head.Coord.X + game.StepDisplay
                            != game.SnakeObj[0].Coord.X)
                    {
                        direction = InputUser.RightArrow;
                    }
                    break;

                case Keys.Up:
                    if (direction != InputUser.DownArrow
                            && game.SnakeObj.Head.Coord.Y - game.StepDisplay
                            != game.SnakeObj[0].Coord.Y)
                    {
                        direction = InputUser.UpArrow;
                    }
                    break;

                case Keys.Down:
                    if (direction != InputUser.UpArrow
                            && game.SnakeObj.Head.Coord.Y + game.StepDisplay
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
