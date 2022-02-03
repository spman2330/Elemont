﻿using System;
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
            this.Bounds = Screen.PrimaryScreen.Bounds;
            numericUpDown3.Value = pictureBox1.Width;
            numericUpDown4.Value = pictureBox1.Height;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            x = (int)numericUpDown1.Value;
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            y = (int)numericUpDown2.Value;            
        }
        int x;
        int y;
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
            if (pictureBox2.Image != null && numericUpDown5.Value*numericUpDown6.Value !=0)
            {     
                foreach (Control c1 in flowLayoutPanel1.Controls)
            {
                flowLayoutPanel1.Controls.Remove(c1);
            }                   
                PictureBox pb = new PictureBox();
                pb.BackColor = Color.Blue;
                pb.Parent = flowLayoutPanel1;
                pb.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
                pb.Click += new System.EventHandler(this.pictureBox_Click);
                pb.Size = new Size((int)numericUpDown5.Value, (int)numericUpDown6.Value);
                pb.Image = pictureBox2.Image;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                ControlExtension.Draggable(pb, true);
            }
            else
            {
                MessageBox.Show("Please check all properties", "",MessageBoxButtons.OK);
            }
        }
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (!flowLayoutPanel1.HasChildren)
            {
                PictureBox pb = sender as PictureBox;
                numericUpDown1.Value = pb.Location.X;
                numericUpDown2.Value = pb.Location.Y;
                numericUpDown5.Value = pb.Width;
                numericUpDown6.Value = pb.Height;
                flowLayoutPanel1.Controls.Add(pb);
            }
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            numericUpDown1.Value = pb.Location.X;
            numericUpDown2.Value = pb.Location.Y;
            numericUpDown5.Value = pb.Width;
            numericUpDown6.Value = pb.Height;

        }
      
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = numericUpDown3.Value;
            pictureBox1.Width = (int)numericUpDown3.Value;
        }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Maximum = numericUpDown4.Value;
            pictureBox1.Height = (int)numericUpDown4.Value;
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
       

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control c1 in flowLayoutPanel1.Controls)
            {
                c1.Width = (int)numericUpDown5.Value;
            }
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control c1 in flowLayoutPanel1.Controls)
            {
                c1.Height = (int)numericUpDown6.Value;
            }
        }

        private void bimg_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBox3.Image = new Bitmap(open.FileName);
                    pictureBox1.Image = new Bitmap(open.FileName);
                }
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();             
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {                   
                    pictureBox2.Image = new Bitmap(open.FileName);
                }
            }
            catch
            {
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Map Created and Saved", "", MessageBoxButtons.OK);
        }
    }
}

