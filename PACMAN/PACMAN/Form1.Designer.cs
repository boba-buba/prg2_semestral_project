
namespace PACMAN
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BPlay
            // 
            this.BPlay.BackColor = System.Drawing.Color.Black;
            this.BPlay.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.BPlay.FlatAppearance.BorderSize = 5;
            this.BPlay.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BPlay.ForeColor = System.Drawing.Color.Yellow;
            this.BPlay.Location = new System.Drawing.Point(333, 53);
            this.BPlay.Name = "BPlay";
            this.BPlay.Size = new System.Drawing.Size(190, 60);
            this.BPlay.TabIndex = 0;
            this.BPlay.Tag = "playButton";
            this.BPlay.Text = "PLAY";
            this.BPlay.UseVisualStyleBackColor = false;
            this.BPlay.Click += new System.EventHandler(this.BPlay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::PACMAN.Properties.Resources.intro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.BPlay);
            this.Name = "Form1";
            this.Text = "Pac Man";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BPlay;
    }
}

