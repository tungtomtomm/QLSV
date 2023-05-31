using Quanlysinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlysinhvien.DAO
{
    class SinhVien_DAO:DataProvider
    {
        public DataTable load()
        {
            string sqlString = @"select * from tblSinhVien";
            return GetData(sqlString);
        }
        public bool CheckExist(string _table, string _str, string _where)
        {
            if (GetData(string.Format("select* from {0} where {1} = N'{2}'", _table, _where, _str)).Rows.Count > 0)
                return true;
            return false;
        }
        public DataTable load1(string _loai, string _loc)
        {
            string sqlString = string.Format("select * from tblSinhVien where {0} = N'{1}'", _loai, _loc);
            return GetData(sqlString);
        }
        public DataTable load2(string _loai, string _loc, string _loai2, string _loc2)
        {
            string sqlString = string.Format("select * from tblSinhVien where {0} = N'{1}' and {2}=N'{3}'", _loai, _loc, _loai2, _loc2);
            return GetData(sqlString);
        }
        public DataTable load3(string _loai, string _loc, string _loai2, string _loc2, string _loai3, string _loc3)
        {
            string sqlString = string.Format("select * from tblSinhVien where {0} = N'{1}' and {2}=N'{3}' and {4}=N'{5}'", _loai, _loc, _loai2, _loc2, _loai3, _loc3);
            return GetData(sqlString);
        }
        public bool Insert(SinhVien _sV)
        {
            string sql = string.Format("Insert Into tblSinhVien values('{0}',N'{1}','{2}','{3}','{4}',N'{5}',N'{6}','{7}',N'{8}')",
                _sV.masv, _sV.tensv, _sV.malop, _sV.dienthoai, _sV.email, _sV.quequan, _sV.ngaysinh,_sV.gioitinh, _sV.trangthai);
            string sql2 = string.Format("Insert Into tblNguoiDung values('{0}','{1}','{2}')",
                _sV.masv,"123456","1");
            Excute(sql);
            Excute(sql2);
            return true;
        }
        public bool Delete(string mSV)
        {
            Excute("delete from tblSinhVien where masv = '" + mSV + "'");
            return true;
        }

        public void Update(SinhVien _sV)
        {
            string sql = string.Format("update tblSinhVien set tensv = N'{0}',malop = '{1}', dienthoai = '{2}', email = '{3}', quequan = N'{4}',ngaysinh = '{5}',gioitinh = '{6}',trangthai = N'{7}' where masv = '{8}'",
                _sV.tensv, _sV.malop, _sV.dienthoai, _sV.email, _sV.quequan, _sV.ngaysinh, _sV.gioitinh, _sV.trangthai, _sV.masv);
            Excute(sql);
        }
        public DataTable Search(string _timkiem, string _loaitk)
        {
            string sqlString = string.Format("select * from tblSinhVien where {0} like N'%{1}%'", _loaitk, _timkiem);
            return GetData(sqlString);
        }
    }
}
