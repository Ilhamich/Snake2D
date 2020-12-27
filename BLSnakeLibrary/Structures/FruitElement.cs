namespace BLSnakeLibrary
{
    public class FruitElement 
    {
        Coordinate _coord;

        public Coordinate Coord
        {
            get{ return _coord; }
            internal set { _coord = value; }
        }

        public char Symbol { get; internal set; }

        public int X 
        {
            get { return _coord.X; }
        }

        public int Y
        {
            get { return _coord.Y; }
        }

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
