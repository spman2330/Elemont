using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Media;
using Elemont.Gui.Game;

namespace Elemont.Gui.Game
{
    public partial class Map1 : Form
    {
        public Map1()
        {
            InitializeComponent();
            //ControlExtension.Draggable(trainer, true);
            
        }

        public bool touch()
        {
            foreach (Control c1 in this.Controls)
            {                               
                    if ((trainer.Bounds.IntersectsWith(c1.Bounds) || shadow.Bounds.IntersectsWith(c1.Bounds)) && !trainer.Equals(c1) && !vision.Equals(c1) && !background.Equals(c1) && !shadow.Equals(c1))
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
                if (!vision.Equals(c1) && vision.Bounds.IntersectsWith(c1.Bounds) && !shadow.Equals(c1))
                {
                    c1.Visible = true;
                }
            }
        }
        int sp = 4;
        int vi = 30;
        public void Map1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (!move)
            {
                timer1.Start();
                int x = trainer.Location.X;
                int y = trainer.Location.Y;
                int x1 = x, y1 = y, x2 = x, y2 = y;
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    move = true;
                    
                    x2 += sp;
                    if (!(trainer.Right >= this.Width * 3 / 4 && !touch()))
                    {
                        x1 += sp; 
                        x2 -= sp;
                    }
                }
                else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    move = true;
                   
                    x2 -= sp;
                    if (!(trainer.Left <= this.Width * 1 / 4 && !touch()))
                    {
                        x1 -= sp;
                        x2 += sp;
                    }
                }
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                {
                    move = true;
                   
                    y2 -= sp;
                    if (!(trainer.Top <= this.Height * 1 / 4 && !touch()))
                    {
                        y1 -= sp;
                        y2 += sp;
                    }
                }
                else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                    move = true;
                    
                    y2 += sp;
                    if (!(this.Height * 3 / 4 <= trainer.Bottom && !touch()))
                    {
                        y1 += sp;
                        y2 -= sp;
                    }
                }

                shadow.Location = new Point(x1+x2-x, y1+y2-y);
                
                if (!touch())
                {                 
                    trainer.Location = new Point(x1, y1);
                    vision.Location = new Point(x1 - vi, y1 - vi);
                    foreach (Control c1 in this.Controls)
                    {
                        if (!trainer.Equals(c1) && !vision.Equals(c1) && !c1.Equals(back) && !c1.Equals(bag))
                        {
                            c1.Top += y - y2;
                            c1.Left += x - x2;
                        }
                    }
                    
                }               
                visible();
                shadow.Location = trainer.Location;
            }
        }

        
        bool move;
        private void timer1_Tick(object sender, EventArgs e)
        {
            move = false;
        }
        
        private void Map1_SizeChanged(object sender, EventArgs e)
        {
            int x = trainer.Top - this.ClientSize.Height / 2;
            int y = trainer.Left - this.ClientSize.Width / 2;
            foreach (Control c1 in this.Controls)
            {
                if (!c1.Equals(back)&& !c1.Equals(bag))
                {
                    c1.Top -= x;
                    c1.Left -= y;
                }
            }

        }

 

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void back_MouseEnter(object sender, EventArgs e)
        {
            back.BackColor = Color.Blue;
        }

        

        private void back_MouseLeave(object sender, EventArgs e)
        {
            back.BackColor = Color.White;
        }

       

        private void bag_Click(object sender, EventArgs e)
        {
            Storage storage = new Storage();
            storage.Show();
        }

        private void bag_MouseEnter(object sender, EventArgs e)
        {
            bag.BackColor = Color.Blue;
        }

        private void bag_MouseLeave(object sender, EventArgs e)
        {
            bag.BackColor = Color.White;
        }

        private void Map1_Load(object sender, EventArgs e)
        {
            vision.Size = new Size(2 * vi + trainer.Width, 2 * vi + trainer.Height);
            vision.Top = trainer.Top - vi;
            vision.Left = trainer.Left - vi;
            shadow.Location = trainer.Location;
            shadow.Size = trainer.Size;
            foreach (Control c1 in this.Controls)
            {

                if (!trainer.Equals(c1) && !((string)c1.Tag == "frame") && !c1.Equals(back) && !c1.Equals(bag))
                {
                    c1.Visible = false;

                }

            }

            visible();

            // this.Bounds = Screen.PrimaryScreen.Bounds;

            pictureBox6.Width = background.Width;
            pictureBox8.Width = background.Width;
            pictureBox7.Height = background.Height;
            pictureBox9.Height = background.Height;
            pictureBox6.Location = background.Location;
            pictureBox7.Location = background.Location;
            pictureBox9.Top = pictureBox6.Top;
            pictureBox9.Left = background.Left + background.Width - pictureBox9.Width;
            pictureBox8.Left = pictureBox6.Left;
            pictureBox8.Top = background.Top + background.Height - pictureBox8.Height;
        }
    }

}
