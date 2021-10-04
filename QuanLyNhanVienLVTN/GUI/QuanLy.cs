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
            SoHieuMayBay();
            Nhom();
            NgayNghi();
            if (BLL.BLL_Handler.role == "adminroster")
            {
                tabControl1.SelectedIndex = 0;

                tabControl1.TabPages.Remove(tabPage2);

                tabControl1.TabPages.Remove(tabPage3);
            } else
            {
                tabControl1.SelectedIndex = 1;
 
                tabControl1.TabPages.Remove(tabPage1);

                tabControl1.TabPages.Remove(tabPage4);

                tabControl1.TabPages.Remove(tabPage5);
            }

        }
        private void SoHieuMayBay()
        {
            dataGridViewSHMB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSHMB.ReadOnly = true;
            dataGridViewSHMB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void QuanLyWO()
        {
            dtgvQuanLyWO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvQuanLyWO.ReadOnly = true;
            dtgvQuanLyWO.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            int j = 0;
            foreach (DataRow i in BLL.BLL_Handler.Instance.getAllSHMB().Rows)
            {
                j++;
                comboBoxAC.Items.Add(new DTO.CBBItems { Key = j, Value = i.Field<string>("AC") });
            }
            comboBoxAC.SelectedIndex = 1;
        }

        private void NgayNghi()
        {
            dataGridViewNN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewNN.ReadOnly = true;
            dataGridViewNN.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            radioButton1.Checked = true;
            textBox1.ReadOnly = true;
           
         
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

        private void Nhom()
        {
            dataGridViewNHOM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewNHOM.ReadOnly = true;
            dataGridViewNHOM.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void show(string search)
        {
            dtgvTkDangNhap.DataSource = BLL.BLL_Handler.Instance.getAlltkDangNhap(search);
            dtgvQuanLyWO.DataSource = BLL.BLL_Handler.Instance.getAllQLWO(search);
            dataGridViewSHMB.DataSource = BLL.BLL_Handler.Instance.getAllSHMB();
            dataGridViewNHOM.DataSource = BLL.BLL_Handler.Instance.getAllNHOM();
            dataGridViewNN.DataSource = BLL.BLL_Handler.Instance.getAllDataNN(Convert.ToDateTime(dateTimePickerNN.Value).ToString("yyMMdd"), search);
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
           
            labelHLMK.Show();
            txtMK2.Show();
            labelTitle.Text = "Thêm dữ liệu";
            txtTenDN.Text = txtTHT.Text = txtMK.Text = txtMK2.Text = "";
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
            if (e.RowIndex == -1)
            {
                if (dtgvTkDangNhap.RowCount > 0)
                    itemRow = dtgvTkDangNhap.Rows[0];
                else MessageBox.Show("Không có dữ liệu để thao tác !"); ;
            }
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
                MessageBox.Show("Bạn nên chọn một đối tượng để sửa nó !");
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
                        if (BLL.BLL_Handler.Instance.checkExistAccount(txtTenDN.Text))
                        {
                            BLL.BLL_Handler.Instance.AddtkDangNhap(txtTenDN.Text, txtTHT.Text, type, txtMK.Text);
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
                       
                            MessageBox.Show("Chỉnh sửa tài khoản thành công !");
                        show("");
                        txtTenDN.Text = "";
                        txtTHT.Text = "";
                        txtMK.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Chỉnh sửa tài khoản thất bại !");
                    }
                  
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
                try
                {
                    BLL.BLL_Handler.Instance.DeltkDangNhap((string)itemRow.Cells[0].Value);
                }
                catch (SqlException ex) when (ex.Number == 547)
                {

                    MessageBox.Show("Không thể xóa Nhóm này vif tồn tại constraint !");
                }
                show("");
            }
            else
            {
                MessageBox.Show("You should choose one record to Delete it !");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBoxCC.Text != "" && richTextBoxDC.Text != "" && richTextBoxND.Text != "" && textBoxMND.Text != "")
            {
                // Add
                int AC = BLL.BLL_Handler.Instance.getACID(((DTO.CBBItems)comboBoxAC.SelectedItem).Value);
                BLL.BLL_Handler.Instance.AddWO(AC, textBoxCC.Text, richTextBoxDC.Text, richTextBoxND.Text, textBoxMND.Text);
                show("");
                textBoxCC.Text = "";
                richTextBoxDC.Text = "";
                richTextBoxND.Text = "";
                textBoxMND.Text = "";
                comboBoxAC.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cần thêm !");
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            show(txtSearch.Text);
        }

        private void dataGridViewSHMB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if (dataGridViewSHMB.RowCount > 0)
                    itemRow = dataGridViewSHMB.Rows[0];
                else MessageBox.Show("Không có dữ liệu để thao tác !"); ;
            }
            else itemRow = dataGridViewSHMB.Rows[e.RowIndex];
            if (dataGridViewSHMB.SelectedRows.Count > 1)
            {
                MessageBox.Show("Bạn nên chọn một hàng để sửa !");
            }
        }

        private void buttonAddSHMB_Click(object sender, EventArgs e)
        {
            if(textBoxSHMB.Text != "")
            {
                BLL.BLL_Handler.Instance.AddSHMB(textBoxSHMB.Text);
                show("");
                textBoxSHMB.Text = "";
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
            }
        }

        private void buttonDelSHMB_Click(object sender, EventArgs e)
        {
            if (itemRow != null)
            {     
                try
                {
                    BLL.BLL_Handler.Instance.DelSHMB(Convert.ToInt32(itemRow.Cells[0].Value));
                }
                catch (SqlException ex) when (ex.Number == 547)
                {

                    MessageBox.Show("Không thể xóa Nhóm này vì tồn tại constraint !");
                }
                show("");

            }
            else
            {
                MessageBox.Show("Bạn nên chọn một đối tượng để xóa nó !");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (itemRow != null)
            {
               
                try
                {
                    BLL.BLL_Handler.Instance.DelWO(Convert.ToInt32(itemRow.Cells[0].Value));    
                }
                catch (SqlException ex) when (ex.Number == 547)
                {

                    MessageBox.Show("Không thể xóa Nhóm này vì tồn tại constraint !");
                }
                show("");

            }
            else
            {
                MessageBox.Show("You should choose one record to Delete it !");
            }
        }

        private void dtgvQuanLyWO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if (dtgvQuanLyWO.RowCount > 0)
                    itemRow = dtgvQuanLyWO.Rows[0];
                else MessageBox.Show("Không có dữ liệu để thao tác !"); ;
            }
            else itemRow = dtgvQuanLyWO.Rows[e.RowIndex];
            if (dtgvQuanLyWO.SelectedRows.Count > 1)
            {
                MessageBox.Show("Bạn nên chọn một hàng để sửa !");
            }
        }

        private void buttonThemNhom_Click(object sender, EventArgs e)
        {
            if (textBoxNhom.Text != "")
            {
                BLL.BLL_Handler.Instance.AddNhom(textBoxNhom.Text);
                show("");
                textBoxSHMB.Text = "";
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
            }
        }

        private void buttonXoaNhom_Click(object sender, EventArgs e)
        {
            if (itemRow != null)
            {

                try
                {
                    BLL.BLL_Handler.Instance.DelNhom(Convert.ToInt32(itemRow.Cells[0].Value));
                } catch (SqlException ex) when (ex.Number == 547)
                {
                   
                    MessageBox.Show("Không thể xóa Nhóm này vì tồn tại constraint !");
                }
                show("");

            }
            else
            {
                MessageBox.Show("Bạn nên chọn một đối tượng để xóa nó !");
            }
        }

        private void dataGridViewNHOM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if (dataGridViewNHOM.RowCount > 0)
                    itemRow = dataGridViewNHOM.Rows[0];
                else MessageBox.Show("Không có dữ liệu để thao tác !"); ;
            }
            else itemRow = dataGridViewNHOM.Rows[e.RowIndex];
            if (dataGridViewNHOM.SelectedRows.Count > 1)
            {
                MessageBox.Show("Bạn nên chọn một hàng để sửa !");
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            show("");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dateTimePicker2.Enabled = false;
                dateTimePicker2.Visible = false;
                labelNN1.Text = "Ngày nghỉ:";
                labelNN2.Visible = false;
            }
            else
            {
                dateTimePicker2.Enabled = true;
                dateTimePicker2.Visible = true;
                labelNN1.Text = "Ngày bắt đầu:";
                labelNN2.Visible = true;
            }

        }

        private void dataGridViewNN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if (dataGridViewNHOM.RowCount > 0)
                    itemRow = dataGridViewNN.Rows[0];
                else MessageBox.Show("Không có dữ liệu để thao tác !"); ;
            }
            else
            {
                itemRow = dataGridViewNN.Rows[e.RowIndex];
                textBox1.Text = (string)itemRow.Cells[1].Value;
            }
            if (dataGridViewNN.SelectedRows.Count > 1)
            {
                MessageBox.Show("Bạn nên chọn một hàng để sửa !");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void buttonAddNN_Click(object sender, EventArgs e)
        {
            if (itemRow != null)
            {
                if(radioButton1.Checked)
                {
                    // Xin nghi 1 nggay
                    BLL.BLL_Handler.Instance.AddNN_1day(Convert.ToInt32(itemRow.Cells[0].Value), Convert.ToDateTime(dateTimePicker1.Value).ToString("yyMMdd"));
                    MessageBox.Show("Thêm 1 ngày nghỉ thành công !");
                    show("");
                }
                else {
                    // Xin nghi nhieu ngay
                    Console.WriteLine((dateTimePicker2.Value - dateTimePicker1.Value).Days.ToString());
                    for(int i = 0; i <= (dateTimePicker2.Value - dateTimePicker1.Value).Days; i++ )
                    {
                        BLL.BLL_Handler.Instance.DelNN(Convert.ToInt32(itemRow.Cells[0].Value), Convert.ToDateTime(dateTimePicker1.Value).AddDays(i).ToString("yyMMdd"));
                        BLL.BLL_Handler.Instance.AddNN_1day(Convert.ToInt32(itemRow.Cells[0].Value), Convert.ToDateTime(dateTimePicker1.Value).AddDays(i).ToString("yyMMdd"));
                    }
                    MessageBox.Show("Thêm nhiều ngày nghỉ thành công !");
                    show("");
                }
            }
            else MessageBox.Show("Vui lòng chọn 1 đối tượng để thao tác !");
        }

        private void buttonDelNN_Click(object sender, EventArgs e)
        {
            if (itemRow != null)
            {
                BLL.BLL_Handler.Instance.DelNN(Convert.ToInt32(itemRow.Cells[0].Value), Convert.ToDateTime(dateTimePickerNN.Value).ToString("yyMMdd"));
                MessageBox.Show("Xóa 1 ngày nghỉ thành công !");
                show("");
            }
            else MessageBox.Show("Vui lòng chọn 1 đối tượng để thao tác !");
        }
    }
}
