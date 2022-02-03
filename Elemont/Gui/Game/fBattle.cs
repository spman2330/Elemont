using System;
using System.Collections.Generic;
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
        public fBattle()
        {
            InitializeComponent();          
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
           richTextBox1.Text = richTextBox1.Text + "\n" + label1.Text +" uses "+ ((Button)sender).Text; ;
            Useskill(poke1,poke2);
            Useskill(poke2, poke1);
        }

        private void Battle_Load(object sender, EventArgs e)
        {
           
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
    }
}
