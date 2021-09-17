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
        private DataGridViewRow itemRow;
        public QuanLy()
        {
            InitializeComponent();
            QuanLyWO();
            QuanLyTaiKhoanDangNhap();
        }

        private void QuanLyWO()
        {
            dtgvQuanLyWO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvQuanLyWO.ReadOnly = true;
            dtgvQuanLyWO.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            string query = "select WO.ID,SoHieuMayBay.AC,WO.manoidung,WO.Noidung,WO.ChungChi,WO.Dungcu from WO inner join SoHieuMayBay on WO.AcID = SoHieuMayBay.ID";
           dtgvQuanLyWO.DataSource = DataProvider.Instance.ExecuteQuery(query);

        }


        private void QuanLyTaiKhoanDangNhap()
        {
            dtgvTkDangNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvTkDangNhap.ReadOnly = true;
            dtgvTkDangNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           

            comboBoxRole.Items.Add(new DTO.CBBItems { Key = 0, Value = "adminroster" });
            comboBoxRole.Items.Add(new DTO.CBBItems { Key = 1, Value = "adminmcc" });
            comboBoxRole.Items.Add(new DTO.CBBItems { Key = 2, Value = "staff" });

            comboBoxRole.SelectedIndex = 2;
        }

        public void show(string search)
        {
            dtgvTkDangNhap.DataSource = BLL.BLL_Handler.Instance.getAlltkDangNhap(search);
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
           
            labelHLMK.Show();
            txtMK2.Show();
            labelTitle.Text = "Thêm dữ liệu";
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            show("");
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            show(textBoxSearch.Text);
        }

        private void dtgvTkDangNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) itemRow = dtgvTkDangNhap.Rows[0];
            else itemRow = dtgvTkDangNhap.Rows[e.RowIndex];
            if (dtgvTkDangNhap.SelectedRows.Count > 1)
            {
                MessageBox.Show("Bạn nên chọn một hàng để sửa !");
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            labelHLMK.Hide();
            txtMK2.Hide();
            labelTitle.Text = "Sửa dữ liệu";
            if (itemRow == null)
            {
                MessageBox.Show("You should choose one record to Edit it !");
            }
            else
            {

                txtTenDN.Text = (string)itemRow.Cells[0].Value;
                txtTHT.Text = (string)itemRow.Cells[1].Value;
                txtMK.Text = (string)itemRow.Cells[2].Value;
                switch((string)itemRow.Cells[3].Value)
                {
                    case "adminroster":
                        {
                            comboBoxRole.SelectedIndex = 0;
                            break;
                        }
                    case "adminmcc":
                        {
                            comboBoxRole.SelectedIndex = 1;
                            break;
                        }
                    case "staff":
                        {
                            comboBoxRole.SelectedIndex = 2;
                            break;
                        }
                }

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(labelHLMK.Visible)
            {
                // Them du lieu
                if (txtTenDN.Text != "" && txtMK.Text != "" && txtMK2.Text != "" && txtTHT.Text != "")
                {
                    if (txtMK.Text != txtMK2.Text)
                    {
                        MessageBox.Show("Mật khẩu không khớp");
                    }
                    else
                    {
                        int type = 0;
                        switch (((DTO.CBBItems)comboBoxRole.SelectedItem).Value)
                        {
                            case "adminroster":
                                {
                                    type = 2;
                                    break;
                                }
                            case "adminmcc":
                                {
                                    type = 1;
                                    break;
                                }
                            case "staff":
                                {
                                    type = 3;
                                    break;
                                }
                        }
                        if (BLL.BLL_Handler.Instance.AddtkDangNhap(txtTenDN.Text, txtTHT.Text, type, txtMK.Text))
                        {
                            MessageBox.Show("Thêm tài khoản thành công !");
                            txtTenDN.Text = "";
                            txtTHT.Text = "";
                            txtMK.Text ="";
                            txtMK2.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Thêm tài khoản thất bại !");
                        }
                        show("");
                    }

                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !");
                }
            }
            else
            {
                // Sua du lieu
                if (txtTenDN.Text != "" && txtMK.Text != "" && txtTHT.Text != "")
                {           
                    int type = 0;
                    switch (((DTO.CBBItems)comboBoxRole.SelectedItem).Value)
                    {
                        case "adminroster":
                            {
                                type = 2;
                                break;
                            }
                        case "adminmcc":
                            {
                                type = 1;
                                break;
                            }
                        case "staff":
                            {
                                type = 3;
                                break;
                            }
                    }
                    if (BLL.BLL_Handler.Instance.EdittkDangNhap(txtTenDN.Text, txtTHT.Text, type, txtMK.Text))
                    {
                        MessageBox.Show("Thêm tài khoản thành công !");
                        txtTenDN.Text = "";
                        txtTHT.Text = "";
                        txtMK.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Thêm tài khoản thất bại !");
                    }
                    show("");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTenDN.Text = "";
            txtTHT.Text = "";
            txtMK.Text = "";
            txtMK2.Text = "";
            comboBoxRole.SelectedIndex = 2;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (itemRow != null)
            {

                BLL.BLL_Handler.Instance.DeltkDangNhap((string)itemRow.Cells[0].Value);
                show("");
            }
            else
            {
                MessageBox.Show("You should choose one record to Delete it !");
            }
        }
    }
}
