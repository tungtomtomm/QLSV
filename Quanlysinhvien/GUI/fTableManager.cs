using DevExpress.XtraEditors;
using Quanlysinhvien.DAO;
using Quanlysinhvien.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quanlysinhvien
{
    public partial class fTableManager : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private fLogin fLg;
        private string tdn;
        private string quyen;

        public fTableManager(fLogin _flg, string _tdn)
        {
            InitializeComponent();
            tdn = _tdn;
            fLg = _flg;
            DataProvider _dt = new DataProvider();
            DataTable dt = _dt.GetData("select * from tblNguoiDung where tblNguoiDung.username = '" + tdn + "'");
            string gt = dt.Rows[0]["phanquyen"].ToString();
            if (gt == "1")
            {
                ribbonAdmin.Visible = false;
            }
            else
            {
                ribbonPageGroup3.Visible = false;
                ribbonTimKiem.Visible = false;
            }
            quyen = gt;
            fAbout frm = new fAbout();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void barBtnXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc chắn muốn đăng xuất chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fLogin form = new fLogin();
                this.Hide();
                form.Show();
            }

           
        }

        private void barBtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc chắn muốn thoát chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void barBtnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelCha.Controls.Clear();
            ucFrmDoiMatKhau frm = new ucFrmDoiMatKhau(tdn);
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void accordionDoiMK_Click(object sender, EventArgs e)
        {
            panelCha.Controls.Clear();
            ucFrmDoiMatKhau frm = new ucFrmDoiMatKhau(tdn);
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void accordionDangxuat_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc chắn muốn đăng xuất chứ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                fLogin form = new fLogin();
                this.Hide();
                form.Show();
            }
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelCha.Controls.Clear();
            fAbout frm = new fAbout();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            panelCha.Controls.Clear();
            fKhoa frm = new fKhoa();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelCha.Controls.Clear();
            fGiangVien frm = new fGiangVien();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelCha.Controls.Clear();
            fNguoiDung frm = new fNguoiDung();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelCha.Controls.Clear();
            fHoSo frm = new fHoSo(tdn,quyen);
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelCha.Controls.Clear();
            fNganh frm = new fNganh();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelCha.Controls.Clear();
            fLopHoc frm = new fLopHoc();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelCha.Controls.Clear();
            fMonHoc frm = new fMonHoc();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelCha.Controls.Clear();
            fLopHocPhan frm = new fLopHocPhan();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelCha.Controls.Clear();
            fSinhVien frm = new fSinhVien();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelCha.Controls.Clear();
            fDiem frm = new fDiem();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelCha.Controls.Clear();
            fTraCuuDiem frm = new fTraCuuDiem(tdn);
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelCha.Controls.Clear();
            fDangKyHP frm = new fDangKyHP(tdn);
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCha.Controls.Add(frm);
        }
    }
}
