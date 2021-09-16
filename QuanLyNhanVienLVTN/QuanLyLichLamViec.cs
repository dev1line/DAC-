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
        public QuanLyLichLamViec()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LichLamViec f = new LichLamViec();
            f.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuanLyLichLamViec_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            BaoCao f = new BaoCao();
            f.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Danhsachnhanvien f = new Danhsachnhanvien();
            f.ShowDialog();
            this.Show();
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            QuanLy f = new QuanLy();
            f.ShowDialog();
            this.Show();
        }
    }
}
