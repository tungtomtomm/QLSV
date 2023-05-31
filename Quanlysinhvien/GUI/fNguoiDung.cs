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
    public partial class fNguoiDung : DevExpress.XtraEditors.XtraUserControl
    {
        NguoiDung_BUS tvBUS = new NguoiDung_BUS();
        public fNguoiDung()
        {
            InitializeComponent();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            string a = gridView1.GetRowCellValue(e.RowHandle, "phanquyen").ToString();
            if (a == "1")
                cbbQuyen.Text = "Member";
            else if (a == "0")
                cbbQuyen.Text = "Admin";
            txtUsername.Text = gridView1.GetRowCellValue(e.RowHandle, "username").ToString();
            txtPw.Text = gridView1.GetRowCellValue(e.RowHandle, "password").ToString();
        }
        private void ResetGridview()
        {
            txtUsername.ResetText();
            txtPw.ResetText();
            cbbQuyen.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NguoiDung _tv = new NguoiDung();
            _tv.username = txtUsername.Text;
            _tv.password = txtPw.Text;
            if (cbbQuyen.Text == "Admin")
            {
                _tv.phanquyen = 0;
            }
            else if (cbbQuyen.Text == "Member")
            {
                _tv.phanquyen = 1;
            }
            if (txtUsername.Text != "" && txtPw.Text != "" && (cbbQuyen.Text == "Admin" || cbbQuyen.Text == "Member"))
            {
                int check = tvBUS.Them(_tv);
                if (check == -1)
                {
                    XtraMessageBox.Show("Đã tồn tại tên tài khoản này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    fNguoiDung_Load(sender, e);
                    ResetGridview();
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa nhập đủ thông tin hoặc không tồn tại phân quyền!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            NguoiDung _tv = new NguoiDung();
            _tv.username = txtUsername.Text;
            _tv.password = txtPw.Text;
            if (cbbQuyen.Text == "Admin")
            {
                _tv.phanquyen = 0;
            }
            else if (cbbQuyen.Text == "Member")
            {
                _tv.phanquyen = 1;
            }
            if (txtUsername.Text == "" || txtPw.Text == "")
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (tvBUS.CheckExist("tblNguoiDung", txtUsername.Text) == false)
                XtraMessageBox.Show("Không tồn tại người dùng này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                tvBUS.sua(_tv);
            //load lai
            fNguoiDung_Load(sender, e);
            ResetGridview();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "")
            {
                bool check = tvBUS.Xoa(txtUsername.Text);
                if (!check)
                {
                    XtraMessageBox.Show("Không tồn tại tên tài khoản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ResetGridview();
                    fNguoiDung_Load(sender, e);
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa nhập tên tài khoản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void fNguoiDung_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = tvBUS.GetList();

        }

        private void txtTim_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                gridControl1.DataSource = tvBUS.GetList();
            }
            else
                gridControl1.DataSource = tvBUS.TimKiem(txtTim.Text, "username");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Control control = this.Parent;
            control.Controls.Clear();
            fHoSo frm = new fHoSo(txtUsername.Text, cbbQuyen.Text);
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            control.Controls.Add(frm);
        }
    }
}
