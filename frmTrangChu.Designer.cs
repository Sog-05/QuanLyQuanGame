namespace test
{
    partial class frmTrangChu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.lblXinChao = new System.Windows.Forms.Label();
            this.lblTieuDeTrang = new System.Windows.Forms.Label();
            this.pnlNoiDung = new System.Windows.Forms.Panel();
            this.grpChucNang = new System.Windows.Forms.GroupBox();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnMayTinh = new System.Windows.Forms.Button();
            this.btnQuanLyMonAn = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlNoiDung.SuspendLayout();
            this.grpChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlHeader.Controls.Add(this.btnDangXuat);
            this.pnlHeader.Controls.Add(this.lblTaiKhoan);
            this.pnlHeader.Controls.Add(this.lblXinChao);
            this.pnlHeader.Controls.Add(this.lblTieuDeTrang);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.pnlHeader.Size = new System.Drawing.Size(1024, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTieuDeTrang
            // 
            this.lblTieuDeTrang.AutoSize = true;
            this.lblTieuDeTrang.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTrang.ForeColor = System.Drawing.Color.White;
            this.lblTieuDeTrang.Location = new System.Drawing.Point(24, 16);
            this.lblTieuDeTrang.Name = "lblTieuDeTrang";
            this.lblTieuDeTrang.Size = new System.Drawing.Size(220, 30);
            this.lblTieuDeTrang.TabIndex = 0;
            this.lblTieuDeTrang.Text = "TRANG CHỦ NHÂN VIÊN";
            // 
            // lblXinChao
            // 
            this.lblXinChao.AutoSize = true;
            this.lblXinChao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblXinChao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblXinChao.Location = new System.Drawing.Point(27, 52);
            this.lblXinChao.Name = "lblXinChao";
            this.lblXinChao.Size = new System.Drawing.Size(72, 19);
            this.lblXinChao.TabIndex = 1;
            this.lblXinChao.Text = "Xin chào,...";
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblTaiKhoan.Location = new System.Drawing.Point(600, 20);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(280, 20);
            this.lblTaiKhoan.TabIndex = 2;
            this.lblTaiKhoan.Text = "Tài khoản:";
            this.lblTaiKhoan.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(886, 48);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(110, 32);
            this.btnDangXuat.TabIndex = 3;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // pnlNoiDung
            // 
            this.pnlNoiDung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlNoiDung.Controls.Add(this.grpChucNang);
            this.pnlNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoiDung.Location = new System.Drawing.Point(0, 100);
            this.pnlNoiDung.Name = "pnlNoiDung";
            this.pnlNoiDung.Padding = new System.Windows.Forms.Padding(32);
            this.pnlNoiDung.Size = new System.Drawing.Size(1024, 500);
            this.pnlNoiDung.TabIndex = 1;
            // 
            // grpChucNang
            // 
            this.grpChucNang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grpChucNang.BackColor = System.Drawing.Color.White;
            this.grpChucNang.Controls.Add(this.btnBaoCao);
            this.grpChucNang.Controls.Add(this.btnDanhMuc);
            this.grpChucNang.Controls.Add(this.btnTaiKhoan);
            this.grpChucNang.Controls.Add(this.btnMayTinh);
            this.grpChucNang.Controls.Add(this.btnQuanLyMonAn);
            this.grpChucNang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpChucNang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpChucNang.Location = new System.Drawing.Point(112, 24);
            this.grpChucNang.Name = "grpChucNang";
            this.grpChucNang.Padding = new System.Windows.Forms.Padding(24);
            this.grpChucNang.Size = new System.Drawing.Size(800, 360);
            this.grpChucNang.TabIndex = 0;
            this.grpChucNang.TabStop = false;
            this.grpChucNang.Text = "Chức năng quản lý";
            // 
            // btnQuanLyMonAn
            // 
            this.btnQuanLyMonAn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnQuanLyMonAn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanLyMonAn.FlatAppearance.BorderSize = 0;
            this.btnQuanLyMonAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyMonAn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQuanLyMonAn.ForeColor = System.Drawing.Color.White;
            this.btnQuanLyMonAn.Location = new System.Drawing.Point(40, 40);
            this.btnQuanLyMonAn.Name = "btnQuanLyMonAn";
            this.btnQuanLyMonAn.Size = new System.Drawing.Size(340, 80);
            this.btnQuanLyMonAn.TabIndex = 0;
            this.btnQuanLyMonAn.Text = "Quản lý món ăn";
            this.btnQuanLyMonAn.UseVisualStyleBackColor = false;
            this.btnQuanLyMonAn.Click += new System.EventHandler(this.btnQuanLyMonAn_Click);
            // 
            // btnMayTinh
            // 
            this.btnMayTinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnMayTinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMayTinh.FlatAppearance.BorderSize = 0;
            this.btnMayTinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMayTinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMayTinh.ForeColor = System.Drawing.Color.White;
            this.btnMayTinh.Location = new System.Drawing.Point(420, 40);
            this.btnMayTinh.Name = "btnMayTinh";
            this.btnMayTinh.Size = new System.Drawing.Size(340, 80);
            this.btnMayTinh.TabIndex = 1;
            this.btnMayTinh.Text = "Chọn máy (Thuê máy)";
            this.btnMayTinh.UseVisualStyleBackColor = false;
            this.btnMayTinh.Click += new System.EventHandler(this.btnChonMay_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnTaiKhoan.Location = new System.Drawing.Point(40, 140);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(340, 80);
            this.btnTaiKhoan.TabIndex = 2;
            this.btnTaiKhoan.Text = "Quản lý tài khoản";
            this.btnTaiKhoan.UseVisualStyleBackColor = false;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDanhMuc.FlatAppearance.BorderSize = 0;
            this.btnDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhMuc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDanhMuc.ForeColor = System.Drawing.Color.White;
            this.btnDanhMuc.Location = new System.Drawing.Point(420, 140);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(340, 80);
            this.btnDanhMuc.TabIndex = 3;
            this.btnDanhMuc.Text = "Quản lý danh mục";
            this.btnDanhMuc.UseVisualStyleBackColor = false;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(115)))), ((int)(((byte)(22)))));
            this.btnBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCao.FlatAppearance.BorderSize = 0;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnBaoCao.Location = new System.Drawing.Point(230, 240);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(340, 80);
            this.btnBaoCao.TabIndex = 4;
            this.btnBaoCao.Text = "Báo cáo & Thống kê";
            this.btnBaoCao.UseVisualStyleBackColor = false;
            this.btnBaoCao.Click += (s, e) => {
                using (var f = new frmBaoCao()) f.ShowDialog();
            };
            this.grpChucNang.Controls.Add(this.btnBaoCao);
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pnlNoiDung);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "frmTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ - Quản lý quán game";
            this.Load += new System.EventHandler(this.frmTrangChu_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlNoiDung.ResumeLayout(false);
            this.grpChucNang.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDeTrang;
        private System.Windows.Forms.Label lblXinChao;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Panel pnlNoiDung;
        private System.Windows.Forms.GroupBox grpChucNang;
        private System.Windows.Forms.Button btnQuanLyMonAn;
        private System.Windows.Forms.Button btnMayTinh;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnBaoCao;
    }
}
