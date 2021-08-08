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
        Image characterright = Image.FromFile(Application.StartupPath + @"\PlayerRight.png");
        Image characterleft = Image.FromFile(Application.StartupPath + @"\Playerleft.png");
        Image tree = Image.FromFile(Application.StartupPath + @"\tree.jpg");
        Image tree2 = Image.FromFile(Application.StartupPath + @"\tree.jpg");
        Image key = Image.FromFile(Application.StartupPath + @"\key.png");
        Image wall = Image.FromFile(Application.StartupPath + @"\brick_wall.jpg");
        Image ladder = Image.FromFile(Application.StartupPath + @"\Ladder.png");
        Image enemy = Image.FromFile(Application.StartupPath + @"\Enemy.png");
        Rectangle areaCharacter,areaT1,LSide, RSide, TSide, BSide, keyrectangle, lockeddoor, doorL, helicopter;
        Rectangle[] bulletarrayl = new Rectangle[16];
        Rectangle[] bulletarrayr = new Rectangle[16];
        Rectangle[] UpS = new Rectangle[20];
        Rectangle[] DownS = new Rectangle[20];
        Rectangle[] RightS = new Rectangle[20];
        Rectangle[] LeftS = new Rectangle[20];
        Rectangle[] Object = new Rectangle[20];
        Rectangle[] Ladder = new Rectangle[20];
        Rectangle[] Enemy = new Rectangle[20];
        int bulletloopl;
        int bulletloopr;
        int px = 350, py = 400;
        int x = 120, y = 320;
        int x2 = 450, y2 = 120;
        int x3 = 1650;
        int floory = 489;
        int ehp = 3, ehp2 = 3, ehp3 = 3, ehp4 = 3, ehp5 = 3, ehp6 = 3, ehp7 = 3;
        bool left, right, up, jump, shoot, start, game_end, havekey, door_opened;
        int lives = 3;
        int pspeedr = 1, pspeedl = 1, espeedl = 2, espeedr = 2;

        private void btnHelp_Click(object sender, EventArgs e)
        {
            showInstructions();
        }

        private void btnSavename_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {

            }
            else
            {
                txtName.Enabled = false;
                btnSavename.Visible = false;
                btnStart.Enabled = true;
                btnDifficulty.Enabled = true;
            }
          
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string context = txtName.Text;
            bool isletter = true;
            //for loop checks for letters as characters are entered
            for (int i = 0; i < context.Length; i++)
            {
                if (!char.IsLetter(context[i]))// if current character not a letter
                {
                    isletter = false;//make isletter false
                    break; // exit the for loop
                }

            }

            // if not a letter clear the textbox and focus on it
            // to enter name again
            if (isletter == false)
            {
                txtName.Clear();
                txtName.Focus();
            }
            else
            {
                btnSavename.Enabled = true;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TmrInvincibility_Tick(object sender, EventArgs e)
        {
            TmrInvincibility.Enabled = false;
        }

        int gravity = -1;
        string lastkeypressed = "right";
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
            btnStart.Enabled = false;
            btnDifficulty.Enabled = false;
            label5.Visible = false;
            label6.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            difficulty = "theif";
            time = 60;

          

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
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
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
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
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
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
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
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
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
            label5.Visible = false;
            btnHelp.Enabled = false;
            btnHelp.Visible = false;
            lives = 3;
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
               floory = 489;

            for (int O = 1; O < 16; O++)
            {
                Enemy[1] = new Rectangle(x2 + 610, y2 + 260, 50, 50);
                Enemy[2] = new Rectangle(x2 + 130, y2 + 80, 50, 50);
                Enemy[3] = new Rectangle(x2 + 610, y2 - 100, 50, 50);
                Enemy[4] = new Rectangle(x3 + 400, y2 + 260, 50, 50);
                Enemy[5] = new Rectangle(x3 + 200, y2 + 70, 50, 50);
                Enemy[6] = new Rectangle(x3 + 150, y - 570, 100, 100);
            }
            ehp = 3; ehp2 = 3; ehp3 = 3; ehp4 = 3; ehp5 = 3; ehp6 = 3; ehp7 = 3;
            havekey = false;
        }
        private void gameOver()
        {
            game_end = true;
            BtnBack.Visible = true;
            BtnBack.Enabled = true;
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
                Ladder[O] = Rectangle.Empty;
                Enemy[O] = Rectangle.Empty;
            }
            PnlGame.Invalidate();
            tmrCountdown.Enabled = false;
            start = false;
            label2.Visible = false;
            label3.Visible = false;
            label3.Visible = false;
            TmrPlayer.Enabled = false;
            tmrBulletdelay.Enabled = false;
            TmrCollision.Enabled = false;
        }
        private void showInstructions()
        {
            label5.Visible = true;
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
                    pspeedr = 3;
                }
                else
                {
                    espeedr = 3;
                    pspeedr = 0;
                }
                if (x <= -1700)
                {
                    espeedr = 0;
                    x = -1700;
                    pspeedr = 3;
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
                    pspeedl = 3;
                }
                else
                {
                    espeedl = 3;
                    pspeedl = 0;
                }

                if (x >= 200)
                {
                    espeedl = 0;
                    x = 200;
                    pspeedl = 3;
                }


            }
            if (py <= 22)
            {
                py += 6;
                y += 6;
                y2 += 6;
                floory += 6;
                for (int O = 1; O < 16; O++)
                {
                    Enemy[O].Y += 6;
                }
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

                    y -= 6;
                    y2 -= 6;
                    floory -= 6;
                    for (int O = 1; O < 16; O++)
                    {
                        Enemy[O].Y -= 6;
                    }
                }
                if (py >= 382)
                {
                    py -= 6;
                    y -= 6;
                    y2 -= 6;
                    floory -= 6;
                    for (int O = 1; O < 16; O++)
                    {
                        Enemy[O].Y -= 6;
                    }
                }
            }

            if (x < -1000)
            {
                if (y >= 716)
                {
                    y -= 6;
                    y2 -= 6;
                    floory -= 6;
                    for (int O = 1; O < 16; O++)
                    {
                        Enemy[O].Y -= 6;
                    }
                }
                if (py >= 381 && y == 320)
                {
                    py = 381;
                    y += 0;
                    y2 += 0;
                    floory += 0;
                    for (int O = 1; O < 16; O++)
                    {
                        Enemy[O].Y += 0;
                    }
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
                    y -= 6;
                    y2 -= 6;
                    floory -= 6;
                    for (int O = 1; O < 16; O++)
                    {
                        Enemy[O].Y -= 6;
                    }
                }
            }
            if (y == 0)
            {

            }

            if (y == 334 && py == 395)// fixes a bug where the floor would move if you hit your head on the roof, which often lead to clipping thorugh the floor.
            {
                y -= 6;
                y2 -= 6;
                floory -= 6;
                for (int O = 1; O < 16; O++)
                {
                    Enemy[O].Y -= 6 ;
                }
                 
            

            }
            else
            {
                y += 0;
                y2 += 0;
                floory += 0;
                for (int O = 1; O < 16; O++)
                {
                    Enemy[O].Y +=0;
                }
            }

        }



        private void TmrPlayer_Tick(object sender, EventArgs e)
        {
            //declaring player and enemy rectangles

          
            areaCharacter = new Rectangle(px, py, 50, 50);
            LSide = new Rectangle(px, py, 5, 50);//Player Rectangle
            TSide = new Rectangle(px + 5, py, 50, 5);//Player Rectangle
            BSide = new Rectangle(px + 5, py + 45, 50, 5);//Player Rectangle
            RSide = new Rectangle(px + 45, py, 5, 50);//Player Rectangle
           
            keyrectangle = new Rectangle(x2 + 750, y2 - 100, 50, 50);//key
            lockeddoor = new Rectangle(x3, y2 + 250, 50, 60);//door
            doorL = new Rectangle(x3, y2 + 250, 5, 70);//door's collision box
            helicopter = new Rectangle(x3 + 50, y2 - 320, 100,50);//finish line;

            label2.Text = "Health: " + lives;
          
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
      

            Ladder[1] = new Rectangle(x2 + 690, y2 + 130, 50, 180);// Ladder 
            Ladder[2] = new Rectangle(x2 + 60, y2 - 50, 50, 180);
            Ladder[3] = new Rectangle(x3 + 690, y2 + 120, 50, 190);
            Ladder[4] = new Rectangle(x3 + 410, y2 - 70, 50, 190);
            Ladder[5] = new Rectangle(x3 + 690, y2 - 270, 50, 210);
            //enemies

           

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
                if (areaCharacter.IntersectsWith(Enemy[1]) && TmrInvincibility.Enabled == false && ehp > 0)
                {
                    TmrInvincibility.Enabled = true;
                    lives -= 1;
                }
                if (areaCharacter.IntersectsWith(Enemy[2]) && TmrInvincibility.Enabled == false && ehp2 > 0)
                {
                    TmrInvincibility.Enabled = true;
                    lives -= 1;
                }
                if (areaCharacter.IntersectsWith(Enemy[3]) && TmrInvincibility.Enabled == false && ehp3 > 0)
                {
                    TmrInvincibility.Enabled = true;
                    lives -= 1;
                }
                if (areaCharacter.IntersectsWith(Enemy[4]) && TmrInvincibility.Enabled == false && ehp4 > 0)
                {
                    TmrInvincibility.Enabled = true;
                    lives -= 1;
                }
                if (areaCharacter.IntersectsWith(Enemy[5]) && TmrInvincibility.Enabled == false && ehp5 > 0)
                {
                    TmrInvincibility.Enabled = true;
                    lives -= 1;
                }
                if (areaCharacter.IntersectsWith(Enemy[6]) && TmrInvincibility.Enabled == false && ehp7 > 0)
                {
                    TmrInvincibility.Enabled = true;
                    lives -= 1;
                }
                //enemy logic

                if (Enemy[O].X <= 700)// if an enemy has an x value of less than 
                {
                    if (py - 10 <= Enemy[O].Y && py + 50 >= Enemy[O].Y)// if an enemy is within 10 of the players y value
                    {
                        if (px <= Enemy[O].X)// if the enenmy is behind the player
                        {
                            Enemy[O].X -= 2;
                        }
                        if (px >= Enemy[O].X)// if the enenmy is in front of the player
                        {
                            Enemy[O].X += 2;
                        }
                    }
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
                Enemy[1].X += espeedl;
                Enemy[2].X += espeedl;
                Enemy[3].X += espeedl;
                Enemy[4].X += espeedl;
                Enemy[5].X += espeedl;
                Enemy[6].X += espeedl;
            }
            if (right) // if right arrow pressed
            {
                px += pspeedr;
                x -= espeedr;
                x2 -= espeedr;
                x3 -= espeedr;
                Enemy[1].X -= espeedr;
                Enemy[2].X -= espeedr;
                Enemy[3].X -= espeedr;
                Enemy[4].X -= espeedr;
                Enemy[5].X -= espeedr;
                Enemy[6].X -= espeedr;
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
                if (areaCharacter.IntersectsWith(Ladder[O]))
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
                //enemy hp being taken away when a bullet is shot
                if (bulletarrayl[O].IntersectsWith(Enemy[1]))
                {
                    ehp -= 1;
                    bulletarrayl[O] = Rectangle.Empty;
                }
                if (bulletarrayl[O].IntersectsWith(Enemy[2]))
                {
                    ehp2 -= 1;
                    bulletarrayl[O] = Rectangle.Empty;
                }
                if (bulletarrayl[O].IntersectsWith(Enemy[3]))
                {
                    ehp3 -= 1;
                    bulletarrayl[O] = Rectangle.Empty;
                }
                if (bulletarrayl[O].IntersectsWith(Enemy[4]))
                {
                    ehp4 -= 1;
                    bulletarrayl[O] = Rectangle.Empty;
                }
                if (bulletarrayl[O].IntersectsWith(Enemy[5]))
                {
                    ehp5 -= 1;
                    bulletarrayl[O] = Rectangle.Empty;
                }
                if (bulletarrayl[O].IntersectsWith(Enemy[6]))
                {
                    ehp7 -= 1;
                    bulletarrayl[O] = Rectangle.Empty;
                }
                if (bulletarrayr[O].IntersectsWith(Enemy[1]))
                {
                    ehp -= 1;
                    bulletarrayr[O] = Rectangle.Empty;
                }
                if (bulletarrayr[O].IntersectsWith(Enemy[2]))
                {
                    ehp2 -= 1;
                    bulletarrayr[O] = Rectangle.Empty;
                }
                if (bulletarrayr[O].IntersectsWith(Enemy[3]))
                {
                    ehp3 -= 1;
                    bulletarrayr[O] = Rectangle.Empty;
                }
                if (bulletarrayr[O].IntersectsWith(Enemy[4]))
                {
                    ehp4 -= 1;
                    bulletarrayr[O] = Rectangle.Empty;
                }
                if (bulletarrayr[O].IntersectsWith(Enemy[5]))
                {
                    ehp5 -= 1;
                    bulletarrayr[O] = Rectangle.Empty;
                }
                if (bulletarrayr[O].IntersectsWith(Enemy[6]))
                {
                    ehp7 -= 1;
                    bulletarrayr[O] = Rectangle.Empty;
                }
            }

            //deleting the enemies once their hp hits 0
            if (ehp <= 0)
            {
                Enemy[1] = Rectangle.Empty;
                Enemy[1].Y = -2000;// moving them down to stop collision
            }
            if (ehp2 <= 0)
            {
                Enemy[2] = Rectangle.Empty;
                Enemy[2].Y = -2000;
            }
            if (ehp3 <= 0)
            {
                Enemy[3] = Rectangle.Empty;
                Enemy[3].Y = -2000;
            }
            if (ehp4 <= 0)
            {
                Enemy[4] = Rectangle.Empty;
                Enemy[4].Y = -2000;
            }
            if (ehp5 <= 0)
            {
                Enemy[5] = Rectangle.Empty;
                Enemy[5].Y = -2000;
            }
            if (ehp7 <= 0)
            {
                Enemy[6] = Rectangle.Empty;
                Enemy[6].Y = -2000;
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
            //gravity
            if (up == true & jump == true)
            {
                gravity = 15;
                jump = false;
            }
            else if (!BSide.IntersectsWith(areaT1) && gravity >= -15)
            {
                gravity = gravity - 1;
            }



            if (lives == 0 )
            {
                gameOver();
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
       
            for (int O = 1; O < 16; O++)
            {
                g.DrawImage(wall, Object[O]);

                g.DrawImage(ladder, Ladder[O]);

                g.DrawImage(enemy, Enemy[O]);

            }
            e.Graphics.FillRectangle(Brushes.Gray, helicopter);
            g.DrawImage(key, keyrectangle);
            e.Graphics.FillRectangle(Brushes.Red, lockeddoor);
            e.Graphics.FillRectangle(Brushes.Red, lockeddoor);

          

            for (int O = 0; O <= 15; O++)
            {
                e.Graphics.FillRectangle(Brushes.Black, bulletarrayl[O]);
                e.Graphics.FillRectangle(Brushes.Black, bulletarrayr[O]);

            }

            if (lastkeypressed == "right")
            {
                g.DrawImage(characterright, areaCharacter);
            }
            if (lastkeypressed == "left")
            {
                g.DrawImage(characterleft, areaCharacter);
            }
        }
    }
}