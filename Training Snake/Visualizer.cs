using System;
using System.Text;

using BLSnakeLibrary;

namespace Training_Snake
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
                Console.SetCursorPosition(element.Coord.X, element.Coord.Y);
                Console.Write(element.Symbol);
            }
        }

        public static void PrintField(Field field)
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HIGHT);

            Console.ForegroundColor = ConsoleColor.Blue;

            for (int i = 0; i < field.FieldLenght; i++)
            {
                PrintGraphicElement(field[i]);
            }

            Console.ResetColor();
        }

        public static void PrintFruits(Fruits myFruits)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Magenta;

            for (int i = 0; i < myFruits.FruitQuantity; i++)
            {
                PrintGraphicElement(myFruits.GetFruit(i));
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            for (int i = 0; i < myFruits.SuperFruitQuantity; i++)
            {
                PrintGraphicElement(myFruits.GetSuperFruit(i));
            }

            Console.ResetColor();
        }

        public static void PrintStatistic(GameSnake game)
        {
            Coordinate statCoord = new Coordinate(0, 0);

            Console.SetCursorPosition(statCoord.X, statCoord.Y++);
            Console.WriteLine($"Difficulty : {game.Difficulty}");
            Console.SetCursorPosition(statCoord.X, statCoord.Y++);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Fruit eaten = {0}", game.CountEating);
            Console.SetCursorPosition(statCoord.X, statCoord.Y++);
            Console.Write("Snake size : {0}", game.SnakeObj.SizeOfSnake);
            Console.SetCursorPosition(statCoord.X, statCoord.Y++);
            Console.Write("Time : {0}", game.Timer);         
        }

        public static void ClearStatistic(int distance) //TODO
        {
            for (int i = 0, j = 0, q = 0; i < distance * STATISTIC_CATEGORY; i++)
            {
                Console.SetCursorPosition(q++, j);
                Console.Write(' ');

                if (i % 20 == 0 && i > 0)
                {
                    j++;
                    q = 0;
                }
            }
        }

        public static void PrintGameResolt(string resolt, SnakeElement head)
        {
            Console.SetCursorPosition(head.Coord.X, head.Coord.Y);
            Console.Write(resolt);
            Console.ReadKey();
        }

        public static void DrawSnakeElement(SnakeElement body, int iter)
        {
            if (iter % 2 == 0 && body.Symbol != (char)Symbols.Head)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
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
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 1; i <= menu.Length; i++)
            {
                Console.SetCursorPosition(X_COORDINATE_MENU, i);
                Console.Write(menu[i - 1]);
            }

            Console.ResetColor();
        }

        public static void PrintArrow(byte step)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(COORDINATE_ARROW, step);
            Console.Write((char)Symbols.Arrow);
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
            Console.SetCursorPosition(COORDINATE_ARROW, numberOfArrow);
            Console.Write(' ');
        }

        public static void ClearMenu(string[] menu)
        {
            for (int i = 1; i <= menu.Length; i++)
            {
                byte xCoordinete = X_COORDINATE_MENU;

                for (int j = 0; j < menu[i - 1].Length; j++)
                {
                    Console.SetCursorPosition(xCoordinete++, i);
                    Console.Write(' ');
                }
            }
        }

        public static void ClearGameResolt(string resolt, SnakeElement head)
        {
            Coordinate snakeHead = new Coordinate(head.Coord.X, head.Coord.Y);

            Console.SetCursorPosition(snakeHead.X, snakeHead.Y);

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
                if (myFruit.GetFruit(i).Coord != Fruits.UNTOUCHED_FRUIT)
                {
                    PrintGraphicElement(new FruitElement(new Coordinate
                            (myFruit.GetFruit(i).Coord.X,
                            myFruit.GetFruit(i).Coord.Y), ' '));
                }
            }

            for (int i = 0; i < myFruit.SuperFruitLength; i++)
            {
                if (myFruit.GetSuperFruit(i).Coord != Fruits.UNTOUCHED_FRUIT)
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
            Console.SetCursorPosition(x, y);
        }

        public static void ShowMessage(string message, Coordinate coord,
                bool pouse = false)
        {
            Console.SetCursorPosition(coord.X, coord.Y);
            Console.Write(message);

            if (pouse)
            {
                Console.ReadKey();
            }          
        }

        public static void ClearMessage(string message, Coordinate coord)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.SetCursorPosition(coord.X++, coord.Y);
                Console.Write(' ');
            }
        }
    }
}
