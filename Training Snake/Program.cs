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

            _game.InitGameField (Visualizer.SIDE_SIZE,
                    Visualizer.FIELD_X_START, Visualizer.FIELD_Y_START);

            int interval = GameSnake.TICK_SPEED * (byte)Difficulty.Normal;

            do
            {
                choiceMenu = (byte)MenuChois.ButtonStart;
                InputUser key = InputUser.DownArrow;
                int countEating = 0;
                double timer = 0;
               
                Visualizer.PrintField(_game.PlayField);

                InputUser push = InputUser.NoDirection;

                string[] menu = { "START", "DIFFICULTY", "EXIT" };

                do
                {
                    Visualizer.PrintMenu(menu);

                    ShowMenu(menu, ref push, ref choiceMenu);
                } while (push != InputUser.Enter);

                Visualizer.ArrowClear(choiceMenu);
                Visualizer.ClearMenu(menu);

                switch (choiceMenu)
                {
                    case (byte)MenuChois.ButtonStart:

                        _game.InitSnake(new Coordinate
                                (Visualizer.HEAD_X, Visualizer.HEAD_Y));

                        _game.InitFruits();

                        byte chPouseMenu = (byte)MenuChois.ButtonStart;

                        do
                        {
                            Thread.Sleep(interval);

                            timer += (double)interval / MILLISECONDS_IN_SECOND;

                            _game.GenerateFruitByCount(stepDisplay);
                            _game.GenerateSuperFruitByCount(stepDisplay);

                            Visualizer.PrintFruits(_game.FruitsGame);
                            Visualizer.PrintSnake(_game.SnakeGame);
                            Visualizer.PrintStatistic(countEating,
                                    (int)timer, _game.SnakeGame.SizeOfSnake);

                            if (_game.CheckObstructionBorders()
                                    || _game.SnakeGame.CheckEncounter())
                            {
                                chPouseMenu = Controller.EXIT_FROM_LEVEL;
                            }

                            _game.SnakeGame.CheckFruitsEating
                                    (_game.FruitsGame);

                            interval = _game.WorkOnSpeed
                                    (interval, ref countEating);

                            _game.SnakeGame.PassСoordinates();

                            InputUser prevKey = key;

                            key = Controller.SetKurse(key);

                            if (key == InputUser.Escape)
                            {

                                string[] categories = { "Continued", "Exit" };

                                ShowMenu(categories, ref key, ref chPouseMenu);

                                key = prevKey;
                            }

                            _game.SnakeGame.ChangeDirection(key, stepDisplay);

                            if(_game.CheckWin())
                            {
                                chPouseMenu = Controller.EXIT_FROM_LEVEL;
                            }

                        } while(chPouseMenu != Controller.EXIT_FROM_LEVEL);

                        if (_game.CheckWin())
                        {
                            string youWin = "YOU WIN";

                            Visualizer.PrintGameResolt
                                    (youWin, _game.SnakeGame.Head);
                            Visualizer.ClearGameResolt
                                    (youWin, _game.SnakeGame.Head);
                        }
                        else
                        {
                            string gameOver = "GAME OVER";

                            Visualizer.PrintGameResolt
                                    (gameOver, _game.SnakeGame.Head);
                            Visualizer.ClearGameResolt
                                    (gameOver, _game.SnakeGame.Head);
                        }

                        Visualizer.ClearFruits(_game.FruitsGame);
                        Visualizer.ClearSnake(_game.SnakeGame);
                        Visualizer.ClearStatistic(Visualizer.FIELD_X_START);
                        break;

                    case (byte)MenuChois.ButtonDifficulty:

                        InputUser keyDifficulty = InputUser.NoDirection;
                        byte choisDifficulty = (byte)DifficultyChois.Normal;
                        string[] difficulty = { "EASY", "NORMAL", "HIGH" };

                        do
                        {
                            Visualizer.PrintMenu(difficulty);

                            ShowMenu(difficulty,
                                    ref keyDifficulty, ref choisDifficulty);

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

                        Visualizer.ArrowClear(choisDifficulty);
                        Visualizer.ClearMenu(difficulty);
                        break;

                    default:
                        chPouseMenu = Controller.EXIT_FROM_LEVEL;
                        break;
                }

            } while (choiceMenu != (byte)MenuChois.ButtonExit);

            Visualizer.SetCursor(0, _game.PlayField.RightDownAngle.Y + 1);
        }

        private static void ShowMenu(string[] categories,
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
