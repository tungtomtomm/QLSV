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
using Quanlysinhvien.DTO;
using Quanlysinhvien.BUS;

namespace Quanlysinhvien.GUI
{
    public partial class fHoSo : DevExpress.XtraEditors.XtraUserControl
    {
        SinhVien_BUS sVBUS = new SinhVien_BUS();
        DataProvider _dt = new DataProvider();
        private string tdn;
        private string quyen;

        public fHoSo(string _tdn,string _quyen)
        {
            InitializeComponent();
            tdn = _tdn;
            quyen = _quyen;
        }

        private void fHoSo_Load(object sender, EventArgs e)
        {
            if (quyen == "1")
            {
                txtLop.Enabled = false;
                txtStatus.Enabled = false;
            }
            txtMaSV.DataBindings.Clear();
            txtTen.DataBindings.Clear();

            txtGioiTinh.DataBindings.Clear();
            dateNgaySinh.DataBindings.Clear();
            txtLop.DataBindings.Clear();
            txtDt.DataBindings.Clear();
            txtStatus.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtQuequan.DataBindings.Clear();
            DataTable dt = _dt.GetData("select * from tblSinhVien where masv = '" + tdn + "'");
            txtMaSV.DataBindings.Add("Text", dt, "masv", true);
            txtTen.DataBindings.Add("Text", dt, "tensv", true);
            //string gt = dt.Rows[0]["GioiTinh"].ToString();
            txtGioiTinh.DataBindings.Add("Text", dt, "gioitinh", true);
            txtGioiTinh.Visible = false;
            if (txtGioiTinh.Text == "0")
                rdNu.Checked = true;
            else if (txtGioiTinh.Text == "1")
                rdNam.Checked = true;
            dateNgaySinh.DataBindings.Add("Text", dt, "ngaysinh", true);
            txtLop.DataBindings.Add("Text", dt, "malop", true);
            txtDt.DataBindings.Add("Text", dt, "dienthoai", true);
            txtStatus.DataBindings.Add("Text", dt, "trangthai", true);
            txtEmail.DataBindings.Add("Text", dt, "email", true);
            txtQuequan.DataBindings.Add("Text", dt, "quequan", true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.masv = txtMaSV.Text;
            sv.tensv = txtTen.Text;
            sv.ngaysinh = dateNgaySinh.DateTime;
            sv.malop = txtLop.Text;
            sv.dienthoai = txtDt.Text;
            sv.email = txtEmail.Text;
            sv.quequan = txtQuequan.Text;
            sv.trangthai = txtStatus.Text;
            if(rdNu.Checked == true)
            {
                sv.gioitinh = 0;
            }
            else
            {
                sv.gioitinh = 1;

            }
            sVBUS.Sua(sv);
            XtraMessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fHoSo_Load(sender, e);
        }
        
    }
}
