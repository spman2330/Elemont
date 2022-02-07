using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Gui.AccountManager;

namespace Elemont.Gui.GameManager
{
    public partial class fManagerAccount : Form
    {
        public fManagerAccount()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null) currentFormChild.Close();
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fInfo());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fChangePassword());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fSystemManage());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fPlayerManage());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            (new BeginForm()).Show();
        }
    }
}
