using System;
using System.Collections.Generic;

namespace BLSnakeLibrary
{
    [Serializable]
    public class Snake
    {
        #region PRIVATE
        private const byte SUPERFRUIT_PRIZ = 2;
        private SnakeElement _head;
        private List<SnakeElement> _body;
        private SnakeElement _tail;
        #endregion

        public static readonly Coordinate NO_COORDINATE
               = new Coordinate { X = -1, Y = -1 };

        /// <summary>
        /// Size of snake with head but with out tail
        /// </summary>
        public int SizeOfSnake { get; private set; }
        public int ElementSize { get; private set; }
        public SnakeDirection Direction { get; private set; }

        public Snake(int sizeOfSnake, Coordinate startCoord,
            int elementSize = 1)
        {
            _head = new SnakeElement(startCoord,
                    (char)Symbols.Head);

            _body = new List<SnakeElement>(sizeOfSnake - 1);

            for (int i = 0; i < sizeOfSnake - 1; i++)
            {
                _body.Add(new SnakeElement(NO_COORDINATE, '*'));
            }

            _tail = new SnakeElement(NO_COORDINATE, ' ');

            SizeOfSnake = sizeOfSnake;
            ElementSize = elementSize;
            Direction = SnakeDirection.Down;
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
                return _body.Count;
            }
        }

        /// <summary>
        /// Pass coordinate between elemets of Snake
        /// </summary>
        public void PassСoordinates()
        {
            for (int i = SizeOfSnake - 1; i >= 0; i--)
            {
                if ((i == SizeOfSnake - 1)
                        && (_body[i - 1].Coord != NO_COORDINATE))
                {
                    _tail.Coord = _body[i - 1].Coord;
                }
                else
                {
                    if ((i > 0) && (_body[i - 1].Coord != NO_COORDINATE))
                    {
                        _body[i].ChangeCoordinate(_body[i - 1].Coord);
                    }
                    else
                    {
                        if (i == 0)
                        {
                            _body[i].ChangeCoordinate(_head.Coord);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Change direction of movement by enum for key
        /// </summary>
        /// <param name="key">key of movement</param>
        public void ChangeDirection(InputUser key)
        {
            if (key <= InputUser.DownArrow)
            {
                Direction = (SnakeDirection)key;
            }
            
            switch (Direction)
            {
                case SnakeDirection.Left:
                    _head.Coord = new Coordinate
                            (_head.Coord.X - ElementSize, _head.Coord.Y);
                    break;
                case SnakeDirection.Up:
                    _head.Coord = new Coordinate
                            (_head.Coord.X, _head.Coord.Y - ElementSize);
                    break;
                case SnakeDirection.Right:
                    _head.Coord = new Coordinate
                           (_head.Coord.X + ElementSize, _head.Coord.Y);
                    break;
                case SnakeDirection.Down:
                    _head.Coord = new Coordinate
                            (_head.Coord.X, _head.Coord.Y + ElementSize);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Check on the coincidence of coordinate head of snake and 
        /// coordinate all elements of array fruits
        /// and arrey superFruits(check of eating)
        /// </summary>
        /// <param name="myFruits">Object fruits</param>
        public void CheckFruitsEating(Fruits myFruits)//TODO if fruit is array
        {
            myFruits.FruitEaten = Fruits.UNEATEN;

            for (int i = 0; i < myFruits.FruitLength; i++)
            {
                if (Head.Coord == myFruits.GetFruit(i).Coord)
                {
                    myFruits.FruitEaten = i;
                    SizeOfSnake++;

                    if (SizeOfSnake - 1 > SizeOfBody)
                    {
                        _body.Add(new SnakeElement(NO_COORDINATE, '*'));
                    }

                    myFruits.FruitQuantity--;

                    return;
                }
            }

            myFruits.SuperFruitEating = Fruits.UNEATEN;

            for (int i = 0; i < myFruits.SuperFruitLength; i++)
            {
                if (Head.Coord == myFruits.GetSuperFruit(i).Coord)
                {
                    myFruits.SuperFruitEating = i;
                    SizeOfSnake += SUPERFRUIT_PRIZ;

                    if (SizeOfSnake > SizeOfBody)
                    {
                        for (int j = 0; j < SUPERFRUIT_PRIZ; j++)
                        {
                            _body.Add(new SnakeElement(NO_COORDINATE, '*'));
                        }
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
                if (Head.Coord == _body[i].Coord)
                {
                    resolt = true;
                    break;
                }
            }

            return resolt;
        }

        public InputUser SetDirection()
        {
            InputUser direction = InputUser.DownArrow;

            if (_body[0].Coord.X != -1 && _body[0].Coord.Y != -1)
            {
                if (Head.Coord.X == _body[0].Coord.X)
                {
                    if (Head.Coord.Y > _body[0].Coord.Y)
                    {
                        direction = InputUser.DownArrow;
                    }
                    else
                    {
                        direction = InputUser.UpArrow;
                    }
                }
                else
                {
                    if (Head.Coord.X > _body[0].Coord.X)
                    {
                        direction = InputUser.RightArrow;
                    }
                    else
                    {
                        direction = InputUser.LeftArrow;
                    }
                }
            }

            return direction;
        }
    }
}
