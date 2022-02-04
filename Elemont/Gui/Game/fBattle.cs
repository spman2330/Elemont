using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Dto;
namespace Elemont.Gui.Game
{
    public partial class fBattle : Form
    {
        public static fBattle instance;
        public fBattle()
        {
            InitializeComponent();
            instance = this;
        }
        Pokemon poke1;
        Pokemon poke2;
        void Useskill (Pokemon pk1,Pokemon pk2)
        {
            /*switch (skill.type)
            {case "attack":
            pk2.Maxhp -= (skill.num+pk1.attack-pk2.defense);
            mp1 -= skill.manacost;

            break;
            case "heal":
            pk1.Maxhp +=skill.num;
            break;
            }
            */
        }
        private void button_Click(object sender, EventArgs e)
        {          
            Useskill(poke1,poke2);
            Useskill(poke2, poke1);
            progressBar2.Value = progressBar2.Value - 10;                      
            turn++;
            newturn();          
            richTextBox1.Text = richTextBox1.Text  + turn.ToString() + " " + label1.Text + " uses " + ((Button)sender).Text + "\n";
            checkend();
        }
        private void button1_Click(object sender, EventArgs e)
        {            
            Useskill(poke2, poke1);
            progressBar2.Value = progressBar2.Value - 5;                       
            turn++;
            newturn();           
            richTextBox1.Text = richTextBox1.Text + turn.ToString()  + " " + label1.Text+" "  + ((Button)sender).Text + "\n";
            checkend();            
        }
        private void Clearrow()
        {
            richTextBox1.ReadOnly = false;
            string [] str = new string[turn];
            for (int i = 0; i < turn;i++)
            {
                str[i] = richTextBox1.Lines[i];
            }
            richTextBox1.Clear();
            for (int i = 0; i < turn; i++)
            {
                richTextBox1.Text += str[i]+"\n";
            }
            
            richTextBox1.ReadOnly = true;

            for (int i = turn+1;i<battlelog.Rows.Count;)
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
            mana1 = mana2 = 0;
            progressBar2.Value = progressBar2.Maximum;
            progressBar1.Value = progressBar1.Maximum;
            battlelog.Clear();
            richTextBox1.Clear();
            turn = 0;
        }
        private void Loadstt()
        {
            label2.Text = progressBar2.Value.ToString();
            label4.Text = progressBar1.Value.ToString();
        }
        int turn;
        int mana1;
        int mana2;

        private void newturn()
        {
            DataRow r = battlelog.NewRow();
            r["Elemont1"] = label1.Text;
            r["Elemont2"] = label3.Text;
            r["Hp1"] = progressBar1.Value;
            r["Hp2"] = progressBar2.Value;
            r["Turn"] = turn;
            battlelog.Rows.Add(r);
            this.dataGridView1.DataSource = battlelog;
            Loadstt();
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
        }

        DataTable battlelog = new DataTable();
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
        public String pokeselect;
        private void bag_Click(object sender, EventArgs e)
        {
            Storage storage = new Storage();
            storage.Show();
            storage.hideandseek();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                turn = (int)dataGridView1.CurrentRow.Cells[0].Value;
                progressBar1.Value = (int)dataGridView1.CurrentRow.Cells[2].Value;
                progressBar2.Value = (int)dataGridView1.CurrentRow.Cells[5].Value;
                Loadstt();
            }    
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                turn = (int)dataGridView1.CurrentRow.Cells[0].Value;
                progressBar1.Value = (int)dataGridView1.CurrentRow.Cells[2].Value;
                progressBar2.Value = (int)dataGridView1.CurrentRow.Cells[5].Value;
                Clearrow();
            }
        }
        private void checkend()
        {
            if(progressBar2.Value == 0)
            {
                DialogResult dr = MessageBox.Show("You lose, wanna try again?","",MessageBoxButtons.YesNo);
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
            if(progressBar1.Value == 0)
            {
                // thêm 10 coins vào túi
                // pokemon tham chiến tăng xx exp;
                //trainer tăng xx exp;
                DialogResult dr = MessageBox.Show("You win, wanna catch this Elemont?", "", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.No:
                        this.Close();
                        break;
                    case DialogResult.Yes:
                        //Check túi có >1 bóng thì bắt
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
            button8.Visible = false;
            bag.Visible = false;
            panel2.Enabled = true;
            turn = 0;
            newturn();
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
