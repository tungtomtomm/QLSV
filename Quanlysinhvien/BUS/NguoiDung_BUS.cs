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
    class NguoiDung_BUS
    {
        NguoiDung_DAO tvDao = new NguoiDung_DAO();
        public DataTable GetList()
        {
            return tvDao.loadNguoiDung();
        }
        public bool DangNhap(string _tk, string _mk)
        {
            if (tvDao.login(_tk, _mk) == true)
                return true;
            return false;
        }
        public int DangKy(NguoiDung _tv)
        {
            if (string.IsNullOrEmpty(_tv.username) || string.IsNullOrEmpty(_tv.password))
                return -1;
            if (tvDao.signup(_tv) == true)
                return 1;
            return 0;
        }
        public int Them(NguoiDung _tv)
        {
            if (!tvDao.Insert(_tv))
                return -1;
            return 1;
        }
        public bool Xoa(string mT)
        {
            if (!(tvDao.Delete(mT)))
                return false;
            return true;
        }
        public void sua(NguoiDung _tv)
        {
            tvDao.Update(_tv);
        }
        public bool CheckExist(string _table, string _str)
        {
            return tvDao.CheckExist(_table, _str);

        }
        public DataTable TimKiem(string _timkiem, string _loaitk)
        {
            return tvDao.Search(_timkiem, _loaitk);
        }
    }
}
