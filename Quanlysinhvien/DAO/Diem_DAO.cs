using Quanlysinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlysinhvien.DAO
{
    class Diem_DAO:DataProvider
    {
        public DataTable load()
        {
            string sqlString = @"select * from tblDiem";
            return GetData(sqlString);
        }
        public bool CheckExist(string _table, string _str, string _where, string _str2, string _where2)
        {
            if (GetData(string.Format("select* from {0} where {1} = N'{2}' and {3} = N'{4}'", _table, _where, _str, _where2, _str2)).Rows.Count > 0)
                return true;
            return false;
        }
        public DataTable load1(string _loai, string _loc)
        {
            string sqlString = string.Format("select * from tblDiem where {0} = N'{1}'", _loai, _loc);
            return GetData(sqlString);
        }
        public DataTable load2(string _loai, string _loc, string _loai2, string _loc2)
        {
            string sqlString = string.Format("select * from tblDiem where {0} = N'{1}' and {2}=N'{3}'", _loai, _loc, _loai2, _loc2);
            return GetData(sqlString);
        }
        public DataTable load3(string _loai, string _loc, string _loai2, string _loc2, string _loai3, string _loc3)
        {
            string sqlString = string.Format("select * from tblDiem where {0} = N'{1}' and {2}=N'{3}' and {4}=N'{5}'", _loai, _loc, _loai2, _loc2, _loai3, _loc3);
            return GetData(sqlString);
        }
        public bool Insert(Diem _d)
        {
            string sql = string.Format("Insert Into tblDiem values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',N'{11}')",
                _d.malophocphan, _d.masv, _d.lanhoc, _d.thuongxuyen1, _d.thuongxuyen2, _d.tbthuongky, _d.duocduthi, _d.diemthilan1, _d.diemthilan2,_d.diemtongket,_d.xeploai,_d.ghichu);
            Excute(sql);
            return true;
        }
        public bool Dangky(Diem _d)
        {
            string sql = string.Format("Insert Into tblDiem(malophocphan, masv, lanhoc, ghichu) values('{0}','{1}','{2}',N'{3}')",
                _d.malophocphan, _d.masv, _d.lanhoc, _d.ghichu);
            Excute(sql);
            return true;
        }
        public bool Delete(string mlHP, string mSV)
        {
            Excute("delete from tblDiem where malophocphan = '" + mlHP + "' and masv = '"+mSV+ "'");
            return true;
        }

        public void Update(Diem _d)
        {
            string sql = string.Format("update tblDiem set lanhoc = '{0}',thuongxuyen1 = '{1}', thuongxuyen2 = '{2}', tbthuongky = '{3}', duocduthi = '{4}',diemthilan1 = '{5}',diemthilan2 = '{6}',diemtongket = '{7}',xeploai = '{8}',ghichu = N'{9}' where malophocphan = '{10}' and masv = '{11}'",
                _d.lanhoc, _d.thuongxuyen1, _d.thuongxuyen2, _d.tbthuongky, _d.duocduthi, _d.diemthilan1, _d.diemthilan2, _d.diemtongket, _d.xeploai, _d.ghichu, _d.malophocphan, _d.masv);
            Excute(sql);
        }
        public void Update1(Diem _d)
        {
            string sql = string.Format("update tblDiem set thuongxuyen1 = '{0}', thuongxuyen2 = '{1}', tbthuongky = '{2}', duocduthi = '{3}',diemthilan1 = '{4}',diemthilan2 = '{5}',diemtongket = '{6}',xeploai = '{7}',ghichu = N'{8}' where malophocphan = '{9}' and masv = '{10}'",
                _d.thuongxuyen1, _d.thuongxuyen2, _d.tbthuongky, _d.duocduthi, _d.diemthilan1, _d.diemthilan2, _d.diemtongket, _d.xeploai, _d.ghichu, _d.malophocphan, _d.masv);
            Excute(sql);
        }
        public DataTable Search(string _timkiem, string _loaitk)
        {
            string sqlString = string.Format("select * from tblDiem where {0} like N'%{1}%'", _loaitk, _timkiem);
            return GetData(sqlString);
        }
    }
}
