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
        Rectangle areaTree, areaCharacter, areaT1, areaB1, areaL1, areaR1, areaT2, areaB2, areaL2, areaR2, areaTree2, LSide, RSide, TSide, BSide;
        int x = 100, y = 325;
        int px = 110, py;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int x2 = 450, y2 = 100;


        private void TmrGrav_Tick(object sender, EventArgs e)
        {
            /*  if (areaCharacter.IntersectsWith(areaT2)|| areaCharacter.IntersectsWith(areaT1))
              {
                  jump = true;
                  areaCharacter.Y -= 0;
              }
              else
              {
                  if (areaCharacter.Y + 50 > PnlGame.Height)
                  {
                      jump = true;
                      areaCharacter.Y -= 0;

                  }
                  else
                  {
                      areaCharacter.Y += 1;
                      jump = false;
                  }*/
        }


        bool left, right, up, down, jump;
        int hp = 100;
        int xp = 0;
        int dmg = 0;
        int speedr = 1, speedl = 1, speedu = 1, speedd = 1;
        int gravity = -1;
        //asojnedrgnuojerg
        public Form1()
        {
            InitializeComponent();
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


            //stops the objects from flickering
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, PnlGame, new object[] { true });
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up) { up = true; }
            if (e.KeyData == Keys.Down) { down = true; }
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up) { up = false; }
            if (e.KeyData == Keys.Down) { down = false; }
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }
        }
        private void TmrCollision_Tick(object sender, EventArgs e) //collision using rectangles as borders for my object, this simplified my code greatly and allowed for smooth collisions
        {
            if (right == true)
            {
                if (areaCharacter.IntersectsWith(areaL1))
                {
                    speedr = 0;
                }
                if (areaCharacter.IntersectsWith(areaL2))
                {
                    speedr = 0;
                }
            }
            if (left == true)
            {
                if (areaCharacter.IntersectsWith(areaR1))
                {
                    speedl = 0;
                }
                if (areaCharacter.IntersectsWith(areaR2))
                {
                    speedl = 0;
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
            label1.Text = gravity + "";
            if (left) // if left arrow pressed
            {
                px -= speedl;

            }
            if (right) // if right arrow pressed
            {
                px += speedr;
            }

            if (BSide.IntersectsWith(areaT1))
            {
                gravity = 0;
                py = areaT1.Top - 49;
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
                gravity = -1;
            }
            if (TSide.IntersectsWith(areaB2))
            {
                gravity = -1;
            }
            if (!areaCharacter.IntersectsWith(areaT1) || !(py + 50 > PnlGame.Height))
            {
                speedl = 2;
                speedr = 2;
                jump = false;
            }
            py = py - gravity;

            PnlGame.Invalidate();
        }

        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(character, areaCharacter);
            g.DrawImage(tree, areaTree);
            g.DrawImage(tree2, areaTree2);



            e.Graphics.FillRectangle(Brushes.Purple, areaT1);
            e.Graphics.FillRectangle(Brushes.Pink, areaB1);
            /* e.Graphics.FillRectangle(Brushes.Pink, areaL2);
             e.Graphics.FillRectangle(Brushes.Purple, areaR2);*/
        }


    }

}