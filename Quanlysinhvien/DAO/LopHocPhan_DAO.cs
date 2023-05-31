using Quanlysinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlysinhvien.DAO
{
    class LopHocPhan_DAO:DataProvider
    {

        public DataTable loadLopHoc()
        {
            string sqlString = @"select * from tblLopHocPhan";
            return GetData(sqlString);
        }
        public bool CheckExist(string _table, string _str, string _where)
        {
            if (GetData(string.Format("select* from {0} where {1} = N'{2}'", _table, _where, _str)).Rows.Count > 0)
                return true;
            return false;
        }
        public DataTable loadLH(string _loai, string _loc)
        {
            string sqlString = string.Format("select * from tblLopHocPhan where {0} = N'{1}'", _loai, _loc);
            return GetData(sqlString);
        }
        public DataTable loadLH2(string _loai, string _loc, string _loai2, string _loc2)
        {
            string sqlString = string.Format("select * from tblLopHocPhan where {0} = N'{1}' and {2}=N'{3}'", _loai, _loc, _loai2, _loc2);
            return GetData(sqlString);
        }
        public DataTable loadLH3(string _loai, string _loc, string _loai2, string _loc2, string _loai3, string _loc3)
        {
            string sqlString = string.Format("select * from tblLopHocPhan where {0} = N'{1}' and {2}=N'{3}' and {4}=N'{5}'", _loai, _loc, _loai2, _loc2, _loai3, _loc3);
            return GetData(sqlString);
        }
        public bool Insert(LopHocPhan _lHP)
        {
            string sql = string.Format("Insert Into tblLopHoc values('{0}','{1}','{2}','{3}','{4}','{5}',N'{6}')",
                _lHP.malophocphan, _lHP.mamonhoc, _lHP.malop, _lHP.magv, _lHP.hocky, _lHP.namhoc, _lHP.trangthai);

            Excute(sql);
            return true;
        }
        public bool Delete(string mLHP)
        {
            Excute("delete from tblLopHocPhan where mamonhocphan = '" + mLHP + "'");
            return true;
        }

        public void Update(LopHocPhan _lHP)
        {
            string sql = string.Format("update tblLopHocPhan set mamonhoc = '{0}',malop = '{1}', magv = '{2}', hocky = '{3}', namhoc = '{4}', trangthai = N'{5}' where malophocphan = '{6}'",
                _lHP.mamonhoc, _lHP.malop, _lHP.magv, _lHP.hocky, _lHP.namhoc, _lHP.trangthai, _lHP.malophocphan);
            Excute(sql);
        }
        public DataTable Search(string _timkiem, string _loaitk)
        {
            string sqlString = string.Format("select * from tblLopHocPhan where {0} like N'%{1}%'", _loaitk, _timkiem);
            return GetData(sqlString);
        }
    }
}
