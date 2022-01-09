using BLSnakeLibrary;
using DLSnakeLibrary;

namespace ConsoleSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            const short MILLISECONDS_IN_SECOND = 1000;
            byte choiceMenu = (byte)MenuChois.NoButton;
            DLWorker saver = new DLWorker();
            GameSnake game = new GameSnake();

            game.InitGameField(Visualizer.SIDE_SIZE,
                    Visualizer.FIELD_X_START, Visualizer.FIELD_Y_START);

            do//while (choiceMenu != (byte)MenuChois.ButtonExit);
            {
                choiceMenu = (byte)MenuChois.ButtonStart;
                InputUser push = InputUser.NoDirection;

                if (!DLWorker.ExistsDir(game.HomeDir))
                {
                    DLWorker.CreatDir(game.HomeDir);
                }

                string[] menu = new string[]{"START", "LOAD", "DIFFICULTY", "SAVE OPTIONS", "EXIT"};

                Visualizer.PrintField(game.PlayField);

                do
                {
                    Visualizer.PrintMenu(menu);

                    ConnectHelper.WorkWithMenu(menu, ref push, ref choiceMenu);
                } while (push != InputUser.Enter);

                if (choiceMenu == (byte)MenuChois.ButtonLoad)
                {
                    ConnectHelper.WorkWithLoad(ref choiceMenu, saver, ref game);
                }

                switch (choiceMenu)
                {
                    case (byte)MenuChois.ButtonStart:

                        game.InitSnake(new Coordinate(Visualizer.HEAD_X, Visualizer.HEAD_Y));
                        game.InitFruits();

                        ConnectHelper.RunGameProcess(MILLISECONDS_IN_SECOND, game);
                        break;

                    case (byte)MenuChois.ButtonLoad:
                        ConnectHelper.RunGameProcess(MILLISECONDS_IN_SECOND, game);
                        break;

                    case (byte)MenuChois.ButtonDifficulty:
                        ConnectHelper.SetDifficulty(game);
                        break;

                    default:
                        choiceMenu = (byte)MenuChois.ButtonExit;
                        break;
                }
            } while (choiceMenu != (byte)MenuChois.ButtonExit);

            Visualizer.SetCursor(0, game.PlayField.RightDownAngle.Y + 1);
        }
    }
}
