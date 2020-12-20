using BLSnakeLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Training_Snake
{
    public partial class FormGameSnake : Form
    {
        const int STEP_DISPLAY = 10;
        const int FIELD_SIZE = 41;
        const int SNAKE_START_X_POSITION = 200;
        const int SNAKE_START_Y_POSITION = 10;
        const int TICK_SPEED = 40;

        private bool _pouse = false;
        private int _sizeOfSnake = (int)SizesOfSnake.Normal;
        private int _accelerator = (int)Accelerators.Middle;
        private double _timer = 0;
        private int _countEating;
        private InputUser _direction;
        private Snake _snake;
        private Field _playField;
        private FruitsOnField _fruits;

        public FormGameSnake()
        {
            InitializeComponent();

            _playField = new Field(FIELD_SIZE, 0, 0, STEP_DISPLAY);
        }

        private void timerGemeTick(object sender, EventArgs e)
        {
            if (!_pouse)
            {
                _timer += (double)timerGame.Interval / 1000;
                pictureBoxSand.Invalidate();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _pouse = true;
                labelPause.Visible = true;
                buttonContinue.Visible = true;
                buttonExit.Visible = true;
            }
            else
            {
                SetKurse(e);
            }
        }

        public void PrintField(PaintEventArgs e)
        {
            SolidBrush fieldSegment = new SolidBrush(Color.BurlyWood);

            for (int i = 0; i < _playField.FieldLenght; i++)
            {
                e.Graphics.FillRectangle(fieldSegment, _playField[i].X,
                                _playField[i].Y, STEP_DISPLAY, STEP_DISPLAY);
            }
        }

        private void PrintSnake(PaintEventArgs e)
        {
            SolidBrush snakeSegment = new SolidBrush(Color.DarkMagenta);

            for (int i = 0; i < _snake.SizeOfSnake; i++)
            {
                if (i < _snake.SizeOfSnake - 1)
                {
                    if ((_snake[i].Y != Snake.NO_COORDINATE)
                            && (_snake[i].X != Snake.NO_COORDINATE))
                    {
                        if ((i + 1) % 2 == 0)
                        {
                            snakeSegment.Color = Color.Orange;
                        }
                        else
                        {
                            snakeSegment.Color = Color.DarkGreen;
                        }

                        e.Graphics.FillRectangle(snakeSegment, _snake[i].X,
                                _snake[i].Y, STEP_DISPLAY, STEP_DISPLAY);
                    }
                }
                else
                {
                    if (i == _snake.SizeOfSnake - 1)
                    {
                        snakeSegment.Color = Color.Black;

                        e.Graphics.FillRectangle(snakeSegment, _snake.Head.X,
                                _snake.Head.Y, STEP_DISPLAY, STEP_DISPLAY);
                    }
                }
            }
        }

        private void SetKurse(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (_direction != InputUser.RightArrow)
                    {
                        _direction = InputUser.LeftArrow;
                    }
                    break;

                case Keys.Right:
                    if (_direction != InputUser.LeftArrow)
                    {
                        _direction = InputUser.RightArrow;
                    }
                    break;

                case Keys.Up:
                    if (_direction != InputUser.DownArrow)
                    {
                        _direction = InputUser.UpArrow;
                    }
                    break;

                case Keys.Down:
                    if (_direction != InputUser.UpArrow)
                    {
                        _direction = InputUser.DownArrow;
                    }
                    break;

                default:
                    break;
            }
        }

        private void CheckAndGenerateFruit(PaintEventArgs e)
        {
            if (_fruits.FruitCount < _fruits.FruitLength)
            {
                if (_fruits.FruitEating == FruitsOnField.UNTOUCHED_FRUIT)
                {
                    GenerateFruit(_fruits.FruitCount);

                    _fruits.FruitCount++;
                }
                else
                {
                    GenerateFruit(_fruits.FruitEating);

                    _fruits.FruitCount++;
                }
            }
        }

        private void CheckAndGenerateSuperFruit(PaintEventArgs e)
        {
            if (_fruits.SuperFruitCount < _fruits.SuperFruitLength)
            {
                if (_fruits.SuperFruitEating == FruitsOnField.UNTOUCHED_FRUIT)
                {
                    GenerateSuperFruit(_fruits.SuperFruitCount);

                    _fruits.SuperFruitCount++;
                }
                else
                {
                    GenerateSuperFruit(_fruits.SuperFruitEating);

                    _fruits.SuperFruitCount++;
                }
            }
        }

        private void PrintFruits(FruitsOnField fruits, PaintEventArgs e)
        {
            SolidBrush oneOfFruits = new SolidBrush(Color.Crimson);

            for (int i = 0; i < fruits.FruitCount; i++)
            {
                e.Graphics.FillRectangle(oneOfFruits, fruits.GetFruit(i).X,
                        fruits.GetFruit(i).Y, STEP_DISPLAY, STEP_DISPLAY);
            }

            oneOfFruits.Color = Color.Chartreuse;

            for (int i = 0; i < fruits.SuperFruitCount; i++)
            {
                e.Graphics.FillRectangle(oneOfFruits, fruits.GetSuperFruit(i).X,
                        fruits.GetSuperFruit(i).Y, STEP_DISPLAY, STEP_DISPLAY);
            }
        }

        private void GenerateFruit(int fruitNum)
        {
            bool checkResolt = false;

            do
            {
                checkResolt = false;

                FruitElement tmpFruit = _fruits.GetFruit(fruitNum);

                BL.GiveFruitCoordinate(STEP_DISPLAY, _playField.LeftTopAngle,
                        _playField.RightDownAngle, ref tmpFruit);

                _fruits.SetFruit(tmpFruit, fruitNum);

                BL.CheckFruitWithSnake
                        (_fruits.GetFruit(fruitNum),
                        _snake, ref checkResolt);

                if (checkResolt)
                {
                    continue;
                }

                BL.CheckFruitWihtFruits(_fruits, fruitNum,
                        ref checkResolt);
            } while (checkResolt);
        }

        private void GenerateSuperFruit(int fruitNum)
        {
            bool checkResolt = false;

            do
            {
                checkResolt = false;

                FruitElement tmpSuperFruit = _fruits.GetSuperFruit(fruitNum);

                BL.GiveFruitCoordinate(STEP_DISPLAY, _playField.LeftTopAngle,
                        _playField.RightDownAngle, ref tmpSuperFruit);

                _fruits.SetSuperFruit(tmpSuperFruit, fruitNum);

                BL.CheckFruitWithSnake
                        (_fruits.GetSuperFruit(fruitNum),
                        _snake, ref checkResolt);

                if (checkResolt)
                {
                    continue;
                }

                BL.CheckSuperFruitWihtFruits(_fruits, fruitNum,
                        ref checkResolt);
            } while (checkResolt);
        }

        private void CheckAndAddSpeed()
        {
            if (_fruits.FruitEating != FruitsOnField.UNTOUCHED_FRUIT ||
                    _fruits.SuperFruitEating != FruitsOnField.UNTOUCHED_FRUIT)
            {
                _countEating++;

                if (_countEating % _accelerator == 0)
                {
                    timerGame.Interval -= TICK_SPEED;
                }
            }
        }

        private bool CheckObstructionBorders()
        {
            bool obstruction = false;
            bool checkBorder = false;

            for (int i = 0; i < _playField.FieldLenght; i++)
            {
                checkBorder = BL.CheckEncounterWithBorders(_snake.Head, _playField[i]);

                if (checkBorder)
                {
                    obstruction = true;
                    break;
                }
            }

            return obstruction;
        }

        private void pictureBoxSand_Paint(object sender, PaintEventArgs e)
        {
            labelTime.Text = ((int)_timer).ToString() + " sec";
            eatenFruit.Text = _countEating.ToString();
            lStateSSize.Text = _snake.SizeOfSnake.ToString();
            PrintField(e);

            CheckAndGenerateFruit(e);
            CheckAndGenerateSuperFruit(e);
            PrintFruits(_fruits, e);

            if (CheckObstructionBorders() || _snake.CheckEncounter())
            {
                timerGame.Stop();
                lGameResolt.Visible = true;
                buttonExit.Visible = true;
                lGameResolt.Text = "Game Over";
                lGameResolt.Location = new Point
                        (_snake.Head.X + pictureBoxSand.Location.X
                        + STEP_DISPLAY, _snake.Head.Y);
            }

            _snake.CheckFruitsEating(_fruits);
            CheckAndAddSpeed();
            PrintSnake(e);

            _snake.PassСoordinates();
            _snake.ChangeDirection(_direction);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Visible = false;
            buttonDifficulti.Visible = false;

            pictureBoxSand.Visible = true;

            lableСover.Visible = false;
            labelAvtor.Visible = false;
            labelTimer.Visible = true;
            labelEatenFruit.Visible = true;
            labelPause.Visible = false;

            if (radioButtonEasy.Visible || radioButtonNormal.Visible
                    || radioButtonHard.Visible)
            {
                radioButtonEasy.Visible = false;
                radioButtonNormal.Visible = false;
                radioButtonHard.Visible = false;
            }

            pictureBoxSand.Paint += pictureBoxSand_Paint;
            timerGame.Tick += timerGemeTick;

            _snake = new Snake(_sizeOfSnake,
                   SNAKE_START_X_POSITION, SNAKE_START_Y_POSITION);

            _fruits = new FruitsOnField((char)Symbols.Apple,
                  (char)Symbols.BigApple);

            _direction = InputUser.DownArrow;
            _pouse = false;
        }

        private void buttonDifficulti_Click(object sender, EventArgs e)
        {
            if (radioButtonEasy.Visible)
            {
                radioButtonEasy.Visible = false;
                radioButtonNormal.Visible = false;
                radioButtonHard.Visible = false;
            }
            else
            {
                radioButtonEasy.Visible = true;
                radioButtonNormal.Visible = true;
                radioButtonHard.Visible = true;
            }
        }

        private void radioButtonEasy_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEasy.Checked)
            {
                _accelerator = (int)Accelerators.Low;
                timerGame.Interval = TICK_SPEED * (byte)Difficulty.Easy;
                _sizeOfSnake = (int)SizesOfSnake.Big;
            }
        }

        private void radioButtonNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNormal.Checked)
            {
                _accelerator = (int)Accelerators.Middle;
                timerGame.Interval = TICK_SPEED * (byte)Difficulty.Normal;
                _sizeOfSnake = (int)SizesOfSnake.Normal;
            }
        }

        private void radioButtonHard_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHard.Checked)
            {
                _accelerator = (int)Accelerators.High;
                timerGame.Interval = TICK_SPEED * (byte)Difficulty.Hight;
                _sizeOfSnake = (int)SizesOfSnake.Smal;
            }
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            labelPause.Visible = false;
            buttonContinue.Visible = false;
            buttonExit.Visible = false;
            _pouse = false;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (lGameResolt.Visible)
            {
                timerGame.Start();
                lGameResolt.Visible = false;
            }

            _timer = 0;
            _countEating = 0;
            labelTime.Text = "";
            eatenFruit.Text = "";
            lStateSSize.Text = "";

            buttonContinue.Visible = false;
            buttonExit.Visible = false;
            buttonStart.Visible = true;
            buttonDifficulti.Visible = true;

            lableСover.Visible = true;
            labelAvtor.Visible = true;
            labelPause.Visible = false;

            pictureBoxSand.Visible = false;
            pictureBoxSand.Paint -= pictureBoxSand_Paint;
            timerGame.Tick -= timerGemeTick;

            _accelerator = (int)Accelerators.Middle;
            _sizeOfSnake = (int)SizesOfSnake.Normal;
            timerGame.Interval = TICK_SPEED * (byte)Difficulty.Normal;
        }
    }
}
