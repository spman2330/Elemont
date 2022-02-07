using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Dto;
using Elemont.Dao;

using Elemont.Gui.Game;
using Elemont.Gui.GameManager;

namespace Elemont.Gui
{
    public partial class BeginForm : Form
    {
        Account _account;
        public BeginForm(Account account)
        {
            InitializeComponent();
            _account = account;
        }

        private void BeginForm_Load(object sender, EventArgs e)
        {
            if(_account.Type!=1)
            {
                button5.Enabled = false;
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fSelect fselect = new fSelect(_account);
            this.Hide();
            fselect.ShowDialog();
            this.Show();
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
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            fMap fmap = new fMap();
            this.Hide();
            fmap.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            (new fLogin()).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            fGameEdit fGE = new fGameEdit();
            fGE.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Hide();
            (new fManagerAccount()).Show();

        }
    }
}
