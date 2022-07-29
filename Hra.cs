using System;
using System.Collections.Generic;
using System.Drawing;

namespace CSHra
{
    abstract class Prvek
    {
        //public abstract Bitmap MujObrazek();
    }

    abstract class PohyblivyPrvek : Prvek
    {
        public Mapa mapa;
        public int x; 
        public int y;
        public int Smer;
        public abstract void UdelejKrok();
    }

    enum StisknutaSipka { zadna, doleva, nahoru, doprava, dolu };
    class Mince : PohyblivyPrvek
        {
            
            public int x, y;
            public Mapa mapa;
            public Mince(Mapa mapa, int wherex, int wherey)
            {
                this.mapa = mapa;
                this.x = wherex;
                this.y = wherey;
            }
            public override void UdelejKrok()
            {
                return;
            }

            // pro sbirani
        }
    
    class Hrdina : PohyblivyPrvek
    {
        
        public Hrdina(Mapa mapa, int kdex, int kdey)
        {
            this.mapa = mapa;
            this.x = kdex;
            this.y = kdey;
        }
        public override void UdelejKrok()
        {
            int nove_x = x;
            int nove_y = y;

            int nove_bx = x;
            int nove_by = y;
            // ###########################################################

            switch (mapa.stisknutaSipka)
            {
                case StisknutaSipka.zadna:
                    break;
                case StisknutaSipka.doleva:
                    nove_x -= 1;
                    break;
                case StisknutaSipka.nahoru:
                    nove_y -= 1;
                    break;
                case StisknutaSipka.doprava:
                    nove_x += 1;
                    break;
                case StisknutaSipka.dolu:
                    nove_y += 1;
                    break;
                default:
                    break;
            }
            nove_x = (nove_x+mapa.sirka) % mapa.sirka;
            nove_y = (nove_y+mapa.vyska) % mapa.vyska;
            // ###########################################################

            if (mapa.JeVolno(nove_x, nove_y))
            {
                mapa.Presun(x, y, nove_x, nove_y); // presune obsah mapy a pokud je tam pohybliny prvek, zmeni mu x a y
            }
            else if (mapa.JeMinceHrdina(nove_x, nove_y))
            {
                mapa.Presun(x, y, nove_x, nove_y);

            }
            else if (mapa.JePrisera(nove_x, nove_y))
            {               
                mapa.lives--;
                if (mapa.lives == 0) mapa.stav = Stav.prohra;
            }     
            else if (mapa.JeZivot(nove_x, nove_y))
            {
                mapa.lives++;
                mapa.Presun(x, y, nove_x, nove_y);
            }
            else return;

        }
    }

    class Zivot : PohyblivyPrvek
    {
        public Zivot(Mapa mapa, int kdex, int kdey)
        {
            this.mapa = mapa;
            this.x = kdex;
            this.y = kdey;
        }

        public override void UdelejKrok()
        {
            return;
        }
    }

    class PriseraChytra : PohyblivyPrvek
    {
        public PriseraChytra(Mapa mapa, int kdex, int kdey)
        {
            this.mapa = mapa;
            this.x = kdex;
            this.y = kdey;
        }
        //###################################
        static Dictionary<char, (int, int)> zpravaZed = new Dictionary<char, (int, int)>()
        { { '>', (1, 0) }, {'<', (-1, 0)}, {'^', (0, 1)}, {'V', (0, -1)} };

        static Dictionary<char, (int, int)> polohaTah = new Dictionary<char, (int, int)>()
        { { '>', (0, 1) }, {'<', (0, -1)}, {'^', (-1, 0)}, {'V', (1, 0)} };
        public int count = 0;

        static bool pred = false;
        static bool predRight = false;
        char previous = ' ';

        static char left(char p)
        {
            if (p == '>') p = '^';
            else if (p == '^') p = '<';
            else if (p == '<') p = 'V';
            else if (p == 'V') p = '>';
            return p;
        }

        static char right(char p)
        {
            if (p == '>') p = 'V';
            else if (p == '^') p = '>';
            else if (p == '<') p = '^';
            else if (p == 'V') p = '<';
            return p;
        }
      
