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
using Quanlysinhvien.DAO;
using Quanlysinhvien.DTO;

namespace Quanlysinhvien.GUI
{
    public partial class fLopHoc : DevExpress.XtraEditors.XtraUserControl
    {
        DataProvider _dt = new DataProvider();
        LopHoc_BUS lHBUS = new LopHoc_BUS();
        public fLopHoc()
        {
            InitializeComponent();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            string tdn = gridView1.GetRowCellValue(e.RowHandle, "magv").ToString();
            txtGV.DataBindings.Clear();
            DataTable dt = _dt.GetData("select * from tblGiangVien where magv = '" + tdn + "'");
            txtGV.DataBindings.Add("Text", dt, "tengiangvien", true);
            txtMaLop.Text = gridView1.GetRowCellValue(e.RowHandle, "malop").ToString();
            txtMaNganh.Text = gridView1.GetRowCellValue(e.RowHandle, "manganh").ToString();
            txtTen.Text = gridView1.GetRowCellValue(e.RowHandle, "tenlop").ToString();
            txtNam.Text = gridView1.GetRowCellValue(e.RowHandle, "namvaotruong").ToString();
            txtMaGV.Text = gridView1.GetRowCellValue(e.RowHandle, "magv").ToString();
        }
        private void ResetGridview()
        {
            txtGV.ResetText();
            txtMaLop.ResetText();
            txtTen.ResetText();
            txtMaNganh.ResetText();
            txtNam.ResetText();
            txtMaGV.ResetText();
        }

        private void fLopHoc_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = lHBUS.GetList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LopHoc _lH = new LopHoc();

            _lH.malop = txtMaLop.Text;
            _lH.tenlop = txtTen.Text;
            _lH.manganh = txtMaNganh.Text;
            _lH.namvaotruong = Int64.Parse(txtNam.Text);
            _lH.magv = Int32.Parse(txtMaGV.Text);
            if (txtMaLop.Text == "" || txtTen.Text == "" || txtMaNganh.Text == "" || txtNam.Text == "" || txtMaGV.Text == "")
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (lHBUS.CheckExist("tblLopHoc", txtMaLop.Text, "malop"))
                XtraMessageBox.Show("Mã lớp học đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!lHBUS.CheckExist("tblGiangVien", txtMaGV.Text, "magv"))
                XtraMessageBox.Show("Không tồn tại mã giảng viên này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!lHBUS.CheckExist("tblNganh", txtMaNganh.Text, "manganh"))
                XtraMessageBox.Show("Không tồn tại mã ngành này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                lHBUS.Them(_lH);
            fLopHoc_Load(sender, e);
            ResetGridview();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            LopHoc _lH = new LopHoc();

            _lH.malop = txtMaLop.Text;
            _lH.tenlop = txtTen.Text;
            _lH.manganh = txtMaNganh.Text;
            _lH.namvaotruong = Int64.Parse(txtNam.Text);
            _lH.magv = Int32.Parse(txtMaGV.Text);
            if (txtMaLop.Text == "" || txtTen.Text == "" || txtMaNganh.Text == "" || txtNam.Text == "" || txtMaGV.Text == "")
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!lHBUS.CheckExist("tblLopHoc", txtMaLop.Text, "malop"))
                XtraMessageBox.Show("Không tồn tại mã lớp học này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!lHBUS.CheckExist("tblGiangVien", txtMaGV.Text, "magv"))
                XtraMessageBox.Show("Không tồn tại mã giảng viên này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!lHBUS.CheckExist("tblNganh", txtMaNganh.Text, "manganh"))
                XtraMessageBox.Show("Không tồn tại mã ngành này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                lHBUS.Sua(_lH);
            fLopHoc_Load(sender, e);
            ResetGridview();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text != "")
            {
                if (!lHBUS.CheckExist("tblLopHocPhan", txtMaLop.Text, "malop"))
                {
                    XtraMessageBox.Show("Tồn tại lớp học phần thuộc lớp học này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!lHBUS.CheckExist("tblSinhVien", txtMaLop.Text, "malop"))
                {
                    XtraMessageBox.Show("Tồn tại sinh viên phần thuộc lớp học này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!lHBUS.CheckExist("tblLopHoc", txtMaLop.Text, "malop"))
                {
                    XtraMessageBox.Show("Không tồn tại mã lớp cần xoá!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    lHBUS.Xoa(txtMaLop.Text);
                    fLopHoc_Load(sender, e);
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa nhập mã lớp học!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ResetGridview();
        }

        private void txtTim_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                gridControl1.DataSource = lHBUS.GetList();

            }
            else
            {
                if (rdTen.Checked == true)
                    gridControl1.DataSource = lHBUS.TimKiem(txtTim.Text, "tenlop");
                else if (rdMaGV.Checked == true)
                    gridControl1.DataSource = lHBUS.TimKiem(txtTim.Text, "magv");
                else if (rdMaNganh.Checked == true)
                    gridControl1.DataSource = lHBUS.TimKiem(txtTim.Text, "manganh");
            }
        }
    }
}
