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
    class GiangVien_BUS
    {
        GiangVien_DAO gvDao = new GiangVien_DAO();
        public DataTable GetList()
        {
            return gvDao.loadKhoa();
        }
        public DataTable GetListLoc(string _loai, string _loc)
        {
            return gvDao.loadGV(_loai, _loc);
        }
        public DataTable GetListLoc2(string _loai, string _loc, string _loai2, string _loc2)
        {
            return gvDao.loadGV2(_loai, _loc,_loai2,_loc2);
        }
        public bool CheckExist(string _table, string _str)
        {
            return gvDao.CheckExist(_table, _str);

        }
        public int Xoa(string mGV)
        {
            if (gvDao.Delete(mGV)==1)
                return -1;
            if (gvDao.Delete(mGV) == -1)
                return 1;
            return 0;
        }
        public bool Sua(GiangVien gv)
        {
            gvDao.Update(gv);
            return true;
        }
        public int Them(GiangVien gv)
        {
            if (!gvDao.Insert(gv))
                return -1;
            return 1;
        }
        public DataTable TimKiem(string _timkiem, string _loaitk)
        {
            return gvDao.Search(_timkiem, _loaitk);
        }
    }
}
