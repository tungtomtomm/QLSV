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
    class Nganh_BUS
    {
        Nganh_DAO nDao = new Nganh_DAO();
        public DataTable GetList()
        {
            return nDao.loadNganh();
        }
        
        public bool CheckExist(string _table, string _str)
        {
            return nDao.CheckExist(_table, _str);

        }
        public int Xoa(string mGV)
        {
            if (nDao.Delete(mGV) == 1)
                return -1;
            if (nDao.Delete(mGV) == -1)
                return 1;
            return 0;
        }
        public bool Sua(Nganh n)
        {
            nDao.Update(n);
            return true;
        }
        public int Them(Nganh n)
        {
            if (!nDao.Insert(n))
                return -1;
            return 1;
        }
        public DataTable TimKiem(string _timkiem, string _loaitk)
        {
            return nDao.Search(_timkiem, _loaitk);
        }
    }
}
