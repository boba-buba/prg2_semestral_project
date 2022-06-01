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
        enum STATE { START, GAME, LOST, WIN};
        public Form1()
        {
            InitializeComponent();
        }

        private void BPlay_Click(object sender, EventArgs e)
        {
             BPlay.Visible = false;
             BackgroundImage = null;
             BackColor = Color.Black;
        }
    }
}
