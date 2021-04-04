using BLSnakeLibrary;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DLSnakeLibrary
{
    public class DLWorker
    {
        public static bool ExistSaveFile(string path)
        {
            return File.Exists(path);
        }

        public static bool ExistsDir(string dir)
        {
            return Directory.Exists(dir);
        }

        public static void CreatDir(string dir)
        {
            Directory.CreateDirectory(dir);
        }

        public void Save(string path, GameSnake state)
        {
            BinaryFormatter saver = new BinaryFormatter();

            using (FileStream fs = File.Create(path))
            {
                saver.Serialize(fs, state);
            }
        }

        public GameSnake Load(string path)
        {
            GameSnake state = null;
            BinaryFormatter saver = new BinaryFormatter();

            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                state = saver.Deserialize(fs) as GameSnake;
            }

            return state;
        }
    }
}
