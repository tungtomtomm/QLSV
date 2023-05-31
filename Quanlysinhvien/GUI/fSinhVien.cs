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
using Quanlysinhvien.DAO;

namespace Quanlysinhvien.GUI
{
    public partial class fSinhVien : DevExpress.XtraEditors.XtraUserControl
    {
        SinhVien_BUS sVBUS = new SinhVien_BUS();
        DataProvider _dt = new DataProvider();
        public fSinhVien()
        {
            InitializeComponent();
        }
        private void ResetGridview()
        {
            txtMaSV.ResetText();
            txtMaLop.ResetText();
            txtTen.ResetText();
            txtDT.ResetText();
            txtEmail.ResetText();
            cbbTrangthai.ResetText();
            txtQue.ResetText();
            dateNgaysinh.ResetText();
            rdNu.Checked = false;
            rdNam.Checked = false;
        }
        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            dateNgaysinh.Properties.DisplayFormat.FormatString = "mm/dd/yyyy";
            string a = gridView1.GetRowCellValue(e.RowHandle, "gioitinh").ToString();
            if (a == "1")
                rdNam.Checked = true;
            else if (a == "0")
                rdNu.Checked = true;
            txtMaSV.Text = gridView1.GetRowCellValue(e.RowHandle, "masv").ToString();
            txtMaLop.Text = gridView1.GetRowCellValue(e.RowHandle, "malop").ToString();
            txtTen.Text = gridView1.GetRowCellValue(e.RowHandle, "tensv").ToString();
            txtDT.Text = gridView1.GetRowCellValue(e.RowHandle, "dienthoai").ToString();
            txtEmail.Text = gridView1.GetRowCellValue(e.RowHandle, "email").ToString();
            txtQue.Text = gridView1.GetRowCellValue(e.RowHandle, "quequan").ToString();
            dateNgaysinh.Text = gridView1.GetRowCellValue(e.RowHandle, "ngaysinh").ToString();
            cbbTrangthai.Text = gridView1.GetRowCellValue(e.RowHandle, "trangthai").ToString();
        }

