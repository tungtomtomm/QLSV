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
    class Khoa_BUS
    {
        Khoa_DAO khoaDao = new Khoa_DAO();
        public DataTable GetList()
        {
            return khoaDao.loadKhoa();
        }
        public int Xoa(string mK)
        {
            if (!khoaDao.Delete(mK))
                return -1;
            return 1;
        }
        public bool Sua(Khoa k)
        {
            if (string.IsNullOrEmpty(k.makhoa))
                return false;
            khoaDao.Update(k);
            return true;
        }
        public int Them(Khoa k)
        {
            if (string.IsNullOrEmpty(k.makhoa))
                return 0;
            if (!khoaDao.Insert(k))
                return -1;
            return 1;
        }
        public DataTable TimKiem(string _timkiem, string _loaitk)
        {
            return khoaDao.Search(_timkiem, _loaitk);
        }
    }
}
