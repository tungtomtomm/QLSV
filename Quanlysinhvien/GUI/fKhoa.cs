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
    public partial class fKhoa : DevExpress.XtraEditors.XtraUserControl
    {
        Khoa_BUS khoaBUS = new Khoa_BUS();
        public fKhoa()
        {
            InitializeComponent();
        }

        private void fKhoa_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = khoaBUS.GetList();

        }
        private void ResetGridview()
        {
            txtMaKhoa.ResetText();
            txtTenKhoa.ResetText();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            txtMaKhoa.Text = gridView1.GetRowCellValue(e.RowHandle, "makhoa").ToString();
            txtTenKhoa.Text = gridView1.GetRowCellValue(e.RowHandle, "tenkhoa").ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Khoa _k = new Khoa();
            _k.makhoa = txtMaKhoa.Text;
            _k.tenkhoa = txtTenKhoa.Text;

            //kiem tra loi makhoa
            int check = khoaBUS.Them(_k);
            if (check == 0)
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (check == -1)
                XtraMessageBox.Show("Mã khoa đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //load lai
            fKhoa_Load(sender, e);
            ResetGridview();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Khoa _k = new Khoa();
            _k.makhoa = txtMaKhoa.Text;
            _k.tenkhoa = txtTenKhoa.Text;
            if (!khoaBUS.Sua(_k))
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            fKhoa_Load(sender, e);
            ResetGridview();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text != "")
            {
                int check= khoaBUS.Xoa(txtMaKhoa.Text);
                if (check == -1)
                {
                    XtraMessageBox.Show("Tồn tại giảng viên, ngành học, môn học thuộc khoa này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ResetGridview();
                    fKhoa_Load(sender, e);
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa nhập mã khoa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTimKhoa_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTimKhoa.Text == "")
            {
                gridControl1.DataSource = khoaBUS.GetList();
            }
            else
                gridControl1.DataSource = khoaBUS.TimKiem(txtTimKhoa.Text, "tenkhoa");
        }
    }
}
