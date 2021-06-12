using System;
using System.Text;
using static System.Console;

using BLSnakeLibrary;

namespace ConsoleSnake
{
    class Visualizer
    {
        public const int WINDOW_WIDTH = 80;
        public const int WINDOW_HIGHT = 42;

        public const int HEAD_X = 40;
        public const int HEAD_Y = 2;

        public const int SIDE_SIZE = 41;

        public const int FIELD_X_START = 20;
        public const int FIELD_Y_START = 1;
        public const int FIELD_X_END = FIELD_X_START + SIDE_SIZE - 1;
        public const int FIELD_Y_END = FIELD_Y_START + SIDE_SIZE - 1;

        public const int X_COORDINATE_MENU = FIELD_X_END + 3;
        public const int COORDINATE_ARROW = FIELD_X_END + 1;
        public const byte STATISTIC_CATEGORY = 4;

        private static void PrintGraphicElement(IGraphicElement element)
        {
            if (element.Coord.X != -1 && element.Coord.Y != -1)
            {
                SetCursorPosition(element.Coord.X, element.Coord.Y);
                Write(element.Symbol);
            }
        }

        public static void PrintField(Field field)
        {
            SetWindowSize(WINDOW_WIDTH, WINDOW_HIGHT);

            ForegroundColor = ConsoleColor.Blue;

            for (int i = 0; i < field.FieldLenght; i++)
            {
                PrintGraphicElement(field[i]);
            }

            ResetColor();
        }

        public static void PrintFruits(Fruits myFruits)
        {
            OutputEncoding = Encoding.Unicode;
            ForegroundColor = ConsoleColor.Magenta;

            for (int i = 0; i < myFruits.FruitQuantity; i++)
            {
                PrintGraphicElement(myFruits.GetFruit(i));
            }

            ForegroundColor = ConsoleColor.DarkGreen;

            for (int i = 0; i < myFruits.SuperFruitQuantity; i++)
            {
                PrintGraphicElement(myFruits.GetSuperFruit(i));
            }

            ResetColor();
        }

        public static void PrintStatistic(GameSnake game)
        {
            Coordinate statCoord = new Coordinate(0, 0);

            SetCursorPosition(statCoord.X, statCoord.Y++);
            WriteLine($"Difficulty : {game.Difficulty}");
            SetCursorPosition(statCoord.X, statCoord.Y++);
            ForegroundColor = ConsoleColor.Cyan;
            Write("Fruit eaten = {0}", game.CountEating);
            SetCursorPosition(statCoord.X, statCoord.Y++);
            Write("Snake size : {0}", game.SnakeObj.SizeOfSnake);
            SetCursorPosition(statCoord.X, statCoord.Y++);
            Write("Time : {0}", game.Timer);
        }

        public static void ClearStatistic(int distance)
        {
            for (int i = 0, j = 0, q = 0; i < distance * STATISTIC_CATEGORY; i++)
            {
                SetCursorPosition(q++, j);
                Write(' ');

                if (i % 20 == 0 && i > 0)
                {
                    j++;
                    q = 0;
                }
            }
        }

        public static void PrintGameResolt(string resolt, SnakeElement head)
        {
            SetCursorPosition(head.Coord.X, head.Coord.Y);
            Write(resolt);
            ReadKey();
        }

        public static void DrawSnakeElement(SnakeElement body, int iter)
        {
            if (iter % 2 == 0 && body.Symbol != (char)Symbols.Head)
            {
                ForegroundColor = ConsoleColor.DarkYellow;
            }
            else
            {
                ForegroundColor = ConsoleColor.Green;
            }

            PrintGraphicElement(body);
        }

