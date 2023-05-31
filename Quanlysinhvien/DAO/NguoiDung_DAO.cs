using Quanlysinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlysinhvien.DAO
{
    class NguoiDung_DAO:DataProvider
    {
        public DataTable loadNguoiDung()
        {
            string sqlString = @"select * from tblNguoiDung where phanquyen='1'";
            return GetData(sqlString);
        }
        public bool login(string _tk, string _mk)
        {
            if (GetData("select* from tblNguoiDung where username = '" + _tk + "' and password = '" + _mk + "'").Rows.Count > 0)
                return true;
            return false;
        }
        public bool CheckExist(string _table, string _str)
        {
            if (_table == "tblNguoiDung")
                if (GetData("select* from tblNguoiDung where username = '" + _str + "'").Rows.Count > 0)
                    return true;
            return false;
        }
        public bool signup(NguoiDung _tv)
        {
            if (GetData("select* from tblNguoiDung where username = '" + _tv.username + "'").Rows.Count > 0)
                return false;
            string sql = string.Format("Insert Into tblNguoiDung values('{0}','{1}','{2}')",
                 _tv.username, _tv.password, 1);
            Excute(sql);
            return true;
        }
        public bool Insert(NguoiDung _tv)
        {
            if (GetData("select* from tblNguoiDung where username = '" + _tv.username + "'").Rows.Count > 0)
                return false;
            string sql = string.Format("Insert Into tblNguoiDung values('{0}','{1}','{2}')",
                 _tv.username, _tv.password, _tv.phanquyen);
            Excute(sql);
            return true;
        }
        public void Update(NguoiDung _tv)
        {
            string sql = string.Format("update tblNguoiDung set password = N'{0}', phanquyen = '{1}'  where username = '{2}'",
                _tv.password, _tv.phanquyen, _tv.username);
            Excute(sql);
        }
        public bool Delete(string mT)
        {
            if (!(GetData("select* from tblNguoiDung where username = '" + mT + "'").Rows.Count > 0))
                return false;
            Excute("delete from tblNguoiDung where username = '" + mT + "'");
            return true;
        }
        public DataTable Search(string _timkiem, string _loaitk)
        {
            string sqlString = string.Format("select * from tblNguoiDung where {0} like N'%{1}%'", _loaitk, _timkiem);
            return GetData(sqlString);
        }
    }
}
