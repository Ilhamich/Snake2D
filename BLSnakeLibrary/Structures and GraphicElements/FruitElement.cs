using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace BLSnakeLibrary
{
    [Serializable]
    public class FruitElement : IGraphicElement, IEnumerable<Coordinate>
    {
        Image _fruitImage ;
        Coordinate[] _points; //Если fruitElement не точка а колекция точек

        private Coordinate _coord;

        public Coordinate Coord
        {
            get { return _coord; }
            internal set { _coord = value; }
        }

        public Image Picture
        {
            get { return _fruitImage; }
        }

        public char Symbol { get; internal set; }

        public int PictureSize { get; private set; }  

        public FruitElement(Coordinate coord, char symbol)
        {
            Coord = coord;
            Symbol = symbol;
        }

        public FruitElement(Coordinate LeftTopcoord, Bitmap image,   //TODO
                int snakeHeadSize, int fruitSize)
        {
            _fruitImage = image;

            if (fruitSize * 1f / snakeHeadSize % 1 == 0)
            {
                int ratio = fruitSize / snakeHeadSize;
                _points = new Coordinate[ratio * ratio];
                int count = 0; 

                for (int i = 1; i <= ratio; i++)
                {                  
                    for (int j = 1; j <= ratio; j++)
                    {
                        _points[count++] = new Coordinate(LeftTopcoord.X + 
                            (snakeHeadSize * (j - 1)), LeftTopcoord.Y + 
                            (snakeHeadSize * (i - 1)));
                    }
                }

                Coord = LeftTopcoord;
                PictureSize = fruitSize;
            }
            else
            {
                if (fruitSize != snakeHeadSize)
                {
                    throw new ArgumentException("Size of fruit not correct" +
                            " for 2D figure relatively size of snake head");
                }
            }
        }

        internal void SetCoordX(int x)
        {
            _coord.X = x;
        }

        internal void SetCoordY(int y)
        {
            _coord.Y = y;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _points.GetEnumerator();
        }

        public IEnumerator<Coordinate> GetEnumerator()
        {
            return ((IEnumerable<Coordinate>)_points).GetEnumerator();
        }
    }
}
