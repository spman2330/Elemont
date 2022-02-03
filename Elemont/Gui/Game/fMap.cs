using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Gui.Game;
namespace Elemont.Gui.Game
{
    public partial class fMap : Form
    {
        public fMap()
        {
            InitializeComponent();

        }

        private void fMap_Load(object sender, EventArgs e)
        {
            pictureBox1.AllowDrop = true;

            numericUpDown3.Value = pictureBox1.Width;
            numericUpDown4.Value = pictureBox1.Height;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            x = (int)numericUpDown2.Value;            
        }
        int x;
        int y;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            y = (int)numericUpDown1.Value;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control c1 in flowLayoutPanel1.Controls)
            {
                pictureBox1.Controls.Add(c1);
                c1.Location = new Point(x,y);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Control c1 in flowLayoutPanel1.Controls)
            {
                flowLayoutPanel1.Controls.Remove(c1);
            }    
            PictureBox pb = new PictureBox();
            pb.BackColor = Color.Blue;
            pb.Parent = flowLayoutPanel1;
            pb.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
        }
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            numericUpDown1.Value = pb.Location.X;
            numericUpDown2.Value = pb.Location.Y;
            numericUpDown2.Value = pb.Width;
            numericUpDown2.Value = pb.Height;
            flowLayoutPanel1.Controls.Add(pb);
        }
        int w;
        int h;
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = numericUpDown3.Value;
            pictureBox1.Width = (int)numericUpDown3.Value;
        }
        public PictureBox Clone(PictureBox pb)
        {
            PictureBox clone = new PictureBox();
            clone.Size = pb.Size;
            clone.Tag = pb.Tag;
            clone.Image = pb.Image;
            clone.BackColor = pb.BackColor;
            return clone;
        }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Maximum = numericUpDown4.Value;
            pictureBox1.Height = (int)numericUpDown4.Value;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            w = (int)numericUpDown5.Value;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            h =(int)numericUpDown6.Value;
        }
    }
}

