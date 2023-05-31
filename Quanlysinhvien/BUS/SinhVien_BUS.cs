using Quanlysinhvien.DAO;
using Quanlysinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlysinhvien.BUS
{
    class SinhVien_BUS
    {
        SinhVien_DAO sVDao = new SinhVien_DAO();
        public DataTable GetList()
        {
            return sVDao.load();
        }
        public DataTable GetListLoc(string _loai, string _loc)
        {
            return sVDao.load1(_loai, _loc);
        }
        public DataTable GetListLoc2(string _loai, string _loc, string _loai2, string _loc2)
        {
            return sVDao.load2(_loai, _loc, _loai2, _loc2);
        }
        public DataTable GetListLoc3(string _loai, string _loc, string _loai2, string _loc2, string _loai3, string _loc3)
        {
            return sVDao.load3(_loai, _loc, _loai2, _loc2, _loai3, _loc3);
        }

        public bool CheckExist(string _table, string _str, string _where)
        {
            return sVDao.CheckExist(_table, _str, _where);

        }
        public bool Xoa(string mSV)
        {
            if (sVDao.Delete(mSV))
                return true;
            return false;
        }
        public bool Sua(SinhVien sV)
        {
            sVDao.Update(sV);
            return true;
        }
        public bool Them(SinhVien sV)
        {
            if (sVDao.Insert(sV))
                return true;
            return false;
        }
        public DataTable TimKiem(string _timkiem, string _loaitk)
        {
            return sVDao.Search(_timkiem, _loaitk);
        }
    }
}
