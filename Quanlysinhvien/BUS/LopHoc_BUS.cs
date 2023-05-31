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
    class LopHoc_BUS
    {
        LopHoc_DAO lHDao = new LopHoc_DAO();
        public DataTable GetList()
        {
            return lHDao.loadLopHoc();
        }

        public bool CheckExist(string _table, string _str, string _where)
        {
            return lHDao.CheckExist(_table, _str, _where);

        }
        public bool Xoa(string mLH)
        {
            if (lHDao.Delete(mLH))
                return true;
            return false;
        }
        public bool Sua(LopHoc mL)
        {
            lHDao.Update(mL);
            return true;
        }
        public bool Them(LopHoc lH)
        {
            if (lHDao.Insert(lH))
                return true;
            return false;
        }
        public DataTable TimKiem(string _timkiem, string _loaitk)
        {
            return lHDao.Search(_timkiem, _loaitk);
        }
    }
}
