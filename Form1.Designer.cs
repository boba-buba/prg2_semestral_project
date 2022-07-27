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
            this.Intro = new System.Windows.Forms.PictureBox();
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
            this.bNext.Location = new System.Drawing.Point(551, 360);
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
            this.bAgain.Location = new System.Drawing.Point(551, 196);
            this.bAgain.Name = "bAgain";
            this.bAgain.Size = new System.Drawing.Size(200, 104);
            this.bAgain.TabIndex = 2;
            this.bAgain.Text = "AGAIN";
            this.bAgain.UseVisualStyleBackColor = false;
            this.bAgain.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Intro
            // 
            this.Intro.Image = global::CSHra.Properties.Resources.intro;
            this.Intro.Location = new System.Drawing.Point(135, -1);
            this.Intro.Name = "Intro";
            this.Intro.Size = new System.Drawing.Size(1044, 580);
            this.Intro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Intro.TabIndex = 3;
            this.Intro.TabStop = false;
            this.Intro.Click += new System.EventHandler(this.Intro_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1312, 718);
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
            ((System.ComponentModel.ISupportInitialize)(this.Intro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Button bAgain;
        private System.Windows.Forms.PictureBox Intro;
    }
}

