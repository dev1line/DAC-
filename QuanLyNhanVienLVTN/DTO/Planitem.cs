using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVienLVTN
{
   public class Planitem
    {
        private DateTime date;
        private string job;

        public string Job
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

        private Point fromTime;

        public Point FromTime
        {
            get
            {
                return fromTime;
            }

            set
            {
                fromTime = value;
            }
        }
        private Point toTime;

        public Point ToTime
        {
            get
            {
                return toTime;
            }

            set
            {
                toTime = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

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

        private string status;
        

    }

}
