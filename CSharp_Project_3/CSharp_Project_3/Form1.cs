using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
namespace CSharp_Project_3
{
    public partial class Form1 : Form
    {
        Graphics g;
        Image character = Image.FromFile(Application.StartupPath + @"\character2.jpg");
        Image tree = Image.FromFile(Application.StartupPath + @"\tree.jpg");
        Image tree2 = Image.FromFile(Application.StartupPath + @"\tree.jpg");
        Rectangle areaTree, areaCharacter, areaT1, areaB1, areaL1, areaR1, areaT2, areaB2, areaL2, areaR2, areaTree2, LSide, RSide, TSide, BSide, areaT3, areaB3, areaR3, areaL3, bullet;
        Rectangle[] bulletarrayl = new Rectangle[16];
        Rectangle[] bulletarrayr = new Rectangle[16];
        int bulletloopl;
        int bulletloopr;
        int px = 270, py;
        int x = 100, y = 325;
        int x2 = 450, y2 = 100;
        int x3 = -350;
        bool left, right, up, jump, shoot;
        int lives;
        int pspeedr = 1, pspeedl = 1, espeedl = 2, espeedr = 2;
        int gravity = -1;
        string lastkeypressed;
        public Form1()
        {
            InitializeComponent();
           


            //stops the objects from flickering
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, PnlGame, new object[] { true });
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            bulletloopl = 1;
            bulletloopr = 1;
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up) { up = true; }
            if (e.KeyData == Keys.Left) { left = true; lastkeypressed = "left"; }
            if (e.KeyData == Keys.Right) { right = true; lastkeypressed = "right"; }
            if (e.KeyData == Keys.Space) { shoot = true; }
        }
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up) { up = false; }
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false;}
            if (e.KeyData == Keys.Space) { shoot = false; }
        }
        private void tmrBulletdelay_Tick(object sender, EventArgs e)
        {
           
                if (right || lastkeypressed == "right")
                {
                if (shoot == true)
                {
                    bulletarrayr[bulletloopr] = new Rectangle(px + 45, py + 20, 5, 5);
                    if (bulletloopr > 14)
                    {
                        bulletloopr = 1;
                    }
                    else
                    {
                        bulletloopr += 1;
                    }
                }
                }
          

            
            if (shoot == true)
            {
                if (left || lastkeypressed == "left")
                {
                    bulletarrayl[bulletloopl] = new Rectangle(px, py + 20, 5, 5);
                    if (bulletloopl > 14)
                    {
                        bulletloopl = 1;
                    }
                    else
                    {
                        bulletloopl += 1;
                    }
                }
            }
          
        }

        private void TmrCollision_Tick(object sender, EventArgs e) //collision using rectangles as borders for my object, this simplified my code greatly and allowed for smooth collisions
        {
            for (int bulletloopl = 0; bulletloopl <= 15; bulletloopl++)
            {
                bulletarrayl[bulletloopl].X -= 8 - pspeedl;
                if (bulletarrayl[bulletloopl].IntersectsWith(areaTree2))
                {
                    bulletarrayl[bulletloopl] = Rectangle.Empty;
                }
                if (bulletarrayl[bulletloopl].IntersectsWith(areaTree))
                {
                    bulletarrayl[bulletloopl] = Rectangle.Empty;
                }

            }

            for (int bulletloopr = 0; bulletloopr <= 15; bulletloopr++)
            {
                bulletarrayr[bulletloopr].X += 8 - pspeedr;

                if (bulletarrayr[bulletloopr].IntersectsWith(areaTree2))
                {
                    bulletarrayr[bulletloopr] = Rectangle.Empty;
                }
                if (bulletarrayr[bulletloopr].IntersectsWith(areaTree))
                {
                    bulletarrayr[bulletloopr] = Rectangle.Empty;
                }
            }
            if (right == true)
            {
                if (px >= 720)
                {
                    pspeedr = 0;
                    px = 720;
                }
                if (px <= 350)
                {
                    espeedr = 0;
                        pspeedr = 2;
                }
                else
                {
                    espeedr = 2;
                    pspeedr = 0;
                }
                if (areaCharacter.IntersectsWith(areaL1))
                {
                    espeedr = 0;
                    pspeedr = 0;
                }
                if (areaCharacter.IntersectsWith(areaL2))
                {
                    espeedr = 0;
                    pspeedr = 0;
                }
                if (x <= -400)
                {
                    espeedr = 0;
                    x = -400;
                    pspeedr = 2;
                }

               
            }
            if (left == true)
            {
                if (px <= 0)
                {
                    pspeedl = 0;
                    px = 0;
                }
                else
                {
                    pspeedl = 1;
                }

                if (px > 350)
                {
                    espeedl = 0;
                    pspeedl = 2;
                }
                else
                {
                    espeedl = 2;
                    pspeedl = 0;
                }
                if (areaCharacter.IntersectsWith(areaR1))
                {
                    espeedl = 0;
                    pspeedl = 0;
                }

                if (areaCharacter.IntersectsWith(areaR2))
                {
                    espeedl = 0;
                    pspeedl = 0;
                }
                if (x >= 500)
                {
                    espeedl = 0;
                    x = 500;
                    pspeedl = 2;
                }


            }

        }
        private void TmrPlayer_Tick(object sender, EventArgs e)
        {
            areaCharacter = new Rectangle(px, py, 50, 50);
            LSide = new Rectangle(px, py, 5, 50);//Player Rectangle
            TSide = new Rectangle(px + 5, py, 50, 5);//Player Rectangle
            BSide = new Rectangle(px + 5, py + 45, 50, 5);//Player Rectangle
            RSide = new Rectangle(px + 45, py, 5, 50);//Player Rectangle
            areaT1 = new Rectangle(x, y, 250, 5);
            areaB1 = new Rectangle(x, y + 35, 250, 15);
            areaL1 = new Rectangle(x, y + 5, 5, 40);
            areaR1 = new Rectangle(x + 245, y + 5, 5, 40);
            areaTree = new Rectangle(x, y, 250, 50);
            areaTree2 = new Rectangle(x2, y2, 50, 250);
            areaT2 = new Rectangle(x2, y2, 45, 5);
            areaB2 = new Rectangle(x2 + 5, y2 + 235, 45, 15);
            areaL2 = new Rectangle(x2, y2 + 5, 5, 240);
            areaR2 = new Rectangle(x2 + 45, y2 + 5, 5, 240);
            areaT3 = new Rectangle(x3, y, 250, 15);

            label1.Text = bulletloopl + "";
            label2.Text = bulletloopr + "";

            //movement
            if (left) // if left arrow pressed 
            {
                px -= pspeedl;
                x += espeedl;
                x2 += espeedl;
                x3 += espeedl;

            }
            if (right) // if right arrow pressed
            {
                px += pspeedr;
                x -= espeedr;
                x2 -= espeedr;
                x3 -= espeedr;
            }
            //gravity and the interaction with the tops and bottoms of my platforms
            if (BSide.IntersectsWith(areaT1))
            {
                gravity = 0;
                py = areaT1.Top - 49;
                jump = true;
            }
            if (BSide.IntersectsWith(areaT3))
            {
                gravity = 0;
                py = areaT3.Top - 49;
                jump = true;
            }
            if (py + 50 > PnlGame.Height)
            {
                gravity = 0;
                py = PnlGame.Height - 50;
                jump = true;
            }
            if (up == true & jump == true)
            {
                gravity = 15;
                jump = false;
            }
            else if (!BSide.IntersectsWith(areaT1) && gravity >= -15)
            {
                gravity = gravity - 1;
            }

            if (TSide.IntersectsWith(areaB1))
            {
                gravity = -2;
            }
            if (TSide.IntersectsWith(areaB2))
            {
                gravity = -2;
            }
         
            if (!areaCharacter.IntersectsWith(areaT1) || !(py + 50 > PnlGame.Height) || (!areaCharacter.IntersectsWith(areaT3)))
            {
                espeedl = 2;
                espeedr = 2;
                pspeedl = 1;
                pspeedr = 1;
                jump = false;
            }
            py = py - gravity;
            //end of gravity

            PnlGame.Invalidate();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(character, areaCharacter);
            g.DrawImage(tree, areaTree);
            g.DrawImage(tree2, areaTree2);


            for (int bulletloopl = 0; bulletloopl <= 15; bulletloopl++)
            {
                e.Graphics.FillRectangle(Brushes.Black, bulletarrayl[bulletloopl]);

            }

            for (int bulletloopr = 0; bulletloopr <= 15; bulletloopr++)
            {
                e.Graphics.FillRectangle(Brushes.Black, bulletarrayr[bulletloopr]);
            }

                e.Graphics.FillRectangle(Brushes.Purple, areaT3);
            e.Graphics.FillRectangle(Brushes.Pink, areaB2);
            e.Graphics.FillRectangle(Brushes.Pink, areaL2);
            e.Graphics.FillRectangle(Brushes.Purple, areaR2);
           
        }


    }

}