﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CSHra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "PACMAN";
            bNext.Visible = false;
            bAgain.Visible = false;
            lResult.Visible = false;
            bAgainLevel.Visible = false;
            pBKonec.Visible = false;
            pBWin.Visible = false;
            pBLost.Visible = false;
            lStatus.Visible = false;
            bStop.Visible = false;

        }

        Mapa mapa;
        Graphics g;
        public int offset = 0;
        public int mezivysledek = 0;
        public int previousOffset = 0;
        public bool music = false;
        private SoundPlayer Player = new SoundPlayer();

        //public string file = "plan.txt";
        //public char[,] p;

        private void button1_Click(object sender, EventArgs e)
        {
            g = CreateGraphics();
            mapa = new Mapa("plan.txt", "ikonky.png", offset);
            this.Text = "PACMAN";
            lStatus.Visible = false;

            //mapa.plan = p;
            offset +=  mapa.offsetLine;
            timer1.Enabled = true;
            button1.Visible = false;
            lResult.Visible = false;
            pBKonec.Visible = false;
            pBWin.Visible = false;
            pBLost.Visible = false;



        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            switch (mapa.stav)
            {
                case Stav.bezi:
                    this.Text = "PACMAN";
                    //this.Text = "Zbývá sebrat " + mezivysledek + "/" + mapa.ZbyvaDiamantu + " mincí" + mapa.lives;
                    lStatus.Text = "Collected " + mezivysledek + "/" + mapa.ZbyvaDiamantu + " coins" + "\nLeft lives "+ mapa.lives;
                    lStatus.Visible = true;
                    if ( mezivysledek  != mapa.pocetDiamantu)
                    {
                        mezivysledek = mapa.pocetDiamantu;
                    }
                    lResult.Visible = false;
                    Intro.Visible = false;
                    bAgain.Visible = false;
                    bNext.Visible = false;
                    bAgainLevel.Visible = false;
                    bStop.Visible = true;
                    pBKonec.Visible = false;
                    pBWin.Visible = false;
                    pBLost.Visible = false;


                    this.BackgroundImage = null;
                    this.BackColor = Color.Black;
                    mapa.PohniVsemiPrvky(stisknutaSipka);
                    mapa.VykresliSe(g, ClientSize.Width, ClientSize.Height);                   
                    break;
                case Stav.vyhra:
                    lStatus.Visible = false;
                    pBKonec.Visible = false;
                    pBWin.Visible = true;
                    pBLost.Visible = false;
                    bAgain.Visible = true;
                    bAgainLevel.Visible = true;
                    Intro.Visible = false;
                    timer1.Enabled = false;
                    bNext.Visible = true;
                    bStop.Visible = false;
                    mezivysledek++;
                    lResult.Text = "Winning!" + " You collected " + mezivysledek + " / " + mapa.ZbyvaDiamantu + " coins\n"
                        + "Press NEXT to start\n next level!";
                    lResult.Visible = true;
                    break;
                case Stav.prohra:
                    //p = mapa.plan;
                    pBWin.Visible = false;
                    pBLost.Visible = true;
                    lStatus.Visible = false;
                    pBKonec.Visible = false;
                    bAgainLevel.Visible = true;
                    Intro.Visible = false;
                    bNext.Visible = false;
                    timer1.Enabled = false;
                    bAgain.Visible = true;
                    bStop.Visible = false;
                    lResult.Text = "Lost!" + " You collected " + mezivysledek + " / " + mapa.ZbyvaDiamantu + " coins"; // dodat opci pro povtor tehle urovne nebo pro celou hru, jeste jedna button
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
                bStop.Visible = false;
                pBLost.Visible = false;
                pBWin.Visible = false;
                lStatus.Visible = false;
                bAgainLevel.Visible = false;
                Intro.Visible = false;
                bNext.Visible = false;
                timer1.Enabled = false;
                bAgain.Visible = true;
                lResult.Text = "END! You won all levels!\nPress \nAGAIN to start the whole game again!";
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

        private void bMusic_Click(object sender, EventArgs e)
        {      
            
            /*if (music)
            {
                string p = "music.wav".Path;
                this.Player.SoundLocation = @"Resources\music.wav";
                //this.Player.Load();
                this.Player.PlayLooping();
            }
            else
            {
                this.Player.Stop();
                music = !music;
            }*/
        }

        string m = "stop";
        private void bStop_Click(object sender, EventArgs e)
        {
            if (bStop.Text == "stop")
            {
                m = "continue";
                timer1.Enabled = false;
                // neco tady dat 
            }
            if (bStop.Text == "continue")
            {
                m = "stop";
                timer1.Enabled = true;
            }
            bStop.Text = m;
            
        }
    }
}
