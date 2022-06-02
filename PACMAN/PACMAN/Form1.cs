using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PACMAN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BackgroundImage = Properties.Resources.intro; // ???????
        }
        Graphics g;
        Map map;
        
        private void BPlay_Click(object sender, EventArgs e)
        {
            g = CreateGraphics();
            map = new Map("plan.txt", "full_icons.png");
            this.Text = "Left to collect " + map.LeftToCollect;
              
            
            timer1.Enabled = true;
            BPlay.Visible = false;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {       
            switch (map.state)
            {
                case State.GAME:
                    map.MoveAllElements(pressedKey);
                    map.PaintAll(g, ClientSize.Width, ClientSize.Height);
                    this.Text = "Left to collect " + map.LeftToCollect;
                    break;
                case State.WIN:
                    timer1.Enabled = false;
                    MessageBox.Show("YOU WON!");
                    break;
                case State.LOST:
                    timer1.Enabled = false;
                    MessageBox.Show("YOU LOST!");
                    break;
                default: break;


            }
        }

        PressedKey pressedKey = PressedKey.none;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                pressedKey = PressedKey.up;
                return true;
            }
            if (keyData == Keys.Down)
            {
                pressedKey = PressedKey.down;
                return true;
            }
            if (keyData == Keys.Left)
            {
                pressedKey = PressedKey.left;
                return true;
            }
            if (keyData == Keys.Right)
            {
                pressedKey = PressedKey.right;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKey = PressedKey.none;
        }
       


    }
}
