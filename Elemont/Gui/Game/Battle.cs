using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Elemont.Gui.Game
{
    public partial class Battle : Form
    {
        public Battle()
        {
            InitializeComponent();
            

        }

        private void button_Click(object sender, EventArgs e)
        {
           richTextBox1.Text = richTextBox1.Text + "\n" + label1.Text +" uses "+ ((Button)sender).Text; ;
            
          
        }

        private void Battle_Load(object sender, EventArgs e)
        {
           
        }
    }
}
