using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Dao;
using Elemont.Dto;

namespace Elemont.Gui.AccountManager
{
    public partial class fPlayerManage : Form
    {
        public fPlayerManage()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            dGVInfo.DataSource = AccountDao.Instance.GetAllAccounts();
        }
        void Reset()
        {
            txtID.Text = txtName.Text = txtPassword.Text = txtUsername.Text = "";
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text=="")
            {
                LoadData();
            }
            else
            {if (AccountDao.Instance.CheckAccount(txtUsername.Text.ToString()))
                {
                    Account account = AccountDao.Instance.GetAccountByUsername(txtUsername.Text);
                    Account[] a = { account };
                    dGVInfo.DataSource = a;
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtName.Text == "" || txtPassword.Text =="" ||cbBType.SelectedItem==null)
            {
                MessageBox.Show("Please check again information", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Account _account = new Account();
                _account.UserName = txtUsername.Text;
                _account.Password = txtPassword.Text;
                _account.Name = txtName.Text;
                _account.Type = cbBType.SelectedIndex;
                if (AccountDao.Instance.AddAccount(_account))
                {
                    MessageBox.Show("Account successfully created", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadData();
            Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                Account _account = AccountDao.Instance.GetAccountById(int.Parse(txtID.Text));
                if (AccountDao.Instance.DeleteAccount(_account))
                {
                    MessageBox.Show("Delete successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else lblID.Text = "Please check the ID";
                LoadData();
                Reset();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AccountDao.Instance.CheckAccount(int.Parse(txtID.Text)))
                {
                    MessageBox.Show("This ID does not exist", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Account account = AccountDao.Instance.GetAccountById(int.Parse(txtID.Text));
                    account.UserName = txtUsername.Text;
                    account.Password = txtPassword.Text;
                    account.Name = txtName.Text;
                    account.Type = cbBType.SelectedIndex;
                    if (AccountDao.Instance.ChangeAccount(account))
                    { MessageBox.Show("Update successful", "", MessageBoxButtons.OK); }
                }
                LoadData();
                Reset();
            }
            catch { }
        }

        private void dGVInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtUsername.Text = dGVInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtPassword.Text = dGVInfo.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtName.Text = dGVInfo.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtID.Text = dGVInfo.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (dGVInfo.Rows[e.RowIndex].Cells[2].Value.ToString() == "1")
                {
                    cbBType.SelectedIndex = 1;
                }
                else cbBType.SelectedIndex = 0;
            }
            catch { }

        }
    }
}