using Quanlysinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlysinhvien.DAO
{
    class GiangVien_DAO:DataProvider
    {
        public DataTable loadKhoa()
        {
            string sqlString = @"select * from tblGiangVien";
            return GetData(sqlString);
        }
        public DataTable loadGV(string _loai, string _loc)
        {
            string sqlString = string.Format("select * from tblGiangVien where {0} = N'{1}'", _loai, _loc);
            return GetData(sqlString);
        }
        public DataTable loadGV2(string _loai, string _loc, string _loai2, string _loc2)
        {
            string sqlString = string.Format("select * from tblGiangVien where {0} = N'{1}' and {2}=N'{3}'", _loai, _loc, _loai2, _loc2);
            return GetData(sqlString);
        }
        public bool CheckExist(string _table, string _str)
        {
            if (_table == "tblKhoa")
                if (GetData("select* from tblKhoa where makhoa = '" + _str + "'").Rows.Count > 0)
                    return true;
            if (_table == "tblGiangVien")
                if (GetData("select* from tblGiangVien where magv = '" + _str + "'").Rows.Count > 0)
                    return true;
            return false;
        }
        public bool Insert(GiangVien _gv)
        {
            if (GetData("select* from tblGiangVien where magv = '" + _gv.magv + "'").Rows.Count > 0)
                return false;
            string sql = string.Format("Insert Into tblGiangVien(makhoa,bangcap,chucvu,tengiangvien,gioitinh,ngaysinh,dienthoai,email,diachi)values('{0}',N'{1}',N'{2}',N'{3}','{4}','{5}','{6}','{7}',N'{8}')",
                _gv.makhoa,_gv.bangcap,_gv.chucvu,_gv.tengiangvien,_gv.gioitinh,_gv.ngaysinh,_gv.dienthoai,_gv.email,_gv.diachi);

            Excute(sql);
            return true;
        }
        public int Delete(string mGV)
        {
            if (GetData("select* from tblLopHoc where magv = '" + mGV + "'").Rows.Count > 0 || GetData("select* from tblDiem where magv = '" + mGV + "'").Rows.Count > 0)
                return 1;
            if (!(GetData("select* from tblGiangVien where magv = '" + mGV + "'").Rows.Count > 0))
                return -1;
            Excute("delete from tblGiangVien where magv = '" + mGV + "'");
            return 0;
        }

        public void Update(GiangVien _gv)
        {
            string sql = string.Format("update tblGiangVien set makhoa = '{0}', bangcap = N'{1}', chucvu = N'{2}', tengiangvien = N'{3}', gioitinh = '{4}', ngaysinh = '{5}', dienthoai = '{6}', email = '{7}', diachi = N'{8}' where magv = '{9}'",
                _gv.makhoa, _gv.bangcap,_gv.chucvu,_gv.tengiangvien,_gv.gioitinh,_gv.ngaysinh,_gv.dienthoai,_gv.email,_gv.diachi,_gv.magv);
            Excute(sql);
        }
        public DataTable Search(string _timkiem, string _loaitk)
        {
            string sqlString = string.Format("select * from tblGiangVien where {0} like N'%{1}%'", _loaitk, _timkiem);
            return GetData(sqlString);
        }
    }
}
