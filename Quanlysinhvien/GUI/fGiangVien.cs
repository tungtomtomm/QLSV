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
    public partial class fGiangVien : DevExpress.XtraEditors.XtraUserControl
    {
        GiangVien_BUS gvBUS = new GiangVien_BUS();

        public fGiangVien()
        {
            InitializeComponent();
        }

        private void fGiangVien_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = gvBUS.GetList();
        }
        private void ResetGridview()
        {
            txtMaKhoa.ResetText();
            txtMaGV.ResetText();
            cbbBangCap.ResetText();
            cbbChucVu.ResetText();
            txtTen.ResetText();
            rdNu.Checked = false;
            rdNam.Checked = false;
            dateNamSinh.ResetText();
            txtEmail.ResetText();
            txtDienThoai.ResetText();
            txtDiaChi.ResetText();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
           
            string a = gridView1.GetRowCellValue(e.RowHandle, "gioitinh").ToString();
            if (a == "1")
                rdNam.Checked = true;
            else if (a == "0")
                rdNu.Checked = true;
            txtMaKhoa.Text = gridView1.GetRowCellValue(e.RowHandle, "makhoa").ToString();
            txtMaGV.Text = gridView1.GetRowCellValue(e.RowHandle, "magv").ToString();
            cbbBangCap.Text = gridView1.GetRowCellValue(e.RowHandle, "bangcap").ToString();
            cbbChucVu.Text = gridView1.GetRowCellValue(e.RowHandle, "chucvu").ToString();
            txtTen.Text = gridView1.GetRowCellValue(e.RowHandle, "tengiangvien").ToString();
            dateNamSinh.Text = gridView1.GetRowCellValue(e.RowHandle, "ngaysinh").ToString();
            txtEmail.Text = gridView1.GetRowCellValue(e.RowHandle, "email").ToString();
            txtDienThoai.Text = gridView1.GetRowCellValue(e.RowHandle, "dienthoai").ToString();
            txtDiaChi.Text = gridView1.GetRowCellValue(e.RowHandle, "diachi").ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            GiangVien _gv = new GiangVien();
            _gv.makhoa = txtMaKhoa.Text;
            _gv.tengiangvien = txtTen.Text;
            _gv.bangcap = cbbBangCap.Text;
            _gv.chucvu = cbbChucVu.Text;
            _gv.email = txtEmail.Text;
            _gv.dienthoai = txtDienThoai.Text;
            _gv.diachi = txtDiaChi.Text;

            if (rdNam.Checked == true)
                _gv.gioitinh = 1;
            else if (rdNu.Checked == true)
                _gv.gioitinh = 0;

            if (dateNamSinh.Text == "")
                _gv.ngaysinh = DateTime.Now;
            else
                _gv.ngaysinh = dateNamSinh.DateTime;
            //kiem tra loi makhoa
            int check = gvBUS.Them(_gv);
            if (txtMaKhoa.Text=="" || cbbBangCap.Text == "" || cbbChucVu.Text == "" || txtTen.Text == "")
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (check == -1)
                XtraMessageBox.Show("Mã giảng viên đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(gvBUS.CheckExist("tblKhoa", txtMaKhoa.Text) == false)
                XtraMessageBox.Show("Không tồn tại mã khoa này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            fGiangVien_Load(sender, e);
            ResetGridview();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            GiangVien _gv = new GiangVien();
            _gv.magv = Int32.Parse(txtMaGV.Text);
            _gv.makhoa = txtMaKhoa.Text;
            _gv.tengiangvien = txtTen.Text;
            _gv.bangcap = cbbBangCap.Text;
            _gv.chucvu = cbbChucVu.Text;
            _gv.email = txtEmail.Text;
            _gv.dienthoai = txtDienThoai.Text;
            _gv.diachi = txtDiaChi.Text;

            if (rdNam.Checked == true)
                _gv.gioitinh = 1;
            else if (rdNu.Checked == true)
                _gv.gioitinh = 0;

            if (dateNamSinh.Text == "")
                _gv.ngaysinh = DateTime.Now;
            else
                _gv.ngaysinh = dateNamSinh.DateTime;

            if (txtMaGV.Text == "" || txtMaKhoa.Text == "" || cbbBangCap.Text == "" || cbbChucVu.Text == "" || txtTen.Text == "")
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (gvBUS.CheckExist("tblKhoa", txtMaKhoa.Text) == false)
                XtraMessageBox.Show("Không tồn tại mã khoa này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (gvBUS.CheckExist("tblGiangVien", txtMaGV.Text) == false)
                XtraMessageBox.Show("Không tồn tại mã giảng viên này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                gvBUS.Sua(_gv);
            //load lai
            fGiangVien_Load(sender, e);
            ResetGridview();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaGV.Text != "")
            {
                int check = gvBUS.Xoa(txtMaGV.Text);
                if (check == -1)
                {
                    XtraMessageBox.Show("Tồn tại lớp học, điểm thuộc giáo viên này phụ trách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (check == 1)
                {
                    XtraMessageBox.Show("Không tồn tại mã giảng viên cần xoá!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    ResetGridview();
                    fGiangVien_Load(sender, e);
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa nhập mã giảng viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTim_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                gridControl1.DataSource = gvBUS.GetList();

            }
            else
            {
                if (rdTen.Checked == true)
                    gridControl1.DataSource = gvBUS.TimKiem(txtTim.Text, "tengiangvien");
                else if (rdSDT.Checked == true)
                    gridControl1.DataSource = gvBUS.TimKiem(txtTim.Text, "dienthoai");
                else if (rdEmail.Checked == true)
                    gridControl1.DataSource = gvBUS.TimKiem(txtTim.Text, "email");
            }
        }

        private void cbbLocBc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbLocBc.Text=="" && cbbLocCv.Text == "")
            {
                gridControl1.DataSource = gvBUS.GetList();
            }
            else if(cbbLocBc.Text == "")
            {
                gridControl1.DataSource = gvBUS.GetListLoc("chucvu", cbbLocCv.Text);
            }
            else if(cbbLocCv.Text == "")
            {
                gridControl1.DataSource = gvBUS.GetListLoc("bangcap", cbbLocBc.Text);
            }
            else
            {
                gridControl1.DataSource = gvBUS.GetListLoc2("chucvu", cbbLocCv.Text, "bangcap", cbbLocBc.Text);

            }
        }

        private void cbbLocCv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLocBc.Text == "" && cbbLocCv.Text == "")
            {
                gridControl1.DataSource = gvBUS.GetList();
            }
            else if (cbbLocBc.Text == "")
            {
                gridControl1.DataSource = gvBUS.GetListLoc("chucvu", cbbLocCv.Text);
            }
            else if (cbbLocCv.Text == "")
            {
                gridControl1.DataSource = gvBUS.GetListLoc("bangcap", cbbLocBc.Text);
            }
            else
            {
                gridControl1.DataSource = gvBUS.GetListLoc2("chucvu", cbbLocCv.Text, "bangcap", cbbLocBc.Text);

            }
        }
    }
}
