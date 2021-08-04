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
        Image key = Image.FromFile(Application.StartupPath + @"\key.png");
        Image wall = Image.FromFile(Application.StartupPath + @"\brick_wall.jpg");
        Image ladder = Image.FromFile(Application.StartupPath + @"\ladder1.png");
        Rectangle areaTree, areaCharacter, areaT1, areaB1, areaL1, areaR1, areaT2, areaB2, areaL2, areaR2, areaTree2, LSide, RSide, TSide, BSide, areaT3, areaB3, areaR3, areaL3, bullet, enemy, Ladder, Ladder2, Ladder3, Ladder4, Ladder5, gameoverRectangle, keyrectangle, lockeddoor, doorL, helicopter;
        Rectangle[] bulletarrayl = new Rectangle[16];
        Rectangle[] bulletarrayr = new Rectangle[16];
        Rectangle[] UpS = new Rectangle[20];
        Rectangle[] DownS = new Rectangle[20];
        Rectangle[] RightS = new Rectangle[20];
        Rectangle[] LeftS = new Rectangle[20];
        Rectangle[] Object = new Rectangle[20];
        public class Enemy { };



        int bulletloopl;
        int bulletloopr;
        int px = 350, py = 400;
        int x = 120, y = 320;
        int x2 = 450, y2 = 120;
        int x3 = 1650;
        int x4 = 500;
        int floory = 489;
        int enemyhp = 3;
        bool left, right, up, jump, shoot, start, game_end, havekey, door_opened;
        int lives;
        int pspeedr = 1, pspeedl = 1, espeedl = 2, espeedr = 2, espeedu = 0, espeedd = 0;
        int gravity = -1;
        string lastkeypressed;
        string difficulty;
        int time;

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
            start = false;
            game_end = false;

            tmrCountdown.Enabled = false;
            tmrBulletdelay.Enabled = false;
            TmrCollision.Enabled = false;
            TmrPlayer.Enabled = false;
            btnBurglar.Visible = false;
            btnBurglar.Enabled = false;
            btnCriminal.Enabled = false;
            btnCriminal.Visible = false;
            btnTheif.Visible = false;
            btnTheif.Enabled = false;
            difficulty = "theif";
            time = 60;

            gameoverRectangle = new Rectangle(0, 0, 1000, 1000);

        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            backtomenu();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            startGame();
        }
        private void btnDifficulty_Click(object sender, EventArgs e)
        {
            optionSelect();
        }
        private void btnTheif_Click(object sender, EventArgs e)
        {
            difficulty = "theif";
            btnStart.Visible = true;
            btnStart.Enabled = true;
            btnDifficulty.Enabled = true;
            btnDifficulty.Visible = true;
            btnBurglar.Visible = false;
            btnBurglar.Enabled = false;
            btnCriminal.Enabled = false;
            btnCriminal.Visible = false;
            btnTheif.Visible = false;
            btnTheif.Enabled = false;
        }

        private void btnBurglar_Click(object sender, EventArgs e)
        {
            difficulty = "burglar";
            btnStart.Visible = true;
            btnStart.Enabled = true;
            btnDifficulty.Enabled = true;
            btnDifficulty.Visible = true;
            btnBurglar.Visible = false;
            btnBurglar.Enabled = false;
            btnCriminal.Enabled = false;
            btnCriminal.Visible = false;
            btnTheif.Visible = false;
            btnTheif.Enabled = false;
        }

        private void btnCriminal_Click(object sender, EventArgs e)
        {
            difficulty = "criminal";
            btnStart.Visible = true;
            btnStart.Enabled = true;
            btnDifficulty.Enabled = true;
            btnDifficulty.Visible = true;
            btnBurglar.Visible = false;
            btnBurglar.Enabled = false;
            btnCriminal.Enabled = false;
            btnCriminal.Visible = false;
            btnTheif.Visible = false;
            btnTheif.Enabled = false;

        }
        private void optionSelect()
        {
            btnStart.Visible = false;
            btnStart.Enabled = false;
            btnDifficulty.Enabled = false;
            btnDifficulty.Visible = false;
            btnBurglar.Visible = true;
            btnBurglar.Enabled = true;
            btnCriminal.Enabled = true;
            btnCriminal.Visible = true;
            btnTheif.Visible = true;
            btnTheif.Enabled = true;
        }
        private void startGame()//start game function
        {
            start = true;
            btnStart.Visible = false;
            btnStart.Enabled = false;
            tmrBulletdelay.Enabled = true;
            TmrCollision.Enabled = true;
            TmrPlayer.Enabled = true;
            tmrCountdown.Enabled = true;
            btnDifficulty.Enabled = false;
            btnDifficulty.Visible = false;
            btnBurglar.Visible = false;
            btnBurglar.Enabled = false;
            btnCriminal.Enabled = false;
            btnCriminal.Visible = false;
            btnTheif.Visible = false;
            btnTheif.Enabled = false;
            if (difficulty == "theif")
            {
                time = 60;
            }
            if (difficulty == "burglar")
            {
                time = 45;
            }
            if (difficulty == "criminal")
            {
                time = 30;
            }
               px = 350;
               py = 400;
               x = 120; 
               y = 320;
               x2 = 450; 
               y2 = 120;
               x3 = 1650;
               x4 = 500;
               floory = 489;


        }
        private void gameOver()
        {
            game_end = true;
            BtnBack.Visible = true;
            BtnBack.Enabled = true;
            gameoverRectangle = new Rectangle(0, 0, 1000, 1000);
            enemy = Rectangle.Empty;
            Ladder = Rectangle.Empty;
            Ladder2 = Rectangle.Empty;
            Ladder3 = Rectangle.Empty;
            Ladder4 = Rectangle.Empty;
            Ladder5 = Rectangle.Empty;
            areaCharacter = Rectangle.Empty;
            keyrectangle = Rectangle.Empty;
            doorL = Rectangle.Empty;
            lockeddoor = Rectangle.Empty;
            helicopter = Rectangle.Empty;
            for (int bulletloopl = 0; bulletloopl <= 15; bulletloopl++)
            {
                bulletarrayl[bulletloopl] = Rectangle.Empty;
            }
            for (int bulletloopr = 0; bulletloopr <= 15; bulletloopr++)
            {

                bulletarrayr[bulletloopr] = Rectangle.Empty;
            }
            for (int O = 1; O < 16; O++)
            {
                Object[O] = Rectangle.Empty;
            }
            PnlGame.Invalidate();
            tmrCountdown.Enabled = false;
            start = false;

            TmrPlayer.Enabled = false;
            tmrBulletdelay.Enabled = false;
            TmrCollision.Enabled = false;
        }
        private void backtomenu()
        {
            btnStart.Visible = true;
            btnStart.Enabled = true;
            btnDifficulty.Enabled = true;
            btnDifficulty.Visible = true;
            BtnBack.Visible = false;
            BtnBack.Enabled = false;
            label3.Visible = false;
        }
        private void win()
        {
            gameOver();
           label3.Visible = true;
        }
        private void tmrCountdown_Tick(object sender, EventArgs e)
        {


            label1.Text = time + "";
            time -= 1;
            if (time <= 0)
            {
                gameOver();
            }
    
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
            if (e.KeyData == Keys.Right) { right = false; }
            if (e.KeyData == Keys.Space) { shoot = false; }
        }

        private void tmrBulletdelay_Tick(object sender, EventArgs e)
        {

            if (right || lastkeypressed == "right" && left == false)
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
                if (left || lastkeypressed == "left" && right == false)
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
                for (int O = 1; O < 16; O++)
                {
                    if (bulletarrayl[bulletloopl].IntersectsWith(Object[O]))
                    {
                        bulletarrayl[bulletloopl] = Rectangle.Empty;
                    }
                }

            }

            for (int bulletloopr = 0; bulletloopr <= 15; bulletloopr++)
            {
                bulletarrayr[bulletloopr].X += 8 - pspeedr;
                for (int O = 1; O < 16; O++)
                {


                    if (bulletarrayr[bulletloopr].IntersectsWith(Object[O]) || bulletarrayr[bulletloopr].IntersectsWith(doorL))
                    {
                        bulletarrayr[bulletloopr] = Rectangle.Empty;
                    }
                }

            }


            if (right == true)
            {
                if (px >= 920)
                {
                    pspeedr = 0;
                    px = 920;
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
                if (x <= -1700)
                {
                    espeedr = 0;
                    x = -1700;
                    pspeedr = 2;
                }



                if (px + 50 > PnlGame.Width)
                {
                    pspeedr = 0;
                    espeedr = 0;
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

                if (x >= 200)
                {
                    espeedl = 0;
                    x = 200;
                    pspeedl = 2;
                }


            }
            if (py <= 22)
            {
                /*  py += 14;*/
                y += 14;
                y2 += 14;
                floory += 14;
            }

            if (y >= 500)
            {
                y += 0;
                y2 += 0;
                floory += 0;
            }
            else
            {

            }

            if (x > -1000)
            {
                if (py >= 381 && y == 320)
                {
                    py = 381;
                    y += 0;
                    y2 += 0;
                    floory += 0;
                }
                if (py >= 367 && y == 306)
                {
                    y = 320;
                    y2 = 120;
                    floory = 489;
                }


                if (y >= 558)
                {
                    y = 558;
                }
                if (y >= 516)
                {

                    y -= 14;
                    y2 -= 14;
                    floory -= 14;
                }
                if (py >= 382)
                {
                    py -= 14;
                    y -= 14;
                    y2 -= 14;
                    floory -= 14;

                }
            }

            if (x < -1000)
            {
                if (y >= 716)
                {
                    y -= 14;
                    y2 -= 14;
                    floory -= 14;
                }
                if (py >= 381 && y == 320)
                {
                    py = 381;
                    y += 0;
                    y2 += 0;
                    floory += 0;
                }
                if (py >= 367 && y == 306)
                {
                    y = 320;
                    y2 = 120;
                    floory = 489;
                }
                if (py >= 382)
                {
                    /*  py -= 14;*/
                    y -= 14;
                    y2 -= 14;
                    floory -= 14;
                }
            }
            if (y == 0)
            {

            }

            if (y == 334 && py == 395)// fixes a bug where the floor would move if you hit your head on the roof, which often lead to clipping thorugh the floor.
            {
                y -= 14;
                y2 -= 14;
                floory -= 14;
            }
            else
            {
                y += 0;
                y2 += 0;
                floory += 0;
            }

        }



        private void TmrPlayer_Tick(object sender, EventArgs e)
        {
            //declaring player and enemy rectangles

            enemy = new Rectangle(x4, floory - 110, 50, 50);
            areaCharacter = new Rectangle(px, py, 50, 50);
            LSide = new Rectangle(px, py, 5, 50);//Player Rectangle
            TSide = new Rectangle(px + 5, py, 50, 5);//Player Rectangle
            BSide = new Rectangle(px + 5, py + 45, 50, 5);//Player Rectangle
            RSide = new Rectangle(px + 45, py, 5, 50);//Player Rectangle
            Ladder = new Rectangle(x2 + 690, y2 + 130, 50, 180);// Ladder Test
            Ladder2 = new Rectangle(x2 + 60, y2 - 50, 50, 180);
            Ladder3 = new Rectangle(x3 + 690, y2 + 120, 50, 190);
            Ladder4 = new Rectangle(x3 + 410, y2 - 70, 50, 190);
            Ladder5 = new Rectangle(x3 + 690, y2 - 270, 50, 210);
            keyrectangle = new Rectangle(x2 + 750, y2 - 100, 50, 50);//key
            lockeddoor = new Rectangle(x3, y2 + 250, 50, 70);//door
            doorL = new Rectangle(x3, y2 + 250, 5, 70);//door's collision box
            helicopter = new Rectangle(x3, y2 - 300,100,50);//finish line;

            label2.Text = havekey + "";
          
            //first building objects
            Object[1] = new Rectangle(x2, y2 - 50, 50, 300);
            Object[2] = new Rectangle(x2 + 50, y - 70, 630, 50);
            Object[3] = new Rectangle(x2 + 750, y2 - 50, 50, 300);
            Object[4] = new Rectangle(x2 + 375, y2 + 150, 50, 100);
            Object[5] = new Rectangle(x2 + 120, y2 - 50, 630, 50);
            Object[6] = new Rectangle(x2 + 375, y2 - 30, 50, 100);
            Object[7] = new Rectangle(0, floory - 60, 5000, 50);
            //second building objects
            Object[8] = new Rectangle(x3, y2 - 290, 50, 540);
            Object[9] = new Rectangle(x3 + 50, y2 + 120, 630, 50);
            Object[10] = new Rectangle(x3 + 750, y2 - 290, 50, 540);
            Object[11] = new Rectangle(x3 + 470, y2 - 70, 330, 50);
            Object[12] = new Rectangle(x3 + 350, y2 + 150, 50, 100);
            Object[13] = new Rectangle(x3 + 350, y2 - 100, 50, 150);
            Object[14] = new Rectangle(x3, y2 - 270, 680, 50);
            //automatically setting up collision for my objects.
            for (int O = 1; O < 16; O++)
            {
                UpS[O] = new Rectangle(Object[O].Left, Object[O].Top, Object[O].Width, 20);
                RightS[O] = new Rectangle(Object[O].Right - 5, Object[O].Top + 5, 5, Object[O].Height - 5);
                LeftS[O] = new Rectangle(Object[O].Left, Object[O].Top + 5, 5, Object[O].Height - 5);
                DownS[O] = new Rectangle(Object[O].Left, Object[O].Bottom - 20, Object[O].Width, 25);

                if (right == true && RSide.IntersectsWith(LeftS[O]) || right == true && RSide.IntersectsWith(doorL) && havekey == false)
                {
                    espeedr = 0;
                    pspeedr = 0;
                }

                if (left == true && LSide.IntersectsWith(RightS[O]))
                {
                    espeedl = 0;
                    pspeedl = 0;
                }

            }

            //collsion ends

            //movement
            if (left) // if left arrow pressed 
            {
                px -= pspeedl;
                x += espeedl;
                x2 += espeedl;
                x3 += espeedl;
                x4 += espeedl;

            }
            if (right) // if right arrow pressed
            {
                px += pspeedr;
                x -= espeedr;
                x2 -= espeedr;
                x3 -= espeedr;
                x4 -= espeedr;
            }


            //gravity and the interaction with the tops and bottoms of my platforms
            for (int O = 1; O < 16; O++)
            {
                if (BSide.IntersectsWith(UpS[O]))
                {
                    gravity = 0;
                    py = Object[O].Top - 49;
                    jump = true;
                }
                if (TSide.IntersectsWith(DownS[O]))
                {
                    gravity = -2;
                }
            }
            if (areaCharacter.IntersectsWith(Ladder) || areaCharacter.IntersectsWith(Ladder2) || areaCharacter.IntersectsWith(Ladder3) || areaCharacter.IntersectsWith(Ladder4) || areaCharacter.IntersectsWith(Ladder5))
            {
                if (up == true)
                {
                    gravity += 1;
                    if (gravity > 6)
                    {
                        gravity = 5;
                    }
                }
            }
          
            if (areaCharacter.IntersectsWith(lockeddoor) && havekey == true)
            {
                door_opened = true;           
            }
            if (door_opened == true)
            {
                lockeddoor = Rectangle.Empty;
                doorL = Rectangle.Empty;
            }
            if (areaCharacter.IntersectsWith(helicopter))
            {
                win();
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




            py = py - gravity;
            //end of gravity
            if (areaCharacter.IntersectsWith(keyrectangle))
            {
                keyrectangle = Rectangle.Empty;
                havekey = true;
            }
            if (havekey == true)
            {
                keyrectangle = Rectangle.Empty;
            }
            PnlGame.Invalidate();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;


            g.DrawImage(ladder, Ladder);
            g.DrawImage(ladder, Ladder2);
            g.DrawImage(ladder, Ladder3);
            g.DrawImage(ladder, Ladder4);
            g.DrawImage(ladder, Ladder5);
            e.Graphics.FillRectangle(Brushes.Gray, helicopter);
            g.DrawImage(character, areaCharacter);
            g.DrawImage(tree, areaTree);
            g.DrawImage(tree2, areaTree2);
            g.DrawImage(character, enemy);
            g.DrawImage(key, keyrectangle);
            e.Graphics.FillRectangle(Brushes.Red, lockeddoor);
            e.Graphics.FillRectangle(Brushes.Red, lockeddoor);
            


            for (int bulletloopl = 0; bulletloopl <= 15; bulletloopl++)
            {
                e.Graphics.FillRectangle(Brushes.Black, bulletarrayl[bulletloopl]);

            }

            for (int bulletloopr = 0; bulletloopr <= 15; bulletloopr++)
            {
                e.Graphics.FillRectangle(Brushes.Black, bulletarrayr[bulletloopr]);
            }
            for (int O = 1; O < 16; O++)
            {
                g.DrawImage(wall, Object[O]);
             /*   e.Graphics.FillRectangle(Brushes.Green, UpS[O]);
                e.Graphics.FillRectangle(Brushes.Green, LeftS[O]);
                e.Graphics.FillRectangle(Brushes.Green, RightS[O]);
                e.Graphics.FillRectangle(Brushes.Green, DownS[O]);*/

            
            }

        }
    }
}

