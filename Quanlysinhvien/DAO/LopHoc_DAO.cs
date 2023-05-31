using Quanlysinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlysinhvien.DAO
{
    class LopHoc_DAO:DataProvider
    {
        public DataTable loadLopHoc()
        {
            string sqlString = @"select * from tblLopHoc";
            return GetData(sqlString);
        }
        public bool CheckExist(string _table, string _str, string _where)
        {
            if (GetData(string.Format("select* from {0} where {1} = N'{2}'", _table, _where, _str)).Rows.Count > 0)
                return true;
            return false;
        }
        public bool Insert(LopHoc _lH)
        {
            string sql = string.Format("Insert Into tblLopHoc values('{0}','{1}',N'{2}','{3}','{4}')",
                _lH.malop, _lH.magv, _lH.tenlop, _lH.manganh,_lH.namvaotruong);

            Excute(sql);
            return true;
        }
        public bool Delete(string mLH)
        {
            Excute("delete from tblLopHoc where mamonhoc = '" + mLH + "'");
            return true;
        }

        public void Update(LopHoc _lH)
        {
            string sql = string.Format("update tblLopHoc set manganh = '{0}',magv = '{1}', tenlop = N'{2}',namvaotruong = '{3}' where malop = '{4}'",
                _lH.manganh, _lH.magv, _lH.tenlop, _lH.namvaotruong, _lH.malop);
            Excute(sql);
        }
        public DataTable Search(string _timkiem, string _loaitk)
        {
            string sqlString = string.Format("select * from tblLopHoc where {0} like N'%{1}%'", _loaitk, _timkiem);
            return GetData(sqlString);
        }
    }
}
