using System;
using System.Drawing;

namespace BLSnakeLibrary
{
    [Serializable]
    public class GameSnake
    {
        public const int TICK_SPEED = 40;
        public const byte SCORE_FOR_WIN = 120;

        #region PRIVATE Fields
        [NonSerialized]
        private static Random rnd = new Random();

        private string[] _fruitImagePaths =
        {
            "..\\..\\Resources\\InvisibleFruit1 40x40.png",
            "..\\..\\Resources\\InvisibleFruit2 40x40.png",
            "..\\..\\Resources\\InvisibleFruit3 40x40.png"
        };

        private string[] _superFruitImagePaths =
        {
            "..\\..\\Resources\\InvisibleSuperFruit1 40x40.png",
            "..\\..\\Resources\\InvisibleSuperFruit2 40x40.png",
            "..\\..\\Resources\\InvisibleSuperFruit3 40x40.png"
        };
<<<<<<< HEAD

=======
      
        [NonSerialized]
        static Random rnd = new Random();

        #region PRIVATE Fields
>>>>>>> 58aa27d5b7fff7891179cec4ef2bafdbf7852165
        private double _timer;

        [NonSerialized]
        private Field _playField;

        private Snake _snake;
        private Fruits _fruits;
        #endregion

        public string HomeDir { get; } = ".\\Save";
        public string HomeFile { get; } = "Save.bin";
        public byte StepDisplay { get; private set; }
        public byte SizeOfSnake { get; private set; }
        public byte Accelerator { get; private set; }
        public byte WinScore { get; private set; }
        public byte FruitsLenght { get; private set; }
        public byte SuperFruitsLenght { get; private set; }
        public int CountEating { get; private set; }
        public Difficultys Difficulty { get; private set; }
        public int Interval { get; private set; } = TICK_SPEED *
                (byte)Difficultys.Normal;

        public int Timer
        {
            get { return (int)_timer; }
        }

        public Field PlayField
        {
            get { return _playField; }
        }

        public Fruits FruitsObj
        {
            get { return _fruits; }
        }

        public Snake SnakeObj
        {
            get { return _snake; }
        }

        public GameSnake()
        {
            SizeOfSnake = (byte)SizesOfSnake.Normal;
            Accelerator = (byte)Accelerators.Middle;
            WinScore = SCORE_FOR_WIN
                    - (TICK_SPEED * (byte)WinSpeed.Middle);

            FruitsLenght = (byte)FruitsSize.Medium;
            SuperFruitsLenght = (byte)SuperFruitsSize.Medium;

            Difficulty = Difficultys.Normal;
        }

        public void InitGameField(int sizeOfSides, int xOfLeftTopAngle,
                int yOfLeftTopAngle, int elementSize = 1)
        {
            _playField = new Field(sizeOfSides, xOfLeftTopAngle,
                    yOfLeftTopAngle, elementSize);

            StepDisplay = (byte)elementSize;
        }

        public void InitFruits(int elementSize = 1)
        {
            _fruits = new Fruits(FruitsLenght, SuperFruitsLenght,
                    elementSize);
        }

        public void InitSnake(Coordinate startCoord, int elementSize = 1)
        {
            _snake = new Snake(SizeOfSnake, startCoord, elementSize);
        }

        public void SetEasyDifficulty()
        {
            if (Difficulty != Difficultys.Easy)
            {
                Accelerator = (byte)Accelerators.Low;
                SizeOfSnake = (byte)SizesOfSnake.Big;
                WinScore = SCORE_FOR_WIN - (TICK_SPEED * (byte)WinSpeed.Easy);
                FruitsLenght = (byte)FruitsSize.Big;
                SuperFruitsLenght = (byte)SuperFruitsSize.Big;
                Interval = TICK_SPEED * (byte)Difficultys.Easy;
                Difficulty = Difficultys.Easy;
            }
        }

