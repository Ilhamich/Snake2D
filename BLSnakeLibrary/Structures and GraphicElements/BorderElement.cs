namespace BLSnakeLibrary
{
    public class BorderElement : IGraphicElement
    {
        public Coordinate Coord { get; }

        public char Symbol { get;}

        public BorderElement(Coordinate coord, char symbol)
        {
            Coord = coord;
            Symbol = symbol;
        }

        //internal BorderElement GetCopy()
        //{
        //    return (BorderElement)MemberwiseClone();
        //}

        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}
