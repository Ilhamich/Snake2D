using System;

namespace BLSnakeLibrary
{
    class FruitEatingException : Exception
    {
        int FruitLenght { get; }

        int SetValue { get; }

        public FruitEatingException()
        {
        }

        public FruitEatingException(string massage)
            : base(massage)
        {
        }

        public FruitEatingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public FruitEatingException(string massage, int fLenght, int value)
            : base(massage)
        {
            FruitLenght = fLenght;
            SetValue = value;
        }
    }
}
