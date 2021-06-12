using BLSnakeLibrary;

namespace WFormsSnake
{
    partial class FormGameSnake
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameSnake));
            this.timerGame = new System.Windows.Forms.Timer(this.components);
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelEatenFruit = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.eatenFruit = new System.Windows.Forms.Label();
            this.pictureBoxSand = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonDifficulti = new System.Windows.Forms.Button();
            this.radioButtonEasy = new System.Windows.Forms.RadioButton();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.radioButtonHard = new System.Windows.Forms.RadioButton();
            this.lableСover = new System.Windows.Forms.Label();
            this.labelAvtor = new System.Windows.Forms.Label();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelSnakeSize = new System.Windows.Forms.Label();
            this.lStateSSize = new System.Windows.Forms.Label();
            this.lGameResolt = new System.Windows.Forms.Label();
            this.labelPause = new System.Windows.Forms.Label();
            this.buttonSaveExit = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSand)).BeginInit();
            this.SuspendLayout();
            // 
            // timerGame
            // 
            this.timerGame.Enabled = true;
            this.timerGame.Interval = 240;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.BackColor = System.Drawing.Color.Black;
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimer.ForeColor = System.Drawing.Color.White;
            this.labelTimer.Location = new System.Drawing.Point(13, 13);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(60, 16);
            this.labelTimer.TabIndex = 0;
            this.labelTimer.Text = "Timer : ";
            // 
            // labelEatenFruit
            // 
            this.labelEatenFruit.AutoSize = true;
            this.labelEatenFruit.BackColor = System.Drawing.Color.Black;
            this.labelEatenFruit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEatenFruit.ForeColor = System.Drawing.Color.White;
            this.labelEatenFruit.Location = new System.Drawing.Point(13, 35);
            this.labelEatenFruit.Name = "labelEatenFruit";
            this.labelEatenFruit.Size = new System.Drawing.Size(101, 16);
            this.labelEatenFruit.TabIndex = 1;
            this.labelEatenFruit.Text = "Fruits eaten : ";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.Black;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.Location = new System.Drawing.Point(65, 13);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(12, 16);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = " ";
            // 
            // eatenFruit
            // 
            this.eatenFruit.AutoSize = true;
            this.eatenFruit.BackColor = System.Drawing.Color.Black;
            this.eatenFruit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eatenFruit.ForeColor = System.Drawing.Color.White;
            this.eatenFruit.Location = new System.Drawing.Point(105, 35);
            this.eatenFruit.Name = "eatenFruit";
            this.eatenFruit.Size = new System.Drawing.Size(12, 16);
            this.eatenFruit.TabIndex = 3;
            this.eatenFruit.Text = " ";
            // 
            // pictureBoxSand
            // 
            this.pictureBoxSand.Image = global::WFormsSnake.Properties.Resources.Pesok_1024x640;
            this.pictureBoxSand.Location = new System.Drawing.Point(200, 20);
            this.pictureBoxSand.Name = "pictureBoxSand";
            this.pictureBoxSand.Size = new System.Drawing.Size(410, 410);
            this.pictureBoxSand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSand.TabIndex = 4;
            this.pictureBoxSand.TabStop = false;
            this.pictureBoxSand.Visible = false;
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.ForeColor = System.Drawing.Color.Gold;
            this.buttonStart.Location = new System.Drawing.Point(200, 350);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100, 50);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonDifficulti
            // 
            this.buttonDifficulti.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.buttonDifficulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDifficulti.ForeColor = System.Drawing.Color.Gold;
            this.buttonDifficulti.Location = new System.Drawing.Point(510, 350);
            this.buttonDifficulti.Name = "buttonDifficulti";
            this.buttonDifficulti.Size = new System.Drawing.Size(100, 50);
            this.buttonDifficulti.TabIndex = 6;
            this.buttonDifficulti.Text = "Difficulti";
            this.buttonDifficulti.UseVisualStyleBackColor = false;
            this.buttonDifficulti.Click += new System.EventHandler(this.buttonDifficulti_Click);
            // 
            // radioButtonEasy
            // 
            this.radioButtonEasy.AutoSize = true;
            this.radioButtonEasy.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonEasy.ForeColor = System.Drawing.Color.Crimson;
            this.radioButtonEasy.Location = new System.Drawing.Point(630, 300);
            this.radioButtonEasy.Name = "radioButtonEasy";
            this.radioButtonEasy.Size = new System.Drawing.Size(73, 28);
            this.radioButtonEasy.TabIndex = 7;
            this.radioButtonEasy.Text = "Easy";
            this.radioButtonEasy.UseVisualStyleBackColor = false;
            this.radioButtonEasy.Visible = false;
            this.radioButtonEasy.CheckedChanged += new System.EventHandler(this.radioButtonEasy_CheckedChanged);
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.AutoSize = true;
            this.radioButtonNormal.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonNormal.Checked = true;
            this.radioButtonNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonNormal.ForeColor = System.Drawing.Color.Crimson;
            this.radioButtonNormal.Location = new System.Drawing.Point(630, 340);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(95, 28);
            this.radioButtonNormal.TabIndex = 8;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "Normal";
            this.radioButtonNormal.UseVisualStyleBackColor = false;
            this.radioButtonNormal.Visible = false;
            this.radioButtonNormal.CheckedChanged += new System.EventHandler(this.radioButtonNormal_CheckedChanged);
            // 
            // radioButtonHard
            // 
            this.radioButtonHard.AutoSize = true;
            this.radioButtonHard.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonHard.ForeColor = System.Drawing.Color.Crimson;
            this.radioButtonHard.Location = new System.Drawing.Point(630, 380);
            this.radioButtonHard.Name = "radioButtonHard";
            this.radioButtonHard.Size = new System.Drawing.Size(73, 28);
            this.radioButtonHard.TabIndex = 9;
            this.radioButtonHard.Text = "Hard";
            this.radioButtonHard.UseVisualStyleBackColor = false;
            this.radioButtonHard.Visible = false;
            this.radioButtonHard.CheckedChanged += new System.EventHandler(this.radioButtonHard_CheckedChanged);
            // 
            // lableСover
            // 
            this.lableСover.AutoSize = true;
            this.lableСover.BackColor = System.Drawing.Color.Transparent;
            this.lableСover.Font = new System.Drawing.Font("MV Boli", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableСover.ForeColor = System.Drawing.Color.Crimson;
            this.lableСover.Location = new System.Drawing.Point(165, 20);
            this.lableСover.Name = "lableСover";
            this.lableСover.Size = new System.Drawing.Size(488, 250);
            this.lableСover.TabIndex = 10;
            this.lableСover.Text = "Snake\nWinForms";
            // 
            // labelAvtor
            // 
            this.labelAvtor.AutoSize = true;
            this.labelAvtor.BackColor = System.Drawing.Color.Transparent;
            this.labelAvtor.Font = new System.Drawing.Font("MV Boli", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAvtor.ForeColor = System.Drawing.Color.White;
            this.labelAvtor.Location = new System.Drawing.Point(630, 238);
            this.labelAvtor.Name = "labelAvtor";
            this.labelAvtor.Size = new System.Drawing.Size(78, 20);
            this.labelAvtor.TabIndex = 11;
            this.labelAvtor.Text = "by Aydin";
            // 
            // buttonContinue
            // 
            this.buttonContinue.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.buttonContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonContinue.ForeColor = System.Drawing.Color.Gold;
            this.buttonContinue.Location = new System.Drawing.Point(23, 261);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(100, 50);
            this.buttonContinue.TabIndex = 13;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = false;
            this.buttonContinue.Visible = false;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.ForeColor = System.Drawing.Color.Gold;
            this.buttonExit.Location = new System.Drawing.Point(23, 317);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(100, 50);
            this.buttonExit.TabIndex = 14;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Visible = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelSnakeSize
            // 
            this.labelSnakeSize.AutoSize = true;
            this.labelSnakeSize.BackColor = System.Drawing.Color.Black;
            this.labelSnakeSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSnakeSize.ForeColor = System.Drawing.Color.White;
            this.labelSnakeSize.Location = new System.Drawing.Point(13, 57);
            this.labelSnakeSize.Name = "labelSnakeSize";
            this.labelSnakeSize.Size = new System.Drawing.Size(92, 16);
            this.labelSnakeSize.TabIndex = 15;
            this.labelSnakeSize.Text = "Snake size :";
            // 
            // lStateSSize
            // 
            this.lStateSSize.AutoSize = true;
            this.lStateSSize.BackColor = System.Drawing.Color.Black;
            this.lStateSSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStateSSize.ForeColor = System.Drawing.Color.White;
            this.lStateSSize.Location = new System.Drawing.Point(111, 57);
            this.lStateSSize.Name = "lStateSSize";
            this.lStateSSize.Size = new System.Drawing.Size(12, 16);
            this.lStateSSize.TabIndex = 16;
            this.lStateSSize.Text = " ";
            // 
            // lGameResolt
            // 
            this.lGameResolt.AutoSize = true;
            this.lGameResolt.BackColor = System.Drawing.Color.Transparent;
            this.lGameResolt.Font = new System.Drawing.Font("MV Boli", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGameResolt.ForeColor = System.Drawing.Color.Crimson;
            this.lGameResolt.Location = new System.Drawing.Point(12, 195);
            this.lGameResolt.Name = "lGameResolt";
            this.lGameResolt.Size = new System.Drawing.Size(0, 39);
            this.lGameResolt.TabIndex = 17;
            this.lGameResolt.Visible = false;
            // 
            // labelPause
            // 
            this.labelPause.AutoSize = true;
            this.labelPause.BackColor = System.Drawing.Color.Transparent;
            this.labelPause.Font = new System.Drawing.Font("MV Boli", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPause.ForeColor = System.Drawing.Color.Gold;
            this.labelPause.Location = new System.Drawing.Point(12, 195);
            this.labelPause.Name = "labelPause";
            this.labelPause.Size = new System.Drawing.Size(158, 63);
            this.labelPause.TabIndex = 12;
            this.labelPause.Text = "Pause";
            this.labelPause.Visible = false;
            // 
            // buttonSaveExit
            // 
            this.buttonSaveExit.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.buttonSaveExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveExit.ForeColor = System.Drawing.Color.Gold;
            this.buttonSaveExit.Location = new System.Drawing.Point(23, 373);
            this.buttonSaveExit.Name = "buttonSaveExit";
            this.buttonSaveExit.Size = new System.Drawing.Size(100, 50);
            this.buttonSaveExit.TabIndex = 18;
            this.buttonSaveExit.Text = "Save and exit";
            this.buttonSaveExit.UseVisualStyleBackColor = false;
            this.buttonSaveExit.Visible = false;
            this.buttonSaveExit.Click += new System.EventHandler(this.buttonSaveExit_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLoad.ForeColor = System.Drawing.Color.Gold;
            this.buttonLoad.Location = new System.Drawing.Point(355, 350);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(100, 50);
            this.buttonLoad.TabIndex = 19;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // FormGameSnake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.BackgroundImage = global::WFormsSnake.Properties.Resources.Snakes___pic;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(804, 451);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSaveExit);
            this.Controls.Add(this.lGameResolt);
            this.Controls.Add(this.lStateSSize);
            this.Controls.Add(this.labelSnakeSize);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.labelPause);
            this.Controls.Add(this.labelAvtor);
            this.Controls.Add(this.lableСover);
            this.Controls.Add(this.radioButtonHard);
            this.Controls.Add(this.radioButtonNormal);
            this.Controls.Add(this.radioButtonEasy);
            this.Controls.Add(this.buttonDifficulti);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.pictureBoxSand);
            this.Controls.Add(this.eatenFruit);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelEatenFruit);
            this.Controls.Add(this.labelTimer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSnake";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerGame;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelEatenFruit;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label eatenFruit;
        private System.Windows.Forms.PictureBox pictureBoxSand;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonDifficulti;
        private System.Windows.Forms.RadioButton radioButtonEasy;
        private System.Windows.Forms.RadioButton radioButtonNormal;
        private System.Windows.Forms.RadioButton radioButtonHard;
        private System.Windows.Forms.Label lableСover;
        private System.Windows.Forms.Label labelAvtor;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelSnakeSize;
        private System.Windows.Forms.Label lStateSSize;
        private System.Windows.Forms.Label lGameResolt;
        private System.Windows.Forms.Label labelPause;
        private System.Windows.Forms.Button buttonSaveExit;
        private System.Windows.Forms.Button buttonLoad;
    }
}

