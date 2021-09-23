using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNhanVienLVTN
{
    public partial class Login :Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txbUserName.Text != "" && txbPassWord.Text != "")
            {
                if (BLL.BLL_Handler.Instance.checkDangNhap(txbUserName.Text, txbPassWord.Text))
                {
                    QuanLyLichLamViec f = new QuanLyLichLamViec(this);
                    this.Hide();
                    f.ShowDialog();
                }else
                {
                    MessageBox.Show("Username hoặc password không đúng !");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập !");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn chắc chắn muốn thoát?","Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
