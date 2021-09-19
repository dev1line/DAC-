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
            foreach(DataRow i in BLL.BLL_Handler.Instance.getAllQLWO("").Rows)
            {
                k++;
                comboBoxWO.Items.Add(new DTO.CBBItems { Key = k, Value = "" + i.Field<string>("Mã nội dung") + "-" + i.Field<string>("Nội dung") });
            }

            comboBoxWO.SelectedIndex = 1;
            int j = 0;
            foreach (DataRow i in BLL.BLL_Handler.Instance.getAllTTNV("").Rows)
            {
                j++;
                comboBoxNV.Items.Add(new DTO.CBBItems { Key = j, Value = "" + i.Field<string>("Chứng chỉ") + "-" + i.Field<string>("Tên nhân viên") });
            }
            comboBoxNV.SelectedIndex = 1;
            
            foreach (DataRow i in BLL.BLL_Handler.Instance.getCaLam().Rows)
            {
                cbCalam.Items.Add(new DTO.CBBItems { Key = i.Field<int>("ID"), Value = i.Field<string>("Calam") });
            }
            cbCalam.SelectedIndex = 1;
            int s = 0;
            foreach (DataRow i in BLL.BLL_Handler.Instance.getAllTTNV("").Rows)
            {
                s++;
                cbNV.Items.Add(new DTO.CBBItems { Key = s, Value = "" + i.Field<string>("Nhóm") + "-" + i.Field<string>("Chứng chỉ") + "-" + i.Field<string>("Tên nhân viên") });
            }
            cbNV.SelectedIndex = 1;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void show()
        {
            dataGridView1.DataSource = BLL.BLL_Handler.Instance.getAllLichWO(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd"));
            dataGridView2.DataSource = BLL.BLL_Handler.Instance.getAlllichLV(Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd"));
        }

        void showJobByDate(DateTime date)
        {
            Console.WriteLine(date);
        }


        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            showJobByDate((sender as DateTimePicker).Value);
        }


       /* List<Planitem> tabcontrol1 (DateTime date)
        {
            return Job.job.Where(p=>p.Date.Year == date.Year && p.Date.Month == date.Month && p.Date.Day == date.Day).ToList();
        }
        */

        private void btnPreviousDay_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(-1);
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(1);
        }

        private void buttonWO_Click(object sender, EventArgs e)
        {
            DataRow item = BLL.BLL_Handler.Instance.getAllQLWO("").Rows[((DTO.CBBItems)comboBoxWO.SelectedItem).Key - 1];
            Console.WriteLine(item.Field<string>("Mã nội dung"));
            //comboBoxWO.Items.RemoveAt(comboBoxWO.SelectedIndex);
            BLL.BLL_Handler.Instance.AddlichWO_WO(item.Field<string>("Số hiệu máy bay"), item.Field<string>("Mã nội dung"), item.Field<string>("Nội dung"), item.Field<string>("Chứng chỉ"), item.Field<string>("Dụng cụ"), Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd"));
            show();
        }

        private void lsvLenLich_Load(object sender, EventArgs e)
        {
            show();
        }

        private void buttonNV_Click(object sender, EventArgs e)
        {
            DataRow item = BLL.BLL_Handler.Instance.getAllTTNV("").Rows[((DTO.CBBItems)comboBoxNV.SelectedItem).Key - 1];
            Console.WriteLine(item.Field<string>("Tên nhân viên"));
            //comboBoxNV.Items.RemoveAt(comboBoxNV.SelectedIndex);
            BLL.BLL_Handler.Instance.AddlichWO_NV(Convert.ToInt32(itemRow.Cells[0].Value), item.Field<string>("Chứng chỉ"), item.Field<string>("Tên nhân viên"));
            show();
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
                    show();
                }
                catch (System.Exception ex)
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
            if (e.RowIndex == -1) itemRow = dataGridView1.Rows[0];
            else itemRow = dataGridView1.Rows[e.RowIndex];
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Bạn nên chọn một hàng để sửa !");
            }
        }

        private void btnXoaWO_Click(object sender, EventArgs e)
        {
            BLL.BLL_Handler.Instance.DellichWO_WO(Convert.ToInt32(itemRow.Cells[0].Value));
            show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) itemRow = dataGridView2.Rows[0];
            else itemRow = dataGridView2.Rows[e.RowIndex];
            if (dataGridView2.SelectedRows.Count > 1)
            {
                MessageBox.Show("Bạn nên chọn một hàng để sửa !");
            }
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            if(textBoxstartDay.Text != "" && textBoxendDay.Text != "")
            {
               
                DataRow item = BLL.BLL_Handler.Instance.getAllTTNV("").Rows[((DTO.CBBItems)cbNV.SelectedItem).Key - 1];
                Console.WriteLine(item.Field<string>("Tên nhân viên"));
                BLL.BLL_Handler.Instance.AddlichLV(((DTO.CBBItems)cbCalam.SelectedItem).Value,item.Field<string>("Nhóm"), item.Field<string>("Chứng chỉ"), item.Field<string>("Tên nhân viên"), textBoxstartDay.Text, textBoxendDay.Text, Convert.ToDateTime(dtpkDate.Value).ToString("yyMMdd"));
                show();
            } else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
            }
        }

        private void buttonXoaNhanVien_Click(object sender, EventArgs e)
        {
            if(itemRow != null)
            {
                BLL.BLL_Handler.Instance.DellichLV(Convert.ToInt32(itemRow.Cells[0].Value));
                show();
            }
        }

        private void buttonGhichu_Click(object sender, EventArgs e)
        {
            if (textGhiChu.Text != "")
            {
                BLL.BLL_Handler.Instance.AddlichLV_GC(Convert.ToInt32(itemRow.Cells[0].Value), textGhiChu.Text);
                show();
            }else
            {
                MessageBox.Show("Không được để trống !");
            }
        }
    }
}
