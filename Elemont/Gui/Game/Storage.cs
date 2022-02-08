using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Dao;
using Elemont.Dto;


namespace Elemont.Gui.Game
{
    public partial class Storage : Form
    {
        public Storage instance;
        public Storage(Trainer trainer)
        {
            InitializeComponent();
            this.train = TrainerDao.Instance.GetTrainerById(trainer.TrainerId);
            instance = this;
        }
        Trainer train;
        private void button1_Click(object sender, EventArgs e)
        {
            getinfo();
        }
        void getinfo()
        {
            richTextBox1.Clear();
            foreach (Control c1 in store.Controls)
            {
                if (c1.BackColor == Color.Blue)
                {
                    Pokemon pkm = PokemonDao.Instance.GetPokemonById((int)c1.Tag);
                    richTextBox1.Text =
                            pkm.Name + "\n"
                            + "Level " + pkm.Level.ToString() + "\n"
                            + "Species: " + pkm.Species.Name + "\n"
                            + "Element: " + pkm.Species.Element.Name + "\n"
                            + "Skill1: " + pkm.Skill1.Name + "\n"
                            + "Skill2: " + pkm.Skill2.Name + "\n"
                            + "HP: " + pkm.HP.ToString() + "\n"
                            + "Attack: " + pkm.Attack.ToString() + "\n"
                            + "Defense: " + pkm.Defense.ToString();
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
            int t = 0;
            foreach (Control c1 in store.Controls)
            {
                if (c1.BackColor == Color.Blue)
                {
                    t++;
                }

            }
            if (pkname.Text!=null&&t==1)
            {
                foreach (Control c1 in store.Controls)
                {
                    if (c1.BackColor == Color.Blue)
                    {
                        c1.Text = pkname.Text;

                        Pokemon pkm = PokemonDao.Instance.GetPokemonById((int)c1.Tag);
                        pkm.Name = pkname.Text;
                        if (!PokemonDao.Instance.ChangePokemon(pkm))
                        { };
                    }
                }             
            }   
            else
            { MessageBox.Show("Please select 1 pokemon and choose name", "", MessageBoxButtons.OK); }                 
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;

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
            {
                richTextBox1.Clear();
                pb.Parent.BackColor = Color.Blue;
                Pokemon pkm = PokemonDao.Instance.GetPokemonById((int)pb.Tag);
                richTextBox1.Text =
                    pkm.Name + "\n"
                    + "Level " + pkm.Level.ToString() + "\n"
                    + "Species: " + pkm.Species.Name + "\n"
                    + "Element: " + pkm.Species.Element.Name+"\n"
                    + "Skill1: " + pkm.Skill1.Name + "\n" 
                    + "Skill2: " + pkm.Skill2.Name + "\n"
                    + "HP: " + pkm.HP.ToString() + "\n"
                    + "Attack: " + pkm.Attack.ToString() + "\n" 
                    + "Defense: " + pkm.Defense.ToString();
            }
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
                            
                                                                        
                            List< Pokemon > termsList = new List<Pokemon>();
                        foreach (Pokemon pokemon in fMap1.instance.game.Trainers.Pokemons)
                        {
                            termsList.Add(pokemon);
                        }
                        termsList.Remove(PokemonDao.Instance.GetPokemonById((int)c1.Tag));
                        fMap1.instance.game.Trainers.Pokemons = termsList.ToArray();
                            store.Controls.Remove(c1);
                            if (!PokemonDao.Instance.RemovePokemonbyId((int)c1.Tag))
                            { };
                            fMap1.instance.game.Trainers = TrainerDao.Instance.GetTrainerById(fMap1.instance.game.Trainers.TrainerId);
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
        private void Storage_Load(object sender, EventArgs e)
        {            
            foreach (Pokemon pkm in this.train.Pokemons)
            {
                GroupBox gb = new GroupBox();
                gb.Size = new Size(140, 115);
                PictureBox pb = new PictureBox();
                pb.Size = new Size(125, 90);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BackColor = Color.Transparent;
                pb.Tag = pkm.PokemonId;
                pb.Click += new System.EventHandler(this.pictureBox_Click);
                pb.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
                pb.Location = new Point(5, 20);
                pb.Image = Image.FromFile("..\\..\\..\\" + pkm.Species.Image);
                gb.Controls.Add(pb);
                gb.Text = pkm.Name;
                gb.Tag = pkm.PokemonId;
                gb.BackColor = Color.White;
                store.Controls.Add(gb);
            }
            gettrainerinfo();
            pictureBox3.Image = Image.FromFile("..\\..\\..\\" + this.train.Skin.Avatar);
        }
        public void unselect()
        {
            selectpkm.Visible = false;           
        }
        public void hideandseek()
        {
            selectpkm.Visible = true;
            namebttn.Visible = false;          
            deletebttn.Visible = false;
           
        }
        private void selectpkm_Click(object sender, EventArgs e)
        {
            int t = 0;
            foreach (Control c1 in store.Controls)
            {
                if (c1.BackColor == Color.Blue)
                {
                    t++;
                }
            }
            if (t == 0 || t > 1)
            {
                MessageBox.Show("Please select 1 pokemon", "", MessageBoxButtons.OK);
            }
            if (t == 1)
            {
                foreach (Control c1 in store.Controls)
                {
                    if (c1.BackColor == Color.Blue)
                    {
                        fBattle.instance.poke1 = PokemonDao.Instance.GetPokemonById((int)c1.Tag);
                        fBattle.instance.showpanel();
                        this.Close();
                    }
                }

            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {

                DialogResult r = MessageBox.Show("Do you want to change your name to "+textBox1.Text,"",MessageBoxButtons.YesNo);
                switch (r)
                {
                    case DialogResult.Yes:
                        this.train.Name = textBox1.Text;
                        if (!TrainerDao.Instance.Updatetrainer(this.train))
                        { };
                        break;
                    case DialogResult.No:
                        break;
                }    
            }
            gettrainerinfo();
        }
        void gettrainerinfo()
        {
            richTextBox2.Text =
                train.Name + "\n"
                + "Exp: " + train.Exp.ToString() + "\n"
                + "Vision: " + train.Speed.ToString()+"\n"
                + "Speed: " + train.Vision.ToString();
            string s;
            if (train.Ball1Num > 1)
            {
                 s = "Pokeballs: ";
            }
            else
            {  s = "Pokeball: "; }
            label1.Text = s + train.Ball1Num.ToString();
            label2.Text = "Gold: " + train.Gold.ToString();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if(train.Gold/5 >=numericUpDown2.Value )
            {
                train.Gold -= 5 * (int)numericUpDown2.Value;
                train.Ball1Num += (int)numericUpDown2.Value;
                gettrainerinfo();
                if (!TrainerDao.Instance.Updatetrainer(this.train))
                {     

                }

            }
            else
            {
                MessageBox.Show("You do not have enough gold!", "", MessageBoxButtons.OK);
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = "Prices: " + 5*numericUpDown2.Value;
        }
    }
}