        public static void PrintSnake(Snake mySnake)
        {
            for (int i = 0; i <= mySnake.SizeOfSnake; i++)
            {
                if (i < mySnake.SizeOfSnake - 1)
                {
                    if (mySnake[i].Coord != Snake.NO_COORDINATE)
                    {
                        DrawSnakeElement(mySnake[i], i);
                    }
                }
                else
                {
                    if ((mySnake.Tail.Coord != Snake.NO_COORDINATE)
                            && (i == mySnake.SizeOfSnake - 1))
                    {
                        DrawSnakeElement(mySnake.Tail, i);
                    }
                    else
                    {
                        if (i == mySnake.SizeOfSnake)
                        {
                            DrawSnakeElement(mySnake.Head, i);
                        }
                    }
                }
            }
        }

        public static void PrintMenu(string[] menu)
        {
            ForegroundColor = ConsoleColor.White;

            for (int i = 1; i <= menu.Length; i++)
            {
                SetCursorPosition(X_COORDINATE_MENU, i);
                Write(menu[i - 1]);
            }

            ResetColor();
        }

        public static void PrintArrow(byte step)
        {
            ForegroundColor = ConsoleColor.Red;
            SetCursorPosition(COORDINATE_ARROW, step);
            Write((char)Symbols.Arrow);
        }

        public static void PrintArrowMenu(byte tmpStep, string[] categories,
                InputUser key, byte stepMenu)
        {
            ArrowClear(tmpStep);
            PrintArrow(stepMenu);

            if (key == InputUser.Enter)
            {
                ArrowClear(stepMenu);
                ClearMenu(categories);
            }
        }

        public static void ArrowClear(byte numberOfArrow)
        {
            SetCursorPosition(COORDINATE_ARROW, numberOfArrow);
            Write(' ');
        }

        public static void ClearMenu(string[] menu)
        {
            for (int i = 1; i <= menu.Length; i++)
            {
                byte xCoordinete = X_COORDINATE_MENU;

                for (int j = 0; j < menu[i - 1].Length; j++)
                {
                    SetCursorPosition(xCoordinete++, i);
                    Write(' ');
                }
            }
        }

        public static void ClearGameResolt(string resolt, SnakeElement head)
        {
            Coordinate snakeHead = new Coordinate(head.Coord.X, head.Coord.Y);

            SetCursorPosition(snakeHead.X, snakeHead.Y);

            for (int i = 0; i < resolt.Length; i++)
            {
                PrintGraphicElement(new SnakeElement
                        (new Coordinate(snakeHead.X++, snakeHead.Y), ' '));
            }
        }

        public static void ClearFruits(Fruits myFruit)
        {
            for (int i = 0; i < myFruit.FruitLength; i++)
            {
                if (myFruit.GetFruit(i) != null)
                {
                    PrintGraphicElement(new FruitElement(new Coordinate
                            (myFruit.GetFruit(i).Coord.X,
                            myFruit.GetFruit(i).Coord.Y), ' '));
                }
            }

            for (int i = 0; i < myFruit.SuperFruitLength; i++)
            {
                if (myFruit.GetSuperFruit(i) != null)
                {
                    PrintGraphicElement(new FruitElement(new Coordinate
                          (myFruit.GetSuperFruit(i).Coord.X,
                          myFruit.GetSuperFruit(i).Coord.Y), ' '));
                }
            }
        }

        public static void ClearSnake(Snake mySnake)
        {
            for (int i = 0; i < mySnake.SizeOfSnake - 1; i++)
            {
                PrintGraphicElement(new SnakeElement(mySnake[i].Coord, ' '));
            }

            PrintGraphicElement(mySnake.Tail);
        }

        public static void SetCursor(int x, int y)
        {
            SetCursorPosition(x, y);
        }

        public static void ShowMessage(string message, Coordinate coord,
                bool pouse = false)
        {
            SetCursorPosition(coord.X, coord.Y);
            Write(message);

            if (pouse)
            {
                ReadKey();
            }
        }

        public static void ClearMessage(string message, Coordinate coord)
        {
            for (int i = 0; i < message.Length; i++)
            {
                SetCursorPosition(coord.X++, coord.Y);
                Write(' ');
            }
        }
    }
}
