using System;
using System.Drawing;

namespace BLSnakeLibrary
{
    [Serializable]
    public class SnakeElement : IGraphicElement
    {
        public Coordinate Coord { get; internal set; }

        public char Symbol { get;}

        public Image Picture => throw new NotImplementedException();

        public int PictureSize { get => throw new NotImplementedException(); }

        public SnakeElement(Coordinate coord, char symbol)
        {
            Coord = coord;
            Symbol = symbol; 
        }

        internal void ChangeCoordinate(Coordinate coord) => Coord = coord;
    }
}
