using System;

namespace BLSnakeLibrary
{
    [Serializable]
    public class FruitElement : IGraphicElement
    {
        Coordinate[] _points;//TODO if fruit is point collection array paralel image

        private Coordinate _coord;

        public Coordinate Coord
        {
            get { return _coord; }
            internal set { _coord = value; }
        }

        public char Symbol { get; internal set; }

        public FruitElement(Coordinate coord, char symbol)
        {
            Coord = coord;
            Symbol = symbol;
        }

        public FruitElement(Coordinate coord, char symbol, //TODO
                int snakeHeadSize, int fruitSize)
        {
            float Checker2D = 2f;

            if (fruitSize > snakeHeadSize 
                    && (fruitSize / Checker2D / snakeHeadSize) % 1 == 0)
            {
                _points = new Coordinate[fruitSize / snakeHeadSize];
            }
            else
            {
                if (fruitSize != snakeHeadSize)
                {
                    throw new ArgumentException("Size of fruit not correct" +
                            " for 2D figure relatively size of snake head");
                }
            }

            Coord = coord;
            Symbol = symbol;
        }

        internal void SetCoordX(int x)
        {
            _coord.X = x;
        }

        internal void SetCoordY(int y)
        {
            _coord.Y = y;
        }
    }
}
