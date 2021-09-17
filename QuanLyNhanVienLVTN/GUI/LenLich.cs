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

        

        public lsvLenLich(DateTime date, PlanData job)
        {
            InitializeComponent();
            this.Date = date;
            this.Job = job;

            dtpkDate.Value = Date;
        }

        

        void showJobByDate(DateTime date)
        {

        }

        void showLich()
        {
           
        }

        

        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            showJobByDate((sender as DateTimePicker).Value);
        }


        private void lsvLenLich_Load(object sender, EventArgs e)
        {
            

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

       

        
    }
}
