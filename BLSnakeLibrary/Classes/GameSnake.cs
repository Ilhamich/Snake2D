using System;

namespace BLSnakeLibrary
{
    public class GameSnake
    {
        public const int TICK_SPEED = 40;
        public const byte SCORE_FOR_WIN = 120;

        static Random rnd = new Random();

        private bool _easyDif;
        private bool _middleDif;
        private bool _highDif;

        public byte StepDisplay { get; private set; }
        public byte SizeOfSnake { get; private set; }
        public byte Accelerator { get; private set; }
        public byte WinScore { get; private set; }
        public byte FruitsLenght { get; private set; }
        public byte SuperFruitsLenght { get; private set; }

        private Field _playField;
        private Snake _snake;
        private Fruits _fruits;

        public Field PlayField
        {
            get { return _playField; }
        }

        public Fruits FruitsGame
        {
            get { return _fruits; }
        }

        public Snake SnakeGame
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

        public int SetEasyDifficulty(int oldInterval)
        {
            int interval = oldInterval;

            if (!_easyDif)
            {
                Accelerator = (byte)Accelerators.Low;
                SizeOfSnake = (byte)SizesOfSnake.Big;
                WinScore = SCORE_FOR_WIN - (TICK_SPEED * (byte)WinSpeed.Easy);
                FruitsLenght = (byte)FruitsSize.Big;
                SuperFruitsLenght = (byte)SuperFruitsSize.Big;
                interval = TICK_SPEED * (byte)Difficulty.Easy;
                _easyDif = true;
                _middleDif = false;
                _highDif = false;
            }

            return interval;
        }

        public int SetMiddleDifficulty(int oldInterval)
        {
            int interval = oldInterval;

            if (!_middleDif)
            {
                Accelerator = (byte)Accelerators.Middle;
                SizeOfSnake = (byte)SizesOfSnake.Normal;
                WinScore = SCORE_FOR_WIN - (TICK_SPEED * (byte)WinSpeed.Middle);
                FruitsLenght = (byte)FruitsSize.Medium;
                SuperFruitsLenght = (byte)SuperFruitsSize.Medium;
                interval = TICK_SPEED * (byte)Difficulty.Normal;
                _easyDif = false;
                _middleDif = true;
                _highDif = false;
            }

            return interval;
        }

        public int SetHightDifficulty(int oldInterval)
        {
            int interval = oldInterval;

            if (!_highDif)
            {
                Accelerator = (byte)Accelerators.High;
                SizeOfSnake = (byte)SizesOfSnake.Small;
                WinScore = SCORE_FOR_WIN - (TICK_SPEED * (byte)WinSpeed.High);
                FruitsLenght = (byte)FruitsSize.Small;
                SuperFruitsLenght = (byte)SuperFruitsSize.Small;
                interval = TICK_SPEED * (byte)Difficulty.Hight;
                _easyDif = false;
                _middleDif = false;
                _highDif = true;
            }

            return interval;
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

        public int WorkOnSpeed(int interval, ref int countEating)
        {
            int intervalNew = interval;

            if (_fruits.FruitEaten != Fruits.UNEATEN
                    || _fruits.SuperFruitEating != Fruits.UNEATEN)
            {
                countEating++;

                if (countEating % Accelerator == 0
                        && intervalNew - TICK_SPEED > TICK_SPEED)
                {
                    intervalNew -= TICK_SPEED;
                }
            }

            return intervalNew;
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
    }
}