        public void SetMiddleDifficulty()
        {
<<<<<<< HEAD
            Accelerator = (byte)Accelerators.Middle;
            SizeOfSnake = (byte)SizesOfSnake.Normal;
            WinScore = SCORE_FOR_WIN - (TICK_SPEED * (byte)WinSpeed.Middle);
            FruitsLenght = (byte)FruitsSize.Medium;
            SuperFruitsLenght = (byte)SuperFruitsSize.Medium;
            Interval = TICK_SPEED * (byte)Difficultys.Normal;
            Difficulty = Difficultys.Normal;
=======
            //TODO при выходе не меняет интервал на средней сложности
            //if (Difficulty != Difficultys.Normal)
            {
                Accelerator = (byte)Accelerators.Middle;
                SizeOfSnake = (byte)SizesOfSnake.Normal;
                WinScore = SCORE_FOR_WIN - (TICK_SPEED * (byte)WinSpeed.Middle);
                FruitsLenght = (byte)FruitsSize.Medium;
                SuperFruitsLenght = (byte)SuperFruitsSize.Medium;
                Interval = TICK_SPEED * (byte)Difficultys.Normal;
                Difficulty = Difficultys.Normal;
            }
>>>>>>> 58aa27d5b7fff7891179cec4ef2bafdbf7852165
        }

        public void SetHightDifficulty()
        {
            if (Difficulty != Difficultys.Hight)
            {
                Accelerator = (byte)Accelerators.High;
                SizeOfSnake = (byte)SizesOfSnake.Small;
                WinScore = SCORE_FOR_WIN - (TICK_SPEED * (byte)WinSpeed.High);
                FruitsLenght = (byte)FruitsSize.Small;
                SuperFruitsLenght = (byte)SuperFruitsSize.Small;
                Interval = TICK_SPEED * (byte)Difficultys.Hight;
                Difficulty = Difficultys.Hight;
            }
        }

        /// <summary>
        /// Generate fruit coordinate
        /// </summary>
        /// <param name="fruit">fruit for coordinate generation </param>
        /// <param name="LeftTopAngle">left top angle of field</param>
        /// <param name="RightDownAngle">right down angle of field</param>
        /// <returns>fruit with coordinate </returns>
        public Coordinate GiveFruitCoordinate()
        {
            if (_playField == null)
            {
                throw new ArgumentNullException("object field not initialized");
            }

            int minusArg = 0;

            if (_playField.ElementSize >= _fruits.ElementSize)
            {
                minusArg = _playField.ElementSize;
            }
            else
            {
                minusArg = _fruits.ElementSize;
            }

            int lowerLimitX = (_playField.LeftTopAngle.X +
                    _playField.ElementSize) / _playField.ElementSize;
            int upperLimitX = (_playField.RightDownAngle.X -
                    minusArg) / _playField.ElementSize;
            int lowerLimitY = (_playField.LeftTopAngle.Y +
                    _playField.ElementSize) / _playField.ElementSize;
            int upperLimitY = (_playField.RightDownAngle.Y -
                    minusArg) / _playField.ElementSize;

            return new Coordinate(rnd.Next(lowerLimitX, upperLimitX) *
                    _playField.ElementSize, rnd.Next(lowerLimitY,
                    upperLimitY) * _playField.ElementSize);
        }

        /// <summary>
        /// Check coordinates one of fruit with location of snake.
        /// </summary>
        /// <param name="fruit">one of fruit</param>
        /// <param name="mySnake">Object of snake</param>
        /// <returns>Resolt of check, if was coincidence true and false if not</returns>
        public void CheckFruitWithSnake(FruitElement fruit, ref bool check)
        {
            if (fruit.Coord == _snake.Head.Coord)
            {
                check = true;
            }

            for (int i = 0; i < _snake.SizeOfSnake - 1; i++)
            {
                if (fruit.Coord == _snake[i].Coord)
                {
                    check = true;
                    return;
                }
            }

            if (fruit.Coord == _snake.Tail.Coord)
            {
                check = true;
            }
        }

