using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVienLVTN.DAO
{
   public class DataProvider
    {
        private static DataProvider instance; // ctrl r e

        private string connectionSTR = System.Configuration.ConfigurationManager.ConnectionStrings["QuanLyNhanVienLVTN"].ConnectionString;
       //private string connectionSTR = @"Data Source=localhost;Initial Catalog=Quanlynhanvien;Integrated Security=True";

        public static DataProvider Instance
        {
            get
            {
                if(instance == null) instance = new DataProvider();
                return DataProvider.instance;
            }

            private set
            {
                DataProvider.instance = value;
            }
        }

       private DataProvider() { }

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);

                connection.Close();
            }

            return data;

        }


    }
}
