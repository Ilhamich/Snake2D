using System;

namespace BLSnakeLibrary
{
    public class Snake
    {
        public const int NO_COORDINATE = -1;
        public static int START_SNAKE_BODY_RANGE = 15;
        private SnakeElement _head;
        private SnakeElement[] _body;
        private SnakeElement _tail;

        /// <summary>
        /// Size of snake with head but with out tail
        /// </summary>
        public int SizeOfSnake { get; private set; }

        public Snake(int sizeOfSnake, int startX, int startY)
        {
            _head = new SnakeElement(startY, startX, (char)Symbols.Head);

            _body = new SnakeElement[START_SNAKE_BODY_RANGE];

            for (int i = 0; i < _body.Length; i++)
            {
                _body[i] = new SnakeElement(NO_COORDINATE, NO_COORDINATE, '*');
            }

            _tail = new SnakeElement(NO_COORDINATE, NO_COORDINATE, ' ');

            SizeOfSnake = sizeOfSnake;
        }

        /// <summary>
        /// Get head of snake
        /// </summary>
        public SnakeElement Head
        {
            get
            {
                return _head;
            }
        }

        /// <summary>
        /// Get tail of snake
        /// </summary>
        public SnakeElement Tail
        {
            get
            {
                return _tail;
            }
        }

        /// <summary>
        /// Get one element of snake body by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>element of snake body by index</returns>
        public SnakeElement this[int index]
        {
            get
            {
                return _body[index];
            }
        }

        /// <summary>
        /// Get size of snake body with out of snake head and tail
        /// </summary>
        public int SizeOfBody
        {
            get
            {
                return _body.Length;
            }
        }

        /// <summary>
        /// Pass coordinate between elemets of Snake
        /// </summary>
        public void PassСoordinates()
        {
            for (int i = SizeOfSnake - 1; i >= 0; i--)
            {
                if ((i == SizeOfSnake - 1) && (_body[i - 1].Y != NO_COORDINATE)
                        && (_body[i - 1].X != NO_COORDINATE))
                {
                    _tail.X = _body[i - 1].X;
                    _tail.Y = _body[i - 1].Y;
                }
                else
                {
                    if ((i > 0) && (_body[i - 1].Y != NO_COORDINATE) &&
                        (_body[i - 1].X != NO_COORDINATE))
                    {
                        _body[i].X = _body[i - 1].X;
                        _body[i].Y = _body[i - 1].Y;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            _body[i].X = _head.X;
                            _body[i].Y = _head.Y;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Change direction of movement by enum for key
        /// </summary>
        /// <param name="key">key of movement</param>
        /// <param name="step">size of step on field</param>
        public void ChangeDirection(InputUser key, int step)
        {
            switch (key)
            {
                case InputUser.LeftArrow:
                    _head.X -= step;
                    break;
                case InputUser.UpArrow:
                    _head.Y -= step;
                    break;
                case InputUser.RightArrow:
                    _head.X += step;
                    break;
                case InputUser.DownArrow:
                    _head.Y += step;
                    break;
                default:
                    break;
            }
        }

        private void EnlargeRangeOfSnakeBody(int oldSizeOfBody)
        {
            Array.Resize(ref _body, _body.Length * 2);

            for (int j = 0; j < _body.Length; j++)
            {
                if (j >= oldSizeOfBody)
                {
                    _body[j] = new SnakeElement(NO_COORDINATE, NO_COORDINATE, '*');
                }
            }
        }

        /// <summary>
        /// Check on the coincidence of coordinate head of snake and 
        /// coordinate all elements of array fruits
        /// and arrey superFruits(check of eating)
        /// </summary>
        /// <param name="myFruits">Object fruits</param>
        public void CheckFruitsEating(Fruits myFruits)
        {
            myFruits.FruitEaten = Fruits.UNTOUCHED_FRUIT;

            int tmpSizeOfBody = SizeOfBody;

            for (int i = 0; i < myFruits.FruitLength; i++)
            {
                if (Head.X == myFruits.GetFruit(i).X
                        && Head.Y == myFruits.GetFruit(i).Y)
                {
                    myFruits.FruitEaten = i;
                    SizeOfSnake++;

                    if (SizeOfSnake > SizeOfBody)
                    {
                        EnlargeRangeOfSnakeBody(tmpSizeOfBody);
                    }

                    myFruits.FruitQuantity--;
                }
            }

            myFruits.SuperFruitEating = Fruits.UNTOUCHED_FRUIT;

            for (int i = 0; i < myFruits.SuperFruitLength; i++)
            {
                if (Head.X == myFruits.GetSuperFruit(i).X
                        && Head.Y == myFruits.GetSuperFruit(i).Y)
                {
                    myFruits.SuperFruitEating = i;
                    SizeOfSnake += 2;

                    if (SizeOfSnake > SizeOfBody)
                    {
                        EnlargeRangeOfSnakeBody(tmpSizeOfBody);
                    }

                    myFruits.SuperFruitQuantity--;
                }
            }
        }

        /// <summary>
        /// Check of encounter snake head with its body
        /// </summary>
        /// <returns>true if encounter was or false if not</returns>
        public bool CheckEncounter()
        {
            bool resolt = false;

            for (int i = 0; i < SizeOfSnake - 1; i++)
            {
                if (Head.X == _body[i].X && Head.Y == _body[i].Y)
                {
                    resolt = true;
                    break;
                }
            }

            return resolt;
        }
    }
}
