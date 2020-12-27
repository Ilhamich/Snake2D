using BLSnakeLibrary;
using System;
using System.Text;

namespace Training_Snake
{
    class UI
    {
        public const int WINDOW_WIDTH = 80;
        public const int WINDOW_HIGHT = 42;

        public const byte EXIT_FROM_LEVEL = 2;
        public const byte EXIT_FROM_MENU = 3;

        public const int HEAD_X = 40;
        public const int HEAD_Y = 2;

        public const int SIDE_SIZE = 41;

        public const int FIELD_X_START = 20;
        public const int FIELD_Y_START = 1;
        public const int FIELD_X_END = FIELD_X_START + SIDE_SIZE - 1;
        public const int FIELD_Y_END = FIELD_Y_START + SIDE_SIZE - 1;

        public const int X_COORDINATE_MENU = FIELD_X_END + 3;
        public const int COORDINATE_ARROW = FIELD_X_END + 1;

        public static void PrintField(Field field)
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HIGHT);

            Console.ForegroundColor = ConsoleColor.Blue;

            for (int i = 0; i < field.FieldLenght; i++)
            {
                Console.SetCursorPosition(field[i].Coord.X, field[i].Coord.Y);
                Console.Write(field[i].Symbol);
            }

            Console.ResetColor();
        }

        public static void PrintFruits(Fruits myFruits)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Magenta;

            for (int i = 0; i < myFruits.FruitQuantity; i++)
            {
                Console.SetCursorPosition(myFruits.GetFruit(i).X,
                        myFruits.GetFruit(i).Y);
                Console.Write(myFruits.GetFruit(i).Symbol);
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            for (int i = 0; i < myFruits.SuperFruitQuantity; i++)
            {
                Console.SetCursorPosition(myFruits.GetSuperFruit(i).X,
                        myFruits.GetSuperFruit(i).Y);
                Console.Write(myFruits.GetSuperFruit(i).Symbol);
            }

            Console.ResetColor();
        }

        public static void PrintStatistic(int eating, int timer, int size)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Fruit eaten = {0}", eating);
            Console.SetCursorPosition(0, 1);
            Console.Write("Snake size : {0}", size);
            Console.SetCursorPosition(0, 2);
            Console.Write("Time : {0}", timer);
        }

        public static void ClearStatistic(int distance)
        {
            for (int i = 0, j = 0, q = 0; i < distance * 3; i++)
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

            Console.SetCursorPosition(body.Coord.X, body.Coord.Y);
            Console.Write("{0}", body.Symbol);
        }

        public static InputUser SetKurse(InputUser key)
        {
            InputUser chekKey = key;
            ConsoleKey keyReal = 0;

            if (Console.KeyAvailable)
            {
                keyReal = Console.ReadKey().Key;
            }

            switch (keyReal)
            {
                case ConsoleKey.LeftArrow:
                    if (chekKey == InputUser.RightArrow)
                    {
                        key = chekKey;
                    }
                    else
                    {
                        key = InputUser.LeftArrow;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (chekKey == InputUser.DownArrow)
                    {
                        key = chekKey;
                    }
                    else
                    {
                        key = InputUser.UpArrow;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (chekKey == InputUser.LeftArrow)
                    {
                        key = chekKey;
                    }
                    else
                    {
                        key = InputUser.RightArrow;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (chekKey == InputUser.UpArrow)
                    {
                        key = chekKey;
                    }
                    else
                    {
                        key = InputUser.DownArrow;
                    }
                    break;

                case ConsoleKey.Escape:
                    key = InputUser.Escape;
                    break;

                default:
                    key = chekKey;
                    break;
            }

            return key;
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

        public static byte СhooseExitOrPlay(byte step, out InputUser push)
        {
            int tmpStep = step;

            PrintArrow(step);

            push = PushButton();

            if (push == InputUser.DownArrow && step < EXIT_FROM_LEVEL)
            {
                step++;
            }
            else
            {
                if (push == InputUser.UpArrow && step > 1)
                {
                    step--;
                }
            }

            Console.SetCursorPosition(FIELD_X_END + 1, tmpStep);
            Console.Write("  ");

            PrintArrow(step);

            Console.ResetColor();

            return step;
        }

        public static byte GetChoisMenu(byte step, out InputUser push)
        {
            byte tmpStep = step;

            PrintArrow(step);

            push = PushButton();

            if (push == InputUser.DownArrow && step < EXIT_FROM_MENU)
            {
                step++;
            }
            else
            {
                if (push == InputUser.UpArrow && step > 1)
                {
                    step--;
                }
            }

            Console.SetCursorPosition(FIELD_X_END + 1, tmpStep);
            Console.Write("  ");

            PrintArrow(step);

            Console.ResetColor();

            return step;
        }

        public static void GetChoisDifficulty(ref byte step, out InputUser Push)
        {
            int tmpStep = step;

            PrintArrow(step);

            Push = PushButton();

            if (Push == InputUser.DownArrow && step < (byte)MenuChois.ButtonExit)
            {
                step++;
            }
            else
            {
                if (Push == InputUser.UpArrow && step > (byte)MenuChois.ButtonStart)
                {
                    step--;
                }
                else
                {

                }
            }

            Console.SetCursorPosition(FIELD_X_END + 1, tmpStep);
            Console.Write("  ");

            PrintArrow(step);

            Console.ResetColor();
        }

        public static InputUser PushButton()
        {
            ConsoleKey key = Console.ReadKey().Key;
            InputUser result = InputUser.NoDirection;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    result = InputUser.UpArrow;
                    break;

                case ConsoleKey.DownArrow:
                    result = InputUser.DownArrow;
                    break;

                case ConsoleKey.Enter:
                    result = InputUser.Enter;
                    break;

                default:
                    break;
            }

            return result;
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

        public static void ChooseInPouse
                (InputUser keyTmp, ref InputUser key, ref byte choiceExOrPl)
        {
            while (key == InputUser.Escape)
            {
                string[] exitContinued = { "Continued", "Exit" };

                PrintMenu(exitContinued);

                InputUser keyExOrPl = InputUser.NoDirection;

                choiceExOrPl = СhooseExitOrPlay(choiceExOrPl, out keyExOrPl);

                if (keyExOrPl == InputUser.Enter)
                {
                    key = keyTmp;

                    ArrowClear(choiceExOrPl);
                    ClearMenu(exitContinued);

                    break;
                }
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
                Console.SetCursorPosition(snakeHead.X++, snakeHead.Y);
                Console.Write(' ');
            }
        }

        public static void ClearFruits(Fruits myFruit)
        {
            for (int i = 0; i < myFruit.FruitLength; i++)
            {
                if (myFruit.GetFruit(i).Coord != Fruits.UNTOUCHED_FRUIT)
                {
                    Console.SetCursorPosition(myFruit.GetFruit(i).X,
                            myFruit.GetFruit(i).Y);
                    Console.Write(' ');
                }
            }

            for (int i = 0; i < myFruit.SuperFruitLength; i++)
            {
                if (myFruit.GetSuperFruit(i).Coord != Fruits.UNTOUCHED_FRUIT)
                {
                    Console.SetCursorPosition(myFruit.GetSuperFruit(i).X,
                            myFruit.GetSuperFruit(i).Y);
                    Console.Write(' ');
                }
            }
        }

        public static void ClearSnake(Snake mySnake)
        {
            for (int i = 0; i < mySnake.SizeOfSnake - 1; i++)
            {
                Console.SetCursorPosition(mySnake[i].Coord.X, mySnake[i].Coord.Y);
                Console.Write(' ');
            }

            Console.SetCursorPosition(mySnake.Tail.Coord.X, mySnake.Tail.Coord.Y);
            Console.Write(' ');
        }

        public static void SetCursor(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
}
