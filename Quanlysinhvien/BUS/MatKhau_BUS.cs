﻿using Quanlysinhvien.DAO;
using Quanlysinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlysinhvien.BUS
{
    class MatKhau_BUS
    {
        MatKhau_DAO mkDao = new MatKhau_DAO();
        public void DoiMatKhau(NguoiDung _tv)
        {
            mkDao.ChangePassWord(_tv);
        }
        public bool CheckExist(string _tdn, string _mkc)
        {
            return mkDao.CheckExist(_tdn, _mkc);

        }
    }
}
