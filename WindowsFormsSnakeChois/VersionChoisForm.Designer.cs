
namespace WindowsFormsSnakeChois
{
    partial class VersionChoisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WindowForms = new System.Windows.Forms.Button();
            this.Console = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // WindowForms
            // 
            this.WindowForms.Location = new System.Drawing.Point(385, 319);
            this.WindowForms.Name = "WindowForms";
            this.WindowForms.Size = new System.Drawing.Size(100, 30);
            this.WindowForms.TabIndex = 2;
            this.WindowForms.Text = "WF";
            this.WindowForms.UseVisualStyleBackColor = true;
            this.WindowForms.Click += new System.EventHandler(this.WindowForms_Click);
            // 
            // Console
            // 
            this.Console.Location = new System.Drawing.Point(95, 319);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(100, 30);
            this.Console.TabIndex = 3;
            this.Console.Text = "Console";
            this.Console.UseVisualStyleBackColor = true;
            this.Console.Click += new System.EventHandler(this.Console_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsSnakeChois.Properties.Resources.Снимок_экрана__11_;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(270, 290);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsSnakeChois.Properties.Resources.Снимок_экрана__14_;
            this.pictureBox1.Location = new System.Drawing.Point(302, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(270, 290);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // VersionChoisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.Console);
            this.Controls.Add(this.WindowForms);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "VersionChoisForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button WindowForms;
        private System.Windows.Forms.Button Console;
    }
}

