using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Media;


namespace Elemont.Gui.Game
{
    public partial class Map1 : Form
    {
        public Map1()
        {
            InitializeComponent();
            ControlExtension.Draggable(pictureBox3, true);
            pictureBox5.Size = new Size(2 * vi + pictureBox3.Width, 2 * vi + pictureBox3.Height);
            pictureBox5.Top = pictureBox3.Top - vi;
            pictureBox5.Left = pictureBox3.Left - vi;
            foreach (Control c1 in this.Controls)
            {
                if (!pictureBox3.Equals(c1)&&!((string)c1.Tag=="frame"))
                {
                    c1.Visible = false;
                    c1.Parent = this;
                }
            }
            //pictureBox1.Parent = pictureBox10;

            visible();
            this.ClientSize = new Size(600, 600);
            // this.FormBorderStyle = FormBorderStyle.None;
            // fill the screen
            // this.Bounds = Screen.PrimaryScreen.Bounds;
            pictureBox6.Width = pictureBox10.Width;
            pictureBox8.Width = pictureBox10.Width;
            pictureBox7.Height = pictureBox10.Height;
            pictureBox9.Height = pictureBox10.Height;
            pictureBox6.Location = pictureBox10.Location;
            pictureBox7.Location = pictureBox10.Location;
            pictureBox9.Top = pictureBox6.Top;
            pictureBox9.Left = pictureBox10.Left + pictureBox10.Width - pictureBox9.Width;
            pictureBox8.Left = pictureBox6.Left;
            pictureBox8.Top = pictureBox10.Top + pictureBox10.Height - pictureBox8.Height;
        }

        public bool touch()
        {
            foreach (Control c1 in this.Controls)
            {
                if (!pictureBox3.Equals(c1) && !pictureBox5.Equals(c1) && !pictureBox10.Equals(c1) && pictureBox3.Bounds.IntersectsWith(c1.Bounds) && c1 is PictureBox)
                {
                    return true;
                }
            }
            return false;
        }
        public void visible()
        {
            foreach (Control c1 in this.Controls)
            {
                if (!pictureBox5.Equals(c1) && pictureBox5.Bounds.IntersectsWith(c1.Bounds) && c1 is PictureBox)
                {
                    c1.Visible = true;
                }
            }
        }
        int sp = 5;
        int vi = 30;
        private void Map1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!move)
            {
                int x = pictureBox3.Location.X;
                int y = pictureBox3.Location.Y;
                int x1 = x, y1 = y, x2 = x, y2 = y;
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    move = true;
                    timer1.Start();
                    x2 += sp;
                    if (!(pictureBox3.Right >= this.Width * 2 / 3 && !touch()))
                    {
                        x1 += sp;
                    }
                }
                else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    move = true;
                    timer1.Start();
                    x2 -= sp;
                    if (!(pictureBox3.Left <= this.Width * 1 / 3 && !touch()))
                    {
                        x1 -= sp;
                    }
                }
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                {
                    move = true;
                    timer1.Start();
                    y2 -= sp;
                    if (!(pictureBox3.Top <= this.Height * 1 / 3 && !touch()))
                    {
                        y1 -= sp;
                    }
                }
                else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                    move = true;
                    timer1.Start();
                    y2 += sp;
                    if (!(this.Height * 2 / 3 <= pictureBox3.Bottom && !touch()))
                    {
                        y1 += sp;
                    }
                }
                pictureBox3.Location = new Point(x1, y1);
                pictureBox5.Location = new Point(x1 - vi, y1 - vi);
                foreach (Control c1 in this.Controls)
                {
                    if (!pictureBox3.Equals(c1) && !pictureBox5.Equals(c1))
                    {
                        c1.Top += y - y2;
                        c1.Left += x - x2;
                    }
                }
                if (touch())
                {
                    pictureBox3.Location = new Point(x, y);
                    pictureBox5.Location = new Point(x - vi, y - vi);
                    foreach (Control c1 in this.Controls)
                    {
                        if (!pictureBox3.Equals(c1) && !pictureBox5.Equals(c1))
                        {
                            c1.Top -= y - y2;
                            c1.Left -= x - x2;
                        }
                    }
                }
                
                visible();
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
        bool move;
        private void timer1_Tick(object sender, EventArgs e)
        {
            move = false;
        }
        
        private void Map1_SizeChanged(object sender, EventArgs e)
        {
            int x = pictureBox3.Top - this.ClientSize.Height / 2;
            int y = pictureBox3.Left - this.ClientSize.Width / 2;
            foreach (Control c1 in this.Controls)
            {
                c1.Top -= x;
                c1.Left -= y;
            }

        }


 
    }

}