        public void Check2DFruitWithSnake(FruitElement fruit, ref bool check)
        {
            if (Check2DFruitWithSnakeElement(fruit, _snake.Head))
            {
                check = true;
            }

            for (int i = 0; i < _snake.SizeOfSnake - 1; i++)
            {
                if (Check2DFruitWithSnakeElement(fruit, _snake[i]))
                {
                    check = true;
                    return;
                }
            }

            if (Check2DFruitWithSnakeElement(fruit, _snake.Tail))
            {
                check = true;
            }
        }

        private bool Check2DFruitWithSnakeElement(FruitElement fruit,
                SnakeElement sElement)
        {
            bool resolt = false;

            foreach (var item in fruit)
            {
                if (item == sElement.Coord)
                {
                    resolt = true;
                    break;
                }
            }

            return resolt;
        }

        /// <summary>
        /// Check of encounter snake head with border field
        /// </summary>
        /// <param name="head">Element head of snake</param>
        /// <param name="border">Array of border elements</param>
        /// <returns>true or false</returns>
        public bool CheckEncounterWithBorders(BorderElement border)
        {
            bool resolt = false;

            if (_snake.Head.Coord == border.Coord)
            {
                resolt = true;
            }

            return resolt;
        }

        public bool CheckObstructionBorders()
        {
            bool obstruction = false;

            for (int i = 0; i < _playField.FieldLenght; i++)
            {
                if (CheckEncounterWithBorders(_playField[i]))
                {
                    obstruction = true;
                    break;
                }
            }

            return obstruction;
        }

        #region Fruit Generator 
        public void GenerateFruit()
        {
            GenerateFruitByCount();
            GenerateSuperFruitByCount();
        }

        public void GenerateFruitByCount()
        {
            if (_fruits.FruitQuantity < _fruits.FruitLength)
            {
                if (_fruits.FruitEaten == Fruits.UNEATEN)
                {
                    GenerateFruit(_fruits.FruitQuantity);

                    _fruits.FruitQuantity++;
                }
                else
                {
                    GenerateFruit(_fruits.FruitEaten);

                    _fruits.FruitQuantity++;
                }
            }
        }

        public void GenerateSuperFruitByCount()
        {
            if (_fruits.SuperFruitQuantity < _fruits.SuperFruitLength)
            {
                if (_fruits.SuperFruitEating == Fruits.UNEATEN)
                {
                    GenerateSuperFruit(_fruits.SuperFruitQuantity);

                    _fruits.SuperFruitQuantity++;
                }
                else
                {
                    GenerateSuperFruit(_fruits.SuperFruitEating);

                    _fruits.SuperFruitQuantity++;
                }
            }
        }

        public void GenerateFruit(int fruitNum)
        {
            bool checkResolt = false;

            do
            {
                checkResolt = false;

                FruitElement tmpFruit = new FruitElement(GiveFruitCoordinate()
                        , (char)Symbols.Apple);

                _fruits.SetFruit(tmpFruit, fruitNum);

                CheckFruitWithSnake(_fruits.GetFruit(fruitNum),
                        ref checkResolt);

                if (checkResolt)
                {
                    continue;
                }

                _fruits.CheckFruitWihtFruits(fruitNum, ref checkResolt);
            } while (checkResolt);
        }

        public void GenerateSuperFruit(int fruitNum)
        {
            bool checkResolt = false;

            do
            {
                checkResolt = false;

                FruitElement tmpSuperFruit = new FruitElement(GiveFruitCoordinate()
                      , (char)Symbols.BigApple);

                _fruits.SetSuperFruit(tmpSuperFruit, fruitNum);

                CheckFruitWithSnake(_fruits.GetSuperFruit(fruitNum),
                        ref checkResolt);

                if (checkResolt)
                {
                    continue;
                }

                _fruits.CheckSuperFruitWihtFruits(fruitNum, ref checkResolt);
            } while (checkResolt);
        }
        #endregion

        #region 2D Fruit Generator
        public void Generate2DFruit()
        {
            Generate2DFruitByCount();
            Generate2DSuperFruitByCount();
            _fruits.IsFruit2D = true;
        }

