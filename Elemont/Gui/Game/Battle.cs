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
    public partial class Battle : Form
    {
        public Battle()
        {
            InitializeComponent();
            

        }
        Pokemon poke1;
        Pokemon poke2;
        private void button_Click(object sender, EventArgs e)
        {
           richTextBox1.Text = richTextBox1.Text + "\n" + label1.Text +" uses "+ ((Button)sender).Text; ;
                     
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
