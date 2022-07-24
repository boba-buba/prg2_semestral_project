using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSHra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bNext.Visible = false;
            bAgain.Visible = false;
        }

        Mapa mapa;
        Graphics g;
        public int offset = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            g = CreateGraphics();
            if (offset + 1 == System.IO.File.ReadAllLines("plan.txt").Count())
            {
                mapa.stav = Stav.konec;
                return;
            }
            mapa = new Mapa("plan.txt", "ikonky.png", offset);
            this.Text = "Zbývá sebrat " + mapa.ZbyvaDiamantu + " diamantů";
            offset +=  mapa.offsetLine;
            timer1.Enabled = true;
            button1.Visible = false;
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            switch (mapa.stav)
            {
                case Stav.bezi:
                    Intro.Visible = false;
                    bAgain.Visible = false;
                    bNext.Visible = false;
                    this.BackgroundImage = null;
                    this.BackColor = Color.Black;
                    mapa.PohniVsemiPrvky(stisknutaSipka);
                    mapa.VykresliSe(g, ClientSize.Width, ClientSize.Height);
                    this.Text = "Zbývá sebrat " + mapa.ZbyvaDiamantu + " diamantů";
                    break;
                case Stav.vyhra:
                    Intro.Visible = false;
                    timer1.Enabled = false;
                    bNext.Visible = true;
                    MessageBox.Show("Vyhra!");
                    break;
                case Stav.prohra:
                    Intro.Visible = false;
                    bNext.Visible = false;
                    timer1.Enabled = false;
                    bAgain.Visible = true;
                    MessageBox.Show("Prohra!");
                    break;
                case Stav.konec:
                    Intro.Visible = false;
                    bNext.Visible = false;
                    timer1.Enabled = false;
                    bAgain.Visible = true;
                    MessageBox.Show("Konec!");
                    break;
                default:
                    break;
            }
        }

        StisknutaSipka stisknutaSipka = StisknutaSipka.zadna;

        // HACK na odchyceni stisku sipek
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                mapa.ZmenaHrdiny('U');
                stisknutaSipka = StisknutaSipka.nahoru;
                
                return true;
            }
            if (keyData == Keys.Down)
            {
                mapa.ZmenaHrdiny('D');
                stisknutaSipka = StisknutaSipka.dolu;
                
                return true;
            }
            if (keyData == Keys.Left)
            {
                mapa.ZmenaHrdiny('L');
                stisknutaSipka = StisknutaSipka.doleva;
                
                return true;
            }
            if (keyData == Keys.Right)
            {
                mapa.ZmenaHrdiny('R');
                stisknutaSipka = StisknutaSipka.doprava;
                
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            stisknutaSipka = StisknutaSipka.zadna;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            button1_Click(sender, e);
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            offset = 0;
            button1_Click(sender, e);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
