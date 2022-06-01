using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    public partial class Form1 : Form
    {

        bool goup, godown, goleft, goright, isGameOver;
        int score, playerSpeed, redGhostSpeed, yellowGhostSpeed, pinkGhostX, pinkGhostY;
        public Form1()
        {
            InitializeComponent();
            ResetGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                goup = true;
            if (e.KeyCode == Keys.Down)
                godown = true;
            if (e.KeyCode == Keys.Left)
                goleft = true;
            if (e.KeyCode == Keys.Right)
                goright = true;
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                goup = false;
            if (e.KeyCode == Keys.Down)
                godown = false;
            if (e.KeyCode == Keys.Left)
                goleft = false;
            if (e.KeyCode == Keys.Right)
                goright = false;
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                ResetGame();
            }
        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            if (goleft)
            {
                pacman.Left -= playerSpeed;
                pacman.Image = Properties.Resources.left;
            }
            if (goright)
            {
                pacman.Left += playerSpeed;
                pacman.Image = Properties.Resources.right;

            }
            if (goup)
            {
                pacman.Top -= playerSpeed;
                pacman.Image = Properties.Resources.Up;
            }
            if (godown)
            {
                pacman.Top += playerSpeed;
                pacman.Image = Properties.Resources.down;
            }
            if (pacman.Left < -10) pacman.Left = 680;
            if (pacman.Left > 680) pacman.Left = -10;

            if (pacman.Top < -10) pacman.Top = 550;
            if (pacman.Top > 550) pacman.Top = 0;

            foreach(Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "coin" && x.Visible == true)
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false; 
                        }
                    if ((string)x.Tag == "wall")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            GameOver("You lost");
                        }

                        if (pinkGhost.Bounds.IntersectsWith(x.Bounds))
                        {
                            pinkGhostX = -pinkGhostX;
                        }
                    }
                    if ((string)x.Tag == "ghost")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            GameOver("You lost");
                        }

                    }
                          
                }
            }

            redGhost.Left += redGhostSpeed;
            if (redGhost.Bounds.IntersectsWith(pictureBox3.Bounds) || redGhost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }

            yellowGhost.Left += yellowGhostSpeed;
            if (yellowGhost.Bounds.IntersectsWith(pictureBox1.Bounds) || yellowGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                yellowGhostSpeed = -yellowGhostSpeed;
            }  

            pinkGhost.Left -= pinkGhostX;
            pinkGhost.Top -= pinkGhostY;
            if (pinkGhost.Top < 0 || pinkGhost.Top > 520)
            {
                pinkGhostY = -pinkGhostY;
            }
            if (pinkGhost.Left < 0 || pinkGhost.Left > 620)
            {
                pinkGhostX = -pinkGhostX;
            }




            if (score == 46) 
            {
                GameOver("You won");
            }
            
        
        }

        private void ResetGame()
        {
            txtScore.Text = "Score: 0";
            score = 0;
            redGhostSpeed = 5;
            yellowGhostSpeed = 5;
            pinkGhostX = 5;
            pinkGhostY = 5;
            playerSpeed = 8;
            isGameOver = false;

            pacman.Left = 31;
            pacman.Top = 46;

            redGhost.Left = 220;
            redGhost.Top = 53;

            pinkGhost.Left = 519;
            pinkGhost.Top = 215;

            yellowGhost.Left = 456;
            yellowGhost.Top = 436;
            gameTimer.Start();

            foreach(Control x in this.Controls)
            {
                if (x is PictureBox)
                    x.Visible = true;
            }

        }

        private void GameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();
            txtScore.Text   = "Score:" + score + Environment.NewLine + message;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}