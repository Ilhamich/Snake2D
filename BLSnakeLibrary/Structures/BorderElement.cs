namespace BLSnakeLibrary
{
    public struct BorderElement
    {
        public int X { get;}

        public int Y { get;}

        public char Symbol { get;}

        public BorderElement(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }
    }
}
