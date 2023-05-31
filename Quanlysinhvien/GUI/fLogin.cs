using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Quanlysinhvien.BUS;
using Quanlysinhvien.DTO;

namespace Quanlysinhvien.GUI
{
    public partial class fLogin : DevExpress.XtraEditors.XtraForm
    {
        NguoiDung_BUS tvBus = new NguoiDung_BUS();
        public fLogin()
        {
            InitializeComponent();
        }

        private void btn_DangKy2_Click(object sender, EventArgs e)
        {

            if (txt_NLMatKhau.Text != txt_MatKhau.Text)
            {
                XtraMessageBox.Show("Mật khẩu nhập lại không trùng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NguoiDung _tv = new NguoiDung();
            _tv.username = txt_TenDangNhap.Text;
            _tv.password = txt_MatKhau.Text;

            int check = tvBus.DangKy(_tv);
            if (check == 1)
            {
                txt_TK.Text = _tv.username;
                txt_MK.Text = _tv.password;
                panelDangKy.Visible = false;
                XtraMessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDangKy.Visible = true;
            }
            else if (check == -1)
            {
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                XtraMessageBox.Show("Đã tồn tại username này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {

            if (tvBus.DangNhap(txt_TK.Text, txt_MK.Text) == true)
            {
                fTableManager f = new fTableManager(this, txt_TK.Text);
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            btnDangKy.Visible = false;
            panelDangKy.Visible = true;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            panelDangKy.Visible = false;
            btnDangKy.Visible = true;
        }
    }
}