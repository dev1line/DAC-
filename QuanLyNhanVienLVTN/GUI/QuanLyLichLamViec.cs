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
    public partial class QuanLyLichLamViec : Form
    {
        public delegate void delegater(string mess);
        public delegater action { get; set; }
        Form mylogin;
        public QuanLyLichLamViec(Form login)
        {
            InitializeComponent();
            mylogin = login;
            init();
        }

        private void init()
        {
            switch(BLL.BLL_Handler.role)
            {
                case "adminroster":
                    {
                        buttonGBC.Enabled = false;
                        break;
                    }
                case "admincc":
                    {
                        buttonGBC.Enabled = false;
                        buttonTTNV.Enabled = false;
                        break;
                    }
                case "staff":
                    {
                        buttonQL.Enabled = false;
                        break;
                    }
            }
        }
  

        private void buttonLLV_Click(object sender, EventArgs e)
        {
            LichLamViec f = new LichLamViec();
            f.ShowDialog();
            this.Show();
        }

        private void buttonQLTK_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
            this.Show();
        }

        private void buttonDX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuanLyLichLamViec_Load(object sender, EventArgs e)
        {

        }

        private void buttonGBC_Click(object sender, EventArgs e)
        {
            BaoCao f = new BaoCao();
            f.ShowDialog();
            this.Show();
        }

        private void buttonTTNV_Click(object sender, EventArgs e)
        {
            Danhsachnhanvien f = new Danhsachnhanvien();
            f.ShowDialog();
            this.Show();
        }

        private void buttonQL_Click(object sender, EventArgs e)
        {
            QuanLy f = new QuanLy();
            f.ShowDialog();
            this.Show();
        }


        private void QuanLyLichLamViec_FormClosed(object sender, FormClosedEventArgs e)
        {
            mylogin.Close();
        }
    }
}
