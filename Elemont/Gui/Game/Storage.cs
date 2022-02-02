using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Elemont.Gui.Game
{
    public partial class Storage : Form
    {
        public Storage()
        {
            InitializeComponent();
           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            PictureBox pic = new PictureBox();
            store.Controls.Add(pic);
           pic.Size = new Size(150, 100);            
            pic.BackColor = Color.Blue;
            //pic.Tag = "pic";
            
            ControlExtension.Draggable(pic, true);
        }
  

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
