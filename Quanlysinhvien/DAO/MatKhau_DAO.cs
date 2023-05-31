using Quanlysinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlysinhvien.DAO
{
    class MatKhau_DAO:DataProvider
    {
        public void ChangePassWord(NguoiDung _tv)
        {
            string sql = string.Format("update tblNguoiDung set password = '{0}' where username = '{1}'", _tv.password, _tv.username);
            Excute(sql);
        }
        public bool CheckExist(string _tdn, string _mkc)
        {
            string sql = string.Format("select* from tblNguoiDung where password = '{0}' and username = '{1}'", _mkc, _tdn);
            if (GetData(sql).Rows.Count > 0)
                return true;
            return false;
        }
    }
}
