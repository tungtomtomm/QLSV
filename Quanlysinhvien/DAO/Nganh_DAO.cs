using Quanlysinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlysinhvien.DAO
{
    class Nganh_DAO:DataProvider
    {
        public DataTable loadNganh()
        {
            string sqlString = @"select * from tblNganh";
            return GetData(sqlString);
        }
        public bool CheckExist(string _table, string _str)
        {
            if (_table == "tblKhoa")
                if (GetData("select* from tblKhoa where makhoa = '" + _str + "'").Rows.Count > 0)
                    return true;
            if (_table == "tblNganh")
                if (GetData("select* from tblNganh where manganh = '" + _str + "'").Rows.Count > 0)
                    return true;
            return false;
        }
        public bool Insert(Nganh _n)
        {
            string sql = string.Format("Insert Into tblNganh(manganh,makhoa,tennganh)values('{0}','{1}',N'{2}')",
                _n.manganh, _n.makhoa, _n.tennganh);

            Excute(sql);
            return true;
        }
        public int Delete(string mN)
        {
            if (GetData("select* from tblLopHoc where manganh = '" + mN + "'").Rows.Count > 0)
                return 1;
            if (!(GetData("select* from tblNganh where manganh = '" + mN + "'").Rows.Count > 0))
                return -1;
            Excute("delete from tblNganh where manganh = '" + mN + "'");
            return 0;
        }

        public void Update(Nganh _n)
        {
            string sql = string.Format("update tblNganh set makhoa = '{0}', tennganh = N'{1}' where manganh = '{2}'",
                _n.makhoa, _n.tennganh, _n.manganh);
            Excute(sql);
        }
        public DataTable Search(string _timkiem, string _loaitk)
        {
            string sqlString = string.Format("select * from tblNganh where {0} like N'%{1}%'", _loaitk, _timkiem);
            return GetData(sqlString);
        }
    }
}
