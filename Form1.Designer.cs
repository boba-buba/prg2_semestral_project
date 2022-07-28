namespace CSHra
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bNext = new System.Windows.Forms.Button();
            this.bAgain = new System.Windows.Forms.Button();
            this.lResult = new System.Windows.Forms.Label();
            this.bAgainLevel = new System.Windows.Forms.Button();
            this.pBKonec = new System.Windows.Forms.PictureBox();
            this.Intro = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lStatus = new System.Windows.Forms.Label();
            this.bMusic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBKonec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Intro)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Stencil", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(551, 522);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 107);
            this.button1.TabIndex = 0;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bNext
            // 
            this.bNext.BackColor = System.Drawing.Color.Black;
            this.bNext.Font = new System.Drawing.Font("Stencil", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNext.ForeColor = System.Drawing.Color.Yellow;
            this.bNext.Location = new System.Drawing.Point(551, 196);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(200, 104);
            this.bNext.TabIndex = 1;
            this.bNext.Text = "Next";
            this.bNext.UseVisualStyleBackColor = false;
            this.bNext.Click += new System.EventHandler(this.button2_Click);
            // 
            // bAgain
            // 
            this.bAgain.BackColor = System.Drawing.Color.Black;
            this.bAgain.Font = new System.Drawing.Font("Stencil", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAgain.ForeColor = System.Drawing.Color.Yellow;
            this.bAgain.Location = new System.Drawing.Point(255, 196);
            this.bAgain.Name = "bAgain";
            this.bAgain.Size = new System.Drawing.Size(200, 104);
            this.bAgain.TabIndex = 2;
            this.bAgain.Text = "AGAIN";
            this.bAgain.UseVisualStyleBackColor = false;
            this.bAgain.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // lResult
            // 
            this.lResult.AutoSize = true;
            this.lResult.Font = new System.Drawing.Font("Stencil", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lResult.ForeColor = System.Drawing.Color.Yellow;
            this.lResult.Location = new System.Drawing.Point(371, 23);
            this.lResult.Name = "lResult";
            this.lResult.Size = new System.Drawing.Size(139, 39);
            this.lResult.TabIndex = 4;
            this.lResult.Text = "label1";
            this.lResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lResult.Click += new System.EventHandler(this.lResult_Click);
            // 
            // bAgainLevel
            // 
            this.bAgainLevel.BackColor = System.Drawing.Color.Black;
            this.bAgainLevel.Font = new System.Drawing.Font("Stencil", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAgainLevel.ForeColor = System.Drawing.Color.Yellow;
            this.bAgainLevel.Location = new System.Drawing.Point(863, 175);
            this.bAgainLevel.Name = "bAgainLevel";
            this.bAgainLevel.Size = new System.Drawing.Size(218, 146);
            this.bAgainLevel.TabIndex = 5;
            this.bAgainLevel.Text = "Again Prevoius level";
            this.bAgainLevel.UseVisualStyleBackColor = false;
            this.bAgainLevel.Click += new System.EventHandler(this.bAgainLevel_Click);
            // 
            // pBKonec
            // 
            this.pBKonec.Image = global::CSHra.Properties.Resources.stray_kids_lee_know;
            this.pBKonec.Location = new System.Drawing.Point(493, 175);
            this.pBKonec.Name = "pBKonec";
            this.pBKonec.Size = new System.Drawing.Size(699, 340);
            this.pBKonec.TabIndex = 6;
            this.pBKonec.TabStop = false;
            // 
            // Intro
            // 
            this.Intro.Image = global::CSHra.Properties.Resources.intro;
            this.Intro.Location = new System.Drawing.Point(162, -2);
            this.Intro.Name = "Intro";
            this.Intro.Size = new System.Drawing.Size(1044, 580);
            this.Intro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Intro.TabIndex = 3;
            this.Intro.TabStop = false;
            this.Intro.Click += new System.EventHandler(this.Intro_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStatus.ForeColor = System.Drawing.Color.Yellow;
            this.lStatus.Location = new System.Drawing.Point(3, 0);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(104, 29);
            this.lStatus.TabIndex = 8;
            this.lStatus.Text = "label2";
            // 
            // bMusic
            // 
            this.bMusic.BackColor = System.Drawing.Color.Black;
            this.bMusic.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMusic.ForeColor = System.Drawing.Color.Yellow;
            this.bMusic.Location = new System.Drawing.Point(1159, 6);
            this.bMusic.Name = "bMusic";
            this.bMusic.Size = new System.Drawing.Size(141, 37);
            this.bMusic.TabIndex = 9;
            this.bMusic.Text = "music";
            this.bMusic.UseVisualStyleBackColor = false;
            this.bMusic.Click += new System.EventHandler(this.bMusic_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1312, 718);
            this.Controls.Add(this.bMusic);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pBKonec);
            this.Controls.Add(this.bAgainLevel);
            this.Controls.Add(this.lResult);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bAgain);
            this.Controls.Add(this.bNext);
            this.Controls.Add(this.Intro);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pBKonec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Intro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Button bAgain;
        private System.Windows.Forms.PictureBox Intro;
        private System.Windows.Forms.Label lResult;
        private System.Windows.Forms.Button bAgainLevel;
        private System.Windows.Forms.PictureBox pBKonec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Button bMusic;
    }
}

