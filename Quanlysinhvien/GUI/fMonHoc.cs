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
    public partial class fMonHoc : DevExpress.XtraEditors.XtraUserControl
    {
        MonHoc_BUS mHBUS = new MonHoc_BUS();
        public fMonHoc()
        {
            InitializeComponent();
        }

        private void fMonHoc_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = mHBUS.GetList();
        }
        private void ResetGridview()
        {
            txtMaKhoa.ResetText();
            txtMaMon.ResetText();
            txtTen.ResetText();
            txtTinChi.ResetText();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            txtMaMon.Text = gridView1.GetRowCellValue(e.RowHandle, "mamonhoc").ToString();
            txtMaKhoa.Text = gridView1.GetRowCellValue(e.RowHandle, "makhoa").ToString();
            txtTen.Text = gridView1.GetRowCellValue(e.RowHandle, "tenmonhoc").ToString();
            txtTinChi.Text = gridView1.GetRowCellValue(e.RowHandle, "sotinchi").ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MonHoc _mH = new MonHoc();

            _mH.mamonhoc = txtMaMon.Text;
            _mH.makhoa = txtMaKhoa.Text;
            _mH.tenmonhoc = txtTen.Text;
            _mH.sotinchi = Int32.Parse(txtTinChi.Text);
            if (txtMaKhoa.Text == "" || txtMaMon.Text == "" || txtTen.Text == "" || txtTinChi.Text=="")
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (mHBUS.CheckExist("tblMonHoc", txtMaMon.Text,"mamonhoc"))
                XtraMessageBox.Show("Mã môn học đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!mHBUS.CheckExist("tblKhoa", txtMaKhoa.Text,"makhoa"))
                XtraMessageBox.Show("Không tồn tại mã khoa này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                mHBUS.Them(_mH);
            fMonHoc_Load(sender, e);
            ResetGridview();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MonHoc _mH = new MonHoc();

            _mH.mamonhoc = txtMaMon.Text;
            _mH.makhoa = txtMaKhoa.Text;
            _mH.tenmonhoc = txtTen.Text;
            _mH.sotinchi = Int32.Parse(txtTinChi.Text);
            if (txtMaKhoa.Text == "" || txtMaMon.Text == "" || txtTen.Text == "" || txtTinChi.Text == "")
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!mHBUS.CheckExist("tblMonHoc", txtMaMon.Text,"mamonhoc"))
                XtraMessageBox.Show("Mã môn học không tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!mHBUS.CheckExist("tblKhoa", txtMaKhoa.Text,"makhoa"))
                XtraMessageBox.Show("Không tồn tại mã khoa này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                mHBUS.Sua(_mH);
            fMonHoc_Load(sender, e);
            ResetGridview();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaMon.Text != "")
            {
                if (!mHBUS.CheckExist("tblLopHocPhan", txtMaMon.Text,"mamonhoc"))
                {
                    XtraMessageBox.Show("Tồn tại lớp học phần thuộc môn học này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!mHBUS.CheckExist("tblMonHoc", txtMaMon.Text,"mamonhoc"))
                {
                    XtraMessageBox.Show("Không tồn tại mã môn học cần xoá!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    mHBUS.Xoa(txtMaMon.Text);
                    fMonHoc_Load(sender, e);
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa nhập mã môn học!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ResetGridview();
        }

        private void txtTim_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                gridControl1.DataSource = mHBUS.GetList();

            }
            else
            {
                if (rdTen.Checked == true)
                    gridControl1.DataSource = mHBUS.TimKiem(txtTim.Text, "tenmonhoc");
                else if (rdMaKhoa.Checked == true)
                    gridControl1.DataSource = mHBUS.TimKiem(txtTim.Text, "makhoa");
                else if (rdMaMonHoc.Checked == true)
                    gridControl1.DataSource = mHBUS.TimKiem(txtTim.Text, "mamonhoc");
            }
        }
    }
}
