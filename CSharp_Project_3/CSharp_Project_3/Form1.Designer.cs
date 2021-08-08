
namespace CSharp_Project_3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TmrPlayer = new System.Windows.Forms.Timer(this.components);
            this.PnlGame = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSavename = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.btnCriminal = new System.Windows.Forms.Button();
            this.btnBurglar = new System.Windows.Forms.Button();
            this.btnTheif = new System.Windows.Forms.Button();
            this.btnDifficulty = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TmrCollision = new System.Windows.Forms.Timer(this.components);
            this.tmrBulletdelay = new System.Windows.Forms.Timer(this.components);
            this.tmrCountdown = new System.Windows.Forms.Timer(this.components);
            this.TmrInvincibility = new System.Windows.Forms.Timer(this.components);
            this.PnlGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // TmrPlayer
            // 
            this.TmrPlayer.Enabled = true;
            this.TmrPlayer.Interval = 4;
            this.TmrPlayer.Tick += new System.EventHandler(this.TmrPlayer_Tick);
            // 
            // PnlGame
            // 
            this.PnlGame.Controls.Add(this.label8);
            this.PnlGame.Controls.Add(this.label7);
            this.PnlGame.Controls.Add(this.label6);
            this.PnlGame.Controls.Add(this.label5);
            this.PnlGame.Controls.Add(this.label4);
            this.PnlGame.Controls.Add(this.btnHelp);
            this.PnlGame.Controls.Add(this.btnSavename);
            this.PnlGame.Controls.Add(this.txtName);
            this.PnlGame.Controls.Add(this.label3);
            this.PnlGame.Controls.Add(this.BtnBack);
            this.PnlGame.Controls.Add(this.btnCriminal);
            this.PnlGame.Controls.Add(this.btnBurglar);
            this.PnlGame.Controls.Add(this.btnTheif);
            this.PnlGame.Controls.Add(this.btnDifficulty);
            this.PnlGame.Controls.Add(this.btnStart);
            this.PnlGame.Controls.Add(this.label2);
            this.PnlGame.Controls.Add(this.label1);
            this.PnlGame.Location = new System.Drawing.Point(-2, -3);
            this.PnlGame.Name = "PnlGame";
            this.PnlGame.Size = new System.Drawing.Size(804, 454);
            this.PnlGame.TabIndex = 0;
            this.PnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlGame_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(536, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "30 Seconds";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(367, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "45 Seconds";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "60 Seconds";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 60);
            this.label5.TabIndex = 12;
            this.label5.Text = "Left and Right Arrow Keys to Move. \r\nUp Arrow Key to Jump, Spacebar to Shoot. \r\nD" +
    "efeat the Enemies and Make it to the \r\n\"Helicopter\" (a grey box) to Win!\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1730, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(699, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Left and Right Arrow Keys to move, Up Arrow to JumpSpacebar to shoot, get past th" +
    "e enemies and make it to the \'helicopter\' to win";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(709, 417);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.Text = "Instuctions";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnSavename
            // 
            this.btnSavename.Location = new System.Drawing.Point(120, 14);
            this.btnSavename.Name = "btnSavename";
            this.btnSavename.Size = new System.Drawing.Size(75, 23);
            this.btnSavename.TabIndex = 9;
            this.btnSavename.Text = "Save";
            this.btnSavename.UseVisualStyleBackColor = true;
            this.btnSavename.Click += new System.EventHandler(this.btnSavename_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(14, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 23);
            this.txtName.TabIndex = 8;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(258, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 86);
            this.label3.TabIndex = 7;
            this.label3.Text = "You Win!";
            this.label3.Visible = false;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Enabled = false;
            this.BtnBack.Location = new System.Drawing.Point(330, 308);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(140, 50);
            this.BtnBack.TabIndex = 6;
            this.BtnBack.Text = "Back to Menu";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Visible = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnCriminal
            // 
            this.btnCriminal.Location = new System.Drawing.Point(489, 308);
            this.btnCriminal.Name = "btnCriminal";
            this.btnCriminal.Size = new System.Drawing.Size(140, 50);
            this.btnCriminal.TabIndex = 5;
            this.btnCriminal.Text = "Criminal";
            this.btnCriminal.UseVisualStyleBackColor = true;
            this.btnCriminal.Click += new System.EventHandler(this.btnCriminal_Click);
            // 
            // btnBurglar
            // 
            this.btnBurglar.Location = new System.Drawing.Point(330, 308);
            this.btnBurglar.Name = "btnBurglar";
            this.btnBurglar.Size = new System.Drawing.Size(140, 50);
            this.btnBurglar.TabIndex = 4;
            this.btnBurglar.Text = "Burglar";
            this.btnBurglar.UseVisualStyleBackColor = true;
            this.btnBurglar.Click += new System.EventHandler(this.btnBurglar_Click);
            // 
            // btnTheif
            // 
            this.btnTheif.Location = new System.Drawing.Point(171, 308);
            this.btnTheif.Name = "btnTheif";
            this.btnTheif.Size = new System.Drawing.Size(140, 50);
            this.btnTheif.TabIndex = 3;
            this.btnTheif.Text = "Thief";
            this.btnTheif.UseVisualStyleBackColor = true;
            this.btnTheif.Click += new System.EventHandler(this.btnTheif_Click);
            // 
            // btnDifficulty
            // 
            this.btnDifficulty.Location = new System.Drawing.Point(330, 391);
            this.btnDifficulty.Name = "btnDifficulty";
            this.btnDifficulty.Size = new System.Drawing.Size(140, 50);
            this.btnDifficulty.TabIndex = 2;
            this.btnDifficulty.Text = "Select Difficulty!";
            this.btnDifficulty.UseVisualStyleBackColor = true;
            this.btnDifficulty.Click += new System.EventHandler(this.btnDifficulty_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(330, 308);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(140, 50);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Game!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 0;
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(682, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TmrCollision
            // 
            this.TmrCollision.Enabled = true;
            this.TmrCollision.Interval = 1;
            this.TmrCollision.Tick += new System.EventHandler(this.TmrCollision_Tick);
            // 
            // tmrBulletdelay
            // 
            this.tmrBulletdelay.Enabled = true;
            this.tmrBulletdelay.Interval = 600;
            this.tmrBulletdelay.Tick += new System.EventHandler(this.tmrBulletdelay_Tick);
            // 
            // tmrCountdown
            // 
            this.tmrCountdown.Interval = 1000;
            this.tmrCountdown.Tick += new System.EventHandler(this.tmrCountdown_Tick);
            // 
            // TmrInvincibility
            // 
            this.TmrInvincibility.Interval = 1000;
            this.TmrInvincibility.Tick += new System.EventHandler(this.TmrInvincibility_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PnlGame);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PnlGame.ResumeLayout(false);
            this.PnlGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlGame;
        private System.Windows.Forms.Timer TmrPlayer;
        private System.Windows.Forms.Timer TmrCollision;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmrBulletdelay;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDifficulty;
        private System.Windows.Forms.Button btnCriminal;
        private System.Windows.Forms.Button btnBurglar;
        private System.Windows.Forms.Button btnTheif;
        private System.Windows.Forms.Timer tmrCountdown;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer TmrInvincibility;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSavename;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

