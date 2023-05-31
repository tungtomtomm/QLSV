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
    class LopHocPhan_BUS
    {
        LopHocPhan_DAO lHPDao = new LopHocPhan_DAO();
        public DataTable GetList()
        {
            return lHPDao.loadLopHoc();
        }
        public DataTable GetListLoc(string _loai, string _loc)
        {
            return lHPDao.loadLH(_loai, _loc);
        }
        public DataTable GetListLoc2(string _loai, string _loc, string _loai2, string _loc2)
        {
            return lHPDao.loadLH2(_loai, _loc, _loai2, _loc2);
        }
        public DataTable GetListLoc3(string _loai, string _loc, string _loai2, string _loc2, string _loai3, string _loc3)
        {
            return lHPDao.loadLH3(_loai, _loc, _loai2, _loc2, _loai3, _loc3);
        }

        public bool CheckExist(string _table, string _str, string _where)
        {
            return lHPDao.CheckExist(_table, _str, _where);

        }
        public bool Xoa(string mLHP)
        {
            if (lHPDao.Delete(mLHP))
                return true;
            return false;
        }
        public bool Sua(LopHocPhan mLHP)
        {
            lHPDao.Update(mLHP);
            return true;
        }
        public bool Them(LopHocPhan lHP)
        {
            if (lHPDao.Insert(lHP))
                return true;
            return false;
        }
        public DataTable TimKiem(string _timkiem, string _loaitk)
        {
            return lHPDao.Search(_timkiem, _loaitk);
        }
    }
}
