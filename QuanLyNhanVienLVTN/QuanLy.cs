using QuanLyNhanVienLVTN.DAO;
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
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
            QuanLyWO();
            QuanLyTaiKhoanDangNhap();
        }

        void QuanLyWO()
        {
            string query = "select WO.ID,SoHieuMayBay.AC,WO.manoidung,WO.Noidung,WO.ChungChi,WO.Dungcu from WO inner join SoHieuMayBay on WO.AcID = SoHieuMayBay.ID";


           dtgvQuanLyWO.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }


        void QuanLyTaiKhoanDangNhap()
        {

            string query = "use Quanlynhanvien select UserName,Password from Account go";


            dtgvTkDangNhap.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
