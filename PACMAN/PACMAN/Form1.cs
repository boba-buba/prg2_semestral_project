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
        }

        private void BPlay_Click(object sender, EventArgs e)
        {
            BPlay.Visible = false;
            BackgroundImage = null;
            BackColor = Color.Black;

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }




    }
}
