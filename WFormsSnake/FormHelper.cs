using BLSnakeLibrary;
using System.Drawing;
using System.Windows.Forms;

namespace Training_Snake
{
    class FormHelper
    {
        public static void PaintSnake
                (Snake snakeFP, Graphics painter, int stepDisplay)
        {
            SolidBrush snakeSegment = new SolidBrush(Color.DarkMagenta);

            for (int i = 0; i < snakeFP.SizeOfSnake; i++)
            {
                if (i < snakeFP.SizeOfSnake - 1)
                {
                    if ((snakeFP[i].Y != Snake.NO_COORDINATE)
                            && (snakeFP[i].X != Snake.NO_COORDINATE))
                    {
                        if ((i + 1) % 2 == 0)
                        {
                            snakeSegment.Color = Color.Orange;
                        }
                        else
                        {
                            snakeSegment.Color = Color.DarkGreen;
                        }

                        painter.FillRectangle(snakeSegment, snakeFP[i].X,
                                snakeFP[i].Y, stepDisplay, stepDisplay);
                    }
                }
                else
                {
                    if (i == snakeFP.SizeOfSnake - 1)
                    {
                        snakeSegment.Color = Color.Black;

                        painter.FillRectangle(snakeSegment, snakeFP.Head.X,
                                snakeFP.Head.Y, stepDisplay, stepDisplay);
                    }
                }
            }
        }

        public static void PaintField
                (Field fieldFP, Graphics painter, int stepDisplay)
        {
            SolidBrush fieldSegment = new SolidBrush(Color.BurlyWood);

            for (int i = 0; i < fieldFP.FieldLenght; i++)
            {
                painter.FillRectangle(fieldSegment, fieldFP[i].X,
                                fieldFP[i].Y, stepDisplay, stepDisplay);
            }
        }

        public static void PaintFruits
                (Fruits fruitsFP, Graphics painter, int stepDisplay)
        {
            SolidBrush oneOfFruits = new SolidBrush(Color.Crimson);

            for (int i = 0; i < fruitsFP.FruitQuantity; i++)
            {
                painter.FillRectangle(oneOfFruits, fruitsFP.GetFruit(i).X,
                        fruitsFP.GetFruit(i).Y, stepDisplay, stepDisplay);
            }

            oneOfFruits.Color = Color.Chartreuse;

            for (int i = 0; i < fruitsFP.SuperFruitQuantity; i++)
            {
                painter.FillRectangle(oneOfFruits, fruitsFP.GetSuperFruit(i).X,
                        fruitsFP.GetSuperFruit(i).Y, stepDisplay, stepDisplay);
            }
        }

        public static void GiveDirectionInputKey
                (GameSnake game, Keys key, ref InputUser direction)
        {
            switch (key)
            {
                case Keys.Left:
                    if (direction != InputUser.RightArrow
                            && game.SnakeGame.Head.X - game.StepDisplay
                            != game.SnakeGame[0].X)
                    {
                        direction = InputUser.LeftArrow;
                    }
                    break;

                case Keys.Right:
                    if (direction != InputUser.LeftArrow
                            && game.SnakeGame.Head.X + game.StepDisplay
                            != game.SnakeGame[0].X)
                    {
                        direction = InputUser.RightArrow;
                    }
                    break;

                case Keys.Up:
                    if (direction != InputUser.DownArrow
                            && game.SnakeGame.Head.Y - game.StepDisplay
                            != game.SnakeGame[0].Y)
                    {
                        direction = InputUser.UpArrow;
                    }
                    break;

                case Keys.Down:
                    if (direction != InputUser.UpArrow
                            && game.SnakeGame.Head.Y + game.StepDisplay
                            != game.SnakeGame[0].Y)
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
