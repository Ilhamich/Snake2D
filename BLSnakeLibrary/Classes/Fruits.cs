using System;

namespace BLSnakeLibrary
{
    [Serializable]
    public class Fruits
    {
        public const int UNEATEN = -1;

        #region PRIVATE
        private FruitElement[] _fruit;
        private int _fruitQuantity;
        private int _fruitEaten;

        private FruitElement[] _superFruit;
        private int _superFruitQuantity;
        private int _superFruitEating;
        #endregion

        public Fruits(byte fruitsLenght, byte superFruitsLehght,
               int elementSize)
        {
            _fruit = new FruitElement[fruitsLenght];

            ElementSize = elementSize;

            _fruitQuantity = 0;
            _fruitEaten = UNEATEN;

            _superFruit = new FruitElement[superFruitsLehght];

            _superFruitQuantity = 0;
            _superFruitEating = UNEATEN;
        }

        public int ElementSize { get; private set; }

        public bool IsFruit2D { get; internal set;}

        public int FruitLength
        {
            get
            {
                return _fruit.Length;
            }
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

        public int SuperFruitLength
        {
            get
            {
                return _superFruit.Length;
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
                if (_fruit[j] == null)
                {
                    break;
                }

                if ((index != j) && (_fruit[index].Coord == _fruit[j].Coord))
                {
                    check = true;
                    return;
                }
            }

            for (int j = 0; j < SuperFruitLength; j++)
            {
                if (_superFruit[j] == null)
                {
                    break;
                }

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
                if (_fruit[j] == null)
                {
                    break;
                }

                if (_superFruit[index].Coord == _fruit[j].Coord)
                {
                    check = true;
                    return;
                }
            }

            for (int j = 0; j < SuperFruitLength; j++)
            {
                if (_superFruit[j] == null)
                {
                    break;
                }

                if ((index != j)
                       && (_superFruit[index].Coord == _superFruit[j].Coord))
                {
                    check = true;
                    break;
                }
            }
        }

        public void Check2DFruitWihtFruits(int index, ref bool check)
        {
            for (int j = 0; j < FruitLength; j++)
            {
                if ((index != j) && Check2DfruitWith2DFruit(_fruit[index], _fruit[j]))
                {
                    check = true;
                    return;
                }
            }

            for (int j = 0; j < SuperFruitLength; j++)
            {
                if (Check2DfruitWith2DFruit(_fruit[index], _superFruit[j]))
                {
                    check = true;
                    break;
                }
            }
        }
        
        public void Check2DSuperFruitWihtFruits(int index, ref bool check)
        {
            for (int j = 0; j < FruitLength; j++)
            {
                if (Check2DfruitWith2DFruit(_superFruit[index], _fruit[j]))
                {
                    check = true;
                    return;
                }
            }

            for (int j = 0; j < SuperFruitLength; j++)
            {
                if ((index != j)
                       && Check2DfruitWith2DFruit(_superFruit[index], _superFruit[j]))
                {
                    check = true;
                    break;
                }
            }
        }
        
        private bool Check2DfruitWith2DFruit(FruitElement first, FruitElement second)
        {
            bool resolt = false;

            foreach (var fCoord in first)
            {
                if (second == null)

                {
                    break;
                }

                foreach (var sCoord in second)
                {
                    if (fCoord == sCoord)
                    {
                        resolt = true;
                        break;
                    }
                }

                if (resolt)
                {
                    break;
                }
            }

            return resolt;
        }
    }
}
