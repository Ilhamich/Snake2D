namespace BLSnakeLibrary
{
    public struct Coordinate
    {
        public int Y { get; set; }

        public int X { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Coordinate first, Coordinate second)
        {
            return first.X == second.X && first.Y == second.Y;
        }

        public static bool operator !=(Coordinate first, Coordinate second)
        {
            return first.X != second.X && first.Y != second.Y;
        }
    }
}
