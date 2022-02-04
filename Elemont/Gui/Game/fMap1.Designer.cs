
namespace Elemont.Gui.Game
{
    partial class fMap1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMap1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.vision = new System.Windows.Forms.PictureBox();
            this.shadow = new System.Windows.Forms.PictureBox();
            this.trainer = new System.Windows.Forms.PictureBox();
            this.background = new System.Windows.Forms.PictureBox();
            this.back = new System.Windows.Forms.PictureBox();
            this.bag = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shadow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox6.Location = new System.Drawing.Point(39, -2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(1321, 15);
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Tag = "frame";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox7.Location = new System.Drawing.Point(15, 36);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(15, 661);
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Tag = "frame";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox8.Location = new System.Drawing.Point(15, 706);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(1231, 15);
            this.pictureBox8.TabIndex = 7;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Tag = "frame";
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox9.Location = new System.Drawing.Point(1312, 44);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(15, 597);
            this.pictureBox9.TabIndex = 8;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Tag = "frame";
            // 
            // vision
            // 
            this.vision.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.vision.Location = new System.Drawing.Point(39, 177);
            this.vision.Name = "vision";
            this.vision.Size = new System.Drawing.Size(111, 101);
            this.vision.TabIndex = 4;
            this.vision.TabStop = false;
            this.vision.Tag = "Wall";
            // 
            // shadow
            // 
            this.shadow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.shadow.Location = new System.Drawing.Point(46, 302);
            this.shadow.Name = "shadow";
            this.shadow.Size = new System.Drawing.Size(53, 45);
            this.shadow.TabIndex = 1;
            this.shadow.TabStop = false;
            // 
            // trainer
            // 
            this.trainer.BackColor = System.Drawing.Color.White;
            this.trainer.Location = new System.Drawing.Point(669, 608);
            this.trainer.Name = "trainer";
            this.trainer.Size = new System.Drawing.Size(53, 45);
            this.trainer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.trainer.TabIndex = 2;
            this.trainer.TabStop = false;
            this.trainer.Click += new System.EventHandler(this.trainer_Click);
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.background.Location = new System.Drawing.Point(69, -15);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(1291, 702);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.background.TabIndex = 9;
            this.background.TabStop = false;
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.White;
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.Location = new System.Drawing.Point(46, 19);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(70, 42);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back.TabIndex = 10;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            this.back.MouseEnter += new System.EventHandler(this.back_MouseEnter);
            this.back.MouseLeave += new System.EventHandler(this.back_MouseLeave);
            // 
            // bag
            // 
            this.bag.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bag.Image = ((System.Drawing.Image)(resources.GetObject("bag.Image")));
            this.bag.Location = new System.Drawing.Point(46, 80);
            this.bag.Name = "bag";
            this.bag.Size = new System.Drawing.Size(70, 62);
            this.bag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bag.TabIndex = 11;
            this.bag.TabStop = false;
            this.bag.Click += new System.EventHandler(this.bag_Click);
            this.bag.MouseEnter += new System.EventHandler(this.bag_MouseEnter);
            this.bag.MouseLeave += new System.EventHandler(this.bag_MouseLeave);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(597, 436);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 62);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "pokemon";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(370, 526);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(125, 62);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "pokemon";
            // 
            // fMap1
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1344, 749);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.trainer);
            this.Controls.Add(this.bag);
            this.Controls.Add(this.back);
            this.Controls.Add(this.shadow);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.vision);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fMap1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Map1_Load);
            this.SizeChanged += new System.EventHandler(this.Map1_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Map1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shadow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox vision;
    
        private System.Windows.Forms.PictureBox trainer;
        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.PictureBox bag;
        private System.Windows.Forms.PictureBox shadow;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}