        public void move()
        {
            char c = mapa.plan[x, y];
            
            int xPrisera = (polohaTah[c].Item1 + mapa.sirka + x) % mapa.sirka;
            int yPrisera = (polohaTah[c].Item2 + mapa.vyska + y) % mapa.vyska;

           
            if (mapa.JeHrdina(xPrisera, yPrisera))
            {
                mapa.lives--;
                if (mapa.lives == 0) mapa.stav = Stav.prohra;
                else
                {
                    mapa.plan[x, y] = left(c);
                }
            }
            else if ((mapa.JeVolno(xPrisera, yPrisera) || mapa.JeMince(xPrisera, yPrisera) || mapa.JeZivot(xPrisera, yPrisera)) || predRight) // Nedosattek podminek
            {
                mapa.plan[x, y] = previous;
                previous = mapa.plan[xPrisera, yPrisera];
                mapa.plan[xPrisera, yPrisera] = c;
                x = xPrisera;
                y = yPrisera;
                pred = true;
                predRight = false;
            }
            else if  (mapa.JeVolno(xPrisera, yPrisera) && pred)
            {
                mapa.plan[x, y] = right(c);
                predRight = true;
                pred = false;
            }

            else if ( !mapa.JeVolno(xPrisera, yPrisera))
            {
               mapa.plan[x, y] = left(c);           
            }
            
        }
        
            
        public override void UdelejKrok()
        {
            move();
            //if (count == 1) { count = 0; move(); }
            //else count++;
        }

    }

    class PriseraHloupa : PohyblivyPrvek
    {
        public PriseraHloupa(Mapa mapa, int kdex, int kdey)
        {
            this.mapa = mapa;
            this.x = kdex;
            this.y = kdey;
        }

        public char previous = ' ';

        char Otocse(char c)
        {
            if (c == '5') return '6';
            if (c == '6') return '5';
            if (c == '7') return '8';
            else return '7';

        }
        public override void UdelejKrok()
        {
            Dictionary<char, (int, int)> polohaTah = new Dictionary<char, (int, int)>()
            { { '5', (0, 1) }, {'6', (0, -1)}, {'7', (-1, 0)}, {'8', (1, 0)} };
            char c2 = mapa.plan[x, y];
            int xPrisera = (polohaTah[c2].Item1 + mapa.sirka + x) % mapa.sirka;
            int yPrisera = (polohaTah[c2].Item2 + mapa.vyska + y) % mapa.vyska;


            if (mapa.JeVolno(xPrisera, yPrisera) || mapa.JeMince(xPrisera, yPrisera) || mapa.JeZivot(xPrisera, yPrisera))
            {     
                mapa.plan[x, y] = previous;
                previous = mapa.plan[xPrisera, yPrisera];
                mapa.plan[xPrisera, yPrisera] = c2;
                x = xPrisera;
                y = yPrisera;

            }
            else if (mapa.JeHrdina(xPrisera, yPrisera))
            {
                mapa.lives--;
                if (mapa.lives == 0) mapa.stav = Stav.prohra;
                mapa.plan[x, y] = Otocse(c2);
            }
            else
            {
                mapa.plan[x, y] = Otocse(c2);
            }
        }
    
    }

    public enum Stav { nezacala, bezi, vyhra, prohra };
    class Mapa
    {
        public char[,] plan;
        public int sirka;
        public int vyska;
        public int ZbyvaDiamantu;
        public int pocetDiamantu;
        public int offsetLine;
        public int lives = 3;

        public Stav stav = Stav.nezacala;

        Bitmap[] ikonky;
        int sx; // velikost kosticky ikonek

        public Hrdina hrdina;
        public List<PohyblivyPrvek> PohyblivePrvkyKromeHrdiny;
        public int offset;
        public StisknutaSipka stisknutaSipka;


        public Mapa(string cestaMapa, string cestaIkonky, int offset)
        {
            NactiIkonky(cestaIkonky);
            NactiMapu(cestaMapa, offset);
            stav = Stav.bezi;
        }

