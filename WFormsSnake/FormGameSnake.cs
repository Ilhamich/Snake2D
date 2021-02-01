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

        private bool _pouse = true;
        private InputUser _direction;
        private GameSnake _game;
        DlFormConnector _saver;

        public FormGameSnake(GameSnake game)
        {
            _game = game;
   
            InitializeComponent();

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
                _game.RunTimer(MILLISECONDS_IN_SECOND);
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
                buttonSaveExit.Visible = true;
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
            FormPainter.PaintSnake(_game.SnakeObj, e.Graphics, STEP_DISPLAY);
        }

        private void ProcessFruit(object sender, PaintEventArgs e)
        {
            _game.GenerateFruitByCount(STEP_DISPLAY);
            _game.GenerateSuperFruitByCount(STEP_DISPLAY);
        }

        private void PrintFruits(object sender, PaintEventArgs e)
        {
            FormPainter.PaintFruits(_game.FruitsObj, e.Graphics, STEP_DISPLAY);
        }

        private void pictureBoxSand_Paint(object sender, PaintEventArgs e)
        {
            if (!_pouse)
            {
                labelTime.Text = _game.Timer.ToString() + " sec";
                eatenFruit.Text = _game.CountEating.ToString();
                lStateSSize.Text = _game.SnakeObj.SizeOfSnake.ToString();

                if (_game.CheckObstructionBorders()
                        || _game.SnakeObj.CheckEncounter())
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

                _game.RunSnakeDynamics(_direction, STEP_DISPLAY);

                timerGame.Interval = _game.Interval;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ReadyStart();

            _game.InitGameField(FIELD_SIZE, 0, 0, STEP_DISPLAY);
            _game.InitSnake(new Coordinate
                    (SNAKE_START_X_POSITION, SNAKE_START_Y_POSITION));
            _game.InitFruits();

            _direction = _game.SnakeObj.SetDirection();
            _pouse = false;
            timerGame.Start();
        }

        private void ReadyStart()
        {
            buttonStart.Visible = false;
            buttonDifficulti.Visible = false;
            buttonLoad.Visible = false;

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
                _game.SetEasyDifficulty();
                timerGame.Interval = _game.Interval;
            }
        }

        private void radioButtonNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNormal.Checked)
            {
                _game.SetMiddleDifficulty();
                timerGame.Interval = _game.Interval;
            }
        }

        private void radioButtonHard_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHard.Checked)
            {
                _game.SetHightDifficulty();
                timerGame.Interval = _game.Interval;
            }
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            labelPause.Visible = false;
            buttonContinue.Visible = false;
            buttonExit.Visible = false;
            buttonSaveExit.Visible = false;
            _pouse = false;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (lGameResolt.Visible)
            {
                timerGame.Start();
                lGameResolt.Visible = false;
            }

            ReadyExit();
        }

        private void ReadyExit()
        {
            labelTime.Text = "";
            eatenFruit.Text = "";
            lStateSSize.Text = "";

            buttonContinue.Visible = false;
            buttonExit.Visible = false;
            buttonSaveExit.Visible = false;
            buttonStart.Visible = true;
            buttonDifficulti.Visible = true;
            buttonLoad.Visible = true;

            lableСover.Visible = true;
            labelAvtor.Visible = true;
            labelPause.Visible = false;

            pictureBoxSand.Visible = false;

            _game.Reset();
            timerGame.Interval = _game.Interval;
        }

        private void buttonSaveExit_Click(object sender, EventArgs e)
        {
            _saver = new DlFormConnector(_game); //TODO
            _saver.Save();
            ReadyExit();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            ReadyStart();

            try
            {
                _saver = new DlFormConnector(_game);//TODO
                _game = _saver.Load();
                _game.InitGameField(FIELD_SIZE, 0, 0, STEP_DISPLAY);
            }
            catch (Exception)
            {
                _game.InitGameField(FIELD_SIZE, 0, 0, STEP_DISPLAY);
                _game.InitSnake(new Coordinate
                        (SNAKE_START_X_POSITION, SNAKE_START_Y_POSITION));
                _game.InitFruits();

                MessageBox.Show("Save file broken or don't exist." +
                                "\nWill be start new game");
            }

            _direction = _game.SnakeObj.SetDirection();
            _pouse = false;
            timerGame.Start();
        }
    }
}
