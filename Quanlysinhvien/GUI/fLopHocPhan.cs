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
using Quanlysinhvien.DAO;
using Quanlysinhvien.BUS;
using Quanlysinhvien.DTO;

namespace Quanlysinhvien.GUI
{
    public partial class fLopHocPhan : DevExpress.XtraEditors.XtraUserControl
    {
        DataProvider _dt = new DataProvider();
        LopHocPhan_BUS lHPBUS = new LopHocPhan_BUS();
        public fLopHocPhan()
        {
            InitializeComponent();
        }
        private void ResetGridview()
        {
            txtMaMH.ResetText();
            txtMaLop.ResetText();
            txtMaLHP.ResetText();
            txtHocky.ResetText();
            txtNamhoc.ResetText();
            cbbTrangthai.ResetText();
            txtMagv.ResetText();
        }
        private void fLopHocPhan_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = lHPBUS.GetList();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            string mmh = gridView1.GetRowCellValue(e.RowHandle, "mamonhoc").ToString();
            string ml = gridView1.GetRowCellValue(e.RowHandle, "malop").ToString();
            string mgv = gridView1.GetRowCellValue(e.RowHandle, "magv").ToString();
            txtMaMH.DataBindings.Clear();
            txtMaLop.DataBindings.Clear();
            txtMagv.DataBindings.Clear();
            DataTable dtMH = _dt.GetData("select * from tblMonHoc where mamonhoc = '" + mmh + "'");
            DataTable dtML = _dt.GetData("select * from tblLopHoc where malop = '" + ml + "'");
            DataTable dtMGV = _dt.GetData("select * from tblGiangVien where magv = '" + mgv + "'");
            txtMaMH.DataBindings.Add("Text", dtMH, "tenmonhoc", true);
            txtMaLop.DataBindings.Add("Text", dtML, "tenlop", true);
            txtMagv.DataBindings.Add("Text", dtMGV, "tengiangvien", true);
            txtMaLHP.Text = gridView1.GetRowCellValue(e.RowHandle, "malophocphan").ToString();
            txtHocky.Text = gridView1.GetRowCellValue(e.RowHandle, "hocky").ToString();
            txtNamhoc.Text = gridView1.GetRowCellValue(e.RowHandle, "namhoc").ToString();
            cbbTrangthai.Text = gridView1.GetRowCellValue(e.RowHandle, "trangthai").ToString();
            txt1.Text = gridView1.GetRowCellValue(e.RowHandle, "mamonhoc").ToString();
            txt2.Text = gridView1.GetRowCellValue(e.RowHandle, "malop").ToString();
            txt3.Text = gridView1.GetRowCellValue(e.RowHandle, "magv").ToString();

        }

