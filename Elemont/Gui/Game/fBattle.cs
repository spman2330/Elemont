using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Dto;
using Elemont.Dao;

namespace Elemont.Gui.Game
{
    public partial class fBattle : Form
    {
        public static fBattle instance;
        public fBattle(Pokemon pk2)
        {
            InitializeComponent(); 
            this.poke2 = pk2;
            poke2.Name = "Wild " + poke2.Species.Name;
            instance = this;           
        }
        public Trainer train;
        public Pokemon poke1;
        public Pokemon poke2;
        int hp1;
        int hp2;
        int turn;
        int mana1;
        int mana2;
        string pk2atk;
        DataTable battlelog = new DataTable();
        int strong(Element ele1, Element ele2) 
        {
            foreach(int i in ele1.Strong)
            {
                if (ele2.ElementId == i)
                { return 2; }    
            }    
            return 1;
        }
        int weak(Element ele1, Element ele2) 
        {
            foreach (int i in ele1.Weak)
            {
                if (ele2.ElementId == i)
                { return 2; }
            }
            return 1;
        }        
        void Useskill(Skill skill)
        {
            int w = weak(poke1.Species.Element, poke2.Species.Element);
            int s = strong(poke1.Species.Element, poke2.Species.Element);
            switch (skill.Type)
            {
                case "attack":
                    hp2 -= (skill.Num + poke1.Attack+poke2.Defense / (poke2.Defense + 2))*s/w;
                    break;
                case "heal":
                    hp1 += skill.Num;
                    if (hp1 > poke1.HP)
                        hp1 = poke1.HP;
                    break;
                default:
                    break;
            }
            if (hp2 < 0) hp2 = 0;
            mana1 -= skill.ManaCost;
        }
        void Useskill2( Skill skill)
        {
            int w = weak(poke2.Species.Element, poke1.Species.Element);
            int s = strong(poke2.Species.Element, poke1.Species.Element);
            switch (skill.Type)
            {
                case "attack":
                    hp1 -= (skill.Num + poke2.Attack * poke1.Defense / (poke1.Defense + 2)) * s / w;                  
                    break;
                case "heal":
                    hp2 += skill.Num;
                    if (hp2 > poke2.HP)
                        hp2 = poke2.HP;
                    break;
                default:
                    break;
            }
            if (hp1 < 0) hp1 = 0;
            mana2 -= skill.ManaCost;
        }
        void Poke2atk()
        {
            if (mana2 < poke2.Skill1.ManaCost && mana2 < poke2.Skill2.ManaCost) // poke2 đánh thường
            {
                mana2 += 3;
                hp1 -= poke2.Attack * poke1.Defense / (poke1.Defense + 2);
                pk2atk = "; " + poke2.Name + " Attacks";
            }
            else if (mana2 >= poke2.Skill1.ManaCost && mana2 >= poke2.Skill2.ManaCost)
            {
                Random r = new Random();
                int t = r.Next(0, 100) % 3;
                if (t == 0)
                {
                    Useskill2(poke2.Skill1);
                    pk2atk = "; " + poke2.Name + " uses " + poke2.Skill1.Name;
                }
                else
                if (t == 1)
                {
                    Useskill2(poke2.Skill2);
                    pk2atk = "; " + poke2.Name + " uses " + poke2.Skill2.Name;
                }
                else
                {
                    mana2 += 3;
                    hp1 -= poke2.Attack * poke1.Defense / (poke1.Defense + 2);
                    pk2atk = "; " + poke2.Name + " Attacks";
                }
            }
            else 
            if (mana2 >= poke2.Skill1.ManaCost && mana2 < poke2.Skill2.ManaCost)

            {
                Random r = new Random();
                int t = r.Next(0, 100) % 2;
                if (t == 0)
                {
                    mana2 += 3;
                    hp1 -= poke2.Attack * poke1.Defense / (poke1.Defense + 2);                    
                    pk2atk = "; " + poke2.Name + " Attacks";
                }
                else { 
                 Useskill2(poke2.Skill1);
                pk2atk = "; " + poke2.Name + " uses " + poke2.Skill1.Name; }
            }    
              else
              if (mana2 < poke2.Skill1.ManaCost && mana2 >= poke2.Skill2.ManaCost)
            {
                Random r = new Random();
                int t = r.Next(0, 100) % 2;
                if (t == 0)
                {
                    mana2 += 3;
                    hp1 -= poke2.Attack * poke1.Defense / (poke1.Defense + 2);                   
                    pk2atk = "; " + poke2.Name + " Attacks";
                }
                else
                {
                    Useskill2(poke2.Skill2);
                    pk2atk = "; " + poke2.Name + " uses " + poke2.Skill2.Name;
                }
                
            }
            if (hp1 < 0) hp1 = 0;
            
        }   
        void checkenvi()
        {
            string s = fMap1.instance.game.Maps.Name;            
            if (poke1.Species.Element.Name == s)
            { hp1 += 10; }
            if (poke2.Species.Element.Name == s)
            { hp2 += 10; }
            
        }
        private void Skill1_Click(object sender, EventArgs e)
        {
            if (mana1 >= poke1.Skill1.ManaCost)
            {
                Useskill(poke1.Skill1);
                if(hp2 > 0)
                Poke2atk();
                Clearrow();
                turn++;
                newturn();
                richTextBox1.Text = richTextBox1.Text + turn.ToString() + " " + label1.Text + " uses " + poke1.Skill1.Name + " " + pk2atk + "\n";
                checkend();
            }
            else { MessageBox.Show("Not enough Mana", "", MessageBoxButtons.OK); }
        }
        private void Skill2_Click(object sender, EventArgs e)
        {
            if (mana1 >= poke1.Skill2.ManaCost)
            {
                Useskill(poke1.Skill2);
                if(hp2>0)
                Poke2atk();
                Clearrow();
                turn++;
                newturn();
                richTextBox1.Text = richTextBox1.Text + turn.ToString() + " " + label1.Text + " uses " + poke1.Skill2.Name + " " + pk2atk + "\n";
                checkend();
            }
            else { MessageBox.Show("Not enough Mana","",MessageBoxButtons.OK); }
        }
        private void button1_Click(object sender, EventArgs e) 
        {
            mana1 += 3;            
            hp2 -= poke1.Attack * poke2.Defense / (poke2.Defense + 2);
            if (hp2 <= 0) hp2 = 0;
            else
            {
                Poke2atk();
            }
            Clearrow();
            Loadstt();
            turn++;
            newturn();                           
            richTextBox1.Text = richTextBox1.Text + turn.ToString() + " " + label1.Text +  " Attacks "+pk2atk+ "\n";
            checkend();
        }
        private void Clearrow()
        {
            richTextBox1.ReadOnly = false;
            string[] str = new string[turn];
            for (int i = 0; i < turn; i++)
            {
                str[i] = richTextBox1.Lines[i];
            }
            richTextBox1.Clear();
            for (int i = 0; i < turn; i++)
            {
                richTextBox1.Text += str[i] + "\n";
            }
            richTextBox1.ReadOnly = true;

            for (int i = turn + 1; i < battlelog.Rows.Count;)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.Rows[i].Index);
            }
            Loadstt();
        }
        private void reset()
        {
            button8.Visible = true;
            bag.Visible = true;
            panel2.Enabled = false;
            panel1.Visible = true;
            turn = 0;
            mana1 = mana2 = 0;
            hp1 = progressBar2.Maximum = poke1.HP;
            hp2 = progressBar1.Maximum= poke2.HP;          
            Loadstt();
            battlelog.Clear();
            richTextBox1.Clear();
            panel1.Visible = false;
        }
        private void Loadstt()
        {
            label1.Text = poke1.Name;
            label7.Text = poke1.Species.Element.Name;
            label3.Text = poke2.Name;
            label6.Text = poke2.Species.Element.Name;
            button2.Text = poke1.Skill1.Name;
            button3.Text = poke1.Skill2.Name;
            progressBar1.Value = hp2;
            progressBar2.Value = hp1;
            label2.Text = hp1.ToString();
            label4.Text = hp2.ToString();
            label5.Text = mana1.ToString();
        }      
        private void newturn()
        {
            DataRow r = battlelog.NewRow();
            r["Elemont1"] = label1.Text;
            r["Elemont2"] = label3.Text;
            r["Mana1"] = mana1;
            r["Mana2"] = mana2;
            r["Hp1"] = hp1;
            r["Hp2"] = hp2;
            r["Turn"] = turn;
            battlelog.Rows.Add(r);
            this.dataGridView1.DataSource = battlelog;           
        }
        private void Battle_Load(object sender, EventArgs e)
        {
            battlelog.Columns.Add("Turn", typeof(int));
            battlelog.Columns.Add("Elemont1", typeof(string));
            battlelog.Columns.Add("Hp1", typeof(int));
            battlelog.Columns.Add("Mana1", typeof(int));
            battlelog.Columns.Add("Elemont2", typeof(string));
            battlelog.Columns.Add("Hp2", typeof(int));
            battlelog.Columns.Add("Mana2", typeof(int));
            this.dataGridView1.DataSource = battlelog;
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 40;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 40;
            dataGridView1.Columns[6].Width = 60;
            panel1.Visible = false;
            label3.Text = poke2.Name;
            label6.Text = poke2.Species.Element.Name;
            hp2 = poke2.HP;
            label4.Text = hp2.ToString();
            progressBar1.Maximum = hp2;
            progressBar1.Value = hp2;
        }   
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit battle?", "", MessageBoxButtons.YesNo);

            switch (result)
            {
                case DialogResult.No:
                    break;
                case DialogResult.Yes:
                    this.Close();
                    break;
                default:
                    break;
            }
        }
        private void bag_Click(object sender, EventArgs e)
        {           
            Storage storage = new Storage(this.train);            
            storage.Show();
            storage.hideandseek();                       
        }
        public void showpanel()
        {
            panel3.Visible = true;
            label1.Text = poke1.Name;
            label7.Text = poke1.Species.Element.Name;
            label2.Text = poke1.HP.ToString();
            label5.Text = "0";
            progressBar1.Value = progressBar1.Maximum;

        }        
        private void button5_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                turn = (int)dataGridView1.CurrentRow.Cells[0].Value;
                hp1 = (int)dataGridView1.CurrentRow.Cells[2].Value;
                hp2 = (int)dataGridView1.CurrentRow.Cells[5].Value;
                mana1 = (int)dataGridView1.CurrentRow.Cells[3].Value;
                mana2 = (int)dataGridView1.CurrentRow.Cells[6].Value;
                //Clearrow();               
                Loadstt();
            }
        }
        private void checkend()
        {
            if (hp1 == 0)
            {
                DialogResult dr = MessageBox.Show("You lose, wanna try again?", "", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.No:
                        this.Close();
                        break;
                    case DialogResult.Yes:
                        reset();
                        break;
                    default:
                        break;
                }
            }
            if (hp2 == 0)
            {

                poke1.Exp += 5;
                if(!PokemonDao.Instance.updateexp(poke1,poke1.Exp))
                { }    
                this.train.Gold += 10;
                this.train.Exp += poke2.Exp+5;     
                if(!TrainerDao.Instance.updateexp(train,train.Exp))
                { }
                if(!TrainerDao.Instance.updategold(train,train.Gold))
                { }                   
                DialogResult dr = MessageBox.Show("You win, wanna catch this Elemont?", "", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.No:
                        this.Close();
                        break;
                    case DialogResult.Yes:
                        if(this.train.Ball1Num>1)
                        {
                            this.train.Ball1Num -= 1;

                            if (!PokemonDao.Instance.MovePokemon(poke2.PokemonId, this.train.TrainerId)) { };
                            if (!TrainerDao.Instance.buyball(this.train, train.Ball1Num))
                            {

                            }
                            fMap1.instance.win = true;
                            this.Close();
                        }    
                        
                        break;
                    default:
                        break;
                }

            }


        }
        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (poke1 != null)
            {
                button8.Visible = false;
                bag.Visible = false;
                panel2.Enabled = true;
                turn = 0;
                mana1 = mana2 = 0;
                hp1 = progressBar2.Maximum = poke1.HP;
                hp2 = progressBar1.Maximum = poke2.HP;
                checkenvi();
                Loadstt();
                newturn();
                
            }
        }
        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.ForeColor = Color.Black;
        }
        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.ForeColor = Color.White;
        }
    }
}
