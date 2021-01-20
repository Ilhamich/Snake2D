using BLSnakeLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Training_Snake
{
    public partial class FormGameSnake : Form
    {
        const byte STEP_DISPLAY = 10;
        const byte FIELD_SIZE = 41;
        const byte SNAKE_START_X_POSITION = 200;
        const byte SNAKE_START_Y_POSITION = 10;
        const short MILLISECONDS_IN_SECOND = 1000;

        private bool _pouse = false;
        private double _timer = 0;
        private int _countEating;
        private InputUser _direction;
        readonly GameSnake _game;

        public FormGameSnake(GameSnake game)
        {
            _game = game;

            InitializeComponent();
            _game.InitGameField(FIELD_SIZE, 0, 0, STEP_DISPLAY);

            pictureBoxSand.Paint += pictureBoxSand_Paint;
            pictureBoxSand.Paint += PrintField;
            pictureBoxSand.Paint += ProcessFruit;
            pictureBoxSand.Paint += PrintFruits;
            pictureBoxSand.Paint += PrintSnake;

            timerGame.Tick += timerGemeTick;
        }

        private void timerGemeTick(object sender, EventArgs e)
        {
            if (!_pouse)
            {
                _timer += (double)timerGame.Interval / MILLISECONDS_IN_SECOND;
                pictureBoxSand.Invalidate();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && !lGameResolt.Visible
                    && pictureBoxSand.Visible)
            {
                _pouse = true;
                labelPause.Visible = true;
                buttonContinue.Visible = true;
                buttonExit.Visible = true;
            }
            else
            {
                FormController.GiveDirectionInputKey
                        (_game, e.KeyCode, ref _direction);
            }
        }

        public void PrintField(object sender, PaintEventArgs e)
        {
            FormPainter.PaintField(_game.PlayField, e.Graphics, STEP_DISPLAY);
        }

        private void PrintSnake(object sender, PaintEventArgs e)
        {
            FormPainter.PaintSnake(_game.SnakeGame, e.Graphics, STEP_DISPLAY);
        }

        private void ProcessFruit(object sender, PaintEventArgs e)
        {
            _game.GenerateFruitByCount(STEP_DISPLAY);
            _game.GenerateSuperFruitByCount(STEP_DISPLAY);
        }

        private void PrintFruits(object sender, PaintEventArgs e)
        {
            FormPainter.PaintFruits(_game.FruitsGame, e.Graphics, STEP_DISPLAY);
        }

        private void pictureBoxSand_Paint(object sender, PaintEventArgs e)
        {
            labelTime.Text = ((int)_timer).ToString() + " sec";
            eatenFruit.Text = _countEating.ToString();
            lStateSSize.Text = _game.SnakeGame.SizeOfSnake.ToString();

            if (_game.CheckObstructionBorders()
                    || _game.SnakeGame.CheckEncounter())
            {
                timerGame.Stop();
                lGameResolt.Visible = true;
                buttonExit.Visible = true;
                lGameResolt.Text = "Game Over";
                return;
            }

            if (_game.CheckWin())
            {
                timerGame.Stop();
                lGameResolt.Visible = true;
                buttonExit.Visible = true;
                lGameResolt.Text = "You win";
                lGameResolt.Location = new Point
                        (buttonContinue.Location.X, buttonContinue.Location.Y);
            }

            _game.SnakeGame.CheckFruitsEating(_game.FruitsGame);

            timerGame.Interval = _game.WorkOnSpeed
                    (timerGame.Interval, ref _countEating);

            _game.SnakeGame.PassСoordinates();
            _game.SnakeGame.ChangeDirection(_direction, STEP_DISPLAY);
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

            _game.InitSnake(new Coordinate
                    (SNAKE_START_X_POSITION, SNAKE_START_Y_POSITION));
            _game.InitFruits();

            _direction = InputUser.DownArrow;
            _pouse = false;
        }

        private void buttonDifficulti_Click(object sender, EventArgs e)
        {
            if (radioButtonEasy.Visible || radioButtonNormal.Visible
                    || radioButtonHard.Visible)
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
                timerGame.Interval = _game.SetEasyDifficulty
                        (timerGame.Interval);
            }
        }

        private void radioButtonNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNormal.Checked)
            {
                timerGame.Interval = _game.SetMiddleDifficulty
                        (timerGame.Interval);
            }
        }

        private void radioButtonHard_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHard.Checked)
            {
                timerGame.Interval = _game.SetHightDifficulty
                        (timerGame.Interval);
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

            timerGame.Interval = _game.SetMiddleDifficulty
                       (timerGame.Interval);
        }
    }
}
