using System;
using System.Threading;

using BLSnakeLibrary;
using DLSnakeLibrary;

namespace Training_Snake
{
    internal class ConnectHelper
    {
        internal static void WorkWithLoad(ref byte choiceMenu, DLWorker saver,
                 ref GameSnake _game)
        {
            try
            {
                _game = saver.Load(_game.HomeDir + "\\"
                      + _game.HomeFile);
                _game.InitGameField(Visualizer.SIDE_SIZE,
                        Visualizer.FIELD_X_START,
                        Visualizer.FIELD_Y_START);
            }
            catch (Exception)
            {
                string[] message = {"Save file broken or don't exist.",
                                "Will be start new game"};

                Coordinate coord = new Coordinate
                        (_game.PlayField.LeftTopAngle.X + 1,
                        _game.PlayField.LeftTopAngle.Y + 1);

                for (int i = 0; i < message.Length; i++)
                {
                    if (i != message.Length - 1)
                    {
                        Visualizer.ShowMessage(message[i], coord);
                        coord.Y++;
                    }
                    else
                    {
                        Visualizer.ShowMessage(message[i], coord, true);
                    }
                }

                coord = new Coordinate(_game.PlayField.LeftTopAngle.X + 1,
                        _game.PlayField.LeftTopAngle.Y + 1);

                for (int i = 0; i < message.Length; i++)
                {
                    Visualizer.ClearMessage(message[i], coord);
                    coord.Y++;
                }

                choiceMenu = (byte)MenuChois.ButtonStart;
            }
        }

        internal static void RunGameProcess(short MILLISECONDS_IN_SECOND,
                int stepDisplay, GameSnake _game)
        {
            RunLevel(MILLISECONDS_IN_SECOND, stepDisplay, _game);

            ShowGameResult(_game);

            Visualizer.ClearFruits(_game.FruitsObj);
            Visualizer.ClearSnake(_game.SnakeObj);
            Visualizer.ClearStatistic(Visualizer.FIELD_X_START);

            _game.Reset();
        }

        internal static void RunLevel(short timeDivider, int stepDisplay, GameSnake _game)
        {
            InputUser keyDirection = _game.SnakeObj.SetDirection();
            byte chPouseMenu = (byte)MenuChois.ButtonStart;

            do// (chPouseMenu != Controller.EXIT_FROM_LEVEL)
            {
                Thread.Sleep(_game.Interval);

                _game.RunTimer(timeDivider);
                _game.GenerateFruitByCount(stepDisplay);
                _game.GenerateSuperFruitByCount(stepDisplay);

                Visualizer.PrintFruits(_game.FruitsObj);
                Visualizer.PrintSnake(_game.SnakeObj);
                Visualizer.PrintStatistic(_game);

                if (_game.CheckObstructionBorders()
                        || _game.SnakeObj.CheckEncounter())
                {
                    chPouseMenu = Controller.EXIT_FROM_LEVEL;
                }

                InputUser prevKey = keyDirection;

                Controller.SetKurse(ref keyDirection);

                if (keyDirection == InputUser.Escape)
                {
                    string[] categories = { "Continued", "Exit" };

                    WorkWithMenu(categories, ref keyDirection, ref chPouseMenu);

                    if (chPouseMenu == Controller.EXIT_FROM_LEVEL)
                    {
                        WorkWithSave(_game);
                    }

                    keyDirection = prevKey;
                }

                _game.RunSnakeDynamics(keyDirection, stepDisplay);

                if (_game.CheckWin())
                {
                    chPouseMenu = Controller.EXIT_FROM_LEVEL;
                }

            } while (chPouseMenu != Controller.EXIT_FROM_LEVEL);
        }

        internal static void WorkWithSave(GameSnake _game)
        {
            string offer = "Do you wont save game?";
            string[] chois = { "Yes", "No" };
            byte choisSaver = (byte)MenuChois.ButtonStart;
            InputUser saveOrNot = InputUser.NoDirection;
            Coordinate coord = new Coordinate
                   (_game.PlayField.LeftTopAngle.X + 1,
                   _game.PlayField.LeftTopAngle.Y + 1);

            Visualizer.ShowMessage(offer, coord, true);
            WorkWithMenu(chois, ref saveOrNot, ref choisSaver);
            Visualizer.ClearMessage(offer, coord);

            if (choisSaver == (byte)MenuChois.ButtonStart)
            {
                DLWorker saver = new DLWorker();

                saver.Save(_game.HomeDir + "\\" + _game.HomeFile,
                        _game);
            }
        }

        internal static void ShowGameResult(GameSnake _game)
        {
            if (_game.CheckWin())
            {
                string youWin = "YOU WIN";

                Visualizer.PrintGameResolt
                        (youWin, _game.SnakeObj.Head);
                Visualizer.ClearGameResolt
                        (youWin, _game.SnakeObj.Head);
            }
            else
            {
                string gameOver = "GAME OVER";

                Visualizer.PrintGameResolt
                        (gameOver, _game.SnakeObj.Head);
                Visualizer.ClearGameResolt
                        (gameOver, _game.SnakeObj.Head);
            }
        }

        internal static void WorkWithMenu(string[] categories,
                ref InputUser key, ref byte choisPouseMenu)
        {
            bool entry = false;
            byte PouseMenuTmp = 0;

            do
            {
                PouseMenuTmp = choisPouseMenu;

                if (entry)
                {
                    key = Controller.PushButton();

                    Controller.MoveArrow(key, (byte)MenuChois.ButtonStart,
                            (byte)categories.Length, ref choisPouseMenu);
                }

                Visualizer.PrintMenu(categories);

                Visualizer.PrintArrowMenu(PouseMenuTmp, categories,
                        ref key, ref choisPouseMenu);

                entry = true;
            } while (key != InputUser.Enter);
        }
    }
}
