﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Dto;

namespace Elemont.Gui.AccountManager
{
    public partial class fInfo : Form
    {
        Account _account;
        public fInfo(Account account)
        {
            InitializeComponent();
            _account = account;
        }

        private void fInfo_Load(object sender, EventArgs e)
        {
            lblUsername.Text = _account.UserName;
            lblID.Text = _account.AccountId.ToString();
            txtName.Text = _account.Name;
            if (_account.Type == 1) lblType.Text = "Admin";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _account.Name = txtName.Text;
        }
    }
}
