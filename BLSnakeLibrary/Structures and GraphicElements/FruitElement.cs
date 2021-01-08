namespace BLSnakeLibrary
{
    public class FruitElement : IGraphicElement
    {
        private Coordinate _coord;

        public Coordinate Coord
        {
            get{ return _coord; }
            internal set { _coord = value; }
        }

        public char Symbol { get; internal set; }

        public FruitElement(Coordinate coord, char symbol)
        {
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
