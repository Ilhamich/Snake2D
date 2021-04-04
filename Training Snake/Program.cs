using BLSnakeLibrary;
using DLSnakeLibrary;

namespace Training_Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            FruitElement test = new FruitElement(new Coordinate(10, 10), 'w', 10, 80);

            const short MILLISECONDS_IN_SECOND = 1000;
            byte choiceMenu = (byte)MenuChois.NoButton;
            DLWorker saver = new DLWorker();
            GameSnake _game = new GameSnake();

            _game.InitGameField(Visualizer.SIDE_SIZE,
                    Visualizer.FIELD_X_START, Visualizer.FIELD_Y_START);

            do//(choiceMenu != (byte)MenuChois.ButtonExit);
            {
                choiceMenu = (byte)MenuChois.ButtonStart;
                InputUser push = InputUser.NoDirection;

                string[] menu = null;

                if (!DLWorker.ExistsDir(_game.HomeDir))
                {
                    DLWorker.CreatDir(_game.HomeDir);
                }

                if (DLWorker.ExistSaveFile(_game.HomeDir + "\\" +
                        _game.HomeFile))
                {
                    menu = new string[]
                    {"START", "LOAD", "DIFFICULTY", "EXIT"};
                }
                else
                {
                    menu = new string[] { "START", "DIFFICULTY", "EXIT" };
                }

                Visualizer.PrintField(_game.PlayField);

                do
                {
                    Visualizer.PrintMenu(menu);

                    ConnectHelper.WorkWithMenu(menu, ref push,
                            ref choiceMenu);
                } while (push != InputUser.Enter);

                if (choiceMenu == (byte)MenuChois.ButtonLoad)
                {
                    ConnectHelper.WorkWithLoad(ref choiceMenu, saver,
                            ref _game);
                }

                switch (choiceMenu)
                {
                    case (byte)MenuChois.ButtonStart:

                        _game.InitSnake(new Coordinate(Visualizer.HEAD_X,
                                Visualizer.HEAD_Y));

                        _game.InitFruits();

                        ConnectHelper.RunGameProcess(MILLISECONDS_IN_SECOND,
                                _game);
                        break;

                    case (byte)MenuChois.ButtonLoad:
                        ConnectHelper.RunGameProcess(MILLISECONDS_IN_SECOND,
                                _game);
                        break;

                    case (byte)MenuChois.ButtonDifficulty:

                        InputUser keyDifficulty = InputUser.NoDirection;
                        byte choisDifficulty = (byte)DifficultyChois.Normal;
                        string[] difficulty = { "EASY", "NORMAL", "HIGH" };

                        do
                        {
                            Visualizer.PrintMenu(difficulty);

                            ConnectHelper.WorkWithMenu(difficulty,
                                    ref keyDifficulty, ref choisDifficulty);

                        } while (keyDifficulty != InputUser.Enter);

                        _game.SetDifficulty(choisDifficulty);

                        Visualizer.ArrowClear(choisDifficulty);
                        Visualizer.ClearMenu(difficulty);
                        break;

                    default:
                        choiceMenu = (byte)MenuChois.ButtonExit;
                        break;
                }//(choiceMenu)
            } while (choiceMenu != (byte)MenuChois.ButtonExit);

            Visualizer.SetCursor(0, _game.PlayField.RightDownAngle.Y + 1);
        }
    }
}
