using BLSnakeLibrary;
using System.Drawing;
using System.Windows.Forms;

namespace Training_Snake
{
    class FormHelper
    {
        private static void PainttGraphicElement
                (IGraphicElement element, SolidBrush brush,
                Graphics painter, int stepDisplay)
        {
            painter.FillRectangle(brush, element.Coord.X,
                               element.Coord.Y, stepDisplay, stepDisplay);
        }

        public static void PaintSnake
                (Snake snakeFP, Graphics painter, int stepDisplay)
        {
            SolidBrush snakeBrush = new SolidBrush(Color.DarkMagenta);

            for (int i = 0; i < snakeFP.SizeOfSnake; i++)
            {
                if (i < snakeFP.SizeOfSnake - 1)
                {
                    if (snakeFP[i].Coord != Snake.NO_COORDINATE)
                    {
                        if ((i + 1) % 2 == 0)
                        {
                            snakeBrush.Color = Color.Orange;
                        }
                        else
                        {
                            snakeBrush.Color = Color.DarkGreen;
                        }

                        PainttGraphicElement(snakeFP[i], snakeBrush,
                                painter, stepDisplay);
                    }
                }
                else
                {
                    if (i == snakeFP.SizeOfSnake - 1)
                    {
                        snakeBrush.Color = Color.Black;

                        PainttGraphicElement(snakeFP.Head, snakeBrush,
                                painter, stepDisplay);
                    }
                }
            }
        }

        public static void PaintField
                (Field fieldFP, Graphics painter, int stepDisplay)
        {
            SolidBrush fieldBrash = new SolidBrush(Color.BurlyWood);

            for (int i = 0; i < fieldFP.FieldLenght; i++)
            {
                PainttGraphicElement
                        (fieldFP[i], fieldBrash, painter, stepDisplay);
            }
        }

        public static void PaintFruits
                (Fruits fruitsFP, Graphics painter, int stepDisplay)
        {
            SolidBrush fruitBrash = new SolidBrush(Color.Crimson);

            for (int i = 0; i < fruitsFP.FruitQuantity; i++)
            {
                PainttGraphicElement(fruitsFP.GetFruit(i),
                        fruitBrash, painter, stepDisplay);
            }

            fruitBrash.Color = Color.Chartreuse;

            for (int i = 0; i < fruitsFP.SuperFruitQuantity; i++)
            {
                PainttGraphicElement(fruitsFP.GetSuperFruit(i),
                        fruitBrash, painter, stepDisplay);
            }
        }

        public static void GiveDirectionInputKey
                (GameSnake game, Keys key, ref InputUser direction)
        {
            switch (key)
            {
                case Keys.Left:
                    if (direction != InputUser.RightArrow
                            && game.SnakeGame.Head.Coord.X - game.StepDisplay
                            != game.SnakeGame[0].Coord.X)
                    {
                        direction = InputUser.LeftArrow;
                    }
                    break;

                case Keys.Right:
                    if (direction != InputUser.LeftArrow
                            && game.SnakeGame.Head.Coord.X + game.StepDisplay
                            != game.SnakeGame[0].Coord.X)
                    {
                        direction = InputUser.RightArrow;
                    }
                    break;

                case Keys.Up:
                    if (direction != InputUser.DownArrow
                            && game.SnakeGame.Head.Coord.Y - game.StepDisplay
                            != game.SnakeGame[0].Coord.Y)
                    {
                        direction = InputUser.UpArrow;
                    }
                    break;

                case Keys.Down:
                    if (direction != InputUser.UpArrow
                            && game.SnakeGame.Head.Coord.Y + game.StepDisplay
                            != game.SnakeGame[0].Coord.Y)
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
