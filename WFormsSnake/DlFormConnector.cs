using BLSnakeLibrary;
using DLSnakeLibrary;

namespace Training_Snake
{
    class DlFormConnector
    {
        DLWorker _saver;
        GameSnake _game;

        public DlFormConnector(GameSnake game)
        {
            _saver = new DLWorker();
            _game = game;
        }

        public bool ExistSave()
        {
            return DLWorker.ExistSaveFile(_game.HomeDir + "\\" + _game.HomeFile);
        }

        public void Save()
        {
            if (!DLWorker.ExistsDir(_game.HomeDir))
            {
                DLWorker.CreatDir(_game.HomeDir);
            }

            _saver.Save(_game.HomeDir + "\\" + _game.HomeFile, _game);
        }

        public GameSnake Load()
        {
            return _saver.Load(_game.HomeDir + "\\" + _game.HomeFile);
        }
    }
}
