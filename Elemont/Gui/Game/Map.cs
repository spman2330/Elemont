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
            this.map = new Map1();
            map.TopLevel = false;
            panel1.Controls.Add(map);
            
            map.Size = map.Parent.Size;
            map.Show();
                }



        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            
        }
        Map1 map;
        private void Map_KeyDown(object sender, KeyEventArgs e)
        {
            map.Map1_KeyDown(sender,  e);
        }
    }
    
}

