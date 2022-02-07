using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Dao;
using Elemont.Dto;


namespace Elemont.Gui
{
    public partial class fSignup : Form
    {
        public fSignup()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtConfirm.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Please check the missing information", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (AccountDao.Instance.CheckAccount(txtUsername.Text))
            {
                MessageBox.Show("This account is already registered", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Text = txtUsername.Text = txtConfirm.Text = "";
                return;
            }
            if (txtPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("Please make sure your password match", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirm.Text = "";
                return;
            }
            Account _account = new Account();
            _account.UserName = txtUsername.Text;
            _account.Password = txtPassword.Text;
            _account.Type = 0;
            if (txtName.Text == "")
            {
                txtName.Text = txtUsername.Text;
            }
            _account.Name = txtName.Text;
            if (AccountDao.Instance.AddAccount(_account))
            {
                MessageBox.Show("Account successfully created", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Text = txtUsername.Text = txtConfirm.Text = "";
            }
        }
    }
}
