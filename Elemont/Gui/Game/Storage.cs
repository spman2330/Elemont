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
        public Storage( )
        {
            InitializeComponent();
           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 50; i++)
            {
                PictureBox pb = new PictureBox();
                pb.Size = new Size(120, 80);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Tag = i.ToString();
                pb.BackColor = Color.Blue;
                pb.Click += new System.EventHandler(this.pictureBox_Click);
                store.Controls.Add(pb);
                Label lbl = new Label();
                
               
            }
        }
  

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        string poke;
        bool selected;
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            
            string s = (string)pb.Tag;
            richTextBox1.Text = s;
            selected = true;
            poke = s;
        }

        private void store_Paint(object sender, PaintEventArgs e)
        {
            selected = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(poke != "" && selected)
            {
                foreach (Control c1 in store.Controls)
                {
                    if ((string)c1.Tag == poke)
                    {

                        store.Controls.Remove(c1);

                    }

                }

            }    
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Control c1 in store.Controls)
            {
                if ((string)c1.Tag == poke)
                {

                    c1.BackColor = Color.White;

                }
                else
                {
                    c1.BackColor = Color.Blue;
                }    

            }
        }
    }
}