        private void txtTim_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetList();

            }
            else
            {
                if (rdMaMH.Checked == true)
                    gridControl1.DataSource = lHPBUS.TimKiem(txtTim.Text, "mamonhoc");
                else if (rdMaLHP.Checked == true)
                    gridControl1.DataSource = lHPBUS.TimKiem(txtTim.Text, "malophocphan");
                else if (rdMaGV.Checked == true)
                    gridControl1.DataSource = lHPBUS.TimKiem(txtTim.Text, "magv");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text == "" || txtMaLHP.Text == "" || txtHocky.Text == "" || txtMagv.Text == "" || txtNamhoc.Text == "" || txtMaMH.Text == "" || cbbTrangthai.Text == "")
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (lHPBUS.CheckExist("tblLopHocPhan", txtMaLHP.Text, "malophocphan"))
                XtraMessageBox.Show("Mã lớp học phần đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!lHPBUS.CheckExist("tblLopHoc", txtMaLop.Text, "malop"))
                XtraMessageBox.Show("Mã lớp học không tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!lHPBUS.CheckExist("tblGiangVien", txtMagv.Text, "magv"))
                XtraMessageBox.Show("Không tồn tại mã giảng viên này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!lHPBUS.CheckExist("tblMonHoc", txtMaMH.Text, "mamonhoc"))
                XtraMessageBox.Show("Không tồn tại mã môn học này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                LopHocPhan _lHP = new LopHocPhan();

                _lHP.malop = txtMaLop.Text;
                _lHP.malophocphan = txtMaLHP.Text;
                _lHP.hocky = Int32.Parse(txtHocky.Text);
                _lHP.magv = Int32.Parse(txtMagv.Text);
                _lHP.namhoc = txtNamhoc.Text;
                _lHP.trangthai = cbbTrangthai.Text;
                _lHP.mamonhoc = txtMaMH.Text;
                lHPBUS.Them(_lHP);
                fLopHocPhan_Load(sender, e);
                ResetGridview();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaMH.Text = txt1.Text;
            txtMaLop.Text = txt2.Text;
            txtMagv.Text = txt3.Text;
            if (txtMaLop.Text == "" || txtMaLHP.Text == "" || txtHocky.Text == "" || txtMagv.Text == "" || txtNamhoc.Text == "" || txtMaMH.Text == "" || cbbTrangthai.Text == "")
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!lHPBUS.CheckExist("tblLopHocPhan", txtMaLHP.Text, "malophocphan"))
                XtraMessageBox.Show("Mã lớp học phần không tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!lHPBUS.CheckExist("tblLopHoc", txtMaLop.Text, "malop"))
                XtraMessageBox.Show("Mã lớp học không tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!lHPBUS.CheckExist("tblGiangVien", txtMagv.Text, "magv"))
                XtraMessageBox.Show("Không tồn tại mã giảng viên này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!lHPBUS.CheckExist("tblMonHoc", txtMaMH.Text, "mamonhoc"))
                XtraMessageBox.Show("Không tồn tại mã môn học này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                LopHocPhan _lHP = new LopHocPhan();

                _lHP.malop = txtMaLop.Text;
                _lHP.malophocphan = txtMaLHP.Text;
                _lHP.hocky = Int32.Parse(txtHocky.Text);
                _lHP.magv = Int32.Parse(txtMagv.Text);
                _lHP.namhoc = txtNamhoc.Text;
                _lHP.trangthai = cbbTrangthai.Text;
                _lHP.mamonhoc = txtMaMH.Text;
                lHPBUS.Sua(_lHP);
                fLopHocPhan_Load(sender, e);
                ResetGridview();
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (txtMaLHP.Text != "")
            {
                if (lHPBUS.CheckExist("tblDiem", txtMaLHP.Text, "malophocphan"))
                {
                    XtraMessageBox.Show("Tồn tại sinh viên thuộc lớp học phần này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lHPBUS.Xoa(txtMaLHP.Text);
                    fLopHocPhan_Load(sender, e);
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa nhập mã lớp học phần!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ResetGridview();
        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit2.Text == "" && txtLocHocky.Text == "" && txtLocNam.Text =="")
            {
                gridControl1.DataSource = lHPBUS.GetList();
            }
            else if (comboBoxEdit2.Text == "" && txtLocHocky.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc("namhoc", txtLocNam.Text);
            }
            else if (comboBoxEdit2.Text == "" && txtLocNam.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc("hocky", txtLocHocky.Text);
            }
            else if (txtLocNam.Text == "" && txtLocHocky.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc("trangthai", cbbTrangthai.Text);

            }
            else if(txtLocNam.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc2("trangthai", cbbTrangthai.Text, "hocky", txtLocHocky.Text);
            }
            else if (txtLocHocky.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc2("trangthai", cbbTrangthai.Text, "namhoc", txtLocNam.Text);
            }
            else if (comboBoxEdit2.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc2("namhoc", txtLocNam.Text, "hocky", txtLocHocky.Text);
            }
            else
            {
                gridControl1.DataSource = lHPBUS.GetListLoc3("namhoc", txtLocNam.Text,"trangthai", cbbTrangthai.Text, "hocky", txtLocHocky.Text);
            }
        }

        private void txtLocHocky_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit2.Text == "" && txtLocHocky.Text == "" && txtLocNam.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetList();
            }
            else if (comboBoxEdit2.Text == "" && txtLocHocky.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc("namhoc", txtLocNam.Text);
            }
            else if (comboBoxEdit2.Text == "" && txtLocNam.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc("hocky", txtLocHocky.Text);
            }
            else if (txtLocNam.Text == "" && txtLocHocky.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc("trangthai", cbbTrangthai.Text);

            }
            else if (txtLocNam.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc2("trangthai", cbbTrangthai.Text, "hocky", txtLocHocky.Text);
            }
            else if (txtLocHocky.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc2("trangthai", cbbTrangthai.Text, "namhoc", txtLocNam.Text);
            }
            else if (comboBoxEdit2.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc2("namhoc", txtLocNam.Text, "hocky", txtLocHocky.Text);
            }
            else
            {
                gridControl1.DataSource = lHPBUS.GetListLoc3("namhoc", txtLocNam.Text, "trangthai", cbbTrangthai.Text, "hocky", txtLocHocky.Text);
            }
        }

        private void txtLocNam_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit2.Text == "" && txtLocHocky.Text == "" && txtLocNam.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetList();
            }
            else if (comboBoxEdit2.Text == "" && txtLocHocky.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc("namhoc", txtLocNam.Text);
            }
            else if (comboBoxEdit2.Text == "" && txtLocNam.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc("hocky", txtLocHocky.Text);
            }
            else if (txtLocNam.Text == "" && txtLocHocky.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc("trangthai", cbbTrangthai.Text);

            }
            else if (txtLocNam.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc2("trangthai", cbbTrangthai.Text, "hocky", txtLocHocky.Text);
            }
            else if (txtLocHocky.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc2("trangthai", cbbTrangthai.Text, "namhoc", txtLocNam.Text);
            }
            else if (comboBoxEdit2.Text == "")
            {
                gridControl1.DataSource = lHPBUS.GetListLoc2("namhoc", txtLocNam.Text, "hocky", txtLocHocky.Text);
            }
            else
            {
                gridControl1.DataSource = lHPBUS.GetListLoc3("namhoc", txtLocNam.Text, "trangthai", cbbTrangthai.Text, "hocky", txtLocHocky.Text);
            }
        }
    }
}
