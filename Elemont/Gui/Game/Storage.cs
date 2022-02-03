using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Dto;


namespace Elemont.Gui.Game
{
    public partial class Storage : Form
    {
        public Storage instance;
        public Storage( )
        {
            InitializeComponent();
            instance = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c1 in store.Controls)
            {
                if (c1.BackColor==Color.Blue)
                { 
                    richTextBox1.Text = (string)c1.Tag;
                    break;
                }
                
            }
        }
  

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {           
        }
       
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            string s = (string)pb.Tag;
            if (pb.Parent.BackColor == Color.White)
            {
                pb.Parent.BackColor = Color.Blue;                                
            }
            else
            {              
                pb.Parent.BackColor = Color.White;
                richTextBox1.Clear();              
            }
            
        }
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            //string s = (string)pb.Tag;
            if (pb.Parent.BackColor == Color.White)
            {
                pb.Parent.BackColor = Color.Blue;
                richTextBox1.Text = (string)pb.Tag;
            }
            

        }

        private void store_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            {
                bool sl = true;
                while (sl)
                {
                    foreach (Control c1 in store.Controls)
                    {
                        if (c1.BackColor == Color.Blue)
                        {
                            store.Controls.Remove(c1);
                        }
                    }
                    sl = false;
                    foreach (Control c1 in store.Controls)
                    {
                        if (c1.BackColor == Color.Blue)
                        {
                            sl = true;
                            break;
                        }
                    }
                }

            }    
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Storage_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 50; i++)
            {
                GroupBox gb = new GroupBox();
                gb.Size = new Size(140, 115);
                PictureBox pb = new PictureBox();
                pb.Size = new Size(125, 90);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Tag = i.ToString();
                pb.BackColor = Color.Green;
                pb.Click += new System.EventHandler(this.pictureBox_Click);
                pb.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
                pb.Location = new Point(5, 20);
                gb.Controls.Add(pb);
                gb.Text = i.ToString();
                gb.Tag = "test";
                gb.BackColor = Color.White;
                store.Controls.Add(gb);
            }
            selectpkm.Visible = false;

        }
        public string select;

        public void hideandseek()
        {
            namebttn.Visible = false;                     
            skillbttn.Visible = false;
            deletebttn.Visible = false;
            selectpkm.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void selectpkm_Click(object sender, EventArgs e)
        {
            int t=0;
            foreach(Control c1 in store.Controls)
            {
                if(c1.BackColor == Color.Blue)
                {
                    t++;
                }    
            }
            if(t==0||t>1)
            {             
                MessageBox.Show("Vui lòng chọn 1 Elemont", "", MessageBoxButtons.OK);
            }    
            if(t==1)
            {
                foreach (Control c1 in store.Controls)
                {
                    if (c1.BackColor == Color.Blue)
                    {
                        fMap1.instance.str1 = (string)c1.Tag;
                    }
                }

            }    
        }
    }
}
