using System;

namespace BLSnakeLibrary
{
    class FruitCountException : Exception
    {
        int OldCountValue { get; }

        int NewCountValue { get; }

        public FruitCountException()
        {
        }

        public FruitCountException(string massege)
            : base(massege)
        {
        }

        public FruitCountException(string massege, Exception innerException)
        : base(massege, innerException)
        {
        }

        public FruitCountException(string massege, int oldValue, int newValue)
            : base(massege)
        {
            OldCountValue = oldValue;
            NewCountValue = newValue;
        }
    }
}
