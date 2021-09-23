using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVienLVTN
{
    public partial class fAccountProfile : Form
    {
        public fAccountProfile()
        {
            InitializeComponent();
            init();   
        }

        private void init()
        {
            BLL.BLL_Handler.Instance.checkDangNhap(BLL.BLL_Handler.username, BLL.BLL_Handler.password);
            txbUserName.Text = BLL.BLL_Handler.username;
            txbDisPlayName.Text = BLL.BLL_Handler.tenhienthi;
            txtPassWord.Text = BLL.BLL_Handler.password;
            txtPassWord.Enabled = false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txbDisPlayName.Text != "")
            {
                if(txbNewPassWord.Text != "" && txbReturnPassWord.Text == txbNewPassWord.Text)
                {
                    // Doi mat khau va ten hien thi
                    BLL.BLL_Handler.Instance.updateTK(txbUserName.Text, txbDisPlayName.Text, txbNewPassWord.Text);
                    MessageBox.Show("Đổi mật khẩu và tên hiển thị thành công !");
                }
                else
                {
                    // Doi ten hien thi
                    BLL.BLL_Handler.Instance.updateTK(txbUserName.Text, txbDisPlayName.Text, txtPassWord.Text);
                    MessageBox.Show("Đổi tên hiển thị thành công !");
                }
                this.Close();
            } else
            {
                MessageBox.Show("Vui lòng nhập ít nhất Tên hiển thị để được cập nhật !");
            }
        }

        private void fAccountProfile_Load(object sender, EventArgs e)
        {

        }
    }
}
