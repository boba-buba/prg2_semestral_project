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
            lResult.Visible = false;
            bAgainLevel.Visible = false;
            pBKonec.Visible = false;

        }

        Mapa mapa;
        Graphics g;
        public int offset = 0;
        public int mezivysledek = 0;
        public int previousOffset = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            g = CreateGraphics();
            mapa = new Mapa("plan.txt", "ikonky.png", offset);
            this.Text = "Zbývá " + mezivysledek + "/" + mapa.ZbyvaDiamantu + " mincí";
            //previousOffset = offset;
            offset +=  mapa.offsetLine;
            timer1.Enabled = true;
            button1.Visible = false;
            lResult.Visible = false;
            pBKonec.Visible = false;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            switch (mapa.stav)
            {
                case Stav.bezi:
                    
                    this.Text = "Zbývá sebrat " + mezivysledek + "/" + mapa.ZbyvaDiamantu + " mincí";
                    if ( mezivysledek  != mapa.pocetDiamantu)
                    {
                        mezivysledek = mapa.pocetDiamantu;
                    }
                    lResult.Visible = false;
                    Intro.Visible = false;
                    bAgain.Visible = false;
                    bNext.Visible = false;
                    bAgainLevel.Visible = false;
                    pBKonec.Visible = false;

                    this.BackgroundImage = null;
                    this.BackColor = Color.Black;
                    mapa.PohniVsemiPrvky(stisknutaSipka);
                    mapa.VykresliSe(g, ClientSize.Width, ClientSize.Height);                   
                    break;
                case Stav.vyhra:
                    pBKonec.Visible = false;
                    bAgain.Visible = true;
                    bAgainLevel.Visible = true;
                    Intro.Visible = false;
                    timer1.Enabled = false;
                    bNext.Visible = true;
                    mezivysledek++;
                    lResult.Text = "Vyhra!" + " Sebrali jste " + mezivysledek + " / " + mapa.ZbyvaDiamantu + " mincí\n"
                        + "Zmačkněte NEXT, abyste přešli\n do další úrovně!";
                    lResult.Visible = true;
                    break;
                case Stav.prohra:
                    pBKonec.Visible = false;
                    bAgainLevel.Visible = true;
                    Intro.Visible = false;
                    bNext.Visible = false;
                    timer1.Enabled = false;
                    bAgain.Visible = true;
                    lResult.Text = "Prohra!" + " Sebrali jste " + mezivysledek + " / " + mapa.ZbyvaDiamantu + " mincí"; // dodat opci pro povtor tehle urovne nebo pro celou hru, jeste jedna button
                    lResult.Visible = true;
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
            if  (offset == System.IO.File.ReadAllLines("plan.txt").Count())
            {
                pBKonec.Visible = true;
                bAgainLevel.Visible = false;
                Intro.Visible = false;
                bNext.Visible = false;
                timer1.Enabled = false;
                bAgain.Visible = true;
                lResult.Text = "Konec! Prošli jste celou hru!\nZmačknutím tlačítka\nAGAIN začněte hru znovu!";
                lResult.Visible = true;
            }
            else
            button1_Click(sender, e);
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            offset = 0; // dodat offset pro uroven nebo tlacitko nove
            //offset =- mapa.offsetLine;
            button1_Click(sender, e);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Intro_Click(object sender, EventArgs e)
        {

        }

        private void lResult_Click(object sender, EventArgs e)
        {

        }

        private void bAgainLevel_Click(object sender, EventArgs e)
        {
            offset = offset - mapa.offsetLine;
            button1_Click(sender, e);
        }
    }
}
