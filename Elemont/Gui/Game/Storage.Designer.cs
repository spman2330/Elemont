
namespace Elemont.Gui.Game
{
    partial class Storage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Storage));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.bttnpnl = new System.Windows.Forms.FlowLayoutPanel();
            this.selectpkm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.namebttn = new System.Windows.Forms.Button();
            this.skillbttn = new System.Windows.Forms.Button();
            this.deletebttn = new System.Windows.Forms.Button();
            this.store = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.exitbttn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pkname = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.bttnpnl.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(139, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(748, 463);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.bttnpnl);
            this.tabPage3.Controls.Add(this.store);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(740, 430);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Elemont";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // bttnpnl
            // 
            this.bttnpnl.Controls.Add(this.selectpkm);
            this.bttnpnl.Controls.Add(this.button1);
            this.bttnpnl.Controls.Add(this.namebttn);
            this.bttnpnl.Controls.Add(this.skillbttn);
            this.bttnpnl.Controls.Add(this.deletebttn);
            this.bttnpnl.Location = new System.Drawing.Point(6, 78);
            this.bttnpnl.Name = "bttnpnl";
            this.bttnpnl.Size = new System.Drawing.Size(115, 281);
            this.bttnpnl.TabIndex = 0;
            // 
            // selectpkm
            // 
            this.selectpkm.Location = new System.Drawing.Point(3, 3);
            this.selectpkm.Name = "selectpkm";
            this.selectpkm.Size = new System.Drawing.Size(108, 49);
            this.selectpkm.TabIndex = 17;
            this.selectpkm.Text = "Select";
            this.selectpkm.UseVisualStyleBackColor = true;
            this.selectpkm.Click += new System.EventHandler(this.selectpkm_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 48);
            this.button1.TabIndex = 10;
            this.button1.Text = "View";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // namebttn
            // 
            this.namebttn.Location = new System.Drawing.Point(3, 112);
            this.namebttn.Name = "namebttn";
            this.namebttn.Size = new System.Drawing.Size(108, 48);
            this.namebttn.TabIndex = 12;
            this.namebttn.Text = "Change name";
            this.namebttn.UseVisualStyleBackColor = true;
            this.namebttn.Click += new System.EventHandler(this.button3_Click);
            // 
            // skillbttn
            // 
            this.skillbttn.Location = new System.Drawing.Point(3, 166);
            this.skillbttn.Name = "skillbttn";
            this.skillbttn.Size = new System.Drawing.Size(108, 48);
            this.skillbttn.TabIndex = 13;
            this.skillbttn.Text = "Change skill";
            this.skillbttn.UseVisualStyleBackColor = true;
            this.skillbttn.Click += new System.EventHandler(this.button4_Click);
            // 
            // deletebttn
            // 
            this.deletebttn.Location = new System.Drawing.Point(3, 220);
            this.deletebttn.Name = "deletebttn";
            this.deletebttn.Size = new System.Drawing.Size(108, 48);
            this.deletebttn.TabIndex = 11;
            this.deletebttn.Text = "Delete";
            this.deletebttn.UseVisualStyleBackColor = true;
            this.deletebttn.Click += new System.EventHandler(this.button2_Click);
            // 
            // store
            // 
            this.store.AutoScroll = true;
            this.store.Location = new System.Drawing.Point(124, 3);
            this.store.Name = "store";
            this.store.Size = new System.Drawing.Size(615, 431);
            this.store.TabIndex = 16;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.numericUpDown2);
            this.tabPage4.Controls.Add(this.numericUpDown1);
            this.tabPage4.Controls.Add(this.pictureBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(740, 430);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Item";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(101, 191);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 29);
            this.button7.TabIndex = 6;
            this.button7.Text = "Mua";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(101, 110);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 29);
            this.button5.TabIndex = 5;
            this.button5.Text = "Xoá";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(477, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(78, 158);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(150, 27);
            this.numericUpDown2.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(78, 68);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(150, 27);
            this.numericUpDown1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(383, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(261, 213);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.pictureBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(740, 430);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Trainer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(486, 367);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(94, 29);
            this.button8.TabIndex = 2;
            this.button8.Text = "Đổi tên";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(422, 319);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 27);
            this.textBox1.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Location = new System.Drawing.Point(374, 33);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(329, 258);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.richTextBox1.Location = new System.Drawing.Point(3, 160);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(130, 335);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // exitbttn
            // 
            this.exitbttn.Location = new System.Drawing.Point(788, 12);
            this.exitbttn.Name = "exitbttn";
            this.exitbttn.Size = new System.Drawing.Size(94, 29);
            this.exitbttn.TabIndex = 4;
            this.exitbttn.Text = "Exit";
            this.exitbttn.UseVisualStyleBackColor = true;
            this.exitbttn.Click += new System.EventHandler(this.button6_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pkname
            // 
            this.pkname.Location = new System.Drawing.Point(3, 127);
            this.pkname.Name = "pkname";
            this.pkname.Size = new System.Drawing.Size(130, 27);
            this.pkname.TabIndex = 5;
            // 
            // Storage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(894, 507);
            this.Controls.Add(this.pkname);
            this.Controls.Add(this.exitbttn);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Storage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Storage";
            this.Load += new System.EventHandler(this.Storage_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.bttnpnl.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button exitbttn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button skillbttn;
        private System.Windows.Forms.Button namebttn;
        private System.Windows.Forms.Button deletebttn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel store;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button selectpkm;
        private System.Windows.Forms.FlowLayoutPanel bttnpnl;
        private System.Windows.Forms.TextBox pkname;
    }
}