using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Dto;

namespace Elemont.Gui.AccountManager
{
    public partial class fChangePassword : Form
    {
        Account _account;
        public fChangePassword(Account account)
        {
            InitializeComponent();
            _account = account;
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtCurrent.Text != _account.Password)
            {
                lblNote.Text = "Please check your current password";
                return;
            }
            else
            {
                if (txtNew != txtConfirm)
                {
                    lblNote.Text = "Please make sure your password match";
                    return;
                }
                else
                {
                    _account.Password = txtNew.Text;
                }
            }
        }
    }
}
