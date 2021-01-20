using System;

using BLSnakeLibrary;

namespace Training_Snake
{
    class Controller
    {
        public const byte EXIT_FROM_LEVEL = 2;

        public static InputUser SetKurse(InputUser key)
        {
            InputUser chekKey = key;
            ConsoleKey keyReal = 0;

            if (Console.KeyAvailable)
            {
                keyReal = Console.ReadKey().Key;
            }

            if (key.ToString() == keyReal.ToString())
            {
                key = chekKey;
            }
            else
            {
                switch (keyReal)
                {
                    case ConsoleKey.LeftArrow:
                        key = InputUser.LeftArrow;
                        break;

                    case ConsoleKey.UpArrow:
                        key = InputUser.UpArrow;
                        break;

                    case ConsoleKey.RightArrow:
                        key = InputUser.RightArrow;
                        break;

                    case ConsoleKey.DownArrow:
                        key = InputUser.DownArrow;
                        break;

                    case ConsoleKey.Escape:
                        key = InputUser.Escape;
                        break;

                    default:
                        key = chekKey;
                        break;
                }
            }

            return key;
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

        public static void MoveArrow
              (InputUser key, byte start, byte exit, ref byte stepMenu)
        {
            if (key == InputUser.DownArrow && stepMenu < exit)
            {
                stepMenu++;
            }
            else
            {
                if (key == InputUser.UpArrow
                        && stepMenu > start)
                {
                    stepMenu--;
                }
            }
        }
    }
}