        private void fSinhVien_Load(object sender, EventArgs e)
        {
            DataTable dtMH = _dt.GetData("select makhoa from tblKhoa");
            cbbKhoa.DataSource = dtMH;
            cbbKhoa.DisplayMember = "makhoa";
            cbbKhoa.SelectedIndex = -1;
            DataTable dt = _dt.GetData("select distinct namvaotruong from tblLopHoc");
            cbbNam.DataSource = dt;
            cbbNam.DisplayMember = "namvaotruong";
            cbbNam.SelectedIndex = -1;
            gridControl1.DataSource = sVBUS.GetList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text == "" || txtMaSV.Text == "" || txtTen.Text == "" || txtQue.Text == "" || cbbTrangthai.Text == "" || dateNgaysinh.Text == "")
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (sVBUS.CheckExist("tblSinhVien", txtMaSV.Text, "masv"))
                XtraMessageBox.Show("Mã sinh viên này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!sVBUS.CheckExist("tblLopHoc", txtMaLop.Text, "malop"))
                XtraMessageBox.Show("Mã lớp học không tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                SinhVien _sv = new SinhVien();
                _sv.malop = txtMaLop.Text;
                _sv.tensv = txtTen.Text;
                _sv.masv = txtMaSV.Text;
                _sv.dienthoai = txtDT.Text;
                _sv.email = txtEmail.Text;
                _sv.quequan = txtQue.Text;
                _sv.trangthai = cbbTrangthai.Text;
                _sv.ngaysinh = dateNgaysinh.DateTime;
                if (rdNam.Checked == true)
                    _sv.gioitinh = 1;
                else if (rdNu.Checked == true)
                    _sv.gioitinh = 0;
                else
                    _sv.gioitinh = 1;
                sVBUS.Them(_sv);
                fSinhVien_Load(sender, e);
                ResetGridview();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text == "" || txtMaSV.Text == "" || txtTen.Text == "" || txtQue.Text == "" || cbbTrangthai.Text == "" || dateNgaysinh.Text == "")
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!sVBUS.CheckExist("tblSinhVien", txtMaSV.Text, "masv"))
                XtraMessageBox.Show("Mã sinh viên cần sửa không tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!sVBUS.CheckExist("tblLopHoc", txtMaLop.Text, "malop"))
                XtraMessageBox.Show("Mã lớp học không tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                SinhVien _sv = new SinhVien();
                _sv.malop = txtMaLop.Text;
                _sv.tensv = txtTen.Text;
                _sv.masv = txtMaSV.Text;
                _sv.dienthoai = txtDT.Text;
                _sv.email = txtEmail.Text;
                _sv.quequan = txtQue.Text;
                _sv.trangthai = cbbTrangthai.Text;
                _sv.ngaysinh = dateNgaysinh.DateTime;
                if (rdNam.Checked == true)
                    _sv.gioitinh = 1;
                else if (rdNu.Checked == true)
                    _sv.gioitinh = 0;
                else
                    _sv.gioitinh = 1;
                sVBUS.Sua(_sv);
                fSinhVien_Load(sender, e);
                ResetGridview();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
                if (txtMaSV.Text != "")
                {
                    if (sVBUS.CheckExist("tblDiem", txtMaSV.Text, "masv"))
                    {
                        XtraMessageBox.Show("Tồn tại lớp học phần có sinh viên này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        sVBUS.Xoa(txtMaSV.Text);
                        fSinhVien_Load(sender, e);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Chưa nhập mã sinh viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ResetGridview();
        }


        

        private void cbbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLop.Text == "" && cbbLoc.Text == "" && rdLocNam.Checked == false && rdLocNu.Checked == false)
            {
                gridControl1.DataSource = sVBUS.GetList();
            }
            else if (cbbLoc.Text == "" && rdLocNam.Checked == false && rdLocNu.Checked == false)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("malop", cbbLop.Text);
            }
            else if (cbbLop.Text == "" && rdLocNam.Checked == false && rdLocNu.Checked == false)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("trangthai", cbbLoc.Text);
            }
            else if (cbbLoc.Text == "" && rdLocNam.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc2("malop", cbbLop.Text, "gioitinh", "1");
            }
            else if (cbbLoc.Text == "" && rdLocNu.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc2("malop", cbbLop.Text, "gioitinh", "0");
            }
            else if (cbbLop.Text == "" && cbbLoc.Text == "" && rdLocNu.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("gioitinh", "0");
            }
            else if (cbbLop.Text == "" && cbbLoc.Text == "" && rdLocNam.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("gioitinh", "1");
            }
            else
            {
                if (rdLocNam.Checked == true)
                {
                    gridControl1.DataSource = sVBUS.GetListLoc3("malop", cbbLop.Text, "trangthai", cbbLoc.Text, "gioitinh", "1");
                }
                if (rdLocNu.Checked == true)
                    gridControl1.DataSource = sVBUS.GetListLoc3("malop", cbbLop.Text, "trangthai", cbbLoc.Text, "gioitinh", "0");
            }
        }

