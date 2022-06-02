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
    abstract class Element
    {

    }
    

    
    enum PressedKey { none, left, right, up, down};

    abstract class MovingElement : Element
    {
        public Map map;
        public int x;
        public int y;
        public int direction;
        public abstract void MakeMove();
    }

    class Coin : MovingElement
    {
        public int x, y;
        public Map map;
        public Coin(Map map, int wherex, int wherey)
        {
            this.map = map;
            this.x = wherex;
            this.y = wherey;
        }
        public override void MakeMove()
        {
            throw new NotImplementedException();
        }

        // pro sbirani
    }

    
    class PacMan : MovingElement
    {
        public PacMan(Map map, int wherex, int wherey)
        {
            this.map = map;
            this.x = wherex;
            this.y = wherey;
        }

        public override void MakeMove()
        {
            int new_x = x;
            int new_y = y;
            //int new_bx = x;
            //int new_by = y;
            switch (map.pressedKey)
            {
                case PressedKey.none:
                    break;
                case PressedKey.left:
                    new_x -= 1;
                    break;
                case PressedKey.right:
                    new_x += 1;
                    break;
                case PressedKey.down:
                    new_y += 1;
                    break;
                case PressedKey.up:
                    new_y -= 1;
                    break;
            }

            if (map.IsFree(new_x, new_y))
            {
                map.Move(x, y, new_x, new_y);
            }
        }
    }

    class Monster : MovingElement  // dopsat jeste ###################################
    {
        public Monster(Map map, int wherex, int wherey, char charDirection)
        {
            this.map = map;
            this.x = wherex;
            this.y = wherey;
            direction = "<>v^".IndexOf(charDirection);
        }
        public override void MakeMove()
        {
            throw new NotImplementedException();
        }
    }

    //balvan a  
    public enum State { START, GAME, LOST, WIN };
    
    class Map
    {
        private char[,] plan;
        int width;
        int height;
        public int LeftToCollect;
        public State state = State.START;
        Bitmap[] icons;
        int sx;

        public PacMan pacman;
        public List<MovingElement> MovingElementsButPacman;
        public PressedKey pressedKey;

        public Map(string pathMap, string pathIcons)
        {
            ReadIcons(pathIcons);
            ReadMap(pathMap);
            state = State.GAME;
        }

        public void Move(int fX, int fY, int toX, int toY)
        {
            char c = plan[fX, fY];
            plan[fX, fY] = ' ';
            plan[toX, toY] = c;

            if (c == 'R') // slozity posun se zmenou pacmana FUNKCEEE 
            {
                pacman.x = toX;
                pacman.y = toY;
                return;
            }
            foreach (MovingElement me in MovingElementsButPacman) //???????????? jestli to potrebuji
            {
                if ((me.x == fX) && (me.y == fY))
                {
                    me.x = toX;
                    me.x = toY;
                    break;
                }
            }

        }

        public void RemoveElement(int fX, int fY)
        {
            for (int i = 0; i < MovingElementsButPacman.Count; i++) ////???????????????????????????????????????????
            {
                if ((MovingElementsButPacman[i].x == fX) && (MovingElementsButPacman[i].y == fY))
                {
                    MovingElementsButPacman.RemoveAt(i);
                    plan[fX, fY] = 'B';
                    break;
                }
            }
        }

        public bool IsPacman(int x, int y)
        {
            return plan[x, y] == 'P';
        }

        public bool IsCoin(int x, int y)
        {
            return plan[x, y] == 'C';
        }

        public bool IsMonster(int x, int y)
        {
            return "<>^".Contains(plan[x, y]);
        }

        public bool IsFree(int x, int y)
        {
            return true; // napsat !!!!!!!!!!!!!!!!!!!!!
        }
        public void ReadMap(string path)
        {
            MovingElementsButPacman = new List<MovingElement>();
            System.IO.StreamReader sr = new System.IO.StreamReader(path);
            width = int.Parse(sr.ReadLine());
            height = int.Parse(sr.ReadLine());
            plan = new char[width, height];
            LeftToCollect = 0;
            for (int y = 0; y < height; y++)
            {
                string row = sr.ReadLine();
                for (int x = 0; x < width; x++)
                {
                    char sign = row[x];
                    plan[x, y] = sign;

                    switch (sign)
                    {
                        case 'H':
                            this.pacman = new PacMan(this, x, y);
                            break;
                        case '<':
                        case '>':
                        case 'v':
                        case '^':
                            Monster monster = new Monster(this, x, y, sign);
                            MovingElementsButPacman.Add(monster);
                            break;
                        case 'C':
                            Coin coin = new Coin(this, x, y);
                            MovingElementsButPacman.Add(coin);
                            break;
                        
                        default: break;
                    }
                }
            }
            sr.Close();
        }

        public void ReadIcons(string path)
        {
            Bitmap bmp = new Bitmap(path);
            this.sx = bmp.Height;
            int number = bmp.Width / sx;
            icons = new Bitmap[number];
            for (int i = 0; i < number; i++)
            {
                Rectangle rect = new Rectangle(i * sx, 0, sx, sx);
                icons[i] = bmp.Clone(rect, System.Drawing.Imaging.PixelFormat.DontCare);
            }

        }

        public void PaintAll(Graphics g, int widthPixels, int heightPixels)
        {
            int widthObrazu = widthPixels / sx;
            int heightObrazu = heightPixels / sx;
            if (widthObrazu > width) widthObrazu = width;
            if (heightObrazu > height) heightObrazu = height;

            int dx = pacman.x - widthObrazu / 2;
            if (dx < 0) dx = 0;
            if (dx + widthObrazu - 1 >= this.width)
                dx = this.width - widthObrazu;

            int dy = pacman.y - heightObrazu / 2;
            if (dy < 0) dy = 0;
            if (dy + heightObrazu - 1 >= this.height)
                dy = this.height - heightObrazu;

            for (int x = 0; x < widthObrazu; x++)
            {
                for (int y = 0; y < heightObrazu; y++)
                {
                    int mx = dx + x;
                    int my = dy + y;

                    char c = plan[mx, my];
                    int indexObrazku = "RLUDBvhu(n)C1234<>^".IndexOf(c);
                    g.DrawImage(icons[indexObrazku], x * sx, y * sx);
                }
            }

        }

        public void MoveAllElements(PressedKey pressedKey)
        {
            this.pressedKey = pressedKey;
            foreach (MovingElement el in MovingElementsButPacman)
            {
                el.MakeMove();
            }
            pacman.MakeMove();
        }

    }
    
}