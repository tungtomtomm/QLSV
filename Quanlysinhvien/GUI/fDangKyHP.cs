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
    public partial class fDangKyHP : DevExpress.XtraEditors.XtraUserControl
    {
        Diem_BUS dBUS = new Diem_BUS();
        DataProvider _dt = new DataProvider();
        private string tdn;
        public fDangKyHP(string _tdn)
        {
            InitializeComponent();
            tdn = _tdn;
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            if (cbbMaLHP.Text != "")
            {
                txtTrangThai.DataBindings.Clear();
                if (txtTrangThai.Text == "mở")
                {
                    Diem d = new Diem();
                    d.masv = tdn;
                    d.malophocphan = cbbMaLHP.Text;
                    d.lanhoc = 1;
                    d.ghichu = "đang học";
                    dBUS.Dangky(d);
                    XtraMessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    XtraMessageBox.Show("Lớp học phần đã đóng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fDangKyHP_Load(object sender, EventArgs e)
        {
            DataTable dt = _dt.GetData("select distinct malophocphan from tblDiem where not masv='"+ tdn +"'");
            cbbMaLHP.DataSource = dt;
            cbbMaLHP.DisplayMember = "malophocphan";
            cbbMaLHP.SelectedIndex = -1;
        }

        private void cbbMaLHP_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTrangThai.DataBindings.Clear();
            DataTable dt1 = _dt.GetData("select * from tblLopHocPhan where malophocphan = '" + cbbMaLHP.Text + "'");
            txtTrangThai.DataBindings.Add("Text", dt1, "trangthai", true);
        }
    }
}
