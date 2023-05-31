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
    public partial class fNganh : DevExpress.XtraEditors.XtraUserControl
    {
        Nganh_BUS nBUS = new Nganh_BUS();
        public fNganh()
        {
            InitializeComponent();
        }

        private void fNganh_Load(object sender, EventArgs e)
        {

            gridControl1.DataSource = nBUS.GetList();
        }
        private void ResetGridview()
        {
            txtMaKhoa.ResetText();
            txtMaNganh.ResetText();
            txtTen.ResetText();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            txtMaNganh.Text = gridView1.GetRowCellValue(e.RowHandle, "manganh").ToString();
            txtMaKhoa.Text = gridView1.GetRowCellValue(e.RowHandle, "makhoa").ToString();
            txtTen.Text = gridView1.GetRowCellValue(e.RowHandle, "tennganh").ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
             Nganh _n= new Nganh();
            
            _n.manganh = txtMaNganh.Text;
            _n.makhoa = txtMaKhoa.Text;
            _n.tennganh = txtTen.Text;

            if (txtMaKhoa.Text == "" || txtMaNganh.Text == "" || txtTen.Text == "")
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (nBUS.CheckExist("tblNganh", txtMaNganh.Text))
                XtraMessageBox.Show("Mã ngành đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (nBUS.CheckExist("tblKhoa", txtMaKhoa.Text) == false)
                XtraMessageBox.Show("Không tồn tại mã khoa này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                nBUS.Them(_n);
            }
            
            fNganh_Load(sender, e);
            ResetGridview();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Nganh _n = new Nganh();

            _n.manganh = txtMaNganh.Text;
            _n.makhoa = txtMaKhoa.Text;
            _n.tennganh = txtTen.Text;
            if (txtMaKhoa.Text == "" || txtMaNganh.Text == "" || txtTen.Text == "")
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (nBUS.CheckExist("tblNganh", txtMaNganh.Text) == false)
                XtraMessageBox.Show("Mã ngành đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (nBUS.CheckExist("tblKhoa", txtMaKhoa.Text) == false)
                XtraMessageBox.Show("Không tồn tại mã khoa này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                nBUS.Sua(_n);
            //load lai
            fNganh_Load(sender, e);
            ResetGridview();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNganh.Text != "")
            {
                int check = nBUS.Xoa(txtMaNganh.Text);
                if (check == -1)
                {
                    XtraMessageBox.Show("Tồn tại lớp học thuộc ngành này phụ trách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (check == 1)
                {
                    XtraMessageBox.Show("Không tồn tại mã ngành cần xoá!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    ResetGridview();
                    fNganh_Load(sender, e);
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
                gridControl1.DataSource = nBUS.GetList();

            }
            else
            {
                if (rdTen.Checked == true)
                    gridControl1.DataSource = nBUS.TimKiem(txtTim.Text, "tennganh");
                else if (rdMaKhoa.Checked == true)
                    gridControl1.DataSource = nBUS.TimKiem(txtTim.Text, "makhoa");
                else if (rdMaNganh.Checked == true)
                    gridControl1.DataSource = nBUS.TimKiem(txtTim.Text, "manganh");
            }
        }
    }
}
