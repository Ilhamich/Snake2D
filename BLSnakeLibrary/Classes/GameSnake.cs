using System;

namespace BLSnakeLibrary
{
    [Serializable]
    public class GameSnake
    {
        public const int TICK_SPEED = 40;
        public const byte SCORE_FOR_WIN = 120;

        [NonSerialized]
        static Random rnd = new Random();

        #region PRIVATE
        private bool _easyDif;
        private bool _middleDif;
        private bool _highDif;
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
        public int Interval { get;private set; } = TICK_SPEED * 
                (byte)Difficulty.Normal;

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

            _middleDif = true;
        }

        public void InitGameField(int sizeOfSides, int xOfLeftTopAngle,
                int yOfLeftTopAngle, int step = 1)
        {
            _playField = new Field
                    (sizeOfSides, xOfLeftTopAngle, yOfLeftTopAngle, step);

            StepDisplay = (byte)step;
        }

        public void InitFruits()
        {
            _fruits = new Fruits(FruitsLenght, SuperFruitsLenght);
        }

        public void InitSnake(Coordinate startCoord)
        {
            _snake = new Snake(SizeOfSnake, startCoord);
        }

        public void SetEasyDifficulty()
        {
            if (!_easyDif)
            {
                Accelerator = (byte)Accelerators.Low;
                SizeOfSnake = (byte)SizesOfSnake.Big;
                WinScore = SCORE_FOR_WIN - (TICK_SPEED * (byte)WinSpeed.Easy);
                FruitsLenght = (byte)FruitsSize.Big;
                SuperFruitsLenght = (byte)SuperFruitsSize.Big;
                Interval = TICK_SPEED * (byte)Difficulty.Easy;
                _easyDif = true;
                _middleDif = false;
                _highDif = false;
            }
        }

        public void SetMiddleDifficulty()
        {
            if (!_middleDif)
            {
                Accelerator = (byte)Accelerators.Middle;
                SizeOfSnake = (byte)SizesOfSnake.Normal;
                WinScore = SCORE_FOR_WIN - (TICK_SPEED * (byte)WinSpeed.Middle);
                FruitsLenght = (byte)FruitsSize.Medium;
                SuperFruitsLenght = (byte)SuperFruitsSize.Medium;
                Interval = TICK_SPEED * (byte)Difficulty.Normal;
                _easyDif = false;
                _middleDif = true;
                _highDif = false;
            }
        }

        public void SetHightDifficulty()
        {
            if (!_highDif)
            {
                Accelerator = (byte)Accelerators.High;
                SizeOfSnake = (byte)SizesOfSnake.Small;
                WinScore = SCORE_FOR_WIN - (TICK_SPEED * (byte)WinSpeed.High);
                FruitsLenght = (byte)FruitsSize.Small;
                SuperFruitsLenght = (byte)SuperFruitsSize.Small;
                Interval = TICK_SPEED * (byte)Difficulty.Hight;
                _easyDif = false;
                _middleDif = false;
                _highDif = true;
            }
        }

        /// <summary>
        /// Generate fruit coordinate
        /// </summary>
        /// <param name="fruit">fruit for coordinate generation </param>
        /// <param name="LeftTopAngle">left top angle of field</param>
        /// <param name="RightDownAngle">right down angle of field</param>
        /// <param name="step">size of step on field</param>
        /// <returns>fruit with coordinate </returns>
        public void GiveFruitCoordinate(int step, ref FruitElement fruit)
        {
            int lowerLimitX = (_playField.LeftTopAngle.X + step) / step;
            int upperLimitX = (_playField.RightDownAngle.X - step) / step;
            int lowerLimitY = (_playField.LeftTopAngle.Y + step) / step;
            int upperLimitY = (_playField.RightDownAngle.Y - step) / step;

            fruit.SetCoordX(rnd.Next(lowerLimitX, upperLimitX) * step);
            fruit.SetCoordY(rnd.Next(lowerLimitY, upperLimitY) * step);
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

        public void GenerateFruit(int stepDispaly, int fruitNum)
        {
            bool checkResolt = false;

            do
            {
                checkResolt = false;

                FruitElement tmpFruit = _fruits.GetFruit(fruitNum);

                GiveFruitCoordinate(stepDispaly, ref tmpFruit);

                _fruits.SetFruit(tmpFruit, fruitNum);

                CheckFruitWithSnake
                        (_fruits.GetFruit(fruitNum), ref checkResolt);

                if (checkResolt)
                {
                    continue;
                }

                _fruits.CheckFruitWihtFruits(fruitNum, ref checkResolt);
            } while (checkResolt);
        }

        public void GenerateSuperFruit(int stepDispaly, int fruitNum)
        {
            bool checkResolt = false;

            do
            {
                checkResolt = false;

                FruitElement tmpSuperFruit = _fruits.GetSuperFruit(fruitNum);

                GiveFruitCoordinate(stepDispaly, ref tmpSuperFruit);

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

        public void GenerateFruitByCount(int step)
        {
            if (_fruits.FruitQuantity < _fruits.FruitLength)
            {
                if (_fruits.FruitEaten == Fruits.UNEATEN)
                {
                    GenerateFruit(step, _fruits.FruitQuantity);

                    _fruits.FruitQuantity++;
                }
                else
                {
                    GenerateFruit(step, _fruits.FruitEaten);

                    _fruits.FruitQuantity++;
                }
            }
        }

        public void GenerateSuperFruitByCount(int step)
        {
            if (_fruits.SuperFruitQuantity < _fruits.SuperFruitLength)
            {
                if (_fruits.SuperFruitEating == Fruits.UNEATEN)
                {
                    GenerateSuperFruit(step, _fruits.SuperFruitQuantity);

                    _fruits.SuperFruitQuantity++;
                }
                else
                {
                    GenerateSuperFruit(step, _fruits.SuperFruitEating);

                    _fruits.SuperFruitQuantity++;
                }
            }
        }

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
            Interval = TICK_SPEED * (byte)Difficulty.Normal;
        }

        public void RunSnakeDynamics(InputUser key, int step)
        {
            SnakeObj.CheckFruitsEating(FruitsObj);
            WorkOnSpeed();
            SnakeObj.PassСoordinates();
            SnakeObj.ChangeDirection(key, step);
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
