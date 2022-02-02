using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Gui.Game;
namespace Elemont.Gui.Game
{
    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();
            
        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            
        }

        private void Map_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
    
}

