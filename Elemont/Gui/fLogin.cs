using System;
using Elemont.Dao;
using Elemont.Dto;
using System.Windows.Forms;

namespace Elemont.Gui
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string UN = txtUsername.Text;
            string PW = txtPassword.Text;
            if (AccountDao.Instance.CheckAccount(UN,PW))
            {
                Account account = AccountDao.Instance.GetAccount(UN, PW);
                BeginForm fBegin = new BeginForm(account);
                Hide();
                fBegin.ShowDialog();
                Show();
                txtPassword.Clear();
                txtUsername.Clear();
            }
            else MessageBox.Show("Please check your username and password", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            fSignup fDky = new fSignup();
            fDky.ShowDialog();
            Show();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
        }
    }
}