        public void Presun(int zX, int zY, int naX, int naY)
        {
            char c = plan[zX, zY];
            plan[zX, zY] = ' ';
            plan[naX, naY] = c;

            // podivat se, jestli tam nestal hrdina:
            if (c=='R' || c == 'L' || c == 'U' || c == 'D')
            {
                hrdina.x = naX;
                hrdina.y = naY;
                return; // kdyz na [zY,zX] stoji hrdina, tak tam nic jineho nestoji
            }

            // najit pripadny pohyblivyPrvek a zmenit mu polohu :
            foreach (PohyblivyPrvek po in PohyblivePrvkyKromeHrdiny)
            {
                if ((po.x == zX) && (po.y == zY))
                {
                    po.x = naX;
                    po.y = naY;
                    break; // jakmile tam stoji jeden, tak uz tam nikdo jiny nestoji
                }
            }

        }

        public void ZrusPohyblivyPrvek(int zX, int zY)
        { 
            // najit pohyblivyPrvek a vyhodit ho ze seznamu :
            for (int i = 0; i < PohyblivePrvkyKromeHrdiny.Count; i++)
            {
                if ((PohyblivePrvkyKromeHrdiny[i].x == zX) && (PohyblivePrvkyKromeHrdiny[i].y == zY))
                {
                    PohyblivePrvkyKromeHrdiny.RemoveAt(i); // 1. vyhodit ze seznamu pohyblivych prvku...
                    plan[zX, zY] = ' ';                    // 2. ...a z planu!
                    break;
                }
            }
        }


        public bool JeHrdina(int x, int y)
        {
            return plan[x, y] == 'R' || plan[x, y] == 'L' || plan[x, y] == 'U' || plan[x, y] == 'D';
        }
        public bool JeMince(int x, int y)
        {
            return (plan[x, y] == 'c' || plan[x, y] == 'C' || plan[x, y] == 'A');
        }

        public bool JeMinceHrdina(int x, int y)
        {
            if (plan[x, y] == 'c' || plan[x, y] == 'C' || plan[x, y] == 'A')
            {
                pocetDiamantu++;
                KonecLevelu();
                return true;
            }
            return false;
        }

        public bool JeZivot(int x, int y)
        {
            return plan[x, y] == 'H';
        }

        public bool JeVolno(int x, int y)
        {
            return (plan[x, y] == ' '); 
        }

        public bool JePriseraChytra(int x, int y)
        {
            return plan[x, y] == '>' || plan[x, y] == '<' || plan[x, y] == 'V' || plan[x, y] == '^';
        }

        public bool JePriseraHloupa(int x, int y)
        {
            return plan[x, y] == '5' || plan[x, y] == '6' || plan[x, y] == '7' || plan[x, y] == '8';
        }

        public bool JePrisera(int x, int y)
        {
            return JePriseraChytra(x, y) || JePriseraHloupa(x, y);
        }
 
        public bool JeZed(int x, int y)
        {
            string s = Convert.ToString(plan[x, y]);
            return "vhu(n)1234".Contains(s);
        }
        public void KonecLevelu()
        {
            if (pocetDiamantu == ZbyvaDiamantu)
            {
                stav = Stav.vyhra;
                return;
            }

        }

        /*public void ZrusZivot(int x, int y)
        {
            plan[x, y] = ' ';

        }*/


