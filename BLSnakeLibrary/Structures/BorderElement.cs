namespace BLSnakeLibrary
{
    public class BorderElement
    {
        public readonly Coordinate Coord;

        public char Symbol { get;}

        public BorderElement(Coordinate coord, char symbol)
        {
            Coord = coord;
            Symbol = symbol;
        }

        internal BorderElement GetCopy()
        {
            return (BorderElement)MemberwiseClone();
        }

        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}
