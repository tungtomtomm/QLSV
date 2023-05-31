using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Quanlysinhvien.BUS;
using Quanlysinhvien.DTO;

namespace Quanlysinhvien.GUI
{
    public partial class ucFrmDoiMatKhau : DevExpress.XtraEditors.XtraUserControl
    {
        MatKhau_BUS mkBus = new MatKhau_BUS();
        private string tdn;
        public ucFrmDoiMatKhau(string _tdn)
        {
            InitializeComponent();
            tdn = _tdn;
        }

        private void btn_CN_Click(object sender, EventArgs e)
        {
            lb_KhongKhop.Visible = false;
            lb_sai.Visible = false;
            lb_ThanhCong.Visible = false;
            lb_Trong.Visible = false;
            if (txt_MKM.Text != txt_NL.Text)
            {
                lb_KhongKhop.Visible = true;
                return;
            }
            if (txt_MKM.Text=="")
            {
                lb_Trong.Visible = true;
                return;
            }

            if (mkBus.CheckExist(tdn, txt_MKC.Text) == true)
            {
                NguoiDung _tv = new NguoiDung();
                _tv.username = tdn;
                _tv.password = txt_MKM.Text;

                mkBus.DoiMatKhau(_tv);
                lb_ThanhCong.Visible = true;
            }
            else
            {
                lb_sai.Visible = true;
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