        public void NactiMapu(string cesta, int offset)
        {
            PohyblivePrvkyKromeHrdiny = new List<PohyblivyPrvek>();

            System.IO.StreamReader sr = new System.IO.StreamReader(cesta);
            for (int i = 0; i < offset; i++)
            {
                sr.ReadLine();
            }
           

            sirka = int.Parse(sr.ReadLine());
            vyska = int.Parse(sr.ReadLine());
            plan = new char[sirka, vyska];
            ZbyvaDiamantu = 0;
            offsetLine = vyska + 2;

            for (int y = 0; y < vyska; y++)
            {
                string radek = sr.ReadLine();
                for (int x = 0; x < sirka; x++)
                {
                    char znak = radek[x];
                    plan[x, y] = znak;

                    // vytvorit pripadne pohyblive objekty:
                    switch (znak)
                    {
                        case 'R':
                        case 'L':
                        case 'U':
                        case 'D':
                            this.hrdina = new Hrdina(this, x, y);
                            break;

                        case '<':
                        case '^':
                        case '>':
                        case 'V':
                            PriseraChytra priseraChytra = new PriseraChytra(this, x, y);
                            PohyblivePrvkyKromeHrdiny.Add(priseraChytra);
                            break;

                        case '5':
                        case '6':
                        case '7':
                        case '8':
                            PriseraHloupa priseraHloupa = new PriseraHloupa(this, x, y);
                            PohyblivePrvkyKromeHrdiny.Add(priseraHloupa);
                            break;

                        case 'c':
                        case 'C':
                        case 'A':
                            Mince mince = new Mince(this, x, y);
                            PohyblivePrvkyKromeHrdiny.Add(mince);
                            ZbyvaDiamantu++;
                            break;
                        case 'H':
                            Zivot zivot = new Zivot(this, x, y);
                            PohyblivePrvkyKromeHrdiny.Add(zivot);
                            break;
                        default:
                            break;
                    }
                }
            }
            sr.Close();
        }
        public void NactiIkonky(string cesta)
        {
            using (Bitmap bmp = new Bitmap(cesta))
            {
                this.sx = bmp.Height;
                int pocet = bmp.Width / sx; // predpokladam, ze to jsou kosticky v rade
                //Console.WriteLine(pocet);
                ikonky = new Bitmap[pocet];
                for (int i = 0; i < pocet; i++)
                {
                    Rectangle rect = new Rectangle(i * sx, 0, sx, sx);
                    ikonky[i] = bmp.Clone(rect, System.Drawing.Imaging.PixelFormat.DontCare);
                }
            }
        }

        public void VykresliSe(Graphics g, int sirkaVyrezuPixely, int vyskaVyrezuPixely)
        {
            int sirkaVyrezu = sirkaVyrezuPixely / sx;
            int vyskaVyrezu = vyskaVyrezuPixely / sx;

            if (sirkaVyrezu > sirka)
                sirkaVyrezu = sirka;

            if (vyskaVyrezu > vyska)
                vyskaVyrezu = vyska;

            // urcit LHR vyrezu:
            int dx = hrdina.x - sirkaVyrezu / 2;
            if (dx < 0)
                dx = 0;
            if (dx + sirkaVyrezu - 1 >= this.sirka)
                dx = this.sirka - sirkaVyrezu;

            int dy = hrdina.y - vyskaVyrezu / 2;
            if (dy < 0)
                dy = 0;
            if (dy + vyskaVyrezu - 1 >= this.vyska)
                dy = this.vyska - vyskaVyrezu;

            for (int x = 0; x < sirkaVyrezu; x++)
            {
                for (int y = 0; y < vyskaVyrezu; y++)
                {
                    int mx = dx + x; // index do mapy
                    int my = dy + y; // index do mapy

                    char c = plan[mx, my];
                    int indexObrazku = "RLUD vhu(n)c1234<>^VCAHqwer5678".IndexOf(c); // 0..
                    
                    g.DrawImage(ikonky[indexObrazku], x * sx, y * sx); 
                }
            }
        }

        public void ZmenaHrdiny(char naCo)
        {
            for (int y =  0; y < vyska; y++)
            {
                for (int x = 0; x < sirka; x++)
                    if (plan[x, y] == 'R' || plan[x, y] == 'L' || plan[x, y] == 'U' || plan[x, y] == 'D') plan[x, y] = naCo;
            }
            return;
        }
        public void PohniVsemiPrvky(StisknutaSipka stisknutaSipka)
        {
            this.stisknutaSipka = stisknutaSipka;
            foreach (PohyblivyPrvek p in PohyblivePrvkyKromeHrdiny)
            {
                p.UdelejKrok();
            }

            hrdina.UdelejKrok();
        }
    }
    

}

