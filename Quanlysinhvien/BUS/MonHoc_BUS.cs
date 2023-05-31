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
    class MonHoc_BUS
    {
        MonHoc_DAO mHDao = new MonHoc_DAO();
        public DataTable GetList()
        {
            return mHDao.loadMonHoc();
        }

        public bool CheckExist(string _table, string _str,string _where)
        {
            return mHDao.CheckExist(_table, _str,_where);

        }
        public bool Xoa(string mMH)
        {
            if (mHDao.Delete(mMH))
                return true;
            return false;
        }
        public bool Sua(MonHoc mH)
        {
            mHDao.Update(mH);
            return true;
        }
        public bool Them(MonHoc mH)
        {
            if (mHDao.Insert(mH))
                return true;
            return false;
        }
        public DataTable TimKiem(string _timkiem, string _loaitk)
        {
            return mHDao.Search(_timkiem, _loaitk);
        }
    }
}
