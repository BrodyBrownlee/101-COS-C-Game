
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
            this.label2.Location = new System.Drawing.Point(638, 14);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PnlGame);
            this.DoubleBuffered = true;
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
    }
}

