using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elemont.Dao;
using Elemont.Dto;

namespace Elemont.Gui.FormAdmin
{
    public partial class FPokeedit : Form
    {
        public FPokeedit()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            if (textBox3.Text != "")
            {
                dataGridView1.DataSource = PokemonDao.Instance.GetPokemonsByCellId(int.Parse(textBox3.Text)).Select(
                 item => new
                 {
                     Name = item.Name,
                     Species = item.Species.Name,
                     Skill1 = item.Skill1.Name,
                     Skill2 = item.Skill2.Name,
                     Exp = item.Exp,
                     PokemondId = item.PokemonId,
                 }
                 ).ToArray();
            }
        }
        private void Pokeedit_Load(object sender, EventArgs e)
        {
            foreach (Map m in MapDao.Instance.GetMaps())
            {
                GroupBox gb = new GroupBox();
                gb.Size = new Size(150, 120);
                PictureBox pb = new PictureBox();
                pb.Size = new Size(150, 105);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Tag = m.MapId;
                pb.Image = Image.FromFile("..\\..\\..\\" + m.Background);
                pb.Click += new System.EventHandler(this.pictureBox1_Click);
                pb.Location = new Point(0, 20);
                gb.Controls.Add(pb);
                gb.Text = m.Name;
                gb.Tag = m.MapId;
                gb.BackColor = Color.White;
                Map1.Controls.Add(gb);
            }
            comboBox1.DataSource = SpeciesDao.Instance.GetAllSpecies();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "SpeciesId";
            comboBox1.SelectedIndex = -1;
            comboBox2.DataSource = SkillDao.Instance.GetAllSkill();
            comboBox2.DisplayMember = "Name";
            comboBox2.SelectedIndex = -1;
            comboBox2.ValueMember = "SkillId";
            comboBox3.DataSource = SkillDao.Instance.GetAllSkill();
            comboBox3.DisplayMember = "Name";
            comboBox3.SelectedIndex = -1;
            comboBox3.ValueMember = "SkillId";
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
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            textBox3.Text = pb.Tag.ToString();


        }
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control c1 in Map1.Controls)
            {
                if (c1.BackColor == Color.Blue)
                {
                    bool child = true;
                    while (child)
                    {
                        foreach (Control c2 in pictureBox1.Controls)
                        { pictureBox1.Controls.Remove(c2); }
                        child = pictureBox1.HasChildren;
                    }
                    Map map = MapDao.Instance.GetMapById((int)c1.Tag);
                    pictureBox1.Tag = map.MapId;
                    pictureBox1.Image = Image.FromFile("..\\..\\..\\" + map.Background);
                    pictureBox1.Width = map.Width;
                    pictureBox1.Height = map.Height;
                    foreach (Cell c in map.Cells)
                    {
                        PictureBox pb = new PictureBox();
                        pb.Size = new Size(c.Width, c.Height);
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.Tag = c.CellId;
                        switch (c.Type)
                        {
                            case "Water":
                                pb.BackColor = Color.Blue;
                                break;
                            case "Wall":
                                pb.BackColor = Color.Brown;
                                break;
                            case "Nest":
                                pb.BackColor = Color.Green;
                                break;
                            default:
                                pb.BackColor = Color.Black;
                                break;
                        }
                        pictureBox1.Controls.Add(pb);
                        pb.Location = new Point(c.LocationX, c.LocationY);
                        pb.BringToFront();
                        pb.Click += new System.EventHandler(this.pictureBox_Click);
                    }
                }
            }
            Loadnull();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                dataGridView1.DataSource = PokemonDao.Instance.GetPokemonsByCellId(Convert.ToInt32(textBox3.Text));
            }
            LoadData();
        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Pokemon poke = PokemonDao.Instance.GetPokemonById(Convert.ToInt32
                    (dataGridView1.Rows[e.RowIndex].Cells[5].Value));
                textBox1.Text = poke.Name;
                textBox2.Text = poke.Exp.ToString();
                textBox4.Text = poke.PokemonId.ToString();
                comboBox1.SelectedValue = poke.Species.SpeciesId;
                comboBox2.SelectedValue = poke.Skill1.SkillId;
                comboBox3.SelectedValue = poke.Skill2.SkillId;
            }
            catch { }
        }
        private void Loadnull()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {

            }
            else
            {
                if (textBox4.Text != "")
                {
                    Pokemon poke = PokemonDao.Instance.GetPokemonById(Convert.ToInt32(textBox4.Text));
                    poke.Name = textBox1.Text;
                    poke.Exp = Convert.ToInt32(textBox2.Text);

                    if (!PokemonDao.Instance.ChangePokemon(poke))
                    { }
                    Loadnull();
                }
                else
                {
                    if (textBox3.Text != "")
                    {
                        Pokemon poke = new Pokemon();
                        poke.Name = textBox1.Text;
                        poke.Exp = Convert.ToInt32(textBox2.Text);
                        poke.CellId = Convert.ToInt32(textBox3.Text);
                        poke.Species = SpeciesDao.Instance.GetSpeciesById(Convert.ToInt32(comboBox1.SelectedValue));
                        poke.Skill1 = SkillDao.Instance.GetskillById(Convert.ToInt32(comboBox2.SelectedValue));
                        poke.Skill2 = SkillDao.Instance.GetskillById(Convert.ToInt32(comboBox3.SelectedValue));

                        PokemonDao.Instance.AddPokemon(poke);
                        Loadnull();
                    }
                }
                LoadData();
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                if (!PokemonDao.Instance.RemovePokemonbyId(Convert.ToInt32(textBox4.Text)))
                {
                }
                Loadnull();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))
                e.Handled = true;
        }
    }

}
