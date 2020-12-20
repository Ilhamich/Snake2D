using BLSnakeLibrary;

namespace Training_Snake
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
            this.labelPause = new System.Windows.Forms.Label();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelSnakeSize = new System.Windows.Forms.Label();
            this.lStateSSize = new System.Windows.Forms.Label();
            this.lGameResolt = new System.Windows.Forms.Label();
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
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimer.ForeColor = System.Drawing.Color.Black;
            this.labelTimer.Location = new System.Drawing.Point(13, 13);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(60, 16);
            this.labelTimer.TabIndex = 0;
            this.labelTimer.Text = "Timer : ";
            // 
            // labelEatenFruit
            // 
            this.labelEatenFruit.AutoSize = true;
            this.labelEatenFruit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEatenFruit.ForeColor = System.Drawing.Color.Black;
            this.labelEatenFruit.Location = new System.Drawing.Point(13, 35);
            this.labelEatenFruit.Name = "labelEatenFruit";
            this.labelEatenFruit.Size = new System.Drawing.Size(101, 16);
            this.labelEatenFruit.TabIndex = 1;
            this.labelEatenFruit.Text = "Fruits eaten : ";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelTime.Location = new System.Drawing.Point(65, 13);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(12, 16);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = " ";
            // 
            // eatenFruit
            // 
            this.eatenFruit.AutoSize = true;
            this.eatenFruit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eatenFruit.ForeColor = System.Drawing.Color.ForestGreen;
            this.eatenFruit.Location = new System.Drawing.Point(105, 35);
            this.eatenFruit.Name = "eatenFruit";
            this.eatenFruit.Size = new System.Drawing.Size(12, 16);
            this.eatenFruit.TabIndex = 3;
            this.eatenFruit.Text = " ";
            // 
            // pictureBoxSand
            // 
            this.pictureBoxSand.Image = global::Training_Snake.Properties.Resources.Pesok_1024x640;
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
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.ForeColor = System.Drawing.Color.DarkGreen;
            this.buttonStart.Location = new System.Drawing.Point(200, 300);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100, 50);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonDifficulti
            // 
            this.buttonDifficulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDifficulti.ForeColor = System.Drawing.Color.DarkGreen;
            this.buttonDifficulti.Location = new System.Drawing.Point(510, 300);
            this.buttonDifficulti.Name = "buttonDifficulti";
            this.buttonDifficulti.Size = new System.Drawing.Size(100, 50);
            this.buttonDifficulti.TabIndex = 6;
            this.buttonDifficulti.Text = "Difficulti";
            this.buttonDifficulti.UseVisualStyleBackColor = true;
            this.buttonDifficulti.Click += new System.EventHandler(this.buttonDifficulti_Click);
            // 
            // radioButtonEasy
            // 
            this.radioButtonEasy.AutoSize = true;
            this.radioButtonEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonEasy.Location = new System.Drawing.Point(630, 300);
            this.radioButtonEasy.Name = "radioButtonEasy";
            this.radioButtonEasy.Size = new System.Drawing.Size(61, 20);
            this.radioButtonEasy.TabIndex = 7;
            this.radioButtonEasy.Text = "Easy";
            this.radioButtonEasy.UseVisualStyleBackColor = true;
            this.radioButtonEasy.Visible = false;
            this.radioButtonEasy.CheckedChanged += new System.EventHandler(this.radioButtonEasy_CheckedChanged);
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.AutoSize = true;
            this.radioButtonNormal.Checked = true;
            this.radioButtonNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonNormal.Location = new System.Drawing.Point(630, 340);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(76, 20);
            this.radioButtonNormal.TabIndex = 8;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "Normal";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            this.radioButtonNormal.Visible = false;
            this.radioButtonNormal.CheckedChanged += new System.EventHandler(this.radioButtonNormal_CheckedChanged);
            // 
            // radioButtonHard
            // 
            this.radioButtonHard.AutoSize = true;
            this.radioButtonHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonHard.Location = new System.Drawing.Point(630, 380);
            this.radioButtonHard.Name = "radioButtonHard";
            this.radioButtonHard.Size = new System.Drawing.Size(60, 20);
            this.radioButtonHard.TabIndex = 9;
            this.radioButtonHard.Text = "Hard";
            this.radioButtonHard.UseVisualStyleBackColor = true;
            this.radioButtonHard.Visible = false;
            this.radioButtonHard.CheckedChanged += new System.EventHandler(this.radioButtonHard_CheckedChanged);
            // 
            // lableСover
            // 
            this.lableСover.AutoSize = true;
            this.lableСover.BackColor = System.Drawing.Color.Transparent;
            this.lableСover.Font = new System.Drawing.Font("MV Boli", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableСover.ForeColor = System.Drawing.Color.Green;
            this.lableСover.Location = new System.Drawing.Point(165, 20);
            this.lableСover.Name = "lableСover";
            this.lableСover.Size = new System.Drawing.Size(488, 250);
            this.lableСover.TabIndex = 10;
            this.lableСover.Text = "Snake\nWinForms";
            // 
            // labelAvtor
            // 
            this.labelAvtor.AutoSize = true;
            this.labelAvtor.Font = new System.Drawing.Font("MV Boli", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAvtor.ForeColor = System.Drawing.Color.Green;
            this.labelAvtor.Location = new System.Drawing.Point(630, 238);
            this.labelAvtor.Name = "labelAvtor";
            this.labelAvtor.Size = new System.Drawing.Size(78, 20);
            this.labelAvtor.TabIndex = 11;
            this.labelAvtor.Text = "by Aydin";
            // 
            // labelPause
            // 
            this.labelPause.AutoSize = true;
            this.labelPause.BackColor = System.Drawing.Color.Transparent;
            this.labelPause.Font = new System.Drawing.Font("MV Boli", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPause.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelPause.Location = new System.Drawing.Point(300, 140);
            this.labelPause.Name = "labelPause";
            this.labelPause.Size = new System.Drawing.Size(206, 85);
            this.labelPause.TabIndex = 12;
            this.labelPause.Text = "Pause";
            this.labelPause.Visible = false;
            // 
            // buttonContinue
            // 
            this.buttonContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonContinue.ForeColor = System.Drawing.Color.DarkOrange;
            this.buttonContinue.Location = new System.Drawing.Point(200, 380);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(100, 50);
            this.buttonContinue.TabIndex = 13;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Visible = false;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.ForeColor = System.Drawing.Color.DarkOrange;
            this.buttonExit.Location = new System.Drawing.Point(510, 380);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(100, 50);
            this.buttonExit.TabIndex = 14;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Visible = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelSnakeSize
            // 
            this.labelSnakeSize.AutoSize = true;
            this.labelSnakeSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSnakeSize.ForeColor = System.Drawing.Color.Black;
            this.labelSnakeSize.Location = new System.Drawing.Point(13, 57);
            this.labelSnakeSize.Name = "labelSnakeSize";
            this.labelSnakeSize.Size = new System.Drawing.Size(92, 16);
            this.labelSnakeSize.TabIndex = 15;
            this.labelSnakeSize.Text = "Snake size :";
            // 
            // lStateSSize
            // 
            this.lStateSSize.AutoSize = true;
            this.lStateSSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStateSSize.ForeColor = System.Drawing.Color.ForestGreen;
            this.lStateSSize.Location = new System.Drawing.Point(111, 57);
            this.lStateSSize.Name = "lStateSSize";
            this.lStateSSize.Size = new System.Drawing.Size(12, 16);
            this.lStateSSize.TabIndex = 16;
            this.lStateSSize.Text = " ";
            // 
            // lGameResolt
            // 
            this.lGameResolt.AutoSize = true;
            this.lGameResolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lGameResolt.Location = new System.Drawing.Point(13, 432);
            this.lGameResolt.Name = "lGameResolt";
            this.lGameResolt.Size = new System.Drawing.Size(0, 24);
            this.lGameResolt.TabIndex = 17;
            this.lGameResolt.Visible = false;
            // 
            // FormGameSnake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 451);
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
        private System.Windows.Forms.Label labelPause;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelSnakeSize;
        private System.Windows.Forms.Label lStateSSize;
        private System.Windows.Forms.Label lGameResolt;
    }
}