        private void Generate2DFruitByCount()
        {
            if (_fruits.FruitQuantity < _fruits.FruitLength)
            {
                if (_fruits.FruitEaten == Fruits.UNEATEN)
                {
                    Generate2DFruit(_fruits.FruitQuantity);

                    _fruits.FruitQuantity++;
                }
                else
                {
                    Generate2DFruit(_fruits.FruitEaten);

                    _fruits.FruitQuantity++;
                }
            }
        }

        private void Generate2DSuperFruitByCount()
        {
            if (_fruits.SuperFruitQuantity < _fruits.SuperFruitLength)
            {
                if (_fruits.SuperFruitEating == Fruits.UNEATEN)
                {
                    Generate2DSuperFruit(_fruits.SuperFruitQuantity);

                    _fruits.SuperFruitQuantity++;
                }
                else
                {
                    Generate2DSuperFruit(_fruits.SuperFruitEating);

                    _fruits.SuperFruitQuantity++;
                }
            }
        }

        public void Generate2DFruit(int fruitNum)
        {
            bool checkResolt = false;

            do
            {
                checkResolt = false;

                FruitElement tmpFruit = new FruitElement(GiveFruitCoordinate(),
                        new Bitmap(_fruitImagePaths[rnd.Next(0,
                        _fruitImagePaths.Length)]), _snake.ElementSize, 30);

                _fruits.SetFruit(tmpFruit, fruitNum);

                Check2DFruitWithSnake(_fruits.GetFruit(fruitNum),
                        ref checkResolt);

                if (checkResolt)
                {
                    continue;
                }

                _fruits.Check2DFruitWihtFruits(fruitNum, ref checkResolt);
            } while (checkResolt);
        }

        public void Generate2DSuperFruit(int fruitNum)
        {
            bool checkResolt = false;

            do
            {
                checkResolt = false;

                FruitElement tmpSuperFruit = new FruitElement(GiveFruitCoordinate(),
                        new Bitmap(_superFruitImagePaths[rnd.Next(0,
                        _superFruitImagePaths.Length)]),
                        _snake.ElementSize, 30);

                _fruits.SetSuperFruit(tmpSuperFruit, fruitNum);

                Check2DFruitWithSnake(_fruits.GetSuperFruit(fruitNum),
                        ref checkResolt);

                if (checkResolt)
                {
                    continue;
                }

                _fruits.Check2DSuperFruitWihtFruits(fruitNum, ref checkResolt);
            } while (checkResolt);
        }
        #endregion

        public void WorkOnSpeed()
        {
            if (_fruits.FruitEaten != Fruits.UNEATEN
                    || _fruits.SuperFruitEating != Fruits.UNEATEN)
            {
                CountEating++;

                if (CountEating % Accelerator == 0
                        && Interval - TICK_SPEED > TICK_SPEED)
                {
                    Interval -= TICK_SPEED;
                }
            }
        }

        public bool CheckWin()
        {
            bool win = false;

            if (_snake.SizeOfSnake == WinScore)
            {
                win = true;
            }

            return win;
        }

        public void RunTimer(short divider)
        {
            _timer += (double)Interval / divider;
        }

        public void Reset()
        {
            CountEating = 0;
            _timer = 0;
            SetMiddleDifficulty();
        }

        public void RunSnakeDynamics(InputUser key)
        {
            if (_fruits.IsFruit2D)
            {
                SnakeObj.Check2DFruitsEating(FruitsObj);
            }
            else
            {
                SnakeObj.CheckFruitsEating(FruitsObj);
            }

            WorkOnSpeed();
            SnakeObj.PassСoordinates();
            SnakeObj.ChangeDirection(key);
        }

        public void SetDifficulty(byte choisDifficulty)
        {
            switch (choisDifficulty)
            {
                case (byte)DifficultyChois.Easy:
                    SetEasyDifficulty();
                    break;

                case (byte)DifficultyChois.Normal:
                    SetMiddleDifficulty();
                    break;

                case (byte)DifficultyChois.High:
                    SetHightDifficulty();
                    break;

                default:
                    SetMiddleDifficulty();
                    break;
            }
        }
    }
}
