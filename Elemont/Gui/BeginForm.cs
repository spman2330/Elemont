﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Gui.Game;

namespace Elemont.Gui
{
    public partial class BeginForm : Form
    {
        public BeginForm()
        {
            InitializeComponent();
        }

        private void BeginForm_Load(object sender, EventArgs e)
        {
            //ControlExtension.Draggable(button1, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            bt.ForeColor = Color.Black;
            bt.BackColor = Color.Transparent;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            bt.ForeColor = Color.Blue;
            bt.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Map1 map1 = new Map1();
            this.Hide();
            map1.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
