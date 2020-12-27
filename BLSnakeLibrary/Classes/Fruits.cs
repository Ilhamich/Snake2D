namespace BLSnakeLibrary
{
    public class Fruits
    {
        public const int UNEATEN = -1;

        public static readonly Coordinate UNTOUCHED_FRUIT = 
                new Coordinate {X = -1, Y =  -1 };

        private FruitElement[] _fruit;
        private int _fruitQuantity;
        private int _fruitEaten;

        private FruitElement[] _superFruit;
        private int _superFruitQuantity;
        private int _superFruitEating;

        public Fruits(byte fruitsLenght, byte superFruitsLehght)
        {
            _fruit = new FruitElement[fruitsLenght];

            for (int i = 0; i < _fruit.Length; i++)
            {
                _fruit[i] = new FruitElement
                    (new Coordinate(UNEATEN, UNEATEN), (char)Symbols.Apple);              
            }

            _fruitQuantity = 0;
            _fruitEaten = UNEATEN;

            _superFruit = new FruitElement[superFruitsLehght];

            for (int i = 0; i < _superFruit.Length; i++)
            {
                _superFruit[i] = new FruitElement
                    (new Coordinate(UNEATEN, UNEATEN), (char)Symbols.BigApple);
            }

            _superFruitQuantity = 0;
            _superFruitEating = UNEATEN;
        }

        /// <summary>
        /// Get or set quantity of fruits on field, but only more or less
        /// one unit like it was before
        /// </summary>
        public int FruitQuantity
        {
            get
            {
                return _fruitQuantity;
            }
            set
            {
                if (_fruitQuantity - value == -1 || _fruitQuantity - value == 1)
                {
                    _fruitQuantity = value;
                }
                else
                {
                    string massege = "Changes of count in one step can't be" +
                        " more 1. Now oldCount = " + _fruitQuantity +
                        " new count = " + value;

                    throw new FruitCountException(massege, _fruitQuantity, value);
                }
            }
        }

        /// <summary>
        /// Get or set number of eaten fruit
        /// </summary>
        public int FruitEaten
        {
            get
            {
                return _fruitEaten;
            }
            set
            {
                if (value < _fruit.Length && value >= -1)
                {
                    _fruitEaten = value;
                }
                else
                {
                    string massege = "Value can be not less -1(untouched)" +
                        " or not more " + _fruit.Length + ". Value is " + value;

                    throw new FruitEatingException(massege, _fruit.Length, value);
                }
            }
        }

        /// <summary>
        /// Get fruit by it's index
        /// </summary>
        /// <param name="index">index of fruit</param>
        /// <returns>FruitElement fruit[index]</returns>
        public FruitElement GetFruit(int index)
        {
            return _fruit[index];
        }

        /// <summary>
        /// Set fruit by it's index
        /// </summary>
        /// <param name="value">installable fruit</param>
        /// <param name="index">index of fruit</param>
        public void SetFruit(FruitElement value, int index)
        {
            _fruit[index] = value;
        }

        /// <summary>
        /// Get size of fruits arrey
        /// </summary>
        public int FruitLength
        {
            get
            {
                return _fruit.Length;
            }
        }

        /// <summary>
        /// Get or set quantity of superFruits on field, but only more or less
        /// one unit like it was before
        /// </summary>
        public int SuperFruitQuantity
        {
            get
            {
                return _superFruitQuantity;
            }
            set
            {
                if (_superFruitQuantity - value == -1
                        || _superFruitQuantity - value == 1)
                {
                    _superFruitQuantity = value;
                }
                else
                {
                    string massege = "Changes of count in one step can't be" +
                        " more 1. Now oldCount = " + _superFruitQuantity +
                        " new count = " + value;

                    throw new FruitCountException(massege, _superFruitQuantity, value);
                }
            }
        }

        /// <summary>
        /// Get or set number of eaten superFruit
        /// </summary>
        public int SuperFruitEating
        {
            get
            {
                return _superFruitEating;
            }
            set
            {
                if (value < _superFruit.Length && value >= -1)
                {
                    _superFruitEating = value;
                }
                else
                {
                    string massege = "Value can be not less -1(untouched)" +
                        " or not more " + _superFruit.Length + ". Value is " + value;

                    throw new FruitEatingException(massege, _superFruit.Length, value);
                }
            }
        }

        /// <summary>
        /// Get superFruit by it's index
        /// </summary>
        /// <param name="index">index of superFruit</param>
        /// <returns>FruitElement superFruit[index]</returns>
        public FruitElement GetSuperFruit(int index)
        {
            return _superFruit[index];
        }

        /// <summary>
        /// Set superFruit by it's index
        /// </summary>
        /// <param name="value">installable superFruit</param>
        /// <param name="index">index of superFruit</param>
        public void SetSuperFruit(FruitElement value, int index)
        {
            _superFruit[index] = value;
        }

        public int SuperFruitLength
        {
            get
            {
                return _superFruit.Length;
            }
        }

        /// <summary>
        /// Check coordinate fruit with coordinate other fruits and superfruits
        /// </summary>
        /// <param name="index"></param>
        /// <param name="check"></param>
        /// <returns>true if coordinate equal or false if not</returns>
        public void CheckFruitWihtFruits(int index, ref bool check)
        {
            for (int j = 0; j < FruitLength; j++)
            {
                if ((index != j) && (_fruit[index].Coord == _fruit[j].Coord))
                {
                    check = true;
                    return;
                }
            }

            for (int j = 0; j < SuperFruitLength; j++)
            {
                if (_fruit[index].Coord == _superFruit[j].Coord)
                {
                    check = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Check coordinate superfruit with coordinate other fruits and superfruits
        /// </summary>
        /// <param name="iter"></param>
        /// <param name="check"></param>
        /// <returns>true if coordinate equal or false if not</returns>
        public void CheckSuperFruitWihtFruits(int index, ref bool check)
        {
            for (int j = 0; j < FruitLength; j++)
            {
                if (_superFruit[index].Coord == _fruit[j].Coord)
                {
                    check = true;
                    return;
                }
            }

            for (int j = 0; j < SuperFruitLength; j++)
            {
                if ((index != j)
                       && (_superFruit[index].Coord == _superFruit[j].Coord))
                {
                    check = true;
                    break;
                }
            }
        }
    }
}
