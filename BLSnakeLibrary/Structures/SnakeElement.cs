namespace BLSnakeLibrary
{
    public struct SnakeElement
    {
        public int Y { get; internal set; }

        public int X { get; internal set; }

        public char Symbol { get;}

        public SnakeElement(int startCoordinateY, int startCoordinateX, char symbol)
        {
            Y = startCoordinateY;
            X = startCoordinateX;
            Symbol = symbol; 
        }
    }
}
