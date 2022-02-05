using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            if (tenDangNhap == "user" && matKhau == "123")
            {
                BeginForm fBegin = new BeginForm();
                fBegin.Show();
                Visible = false;
            }
            else MessageBox.Show("Tài khoản hoặc mật khẩu chưa chính xác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fSignup fDky = new fSignup();
            fDky.Show();
            Hide();
        }
    }
}
