namespace BLSnakeLibrary
{
    public class SnakeElement : IGraphicElement
    {
        public Coordinate Coord { get; internal set; }

        public char Symbol { get;}

        public SnakeElement(Coordinate coord, char symbol)
        {
            Coord = coord;
            Symbol = symbol; 
        }

        internal void ChangeCoordinate(Coordinate coord)
        {
            Coord = coord;
        }
    }
}
