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
    class Diem_BUS
    {
        Diem_DAO sVDao = new Diem_DAO();
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

        public bool CheckExist(string _table, string _str, string _where, string _str2, string _where2)
        {
            return sVDao.CheckExist(_table, _str, _where, _str2, _where2);

        }
        public bool Xoa(string mLHP,string mSV)
        {
            if (sVDao.Delete(mLHP,mSV))
                return true;
            return false;
        }
        public bool Sua(Diem sV)
        {
            sVDao.Update(sV);
            return true;
        }
        public bool Sua1(Diem sV)
        {
            sVDao.Update1(sV);
            return true;
        }
        public bool Them(Diem sV)
        {
            if (sVDao.Insert(sV))
                return true;
            return false;
        }
        public bool Dangky(Diem sV)
        {
            if (sVDao.Dangky(sV))
                return true;
            return false;
        }
        public DataTable TimKiem(string _timkiem, string _loaitk)
        {
            return sVDao.Search(_timkiem, _loaitk);
        }
    }
}
