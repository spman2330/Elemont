using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Media;
using Elemont.Dto;
using Elemont.Dao;

namespace Elemont.Gui.Game
{

    public partial class fMap1 : Form
    {
        public static fMap1 instance;
        public fMap1(Gameplay game)
        {
            InitializeComponent();
            this.game = game;
            instance = this;
        }
        public bool touch()
        {
            foreach (Control c1 in this.Controls)
            {
                if ((trainer.Bounds.IntersectsWith(c1.Bounds) || shadow.Bounds.IntersectsWith(c1.Bounds)) && !trainer.Equals(c1) && !vision.Equals(c1) && !background.Equals(c1) && !shadow.Equals(c1))
                {
                    switch (c1.Tag.ToString())
                    {
                        case "Water":
                            foreach(Pokemon pkm in this.game.Trainers.Pokemons)
                            {
                                if(pkm.Species.Element.Name == "water")
                                { return false; }
                                
                            }
                            return false;                          
                        case "Wall":
                            return true;                        
                        case "Nest":
                            return false;
                    }
                    
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
        public Gameplay game;
        public bool win;
        int sp;
        int vi;
        bool move;
        public void Map1_KeyDown(object sender, KeyEventArgs e)
        {            
            if (!move)
            {
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

                shadow.Location = new Point(x1 + x2 - x, y1 + y2 - y);

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
                if (!c1.Equals(back) && !c1.Equals(bag))
                {
                    c1.Top -= x;
                    c1.Left -= y;
                }
            }

        }
        private void back_Click(object sender, EventArgs e)
        {
            timer2.Stop();
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
            timer2.Stop();
            Storage storage = new Storage(this.game.Trainers);
            storage.unselect();
            storage.ShowDialog();
           
            timer2.Start();

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
            
            background.Size = new Size(game.Maps.Width, game.Maps.Height);
            background.Location = new Point(0, 0);
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
            vi = game.Trainers.Ball2Num;
            sp = game.Trainers.Ball3Num;
            //trainer.Image = game.Trainers.Skin.Avt; đổi sang ảnh
            //background.Image = game.Maps.Background; đổi sang ảnh
            foreach (Cell c in game.Maps.Cells)
            {
                PictureBox pb = new PictureBox();
                pb.Size = new Size(c.Width, c.Height);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Tag = c.Type;
                //pb.Image = c.Background; đổi sang ảnh
                pb.BackColor = Color.Green;
                this.Controls.Add(pb);
                pb.Tag = c.Type;
                pb.Location = new Point(c.LocationX, c.LocationY);
                pb.BringToFront();
                foreach (Pokemon pk in c.Pokemons)
                {
                    PictureBox pkm = new PictureBox();
                    pkm.Size = new Size(35, 25);
                    pkm.SizeMode = PictureBoxSizeMode.StretchImage;
                    pkm.Tag = pk.PokemonId;
                    Random r = new Random();
                    this.Controls.Add(pkm);
                    pkm.Location = new Point(r.Next(c.LocationX, c.LocationX + c.Width), r.Next(c.LocationY, c.LocationY + c.Height));
                    pkm.BringToFront();
                }
            }            
            vision.Size = new Size(2 * vi + trainer.Width, 2 * vi + trainer.Height);
            vision.Top = trainer.Top - vi;
            vision.Left = trainer.Left - vi;
            shadow.Location = trainer.Location;
            shadow.Size = trainer.Size;
            foreach (Control c1 in this.Controls)
            {
                if (!trainer.Equals(c1) && !back.Equals(c1) && !bag.Equals(c1))
                {
                    c1.Visible = false;
                }
            }          
            pictureBox6.Visible = pictureBox7.Visible = pictureBox8.Visible = pictureBox9.Visible = true;
            this.ClientSize = new Size(900, 700);
            foreach (Control c1 in this.Controls)
            {
                if(c1.Tag !=null)
                if (c1.Tag.ToString() == "Water")
                    c1.BringToFront();
            }

            foreach (Control c1 in this.Controls)
            {
                if(c1.Tag !=null)
                if (c1.Tag.ToString() == "Wall")
                    c1.BringToFront();
            }
            bag.BringToFront();
            back.BringToFront();
            timer2.Start();
            visible();
            trainer.BringToFront();

            string s = "\\Resources\\male.png";
            trainer.Image = Image.FromFile(Directory.GetCurrentDirectory() +s );



        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (Control c1 in this.Controls)
            {
                int id;

                if (vision.Bounds.IntersectsWith(c1.Bounds))
                {
                    bool ispoke = int.TryParse(c1.Tag.ToString(), out id);
                    if (ispoke)
                    {
                        timer2.Stop();
                        DialogResult result = MessageBox.Show("Do you want battle?", "", MessageBoxButtons.YesNo);
                        switch (result)
                        {
                            case DialogResult.No:
                                timer2.Start();
                                break;
                            case DialogResult.Yes:
                                {
                                    Pokemon pk2 = PokemonDao.Instance.GetPokemonById(id);
                                    fBattle fbattle = new fBattle(pk2);
                                    fBattle.instance.train = this.game.Trainers;
                                    this.Hide();
                                    fbattle.ShowDialog();
                                    this.Show();
                                    if (win)
                                    {
                                        this.Controls.Remove(c1);
                                    }
                                    win = false;                                    
                                    timer2.Start();
                                }
                                break;
                            default:
                                timer2.Start();
                                break;
                        }
                    }
                }
            }

        }
    }

}
