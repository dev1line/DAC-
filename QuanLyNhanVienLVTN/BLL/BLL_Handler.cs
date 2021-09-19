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
        public static string username = "";
        public static string password = "";
        public static string tenhienthi = "";
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
            
            if (result.Rows.Count > 0)
            {
                role = result.Rows[0]["TypeName"].ToString();
                tenhienthi = result.Rows[0]["DisplayName"].ToString();
                username = result.Rows[0]["UserName"].ToString();
                password = result.Rows[0]["Password"].ToString();
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
        public DataTable getAllQLWO(string search)
        {
            if (search != "")
            {
                return DAO.DataProvider.Instance.ExecuteQuery($"select WO.ID[ID],SoHieuMayBay.AC[Số hiệu máy bay],WO.manoidung[Mã nội dung],WO.Noidung[Nội dung],WO.ChungChi[Chứng chỉ],WO.Dungcu[Dụng cụ] from WO inner join SoHieuMayBay on WO.AcID = SoHieuMayBay.ID WHERE SoHieuMayBay.AC LIKE '%{search}%' or WO.manoidung LIKE '%{search}%'");
            }
            string query = "select WO.ID[ID],SoHieuMayBay.AC[Số hiệu máy bay],WO.manoidung[Mã nội dung],WO.Noidung[Nội dung],WO.ChungChi[Chứng chỉ],WO.Dungcu[Dụng cụ] from WO inner join SoHieuMayBay on WO.AcID = SoHieuMayBay.ID";
            return DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable getAllSHMB()
        {
            
            string query = "select * from SoHieuMayBay";
            return DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        
            public DataTable getAllNHOM()
        {

            string query = "select * from Danhsachnhom ";
            return DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        public void updateTK(string user, string ten, string pass)
        {
            string query = $"UPDATE Account SET DisplayName = '{ten}', Password = '{pass}' WHERE UserName = '{user}'";
            DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        
         public void UpdateNNTV(string ten, double sdt, string email, string cc, string date, int nhom, int ma)
        {
            string query = $"UPDATE Danhsachnhanvien SET Name = '{ten}', Phone = {sdt}, Email = '{email}', Chungchi = '{cc}', Ngayhethanchungchi = '{date}', NhomID = {nhom} WHERE ID = {ma}";
            DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        public void AddSHMB(string text)
        {
            string query = $"INSERT INTO SoHieuMayBay (AC) values('{text}')";
            DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        
        public void AddNhom(string group)
        {
            string query = $"INSERT INTO Danhsachnhom (Nhom) values('{group}')";
            DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        public void DelSHMB(int ma)
        {
            string query = $"DELETE from SoHieuMayBay where ID = {ma}";
            DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        public void DelNhom(int ma)
        {
            string query = $"DELETE from Danhsachnhom where ID = {ma}";
            DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        public int getACID(string SHMB)
        {
            string query = $"select * from SoHieuMayBay where AC = '{SHMB}'";
            return DAO.DataProvider.Instance.ExecuteQuery(query).Rows[0].Field<int>("ID");
        }
        
        public int getNhomID(string Nhom)
        {
            string query = $"select * from Danhsachnhom where Nhom = '{Nhom}'";
            return DAO.DataProvider.Instance.ExecuteQuery(query).Rows[0].Field<int>("ID");
        }
        public DataTable AddWO(int AC, string CC, string DC, string ND, string MND)
        {
            string query = $"INSERT INTO WO (manoidung,Noidung,ChungChi,Dungcu,AcID) values('{MND}', '{ND}','{CC}','{DC}', {AC})";
            return DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        
        public DataTable AddTTNV(int ma, string CC, string email, double sdt, string ten, string Ngayhethanchungchi)
        {
            string query = $"INSERT INTO Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email, Ngayhethanchungchi) values({ma}, '{CC}','{ten}',{sdt}, '{email}', N'{Ngayhethanchungchi}')";
            return DAO.DataProvider.Instance.ExecuteQuery(query);
            
        }
        public void DelWO(int ma)
        {
            string query = $"DELETE from WO where ID = {ma}";
            DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        
             public void DelTTNV(int ma)
        {
            string query = $"DELETE from Danhsachnhanvien where ID = {ma}";
            DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable getAllTTNV(string search)
        {
            if (search != "")
            {
                return DAO.DataProvider.Instance.ExecuteQuery($"select Danhsachnhanvien.ID[ID],Danhsachnhom.Nhom[Nhóm],Danhsachnhanvien.ChungChi[Chứng chỉ],Danhsachnhanvien.Ngayhethanchungchi[Ngày hết hạn chứng chỉ],Danhsachnhanvien.Name[Tên nhân viên],Danhsachnhanvien.Phone[Số điện thoại],Danhsachnhanvien.Email[Email] from Danhsachnhanvien INNER JOIN Danhsachnhom ON Danhsachnhanvien.NhomID = Danhsachnhom.ID WHERE Danhsachnhom.Nhom LIKE '%{search}%' or Danhsachnhanvien.ChungChi LIKE '%{search}%' or Danhsachnhanvien.Name LIKE '%{search}%' or Danhsachnhanvien.Email LIKE '%{search}%'");
            }
            string query = "select Danhsachnhanvien.ID[ID],Danhsachnhom.Nhom[Nhóm],Danhsachnhanvien.ChungChi[Chứng chỉ],Danhsachnhanvien.Ngayhethanchungchi[Ngày hết hạn chứng chỉ],Danhsachnhanvien.Name[Tên nhân viên],Danhsachnhanvien.Phone[Số điện thoại],Danhsachnhanvien.Email[Email] from Danhsachnhanvien INNER JOIN Danhsachnhom ON Danhsachnhanvien.NhomID = Danhsachnhom.ID";
            return DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable getAllLichWO(string Ngay)
        {
            string query = $"SELECT * from lichWO where Ngay = '{Ngay}'";
            return DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        
             public DataTable getAlllichLV(string Ngay)
        {
            string query = $"SELECT * from lichLV where Ngay = '{Ngay}'";
            return DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        public bool AddlichWO_WO(string AC, string MND, string ND, string CC, string DC, string Ngay)
        {
            string query = $"INSERT INTO lichWO(AC, MaWO, noidung, Chungchi, Dungcu, Ngay ) VALUES('{AC}', '{MND}','{ND}','{CC}','{DC}', '{Ngay}')";
            DAO.DataProvider.Instance.ExecuteQuery(query);
            return true;
        }
        public bool AddlichWO_NV(int pos, string cc, string ten)
        {
            string query = $"UPDATE lichWO SET CCNV = '{cc}', NV = '{ten}' WHERE ID = {pos}";
            DAO.DataProvider.Instance.ExecuteQuery(query);
            return true;
        }

        public bool AddlichWO_GC(int pos, string gc)
        {
            string query = $"UPDATE lichWO SET Ghichu = '{gc}' WHERE ID = {pos}";
            DAO.DataProvider.Instance.ExecuteQuery(query);
            return true;
        }
        
        public bool DellichWO_WO(int pos)
        {
            string query = $"DELETE from lichWO WHERE ID = {pos}";
            DAO.DataProvider.Instance.ExecuteQuery(query);
            return true;
        }
        public bool DellichLV(int pos)
        {
            string query = $"DELETE from lichLV WHERE ID = {pos}";
            DAO.DataProvider.Instance.ExecuteQuery(query);
            return true;
        }
        public DataTable getCaLam()
        {
            string query = $"select * from Calamviec";
            return DAO.DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable getlichLV_ID(int pos)
        {
            string query = $"select * from Calamviec where ID = {pos}";
            return DAO.DataProvider.Instance.ExecuteQuery(query);
        }


        public bool AddlichLV(string ca, string nhom, string chungchi, string ten, string start, string end, string Ngay)
        {
            Console.WriteLine(ca + nhom + chungchi + ten + start + end + Ngay);
            string query = $"INSERT INTO lichLV (Calamviec,Nhom,Chungchi,Ten,tgcastart, tgcaend, Ngay) VALUES ('{ca}','{nhom}','{chungchi}','{ten}','{start}', '{end}', '{Ngay}')";
            DAO.DataProvider.Instance.ExecuteQuery(query);
            return true;
        }
        public bool AddlichLV_GC(int pos, string gc)
        {
            string query = $"UPDATE lichLV SET Ghichu = '{gc}' WHERE ID = {pos}";
            DAO.DataProvider.Instance.ExecuteQuery(query);
            return true;
        }
    }
}
