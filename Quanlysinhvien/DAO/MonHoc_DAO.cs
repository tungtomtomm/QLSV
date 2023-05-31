using Quanlysinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlysinhvien.DAO
{
    class MonHoc_DAO:DataProvider
    {
        public DataTable loadMonHoc()
        {
            string sqlString = @"select * from tblMonHoc";
            return GetData(sqlString);
        }
        public bool CheckExist(string _table, string _str, string _where)
        {
            if (GetData(string.Format("select* from {0} where {1} = N'{2}'",_table,_where,_str)).Rows.Count > 0)
                    return true;
            return false;
        }
        public bool Insert(MonHoc _mH)
        {
            string sql = string.Format("Insert Into tblMonHoc values('{0}',N'{1}','{2}','{3}')",
                _mH.mamonhoc, _mH.tenmonhoc,_mH.sotinchi,_mH.makhoa);

            Excute(sql);
            return true;
        }
        public bool Delete(string mMH)
        {
            Excute("delete from tblMonHoc where mamonhoc = '" + mMH + "'");
            return true;
        }

        public void Update(MonHoc _mH)
        {
            string sql = string.Format("update tblMonHoc set makhoa = '{0}', tenmonhoc = N'{1}',sotinchi = '{2}' where mamonhoc = '{3}'",
                _mH.makhoa, _mH.tenmonhoc, _mH.sotinchi,_mH.mamonhoc);
            Excute(sql);
        }
        public DataTable Search(string _timkiem, string _loaitk)
        {
            string sqlString = string.Format("select * from tblMonHoc where {0} like N'%{1}%'", _loaitk, _timkiem);
            return GetData(sqlString);
        }
    }
}
