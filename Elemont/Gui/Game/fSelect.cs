using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Elemont.Dao;
using Elemont.Dto;


namespace Elemont.Gui.Game
{

    public partial class fSelect : Form
    {
        public static fSelect instance;

        public fSelect(Account acc)
        {
            InitializeComponent();
            instance = this;
            this.account = acc;
        }
        Map[] map = MapDao.Instance.GetMaps();
        Account account;
        private void fSelect_Load(object sender, EventArgs e)
        {
            Loadtr();
            foreach (Map m in map)
            {
                GroupBox gb = new GroupBox();
                gb.Size = new Size(700, 500);
                PictureBox pb = new PictureBox();
                pb.Size = new Size(650, 450);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BackColor = Color.White;
                pb.Tag = m.MapId;
                pb.Image = Image.FromFile("..\\..\\..\\" + m.Background);
                pb.Click += new System.EventHandler(this.pictureBox1_Click);
                pb.Location = new Point(30, 30);
                gb.Controls.Add(pb);
                gb.Text = m.Name;
                gb.Tag = m.MapId;
                gb.BackColor = Color.White;
                Map1.Controls.Add(gb);
            }
        }
        private void Loadtr()
        {
            Trainer1.Controls.Clear();
            this.account = AccountDao.Instance.GetAccount(this.account.UserName, this.account.Password);
            foreach (Trainer tr in this.account.Trainers)
            {
                GroupBox gb = new GroupBox();
                gb.Size = new Size(240, 180);
                PictureBox pb = new PictureBox();
                pb.Size = new Size(210, 150);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BackColor = Color.Red;
                pb.Tag = tr.TrainerId;
                pb.Image = Image.FromFile("..\\..\\..\\" + tr.Skin.Avatar);
                pb.Click += new System.EventHandler(this.pictureBox_Click);
                pb.Location = new Point(10, 20);
                gb.Controls.Add(pb);
                gb.Text = tr.Name;
                gb.Tag = tr.TrainerId;
                gb.BackColor = Color.White;
                Trainer1.Controls.Add(gb);
            }

        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            {
                if (pb.Parent.BackColor == Color.Blue)
                {
                    pb.Parent.BackColor = Color.White;
                }
                else
                {
                    foreach (Control c1 in Trainer1.Controls)
                    {
                        c1.BackColor = Color.White;
                    }
                    pb.Parent.BackColor = Color.Blue;
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            {
                if (pb.Parent.BackColor == Color.Blue)
                {
                    pb.Parent.BackColor = Color.White;
                }
                else
                {
                    foreach (Control c1 in Map1.Controls)
                    {
                        c1.BackColor = Color.White;
                    }
                    pb.Parent.BackColor = Color.Blue;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.SelectedItem != null)
            {
                int i;
                switch (comboBox1.Text)
                {
                    case "Male":
                        i = 1;
                        break;
                    case "Female":
                        i = 2;
                        break;
                    default:
                        i = 1;
                        break;
                }    
                Trainer test = new Trainer(this.account.AccountId, textBox1.Text, i);
                if (!TrainerDao.Instance.AddTrainer(test))
                {

                }
                Loadtr();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control c1 in Trainer1.Controls)
            {
                if (c1.BackColor == Color.Blue)
                {
                    if (!TrainerDao.Instance.RemoveTrainerById((int)c1.Tag))
                    {

                    }
                    Trainer1.Controls.Remove(c1);
                }
            }
            button3.Visible = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int k = 0;
            foreach (Control c1 in Trainer1.Controls)
            { k++; }
            if (k == 3)
            {
                button3.Visible = false;
            }
            else if (k == 0)
            {
                button4.Visible = false;
            }
            else
            {
                button3.Visible = true;
                button4.Visible = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            Gameplay game = new Gameplay();
            foreach (Control c1 in Map1.Controls)
            {
                if (c1.BackColor == Color.Blue)
                {
                    game.Maps = MapDao.Instance.GetMapById((int)c1.Tag);
                    x++;
                }
            }
            foreach (Control c1 in Trainer1.Controls)
            {
                if (c1.BackColor == Color.Blue)
                {
                    game.Trainers = TrainerDao.Instance.GetTrainerById((int)c1.Tag);
                    y++;
                }
            }
            if (x * y == 1)
            {
                fMap1 map1 = new fMap1(game);
                fMap1.instance.game = game;
                this.Hide();
                map1.ShowDialog();
                this.Show();
                //load thay đổi
            }
            else
            {
                MessageBox.Show("Please select 1 trainer and 1 map", "", MessageBoxButtons.OK);
            }

        }      
    }
}
