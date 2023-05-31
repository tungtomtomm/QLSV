using Quanlysinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlysinhvien.DAO
{
    class Khoa_DAO:DataProvider
    {
        public DataTable loadKhoa()
        {
            string sqlString = @"select * from tblKhoa";
            return GetData(sqlString);
        }
        public bool Insert(Khoa _k)
        {
            if (GetData("select* from tblKhoa where makhoa = '" + _k.makhoa + "'").Rows.Count > 0)
                return false;
            string sql = string.Format("Insert Into tblKhoa values('{0}',N'{1}')",
                _k.makhoa,_k.tenkhoa);

            Excute(sql);
            return true;
        }
        public bool Delete(string mK)
        {
            if (GetData("select* from tblGiangVien where makhoa = '" + mK + "'").Rows.Count > 0 || GetData("select* from tblMonHoc where makhoa = '" + mK + "'").Rows.Count > 0 || GetData("select* from tblNganh where makhoa = '" + mK + "'").Rows.Count > 0)
                return false;
            Excute("delete from tblKhoa where makhoa = '" + mK + "'");
            return true;
        }

        public void Update(Khoa _k)
        {
            string sql = string.Format("update tblKhoa set tenkhoa = N'{0}' where makhoa = '{1}'",
                _k.tenkhoa, _k.makhoa);
            Excute(sql);
        }
        public DataTable Search(string _timkiem, string _loaitk)
        {
            string sqlString = string.Format("select * from tblKhoa where {0} like N'%{1}%'", _loaitk, _timkiem);
            return GetData(sqlString);
        }
    }
}
