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

namespace Quanlysinhvien.GUI
{
    public partial class fTraCuuDiem : DevExpress.XtraEditors.XtraUserControl
    {
        Diem_BUS dBUS = new Diem_BUS();
        DataProvider _dt = new DataProvider();
        private string tdn;
        public fTraCuuDiem(string _tdn)
        {
            InitializeComponent();
            tdn = _tdn;
        }
        private void ResetGridview()
        {
            txtMaLHP.ResetText();

        }
        private void Clear()
        {
            txtDuThi2.DataBindings.Clear();
            txtLanHoc.DataBindings.Clear();
            txtThuongXuyen1.DataBindings.Clear();
            txtThuongXuyen2.DataBindings.Clear();
            txtTBThuongKy.DataBindings.Clear();
            txtTK.DataBindings.Clear();
            txtXepLoai.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            txtTenSV.DataBindings.Clear();
            txtMaMonHoc.DataBindings.Clear();
            txtDuThi2.DataBindings.Clear();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtMaLHP.Text == "")
            {
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!dBUS.CheckExist("tblDiem", txtMaLHP.Text, "malophocphan", tdn, "masv"))
                    XtraMessageBox.Show("Điểm này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    Clear();
                    DataTable dt = _dt.GetData("select * from tblDiem where masv = '" + tdn + "' and malophocphan = '" + txtMaLHP.Text + "'");
                    txtDuThi2.DataBindings.Add("Text", dt, "duocduthi", true);
                    txtLanHoc.DataBindings.Add("Text", dt, "lanhoc", true);
                    txtThuongXuyen2.DataBindings.Add("Text", dt, "thuongxuyen2", true);
                    txtThuongXuyen1.DataBindings.Add("Text", dt, "thuongxuyen1", true);
                    txtTBThuongKy.DataBindings.Add("Text", dt, "tbthuongky", true);
                    txtTK.DataBindings.Add("Text", dt, "diemtongket", true);
                    txtXepLoai.DataBindings.Add("Text", dt, "xeploai", true);
                    txtGhiChu.DataBindings.Add("Text", dt, "ghichu", true);
                    if (txtDuThi2.Text == "1")
                    {
                        cbbDuThi.Text = "Không";
                    }
                    else
                    {
                        cbbDuThi.Text = "Có";

                    }
                    DataTable dt2 = _dt.GetData("select tensv from tblSinhVien where masv = '" + tdn + "'");
                    txtTenSV.DataBindings.Add("Text", dt2, "tensv", true);
                    DataTable dt3 = _dt.GetData("select mamonhoc from tblLopHocPhan where malophocphan = '" + txtMaLHP.Text + "'");
                    txtMaMonHoc.DataBindings.Add("Text", dt3, "mamonhoc", true);
                    groupControl2.Visible = true;
                }
            }
        }
    }
}
