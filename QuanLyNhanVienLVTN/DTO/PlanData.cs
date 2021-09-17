using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVienLVTN
{
    [Serializable]
    public class PlanData
    {
        private List<Planitem> job;

        public List<Planitem> Job
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
    }
}
