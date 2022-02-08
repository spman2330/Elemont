using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Gui.FormAdmin;

namespace Elemont.Gui.GameManager
{
    public partial class fGameEdit : Form
    {
        public fGameEdit()
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
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fSkillEdit());
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fElementEdit());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FSpeciesEdit());

        }
        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Pokeedit poke = new Pokeedit();
            this.Hide();
            poke.ShowDialog();
            this.Show();
        }
    }
}
