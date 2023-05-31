namespace Quanlysinhvien.GUI
{
    partial class fDangKyHP
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDangKyHP));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnDangky = new DevExpress.XtraEditors.SimpleButton();
            this.cbbMaLHP = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrangThai = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrangThai.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtTrangThai);
            this.panelControl1.Controls.Add(this.btnDangky);
            this.panelControl1.Controls.Add(this.cbbMaLHP);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(849, 432);
            this.panelControl1.TabIndex = 0;
            // 
            // btnDangky
            // 
            this.btnDangky.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangky.Appearance.Options.UseFont = true;
            this.btnDangky.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangky.ImageOptions.Image")));
            this.btnDangky.Location = new System.Drawing.Point(645, 94);
            this.btnDangky.Name = "btnDangky";
            this.btnDangky.Size = new System.Drawing.Size(137, 50);
            this.btnDangky.TabIndex = 2;
            this.btnDangky.Text = "Đăng ký";
            this.btnDangky.Click += new System.EventHandler(this.btnDangky_Click);
            // 
            // cbbMaLHP
            // 
            this.cbbMaLHP.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbMaLHP.FormattingEnabled = true;
            this.cbbMaLHP.Location = new System.Drawing.Point(317, 106);
            this.cbbMaLHP.Name = "cbbMaLHP";
            this.cbbMaLHP.Size = new System.Drawing.Size(281, 29);
            this.cbbMaLHP.TabIndex = 1;
            this.cbbMaLHP.SelectedIndexChanged += new System.EventHandler(this.cbbMaLHP_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(123, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn mã lớp học phần";
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(209, 229);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(248, 22);
            this.txtTrangThai.TabIndex = 3;
            this.txtTrangThai.Visible = false;
            // 
            // fDangKyHP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "fDangKyHP";
            this.Size = new System.Drawing.Size(849, 432);
            this.Load += new System.EventHandler(this.fDangKyHP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrangThai.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox cbbMaLHP;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnDangky;
        private DevExpress.XtraEditors.TextEdit txtTrangThai;
    }
}
