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
using DevExpress.Data.Async;
using System.Collections.ObjectModel;
using DevExpress.XtraEditors.Filtering.Templates;

namespace QuanLyNhanVienLVTN
{
    public partial class Danhsachnhanvien : Form
    {
        private DataGridViewRow itemRow;
        public Danhsachnhanvien()
        {
            InitializeComponent();

            ThongTin();
        }

        void ThongTin()
        {
            dtgvThongTinNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvThongTinNhanVien.ReadOnly = true;
            dtgvThongTinNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            int j = 0;
          foreach(DataRow i in BLL.BLL_Handler.Instance.getAllNHOM().Rows)
            {
                //j++;
                comboBoxNhom.Items.Add(new DTO.CBBItems { Key = i.Field<int>("ID"), Value = i.Field<string>("Nhom") });
            }
            comboBoxNhom.SelectedIndex = 1;
        }
        private void Show(string search)
        {
            dtgvThongTinNhanVien.DataSource = BLL.BLL_Handler.Instance.getAllTTNV(search);
        }
        private void Danhsachnhanvien_Load(object sender, EventArgs e)
        {
            Show("");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Show(txbTim.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txbCC.Text != "" && txbEml.Text != "" && txbSDT.Text != "" && txbTen.Text != "")
            {
                int ma = BLL.BLL_Handler.Instance.getNhomID(((DTO.CBBItems)comboBoxNhom.SelectedItem).Value);
                BLL.BLL_Handler.Instance.AddTTNV(ma, txbCC.Text, txbEml.Text, Convert.ToInt32(txbSDT.Text), txbTen.Text);
                Show("");
                txbCC.Text = "";
                txbEml.Text = "";
                txbSDT.Text = "";
                txbTen.Text = "";
                comboBoxNhom.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cần thêm !");
            }
        }

        private void txbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạncó thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (itemRow == null)
            {
                MessageBox.Show("You should choose one record to Edit it !");
            }
            else
            {
                
                if (txbCC.Text != "" && txbEml.Text != "" && txbSDT.Text != "" && txbTen.Text != "")
                {
                    BLL.BLL_Handler.Instance.UpdateNNTV(txbTen.Text, Convert.ToInt32(txbSDT.Text), txbEml.Text, txbCC.Text, ngayhethan.Value, ((DTO.CBBItems)comboBoxNhom.SelectedItem).Key, (int)itemRow.Cells[0].Value);
                    Show("");
                }

            }
        }

        private void dtgvThongTinNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) itemRow = dtgvThongTinNhanVien.Rows[0];
            else
            {
                itemRow = dtgvThongTinNhanVien.Rows[e.RowIndex];

                txbCC.Text = (string)itemRow.Cells[2].Value;
                txbEml.Text = (string)itemRow.Cells[6].Value;
                txbSDT.Text = Convert.ToString(itemRow.Cells[5].Value);
                txbTen.Text = (string)itemRow.Cells[4].Value;
             
                comboBoxNhom.SelectedIndex = comboBoxNhom.FindString((string)itemRow.Cells[1].Value);
  
                
                if (itemRow.Cells[3].Value != null)
                {
                    ngayhethan.Value = Convert.ToDateTime(itemRow.Cells[3].Value).Date;
                }


            } 
                
            if (dtgvThongTinNhanVien.SelectedRows.Count > 1)
            {
                MessageBox.Show("Bạn nên chọn một hàng để sửa !");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (itemRow != null)
            {
                try
                {
                    BLL.BLL_Handler.Instance.DelTTNV((int)itemRow.Cells[0].Value);
                }
                catch (SqlException ex) when (ex.Number == 547)
                {

                    MessageBox.Show("Không thể xóa Nhóm này vif tồn tại constraint !");
                }
                Show("");
            }
            else
            {
                MessageBox.Show("You should choose one record to Delete it !");
            }
        }
    }
}
