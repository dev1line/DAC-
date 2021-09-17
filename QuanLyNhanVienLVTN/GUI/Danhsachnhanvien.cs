using QuanLyNhanVienLVTN.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Data.Async;
using System.Collections.ObjectModel;

namespace QuanLyNhanVienLVTN
{
    public partial class Danhsachnhanvien : Form
    {
        public Danhsachnhanvien()
        {
            InitializeComponent();

            ThongTin();
        }

        void ThongTin()
        {

            string query = "select Danhsachnhanvien.ID,Danhsachnhom.Nhom,Danhsachnhanvien.ChungChi,Danhsachnhanvien.Ngayhethanchungchi,Danhsachnhanvien.Name,Danhsachnhanvien.Phone,Danhsachnhanvien.Email from Danhsachnhanvien INNER JOIN Danhsachnhom ON Danhsachnhanvien.NhomID = Danhsachnhom.ID";
            

            dtgvThongTinNhanVien.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtgvThongTinNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dtgvThongTinNhanVien.CurrentRow.Index;
            txbNhom.Text = dtgvThongTinNhanVien.Rows[i].Cells[1].Value.ToString();
            txbCC.Text = dtgvThongTinNhanVien.Rows[i].Cells[2].Value.ToString();
            dtpCRS.Text = dtgvThongTinNhanVien.Rows[i].Cells[3].Value.ToString();
            dtpRII.Text = dtgvThongTinNhanVien.Rows[i].Cells[4].Value.ToString();
            txbTen.Text = dtgvThongTinNhanVien.Rows[i].Cells[5].Value.ToString();
            txbSDT.Text = dtgvThongTinNhanVien.Rows[i].Cells[6].Value.ToString();
            txbEml.Text = dtgvThongTinNhanVien.Rows[i].Cells[7].Value.ToString();
        }
    
        private void btnThem_Click(object sender, EventArgs e)
        {
    
           // dtgvThongTinNhanVien.CommitEdit = "insert into Thongtinnhanvien values('" + txbNhom.Text + "','" + txbCC.Text + "','" + dtpCRS.Text + "','" + dtpRII.Text + "','" + txbTen.Text + "','" + txbSDT.Text + "','" + txbEml.Text + "')";
            //ThongTin();
            
        }

        private void Danhsachnhanvien_Load(object sender, EventArgs e)
        {

        }
    }
}
