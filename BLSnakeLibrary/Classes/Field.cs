namespace BLSnakeLibrary
{
    public class Field
    {
        #region PRIVATE Fields
        private const byte QUANTITY_OF_SIDE = 4;
        private const byte ANGLES_ON_ONE_SIDE = 2;
        private const byte ANGLES_ON_FIELD = 4;

        private int _sizeOfSides;

        private BorderElement[] _pointOfField;

        private Coordinate _lTopAngleCoord;
        private Coordinate _rDownAngleCoord;

        private char[] _angles =
        {
            (char)BordersSymbols.LeftTop,
            (char)BordersSymbols.RightTop,
            (char)BordersSymbols.LeftDown,
            (char)BordersSymbols.RightDown
        };
        #endregion

        public int ElementSize { get; private set; }

        public int FieldLenght
        {
            get
            {
                int length = 0;

                if (_pointOfField.Length != 0)
                {
                    length = _pointOfField.Length;
                }

                return length;
            }
        }

        public Coordinate LeftTopAngle
        {
            get => _lTopAngleCoord;
        }

        public Coordinate RightDownAngle
        {
            get =>_rDownAngleCoord;          
        }

        public Field(int sizeOfSides, int xOfLeftTopAngle, int yOfLeftTopAngle, int step = 1)
        {
            ElementSize = step;
            _sizeOfSides = sizeOfSides;
            _lTopAngleCoord.X = xOfLeftTopAngle;
            _lTopAngleCoord.Y = yOfLeftTopAngle;
            _rDownAngleCoord.X = _lTopAngleCoord.X + (_sizeOfSides - 1) * ElementSize;
            _rDownAngleCoord.Y = _lTopAngleCoord.Y + (_sizeOfSides - 1) * ElementSize;

            BuildField(sizeOfSides);
        }

        /// <summary>
        /// Return one of BorderElement by it's index
        /// </summary>
        /// <param name="index">index of BorderElement in all BorderElements</param>
        /// <returns>BorderElement</returns>
        public BorderElement this[int index]
        {
            get => _pointOfField[index];
        }

        #region Private Methods
        private void BuildField(int sizeOfSide)
        {
            _pointOfField = new BorderElement[sizeOfSide * QUANTITY_OF_SIDE - ANGLES_ON_FIELD];

            int index = 0;
            int symbolNum = 0;

            for (int sideNumber = 0; sideNumber < QUANTITY_OF_SIDE; sideNumber++)
            {
                if ((sideNumber + 1) % 2 != 0)
                {
                    for (int count = 0; count < sizeOfSide; count++)
                    {
                        BildHorizontalLine(index, count, sideNumber, ref symbolNum);
                        index++;
                    }
                }
                else
                {
                    for (int count = 0; count < sizeOfSide - ANGLES_ON_ONE_SIDE; count++)
                    {
                        BildVerticallLine(index, count, sideNumber);
                        index++;
                    }
                }
            }
        }

        private void BildVerticallLine(int index, int count, int sideNumber)
        {
            int xPosition = 0;

            if (sideNumber == 1) xPosition = _lTopAngleCoord.X;
            else xPosition = _rDownAngleCoord.X;
            
            _pointOfField[index] = new BorderElement(new Coordinate(xPosition, _lTopAngleCoord.Y + ElementSize + (count * ElementSize)), (char)BordersSymbols.Vertical);
        }

        private void BildHorizontalLine(int index, int count, int sideNumber,
                ref int symbol)
        {
            int yPosition = 0;

            if (sideNumber == 0) yPosition = _lTopAngleCoord.Y;
            else yPosition = _rDownAngleCoord.Y;
            
            if (count == 0)
            {
                _pointOfField[index] =new BorderElement(new Coordinate(_lTopAngleCoord.X + count * ElementSize, yPosition), _angles[symbol]);

                symbol++;
            }
            else
            {
                if (count == _sizeOfSides - 1)
                {
                    _pointOfField[index] = new BorderElement(new Coordinate(_lTopAngleCoord.X + count * ElementSize, yPosition), _angles[symbol]);

                    symbol++;
                }
                else
                {
                    _pointOfField[index] = new BorderElement(new Coordinate(_lTopAngleCoord.X + count * ElementSize, yPosition), (char)BordersSymbols.Horizontal);
                }
            }
        }
        #endregion
    }
}
