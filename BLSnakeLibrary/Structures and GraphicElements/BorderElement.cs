﻿using System.Drawing;

namespace BLSnakeLibrary
{
    public class BorderElement : IGraphicElement
    {
        public Coordinate Coord { get; }

        public char Symbol { get;}

        public Image Picture => throw new System.NotImplementedException();

        public int  PictureSize { get => throw new System.NotImplementedException(); }

        public BorderElement(Coordinate coord, char symbol)
        {
            Coord = coord;
            Symbol = symbol;
        }

        public override string ToString() => Symbol.ToString();
    }
}
