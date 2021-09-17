using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyNhanVienLVTN.BLL
{
    public class BLL_Handler
    {
        private static BLL_Handler _Instance;
        public static string role = ""; 
        public static BLL_Handler Instance {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new BLL_Handler();
                }
                return _Instance;
            }
            private set { }
        }

        public BLL_Handler() { }

        public bool checkDangNhap(string user, string pass)
        {
       
            string query = $"Select * from Account INNER JOIN AccountType ON Account.TypeID = AccountType.ID WHERE UserName ='{user}' and Password = '{pass}'";
            DataTable result = DAO.DataProvider.Instance.ExecuteQuery(query);
            role = result.Rows[0]["TypeName"].ToString();
            if (result.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool AddtkDangNhap(string user,string ten, int type, string pass)
        {
            string query = $"INSERT INTO Account (UserName, DisplayName, Password, TypeID) values('{user}', '{ten}', '{pass}', {type})";
             DAO.DataProvider.Instance.ExecuteQuery(query);
            return true;
        }
        public bool EdittkDangNhap(string user, string ten, int type, string pass)
        {
            string query = $"UPDATE Account SET DisplayName='{ten}', Password='{pass}', TypeID={type} where UserName = '{user}'";
             DAO.DataProvider.Instance.ExecuteQuery(query);
            return true;
        }
        public bool DeltkDangNhap(string user)
        {
            string query = $"DELETE from Account where UserName = '{user}'";
             DAO.DataProvider.Instance.ExecuteQuery(query);
            return true;
        }
        public DataTable getAlltkDangNhap(string search)
        {
            if (search != "")
            {
                return DAO.DataProvider.Instance.ExecuteQuery($"use Quanlynhanvien select UserName[Tên Đăng Nhập], DisplayName[Tên Hiển Thị], Password[Mật Khẩu], TypeName[Chức vụ] from Account INNER JOIN AccountType ON Account.TypeID = AccountType.ID WHERE Account.UserName LIKE '%{search}%' or Account.DisplayName LIKE '%{search}%'");
            }
            string query = "use Quanlynhanvien select UserName[Tên Đăng Nhập], DisplayName[Tên Hiển Thị], Password[Mật Khẩu], TypeName[Chức vụ] from Account INNER JOIN AccountType ON Account.TypeID = AccountType.ID";
            return DAO.DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
