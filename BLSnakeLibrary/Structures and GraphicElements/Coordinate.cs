using System;

namespace BLSnakeLibrary
{
    [Serializable]
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

        public override bool Equals(object obj)
        {
            return obj is Coordinate coordinate &&
                   Y == coordinate.Y &&
                   X == coordinate.X;
        }

        public override int GetHashCode()
        {
            int hashCode = 27121115;
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            return hashCode;
        }
    }
}
