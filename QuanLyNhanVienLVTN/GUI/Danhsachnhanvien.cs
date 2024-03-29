﻿using QuanLyNhanVienLVTN.DAO;
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
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace QuanLyNhanVienLVTN
{
    public partial class Danhsachnhanvien : Form
    {
        private DataGridViewRow itemRow;
        public Danhsachnhanvien()
        {
            InitializeComponent();

            ThongTin();

            if(BLL.BLL_Handler.role != "adminroster")
            {
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = false;
                btnSua.BackColor = btnThem.BackColor = btnXoa.BackColor = Color.Gray;

                txbCC.ReadOnly = txbEml.ReadOnly = txbSDT.ReadOnly = txbTen.ReadOnly = true;
                ngayhethan.Enabled = comboBoxNhom.Enabled = false;
            }

        }

        void ThongTin()
        {
            dtgvThongTinNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvThongTinNhanVien.ReadOnly = true;
            dtgvThongTinNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            
          foreach(DataRow i in BLL.BLL_Handler.Instance.getAllNHOM().Rows)
            {
                comboBoxNhom.Items.Add(new DTO.CBBItems { Key = i.Field<int>("ID"), Value = i.Field<string>("Nhóm") });
            }
            comboBoxNhom.SelectedIndex = 0;
        }
        private void Show(string search)
        {
            dtgvThongTinNhanVien.DataSource = BLL.BLL_Handler.Instance.getAllTTNV(search);
            try
            {

                foreach (DataGridViewRow row in dtgvThongTinNhanVien.Rows)
                {
                    if (Convert.ToDateTime(row.Cells["Ngày hết hạn chứng chỉ"].Value) >= DateTime.Now.Date)
                    {
                        row.Cells["Ngày hết hạn chứng chỉ"].Style.BackColor = Color.Yellow;
                    }
                    if (Convert.ToDateTime(row.Cells["Ngày hết hạn chứng chỉ"].Value) >= DateTime.Now.Date.AddDays(60))
                    {
                        row.Cells["Ngày hết hạn chứng chỉ"].Style.BackColor = Color.LightGreen;
                    }
                    if (Convert.ToDateTime(row.Cells["Ngày hết hạn chứng chỉ"].Value) < DateTime.Now.Date)
                    {
                        row.Cells["Ngày hết hạn chứng chỉ"].Style.BackColor = Color.LightSalmon;
                    }
                }

            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw;
            }
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
                BLL.BLL_Handler.Instance.AddTTNV(ma, txbCC.Text, txbEml.Text, Convert.ToDouble(txbSDT.Text), txbTen.Text, Convert.ToDateTime(ngayhethan.Value).ToString("yyMMdd"));
                MessageBox.Show("Thao tác thành công !");
                Show("");
                txbCC.Text = "";
                txbEml.Text = "";
                txbSDT.Text = "";
                txbTen.Text = "";
                comboBoxNhom.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cần thêm !");
            }
        }

        private void txbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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
                MessageBox.Show("Bạn nên chọn một đối tượng để sửa nó !");
            }
            else
            {
                
                if (txbCC.Text != "" && txbEml.Text != "" && txbSDT.Text != "" && txbTen.Text != "")
                {
                    BLL.BLL_Handler.Instance.UpdateNNTV(txbTen.Text, Convert.ToDouble(txbSDT.Text), txbEml.Text, txbCC.Text, Convert.ToDateTime(ngayhethan.Value).ToString("yyMMdd"), ((DTO.CBBItems)comboBoxNhom.SelectedItem).Key, Convert.ToInt32(itemRow.Cells[0].Value));
                    MessageBox.Show("Thao tác thành công !");
                    Show("");
                    txbCC.Text = "";
                    txbEml.Text = "";
                    txbSDT.Text = "";
                    txbTen.Text = "";
                    comboBoxNhom.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi sửa");    
                }

            }
        }

        private void dtgvThongTinNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if (dtgvThongTinNhanVien.RowCount > 0)
                    itemRow = dtgvThongTinNhanVien.Rows[0];
                else MessageBox.Show("Không có dữ liệu để thao tác !"); ;
            }
            /*if (e.RowIndex == -1) itemRow = dtgvThongTinNhanVien.Rows[0];*/
            else 
            {

                itemRow = dtgvThongTinNhanVien.Rows[e.RowIndex];
                txbCC.Text = (string)itemRow.Cells[2].Value;
                txbEml.Text = (string)itemRow.Cells[6].Value;
                txbSDT.Text = Convert.ToString(itemRow.Cells[5].Value);
                txbTen.Text = (string)itemRow.Cells[4].Value;
             
                comboBoxNhom.SelectedIndex = comboBoxNhom.FindString((string)itemRow.Cells[1].Value);
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
                    BLL.BLL_Handler.Instance.DelTTNV(Convert.ToInt32(itemRow.Cells[0].Value));
                    MessageBox.Show("Thao tác thành công !");
                }
                catch (SqlException ex) when (ex.Number == 547)
                {

                    MessageBox.Show("Không thể xóa Nhóm này vì tồn tại constraint !");
                }
                Show("");
                txbCC.Text = "";
                txbEml.Text = "";
                txbSDT.Text = "";
                txbTen.Text = "";
                comboBoxNhom.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Bạn nên chọn một đối tượng để sửa nó !");
            }
        }

       

        private void dtgvThongTinNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*foreach (DataGridViewRow row in dtgvThongTinNhanVien.Rows)
            {
                if (Convert.ToDateTime(row.Cells["Ngày hết hạn chứng chỉ"].Value) > DateTime.Now.Date)
                {
                    row.Cells["Ngày hết hạn chứng chỉ"].Style.BackColor = Color.Yellow;
                }
                if (Convert.ToDateTime(row.Cells["Ngày hết hạn chứng chỉ"].Value) > DateTime.Now.Date.AddDays(60))
                {
                    row.Cells["Ngày hết hạn chứng chỉ"].Style.BackColor = Color.LightGreen;
                }
                if (Convert.ToDateTime(row.Cells["Ngày hết hạn chứng chỉ"].Value) < DateTime.Now.Date)
                {
                    row.Cells["Ngày hết hạn chứng chỉ"].Style.BackColor = Color.LightSalmon;
                }
            }*/
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txbTen.Text = txbCC.Text = txbEml.Text = txbSDT.Text = "";
            comboBoxNhom.SelectedIndex = 0;
        }
    }
}
