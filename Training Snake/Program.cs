using BLSnakeLibrary;
using System.Threading;

namespace Training_Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            const short MILLISECONDS_IN_SECOND = 1000;
            byte choiceMenu = (byte)MenuChois.NoButton;
            int stepDisplay = 1;

            GameSnake _game = new GameSnake();

            _game.InitGameField (UI.SIDE_SIZE, UI.FIELD_X_START, UI.FIELD_Y_START);

            int interval = GameSnake.TICK_SPEED * (byte)Difficulty.Normal;

            do
            {
                choiceMenu = (byte)MenuChois.ButtonStart;
                InputUser key = InputUser.DownArrow;
                int countEating = 0;
                double timer = 0;
               
                UI.PrintField(_game.PlayField);

                InputUser push;

                string[] menu = { "START", "DIFFICULTY", "EXIT" };

                do
                {
                    UI.PrintMenu(menu);

                    choiceMenu = UI.GetChoisMenu(choiceMenu, out push);

                } while (push != InputUser.Enter);

                UI.ArrowClear(choiceMenu);
                UI.ClearMenu(menu);

                switch (choiceMenu)
                {
                    case (byte)MenuChois.ButtonStart:

                        _game.InitSnake(UI.HEAD_X, UI.HEAD_Y);

                        _game.InitFruits();

                        byte choiceExOrPl = (byte)MenuChois.ButtonStart;

                        do
                        {
                            Thread.Sleep(interval);

                            timer += (double)interval / MILLISECONDS_IN_SECOND;

                            _game.GenerateFruitByCount(stepDisplay);
                            _game.GenerateSuperFruitByCount(stepDisplay);

                            UI.PrintFruits(_game.FruitsGame);
                            UI.PrintSnake(_game.SnakeGame);
                            UI.PrintStatistic(countEating, (int)timer, _game.SnakeGame.SizeOfSnake);

                            if (_game.CheckObstructionBorders()
                                    || _game.SnakeGame.CheckEncounter())
                            {
                                choiceExOrPl = UI.EXIT_FROM_LEVEL;
                            }

                            _game.SnakeGame.CheckFruitsEating(_game.FruitsGame);

                            interval = _game.WorkOnSpeed(interval, ref countEating);

                            _game.SnakeGame.PassСoordinates();

                            InputUser keyTmp = key;

                            key = UI.SetKurse(key);

                            UI.ChooseInPouse(keyTmp, ref key, ref choiceExOrPl);

                            _game.SnakeGame.ChangeDirection(key, stepDisplay);

                            if(_game.CheckWin())
                            {
                                choiceExOrPl = UI.EXIT_FROM_LEVEL;
                            }

                        } while (choiceExOrPl != UI.EXIT_FROM_LEVEL);

                        if (_game.CheckWin())
                        {
                            string youWin = "YOU WIN";
                            UI.PrintGameResolt(youWin, _game.SnakeGame.Head);
                            UI.ClearGameResolt(youWin, _game.SnakeGame.Head);
                        }
                        else
                        {
                            string gameOver = "GAME OVER";
                            UI.PrintGameResolt(gameOver, _game.SnakeGame.Head);
                            UI.ClearGameResolt(gameOver, _game.SnakeGame.Head);
                        }

                        UI.ClearFruits(_game.FruitsGame);
                        UI.ClearSnake(_game.SnakeGame);
                        UI.ClearStatistic(UI.FIELD_X_START);

                        break;

                    case (byte)MenuChois.ButtonDifficulty:

                        InputUser keyDifficulty;

                        byte choisDifficulty = (byte)DifficultyChois.Normal;

                        string[] difficulty = { "EASY", "NORMAL", "HIGH" };

                        do
                        {
                            UI.PrintMenu(difficulty);

                            UI.GetChoisDifficulty(ref choisDifficulty, out keyDifficulty);

                        } while (keyDifficulty != InputUser.Enter);

                        switch (choisDifficulty)
                        {
                            case (byte)DifficultyChois.Easy:

                                interval = _game.SetEasyDifficulty(interval);              
                                break;

                            case (byte)DifficultyChois.Normal:

                                interval = _game.SetMiddleDifficulty(interval);
                                break;

                            case (byte)DifficultyChois.High:

                                interval = _game.SetHightDifficulty(interval);                             
                                break;

                            default:
                                interval = _game.SetMiddleDifficulty(interval);                           
                                break;
                        }

                        UI.ArrowClear(choisDifficulty);
                        UI.ClearMenu(difficulty);

                        break;

                    default:
                        choiceExOrPl = UI.EXIT_FROM_LEVEL;
                        break;
                }

            } while (choiceMenu != (byte)MenuChois.ButtonExit);

            UI.SetCursor(0, _game.PlayField.RightDownAngle.Y + 1);
        }
    }
}
