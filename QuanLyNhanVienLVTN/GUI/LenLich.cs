using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyNhanVienLVTN.DAO;

namespace QuanLyNhanVienLVTN
{
    public partial class lsvLenLich : Form

    {
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        private PlanData job;
        public PlanData Job
        {
            get
            {
                return job;
            }

            set
            {
                job = value;
            }
        }

        private DataGridViewRow itemRow;

        public lsvLenLich(DateTime date, PlanData job)
        {
            InitializeComponent();
            this.Date = date;
            this.Job = job;
            dtpkDate.Value = Date;
            init();
        }

        private void init()
        {
            switch(BLL.BLL_Handler.role)
            {
                case "adminroster":
                    {
                        buttonWO.Enabled = buttonGC.Enabled = buttonGhichu.Enabled = btnXoaWO.Enabled = false;
                        buttonWO.BackColor = buttonGC.BackColor = buttonGhichu.BackColor = btnXoaWO.BackColor = Color.Gray;
                        break;
                    }
                case "adminmcc":
                    {
                        buttonNV.Enabled = buttonGC.Enabled = btnThemNhanVien.Enabled = buttonXoaNhanVien.Enabled  = buttonGhichu.Enabled = false;
                        buttonNV.BackColor = buttonGC.BackColor = btnThemNhanVien.BackColor = buttonXoaNhanVien.BackColor = buttonGhichu.BackColor = Color.Gray;
                        break;
                    }
                case "staff":
                    {
                        buttonWO.Enabled = buttonNV.Enabled  = buttonXoaNhanVien.Enabled = btnThemNhanVien.Enabled  = btnXoaWO.Enabled = false;
                        buttonWO.BackColor = buttonNV.BackColor = buttonXoaNhanVien.BackColor = btnThemNhanVien.BackColor = btnXoaWO.BackColor = Color.Gray;
                        break;
                    }
            }
            int k = 0;
            if (BLL.BLL_Handler.Instance.getAllQLWO("").Rows.Count > 0)
            {
                foreach (DataRow i in BLL.BLL_Handler.Instance.getAllQLWO("").Rows)
                {
                    k++;
                    comboBoxWO.Items.Add(new DTO.CBBItems { Key = k, Value = "" + i.Field<string>("Mã nội dung") + " - " + i.Field<string>("Nội dung") });
                }

                comboBoxWO.SelectedIndex = 1;
            }
            
            
            
           if(BLL.BLL_Handler.Instance.getCaLam().Rows.Count > 0)
            {
                foreach (DataRow i in BLL.BLL_Handler.Instance.getCaLam().Rows)
                {
                    cbCalam.Items.Add(new DTO.CBBItems { Key = i.Field<int>("ID"), Value = i.Field<string>("Calam") });
                }
                cbCalam.SelectedIndex = 1;
            }


          

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void updateSelectNV()
        {
            comboBoxNV.Items.Clear();
            comboBoxNV.Text = "";
            if (BLL.BLL_Handler.Instance.getAlllichLVCBB(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd")).Rows.Count > 0)
            {
                foreach (DataRow i in BLL.BLL_Handler.Instance.getAlllichLVCBB(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd")).Rows)
                {
                    comboBoxNV.Items.Add(new DTO.CBBItems { Key = i.Field<int>("ID"), Value = "" + i.Field<string>("Chứng chỉ") + " - " + i.Field<string>("Tên nhân viên") });
                }
                comboBoxNV.SelectedIndex = 0;
            }
        }
        private void show(string search)
        {
            dataGridView1.DataSource = BLL.BLL_Handler.Instance.getAllLichWO(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd"));
            dataGridView2.DataSource = BLL.BLL_Handler.Instance.getAlllichLV(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd"), search);

            labelNVAll.Text = BLL.BLL_Handler.Instance.getNVPerDay(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd"), "").ToString();
           labelNVcaNgay.Text = BLL.BLL_Handler.Instance.getNVPerDay(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd"), "Ca ngày").ToString();
            labelNVCaDem.Text = BLL.BLL_Handler.Instance.getNVPerDay(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd"), "Ca đêm").ToString();

            cbNV.Items.Clear();
            cbNV.Text = "";
            Console.WriteLine("list:", BLL.BLL_Handler.Instance.getAllTTNVCBB(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd")).Rows.Count.ToString());
            if (BLL.BLL_Handler.Instance.getAllTTNVCBB(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd")).Rows.Count > 0 )
            {
                foreach (DataRow i in BLL.BLL_Handler.Instance.getAllTTNVCBB(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd")).Rows)
                {

                    cbNV.Items.Add(new DTO.CBBItems { Key = i.Field<int>("ID"), Value = "" + i.Field<string>("Nhóm") + " - " + i.Field<string>("Chứng chỉ") + " - " + i.Field<string>("Tên nhân viên") });

                }
                cbNV.SelectedIndex = 0;
            }
            updateSelectNV();
        }

        void showJobByDate(DateTime date)
        {
            Console.WriteLine(date);
        }


        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            showJobByDate((sender as DateTimePicker).Value);
        }

        private void btnPreviousDay_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(-1);
            updateSelectNV();
            show("");
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(1);
            updateSelectNV();
            show("");
        }

        private void buttonWO_Click(object sender, EventArgs e)
        {

            DataRow item = BLL.BLL_Handler.Instance.getAllQLWO("").Rows[((DTO.CBBItems)comboBoxWO.SelectedItem).Key - 1];
            Console.WriteLine(item.Field<string>("Mã nội dung"));
            //comboBoxWO.Items.RemoveAt(comboBoxWO.SelectedIndex);
            BLL.BLL_Handler.Instance.AddlichWO_WO(item.Field<string>("Số hiệu máy bay"), item.Field<string>("Mã nội dung"), item.Field<string>("Nội dung"), item.Field<string>("Chứng chỉ"), item.Field<string>("Dụng cụ"), Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd"));
            MessageBox.Show("Thêm WO thành công !");
            show("");
          
        }

        private void lsvLenLich_Load(object sender, EventArgs e)
        {
            show("");
        }

        private void buttonNV_Click(object sender, EventArgs e)
        {
            DataRow item = null;
           if(itemRow != null)
            {
                foreach (DataRow i in BLL.BLL_Handler.Instance.getAlllichLV(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd"), "").Rows)
                {
                    if (i.Field<int>("ID") == ((DTO.CBBItems)comboBoxNV.SelectedItem).Key)
                    {
                        item = i;
                    }
                }
               // DataRow item = BLL.BLL_Handler.Instance.getAlllichLV(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd"), "").Rows[((DTO.CBBItems)comboBoxNV.SelectedItem).Key - 1];
                Console.WriteLine(item.Field<string>("Tên nhân viên"));
                //comboBoxNV.Items.RemoveAt(comboBoxNV.SelectedIndex);
                BLL.BLL_Handler.Instance.AddlichWO_NV(Convert.ToInt32(itemRow.Cells[0].Value), item.Field<string>("Chứng chỉ"), item.Field<string>("Tên nhân viên"));
                MessageBox.Show("Thêm nhân viên thành công !");
                show("");
            }
            else MessageBox.Show("Vui lòng chọn một đối tượng để thao tác !");
        }

        private void buttonGC_Click(object sender, EventArgs e)
        {
           if (textBoxGC.Text != "" && itemRow != null)
            {
                try
                {
                    BLL.BLL_Handler.Instance.AddlichWO_GC(Convert.ToInt32(itemRow.Cells[0].Value), textBoxGC.Text);
                    dataGridView1.Rows[0].Selected = true;
                    Console.WriteLine(itemRow);
                    itemRow = dataGridView1.Rows[0];
                    Console.WriteLine(itemRow);
                    MessageBox.Show("Thêm ghi chú thành công !");
                    show("");
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Vui Lòng chọn 1 đối tượng để ghi chú !");
                    
                };
            } else
            {
                MessageBox.Show("Không được để trống ghi chú !");
            }

           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if (dataGridView1.RowCount > 0)
                    itemRow = dataGridView1.Rows[0];
                else MessageBox.Show("Không có dữ liệu để thao tác !"); ;
            }
            else itemRow = dataGridView1.Rows[e.RowIndex];
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Bạn nên chọn một hàng để sửa !");
            }
        }

        private void btnXoaWO_Click(object sender, EventArgs e)
        {
         if(itemRow != null)
            {
                BLL.BLL_Handler.Instance.DellichWO_WO(Convert.ToInt32(itemRow.Cells[0].Value));
                MessageBox.Show("Xóa WO thành công !");
                show("");
            }
             else MessageBox.Show("Vui lòng chọn một đối tượng để thao tác !");
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 )
            {
                if (dataGridView2.RowCount > 0) 
                itemRow = dataGridView2.Rows[0];
               else  MessageBox.Show("Không có dữ liệu để thao tác !"); ;
            }
            else itemRow = dataGridView2.Rows[e.RowIndex];
            if (dataGridView2.SelectedRows.Count > 1)
            {
                MessageBox.Show("Bạn nên chọn một hàng để sửa !");
            }
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            DataRow item = null;
            if (textBoxstartDay.Text != "" && textBoxendDay.Text != "")
            {
                foreach(DataRow i in BLL.BLL_Handler.Instance.getAllTTNV(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd")).Rows)
                {
                   if(i.Field<int>("ID") == ((DTO.CBBItems)cbNV.SelectedItem).Key)
                    {
                        item = i;
                    }
                }

                Console.WriteLine(item.Field<string>("Tên nhân viên"));
                BLL.BLL_Handler.Instance.AddlichLV(((DTO.CBBItems)cbCalam.SelectedItem).Value, item.Field<string>("Nhóm"), item.Field<string>("Chứng chỉ"), item.Field<string>("Tên nhân viên"), textBoxstartDay.Text, textBoxendDay.Text, Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd"));
                MessageBox.Show("Thêm nhân viên thành công !");
                show("");


            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
            }

        }

        private void buttonXoaNhanVien_Click(object sender, EventArgs e)
        {
            if(itemRow != null)
            {
                BLL.BLL_Handler.Instance.DellichLV(Convert.ToInt32(itemRow.Cells[0].Value));
                MessageBox.Show("Xóa nhân viên thành công !");
                show("");
            }
            else MessageBox.Show("Vui lòng chọn một đối tượng để thao tác !");
        }

        private void buttonGhichu_Click(object sender, EventArgs e)
        {
            if (textGhiChu.Text != "")
            {
                BLL.BLL_Handler.Instance.AddlichLV_GC(Convert.ToInt32(itemRow.Cells[0].Value), textGhiChu.Text);
                MessageBox.Show("Thêm ghi chú thành công !");
                show("");
            }else
            {
                MessageBox.Show("Không được để trống !");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            show(txbTim.Text);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateSelectNV();
        }

        private void buttonXoaNV_Click(object sender, EventArgs e)
        {
          if(itemRow != null)
            {
                DataRow item = BLL.BLL_Handler.Instance.getAllTTNV("").Rows[((DTO.CBBItems)comboBoxNV.SelectedItem).Key - 1];
                Console.WriteLine(item.Field<string>("Tên nhân viên"));
                //comboBoxNV.Items.RemoveAt(comboBoxNV.SelectedIndex);
                BLL.BLL_Handler.Instance.AddlichWO_NV(Convert.ToInt32(itemRow.Cells[0].Value), "", "");
                MessageBox.Show("Xóa nhân viên thành công !");
                show("");
            }
              else MessageBox.Show("Vui lòng chọn một đối tượng để thao tác !");
        }

        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = "Danh sách Lịch làm việc";

                // export header trong DataGridView
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
  
        private void buttonSaoLuu_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dataGridView2, saveFileDialog1.FileName);
            }
        }

        private void buttonSaoLuuWO_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dataGridView1, saveFileDialog1.FileName);
            }
        }
    }
}