        private void txtTim_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                gridControl1.DataSource = sVBUS.GetList();

            }
            else
            {
                if (rdTen.Checked == true)
                    gridControl1.DataSource = sVBUS.TimKiem(txtTim.Text, "tensv");
                else if (rdDT.Checked == true)
                    gridControl1.DataSource = sVBUS.TimKiem(txtTim.Text, "dienthoai");
                else if (rdMaSV.Checked == true)
                    gridControl1.DataSource = sVBUS.TimKiem(txtTim.Text, "masv");
            }
        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = _dt.GetData("select manganh from tblNganh where makhoa = '" + cbbKhoa.Text + "'");
            cbbNganh.DataSource = dt;
            cbbNganh.DisplayMember = "manganh";
            cbbNganh.SelectedIndex = -1;

        }

        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbKhoa.Text !="" && cbbNganh.Text !="")
            {
                cbbLop.SelectedIndex = -1;
                DataTable dt = _dt.GetData("select malop from tblLopHoc where manganh = '" + cbbNganh.Text + "' and namvaotruong = '" + cbbNam.Text + "'");
                cbbLop.DataSource = dt;
                cbbLop.DisplayMember = "malop";
                cbbLop.SelectedIndex = -1;
            }
        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbbLop.Text == "" && cbbLoc.Text == "" && rdLocNam.Checked == false && rdLocNu.Checked == false)
            {
                gridControl1.DataSource = sVBUS.GetList();
            }
            else if (cbbLoc.Text == "" && rdLocNam.Checked == false && rdLocNu.Checked == false)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("malop", cbbLop.Text);
            }
            else if (cbbLop.Text == "" && rdLocNam.Checked == false && rdLocNu.Checked == false)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("trangthai", cbbLoc.Text);
            }
            else if (cbbLoc.Text == "" && rdLocNam.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc2("malop", cbbLop.Text, "gioitinh", "1");
            }
            else if (cbbLoc.Text == "" && rdLocNu.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc2("malop", cbbLop.Text, "gioitinh", "0");
            }
            else if (cbbLop.Text == "" && cbbLoc.Text == "" && rdLocNu.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("gioitinh", "0");
            }
            else if (cbbLop.Text == "" && cbbLoc.Text == "" && rdLocNam.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("gioitinh", "1");
            }
            else
            {
                if (rdLocNam.Checked == true)
                {
                    gridControl1.DataSource = sVBUS.GetListLoc3("malop", cbbLop.Text, "trangthai", cbbLoc.Text, "gioitinh", "1");
                }
                if (rdLocNu.Checked == true)
                    gridControl1.DataSource = sVBUS.GetListLoc3("malop", cbbLop.Text, "trangthai", cbbLoc.Text, "gioitinh", "0");
            }
        }

        private void rdLocNam_Click(object sender, EventArgs e)
        {
            if (cbbLop.Text == "" && cbbLoc.Text == "" && rdLocNam.Checked == false && rdLocNu.Checked == false)
            {
                gridControl1.DataSource = sVBUS.GetList();
            }
            else if (cbbLop.Text == "" && cbbLoc.Text == "" && rdLocNu.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("gioitinh", "0");
            }
            else if (cbbLop.Text == "" && cbbLoc.Text == "" && rdLocNam.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("gioitinh", "1");
            }
            else if (cbbLoc.Text == "" && rdLocNam.Checked == false && rdLocNu.Checked == false)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("malop", cbbLop.Text);
            }
            else if (cbbLop.Text == "" && rdLocNam.Checked == false && rdLocNu.Checked == false)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("trangthai", cbbLoc.Text);
            }
            else if (cbbLoc.Text == "" && rdLocNam.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc2("malop", cbbLop.Text, "gioitinh", "1");
            }
            else if (cbbLoc.Text == "" && rdLocNu.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc2("malop", cbbLop.Text, "gioitinh", "0");
            }
            
            else
            {
                if (rdLocNam.Checked == true)
                {
                    gridControl1.DataSource = sVBUS.GetListLoc3("malop", cbbLop.Text, "trangthai", cbbLoc.Text, "gioitinh", "1");
                }
                if (rdLocNu.Checked == true)
                    gridControl1.DataSource = sVBUS.GetListLoc3("malop", cbbLop.Text, "trangthai", cbbLoc.Text, "gioitinh", "0");
            }
        }

        private void rdLocNu_Click(object sender, EventArgs e)
        {
            if (cbbLop.Text == "" && cbbLoc.Text == "" && rdLocNam.Checked == false && rdLocNu.Checked == false)
            {
                gridControl1.DataSource = sVBUS.GetList();
            }
            else if (cbbLop.Text == "" && cbbLoc.Text == "" && rdLocNu.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("gioitinh", "0");
            }
            else if (cbbLop.Text == "" && cbbLoc.Text == "" && rdLocNam.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("gioitinh", "1");
            }
            else if (cbbLoc.Text == "" && rdLocNam.Checked == false && rdLocNu.Checked == false)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("malop", cbbLop.Text);
            }
            else if (cbbLop.Text == "" && rdLocNam.Checked == false && rdLocNu.Checked == false)
            {
                gridControl1.DataSource = sVBUS.GetListLoc("trangthai", cbbLoc.Text);
            }
            else if (cbbLoc.Text == "" && rdLocNam.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc2("malop", cbbLop.Text, "gioitinh", "1");
            }
            else if (cbbLoc.Text == "" && rdLocNu.Checked == true)
            {
                gridControl1.DataSource = sVBUS.GetListLoc2("malop", cbbLop.Text, "gioitinh", "0");
            }

            else
            {
                if (rdLocNam.Checked == true)
                {
                    gridControl1.DataSource = sVBUS.GetListLoc3("malop", cbbLop.Text, "trangthai", cbbLoc.Text, "gioitinh", "1");
                }
                if (rdLocNu.Checked == true)
                    gridControl1.DataSource = sVBUS.GetListLoc3("malop", cbbLop.Text, "trangthai", cbbLoc.Text, "gioitinh", "0");
            }
        }
    }
}
