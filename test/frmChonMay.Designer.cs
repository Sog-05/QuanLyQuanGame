namespace test
{
    partial class frmChonMay
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
            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlThan = new System.Windows.Forms.Panel();
            this.pnlMenuKhu = new System.Windows.Forms.Panel();
            this.btnThiDau = new System.Windows.Forms.Button();
            this.btnStream = new System.Windows.Forms.Button();
            this.btnGaming = new System.Windows.Forms.Button();
            this.btnTieuChuan = new System.Windows.Forms.Button();
            this.lblMenuKhu = new System.Windows.Forms.Label();
            this.pnlKhuVuc = new System.Windows.Forms.Panel();
            this.flpDanhSachMay = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCauHinh = new System.Windows.Forms.Label();
            this.lblGiaKhu = new System.Windows.Forms.Label();
            this.lblTenKhuDangXem = new System.Windows.Forms.Label();
            this.pnlChiTiet = new System.Windows.Forms.Panel();
            this.lblTongHoaDon = new System.Windows.Forms.Label();
            this.lblTamTinh = new System.Windows.Forms.Label();
            this.lblThoiGianKetThuc = new System.Windows.Forms.Label();
            this.lblThoiGianBatDau = new System.Windows.Forms.Label();
            this.lblPhien = new System.Windows.Forms.Label();
            this.lblTrangThaiMay = new System.Windows.Forms.Label();
            this.lblTenMayChiTiet = new System.Windows.Forms.Label();
            this.lblChiTietTieuDe = new System.Windows.Forms.Label();
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.lblMonAn = new System.Windows.Forms.Label();
            this.pnlNutChiTiet = new System.Windows.Forms.Panel();
            this.btnTatMay = new System.Windows.Forms.Button();
            this.btnBatMay = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTaoHoaDon = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.pnlChuThich = new System.Windows.Forms.FlowLayoutPanel();
            this.lblChuThichOffline = new System.Windows.Forms.Label();
            this.lblChuThichOnline = new System.Windows.Forms.Label();
            this.lblChuThichBaoTri = new System.Windows.Forms.Label();
            this.pnlTieuDe.SuspendLayout();
            this.pnlThan.SuspendLayout();
            this.pnlMenuKhu.SuspendLayout();
            this.pnlKhuVuc.SuspendLayout();
            this.pnlChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            this.pnlNutChiTiet.SuspendLayout();
            this.pnlChuThich.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTieuDe
            // 
            this.pnlTieuDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlTieuDe.Controls.Add(this.lblNhanVien);
            this.pnlTieuDe.Controls.Add(this.lblTieuDe);
            this.pnlTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTieuDe.Location = new System.Drawing.Point(0, 0);
            this.pnlTieuDe.Name = "pnlTieuDe";
            this.pnlTieuDe.Size = new System.Drawing.Size(1180, 56);
            this.pnlTieuDe.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(400, 56);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "CHỌN MÁY";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblNhanVien.Location = new System.Drawing.Point(680, 0);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(480, 56);
            this.lblNhanVien.TabIndex = 1;
            this.lblNhanVien.Text = "Mã NV: — | Tên NV: —";
            this.lblNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlThan
            // 
            this.pnlThan.Controls.Add(this.pnlChiTiet);
            this.pnlThan.Controls.Add(this.pnlKhuVuc);
            this.pnlThan.Controls.Add(this.pnlMenuKhu);
            this.pnlThan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThan.Location = new System.Drawing.Point(0, 56);
            this.pnlThan.Name = "pnlThan";
            this.pnlThan.Size = new System.Drawing.Size(1180, 624);
            this.pnlThan.TabIndex = 1;
            // 
            // pnlMenuKhu
            // 
            this.pnlMenuKhu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlMenuKhu.Controls.Add(this.btnThiDau);
            this.pnlMenuKhu.Controls.Add(this.btnStream);
            this.pnlMenuKhu.Controls.Add(this.btnGaming);
            this.pnlMenuKhu.Controls.Add(this.btnTieuChuan);
            this.pnlMenuKhu.Controls.Add(this.lblMenuKhu);
            this.pnlMenuKhu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuKhu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuKhu.Name = "pnlMenuKhu";
            this.pnlMenuKhu.Padding = new System.Windows.Forms.Padding(8, 12, 8, 12);
            this.pnlMenuKhu.Size = new System.Drawing.Size(160, 624);
            this.pnlMenuKhu.TabIndex = 0;
            // 
            // lblMenuKhu
            // 
            this.lblMenuKhu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMenuKhu.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMenuKhu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblMenuKhu.Location = new System.Drawing.Point(8, 12);
            this.lblMenuKhu.Name = "lblMenuKhu";
            this.lblMenuKhu.Padding = new System.Windows.Forms.Padding(4, 0, 0, 8);
            this.lblMenuKhu.Size = new System.Drawing.Size(144, 28);
            this.lblMenuKhu.TabIndex = 0;
            this.lblMenuKhu.Text = "KHU VỰC";
            this.lblMenuKhu.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnTieuChuan
            // 
            this.btnTieuChuan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTieuChuan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTieuChuan.FlatAppearance.BorderSize = 0;
            this.btnTieuChuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTieuChuan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTieuChuan.ForeColor = System.Drawing.Color.White;
            this.btnTieuChuan.Location = new System.Drawing.Point(8, 40);
            this.btnTieuChuan.Name = "btnTieuChuan";
            this.btnTieuChuan.Size = new System.Drawing.Size(144, 48);
            this.btnTieuChuan.TabIndex = 1;
            this.btnTieuChuan.Text = "Tiêu chuẩn";
            this.btnTieuChuan.UseVisualStyleBackColor = true;
            this.btnTieuChuan.Click += new System.EventHandler(this.NutKhuVuc_Click);
            // 
            // btnGaming
            // 
            this.btnGaming.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGaming.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGaming.FlatAppearance.BorderSize = 0;
            this.btnGaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGaming.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGaming.ForeColor = System.Drawing.Color.White;
            this.btnGaming.Location = new System.Drawing.Point(8, 88);
            this.btnGaming.Name = "btnGaming";
            this.btnGaming.Size = new System.Drawing.Size(144, 48);
            this.btnGaming.TabIndex = 2;
            this.btnGaming.Text = "Gaming";
            this.btnGaming.UseVisualStyleBackColor = true;
            this.btnGaming.Click += new System.EventHandler(this.NutKhuVuc_Click);
            // 
            // btnStream
            // 
            this.btnStream.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStream.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStream.FlatAppearance.BorderSize = 0;
            this.btnStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStream.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStream.ForeColor = System.Drawing.Color.White;
            this.btnStream.Location = new System.Drawing.Point(8, 136);
            this.btnStream.Name = "btnStream";
            this.btnStream.Size = new System.Drawing.Size(144, 48);
            this.btnStream.TabIndex = 3;
            this.btnStream.Text = "Stream";
            this.btnStream.UseVisualStyleBackColor = true;
            this.btnStream.Click += new System.EventHandler(this.NutKhuVuc_Click);
            // 
            // btnThiDau
            // 
            this.btnThiDau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThiDau.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThiDau.FlatAppearance.BorderSize = 0;
            this.btnThiDau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThiDau.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThiDau.ForeColor = System.Drawing.Color.White;
            this.btnThiDau.Location = new System.Drawing.Point(8, 184);
            this.btnThiDau.Name = "btnThiDau";
            this.btnThiDau.Size = new System.Drawing.Size(144, 48);
            this.btnThiDau.TabIndex = 4;
            this.btnThiDau.Text = "Thi đấu";
            this.btnThiDau.UseVisualStyleBackColor = true;
            this.btnThiDau.Click += new System.EventHandler(this.NutKhuVuc_Click);
            // 
            // pnlKhuVuc
            // 
            this.pnlKhuVuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlKhuVuc.Controls.Add(this.flpDanhSachMay);
            this.pnlKhuVuc.Controls.Add(this.lblCauHinh);
            this.pnlKhuVuc.Controls.Add(this.lblGiaKhu);
            this.pnlKhuVuc.Controls.Add(this.lblTenKhuDangXem);
            this.pnlKhuVuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKhuVuc.Location = new System.Drawing.Point(160, 0);
            this.pnlKhuVuc.Name = "pnlKhuVuc";
            this.pnlKhuVuc.Padding = new System.Windows.Forms.Padding(16);
            this.pnlKhuVuc.Size = new System.Drawing.Size(680, 624);
            this.pnlKhuVuc.TabIndex = 1;
            // 
            // lblTenKhuDangXem
            // 
            this.lblTenKhuDangXem.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTenKhuDangXem.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTenKhuDangXem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTenKhuDangXem.Location = new System.Drawing.Point(16, 16);
            this.lblTenKhuDangXem.Name = "lblTenKhuDangXem";
            this.lblTenKhuDangXem.Size = new System.Drawing.Size(648, 32);
            this.lblTenKhuDangXem.TabIndex = 0;
            this.lblTenKhuDangXem.Text = "Khu vực Tiêu chuẩn";
            // 
            // lblGiaKhu
            // 
            this.lblGiaKhu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGiaKhu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGiaKhu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.lblGiaKhu.Location = new System.Drawing.Point(16, 48);
            this.lblGiaKhu.Name = "lblGiaKhu";
            this.lblGiaKhu.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblGiaKhu.Size = new System.Drawing.Size(648, 24);
            this.lblGiaKhu.TabIndex = 1;
            this.lblGiaKhu.Text = "Giá: 8.000 đ/giờ";
            // 
            // lblCauHinh
            // 
            this.lblCauHinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCauHinh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCauHinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCauHinh.Location = new System.Drawing.Point(16, 72);
            this.lblCauHinh.Name = "lblCauHinh";
            this.lblCauHinh.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblCauHinh.Size = new System.Drawing.Size(648, 40);
            this.lblCauHinh.TabIndex = 2;
            this.lblCauHinh.Text = "Cấu hình chung: —";
            // 
            // flpDanhSachMay
            // 
            this.flpDanhSachMay.AutoScroll = true;
            this.flpDanhSachMay.BackColor = System.Drawing.Color.White;
            this.flpDanhSachMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDanhSachMay.Location = new System.Drawing.Point(16, 112);
            this.flpDanhSachMay.Name = "flpDanhSachMay";
            this.flpDanhSachMay.Padding = new System.Windows.Forms.Padding(8);
            this.flpDanhSachMay.Size = new System.Drawing.Size(648, 496);
            this.flpDanhSachMay.TabIndex = 3;
            // 
            // pnlChiTiet
            // 
            this.pnlChiTiet.BackColor = System.Drawing.Color.White;
            this.pnlChiTiet.Controls.Add(this.pnlChuThich);
            this.pnlChiTiet.Controls.Add(this.pnlNutChiTiet);
            this.pnlChiTiet.Controls.Add(this.lblTongHoaDon);
            this.pnlChiTiet.Controls.Add(this.dgvMonAn);
            this.pnlChiTiet.Controls.Add(this.lblMonAn);
            this.pnlChiTiet.Controls.Add(this.lblTamTinh);
            this.pnlChiTiet.Controls.Add(this.lblThoiGianKetThuc);
            this.pnlChiTiet.Controls.Add(this.lblThoiGianBatDau);
            this.pnlChiTiet.Controls.Add(this.lblPhien);
            this.pnlChiTiet.Controls.Add(this.lblTrangThaiMay);
            this.pnlChiTiet.Controls.Add(this.lblTenMayChiTiet);
            this.pnlChiTiet.Controls.Add(this.lblChiTietTieuDe);
            this.pnlChiTiet.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlChiTiet.Location = new System.Drawing.Point(840, 0);
            this.pnlChiTiet.Name = "pnlChiTiet";
            this.pnlChiTiet.Padding = new System.Windows.Forms.Padding(16);
            this.pnlChiTiet.Size = new System.Drawing.Size(340, 624);
            this.pnlChiTiet.TabIndex = 2;
            // 
            // lblChiTietTieuDe
            // 
            this.lblChiTietTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChiTietTieuDe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChiTietTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblChiTietTieuDe.Location = new System.Drawing.Point(16, 16);
            this.lblChiTietTieuDe.Name = "lblChiTietTieuDe";
            this.lblChiTietTieuDe.Size = new System.Drawing.Size(308, 28);
            this.lblChiTietTieuDe.TabIndex = 0;
            this.lblChiTietTieuDe.Text = "Chi tiết máy";
            // 
            // lblTenMayChiTiet
            // 
            this.lblTenMayChiTiet.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTenMayChiTiet.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTenMayChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.lblTenMayChiTiet.Location = new System.Drawing.Point(16, 44);
            this.lblTenMayChiTiet.Name = "lblTenMayChiTiet";
            this.lblTenMayChiTiet.Size = new System.Drawing.Size(308, 32);
            this.lblTenMayChiTiet.TabIndex = 1;
            this.lblTenMayChiTiet.Text = "—";
            // 
            // lblTrangThaiMay
            // 
            this.lblTrangThaiMay.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTrangThaiMay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiMay.Location = new System.Drawing.Point(16, 76);
            this.lblTrangThaiMay.Name = "lblTrangThaiMay";
            this.lblTrangThaiMay.Size = new System.Drawing.Size(308, 22);
            this.lblTrangThaiMay.TabIndex = 2;
            this.lblTrangThaiMay.Text = "Trạng thái: —";
            // 
            // lblPhien
            // 
            this.lblPhien.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPhien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhien.Location = new System.Drawing.Point(16, 98);
            this.lblPhien.Name = "lblPhien";
            this.lblPhien.Size = new System.Drawing.Size(308, 20);
            this.lblPhien.TabIndex = 3;
            this.lblPhien.Text = "Phiên: —";
            // 
            // lblThoiGianBatDau
            // 
            this.lblThoiGianBatDau.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblThoiGianBatDau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThoiGianBatDau.Location = new System.Drawing.Point(16, 118);
            this.lblThoiGianBatDau.Name = "lblThoiGianBatDau";
            this.lblThoiGianBatDau.Size = new System.Drawing.Size(308, 20);
            this.lblThoiGianBatDau.TabIndex = 4;
            this.lblThoiGianBatDau.Text = "Bắt đầu: —";
            // 
            // lblThoiGianKetThuc
            // 
            this.lblThoiGianKetThuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblThoiGianKetThuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThoiGianKetThuc.Location = new System.Drawing.Point(16, 138);
            this.lblThoiGianKetThuc.Name = "lblThoiGianKetThuc";
            this.lblThoiGianKetThuc.Size = new System.Drawing.Size(308, 20);
            this.lblThoiGianKetThuc.TabIndex = 5;
            this.lblThoiGianKetThuc.Text = "Kết thúc: —";
            // 
            // lblTamTinh
            // 
            this.lblTamTinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTamTinh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTamTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTamTinh.Location = new System.Drawing.Point(16, 158);
            this.lblTamTinh.Name = "lblTamTinh";
            this.lblTamTinh.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblTamTinh.Size = new System.Drawing.Size(308, 28);
            this.lblTamTinh.TabIndex = 6;
            this.lblTamTinh.Text = "Tạm tính máy: —";
            // 
            // lblMonAn
            // 
            this.lblMonAn.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMonAn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMonAn.Location = new System.Drawing.Point(16, 186);
            this.lblMonAn.Name = "lblMonAn";
            this.lblMonAn.Size = new System.Drawing.Size(308, 20);
            this.lblMonAn.TabIndex = 7;
            this.lblMonAn.Text = "Món khách đã đặt";
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.AllowUserToAddRows = false;
            this.dgvMonAn.AllowUserToDeleteRows = false;
            this.dgvMonAn.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonAn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonAn.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.dgvMonAn.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvMonAn.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvMonAn.Location = new System.Drawing.Point(16, 206);
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.ReadOnly = true;
            this.dgvMonAn.RowHeadersVisible = false;
            this.dgvMonAn.Size = new System.Drawing.Size(308, 140);
            this.dgvMonAn.TabIndex = 8;
            // 
            // lblTongHoaDon
            // 
            this.lblTongHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTongHoaDon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblTongHoaDon.Location = new System.Drawing.Point(16, 346);
            this.lblTongHoaDon.Name = "lblTongHoaDon";
            this.lblTongHoaDon.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.lblTongHoaDon.Size = new System.Drawing.Size(308, 40);
            this.lblTongHoaDon.TabIndex = 9;
            this.lblTongHoaDon.Text = "Tổng hóa đơn: —";
            // 
            // pnlNutChiTiet
            // 
            this.pnlNutChiTiet.Controls.Add(this.btnTatMay);
            this.pnlNutChiTiet.Controls.Add(this.btnBatMay);
            this.pnlNutChiTiet.Controls.Add(this.btnDong);
            this.pnlNutChiTiet.Controls.Add(this.btnTaoHoaDon);
            this.pnlNutChiTiet.Controls.Add(this.btnCapNhat);
            this.pnlNutChiTiet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNutChiTiet.Location = new System.Drawing.Point(16, 520);
            this.pnlNutChiTiet.Name = "pnlNutChiTiet";
            this.pnlNutChiTiet.Size = new System.Drawing.Size(308, 88);
            this.pnlNutChiTiet.TabIndex = 10;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnCapNhat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapNhat.FlatAppearance.BorderSize = 0;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(0, 0);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(148, 36);
            this.btnCapNhat.TabIndex = 0;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnTaoHoaDon
            // 
            this.btnTaoHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnTaoHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoHoaDon.FlatAppearance.BorderSize = 0;
            this.btnTaoHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnTaoHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnTaoHoaDon.Location = new System.Drawing.Point(158, 0);
            this.btnTaoHoaDon.Name = "btnTaoHoaDon";
            this.btnTaoHoaDon.Size = new System.Drawing.Size(150, 36);
            this.btnTaoHoaDon.TabIndex = 1;
            this.btnTaoHoaDon.Text = "Tạo hóa đơn";
            this.btnTaoHoaDon.UseVisualStyleBackColor = false;
            this.btnTaoHoaDon.Click += new System.EventHandler(this.btnTaoHoaDon_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(158, 44);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(150, 36);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnBatMay
            // 
            this.btnBatMay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnBatMay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatMay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnBatMay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatMay.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnBatMay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnBatMay.Location = new System.Drawing.Point(0, 44);
            this.btnBatMay.Name = "btnBatMay";
            this.btnBatMay.Size = new System.Drawing.Size(72, 36);
            this.btnBatMay.TabIndex = 3;
            this.btnBatMay.Text = "Bật máy";
            this.btnBatMay.UseVisualStyleBackColor = false;
            this.btnBatMay.Click += new System.EventHandler(this.btnBatMay_Click);
            // 
            // btnTatMay
            // 
            this.btnTatMay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTatMay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTatMay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnTatMay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTatMay.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnTatMay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnTatMay.Location = new System.Drawing.Point(76, 44);
            this.btnTatMay.Name = "btnTatMay";
            this.btnTatMay.Size = new System.Drawing.Size(72, 36);
            this.btnTatMay.TabIndex = 4;
            this.btnTatMay.Text = "Tắt máy";
            this.btnTatMay.UseVisualStyleBackColor = false;
            this.btnTatMay.Click += new System.EventHandler(this.btnTatMay_Click);
            // 
            // pnlChuThich
            // 
            this.pnlChuThich.Controls.Add(this.lblChuThichOffline);
            this.pnlChuThich.Controls.Add(this.lblChuThichOnline);
            this.pnlChuThich.Controls.Add(this.lblChuThichBaoTri);
            this.pnlChuThich.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChuThich.Location = new System.Drawing.Point(16, 468);
            this.pnlChuThich.Name = "pnlChuThich";
            this.pnlChuThich.Size = new System.Drawing.Size(308, 52);
            this.pnlChuThich.TabIndex = 11;
            this.pnlChuThich.WrapContents = false;
            // 
            // lblChuThichOffline
            // 
            this.lblChuThichOffline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblChuThichOffline.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblChuThichOffline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblChuThichOffline.Location = new System.Drawing.Point(0, 8);
            this.lblChuThichOffline.Margin = new System.Windows.Forms.Padding(0, 8, 6, 0);
            this.lblChuThichOffline.Name = "lblChuThichOffline";
            this.lblChuThichOffline.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblChuThichOffline.Size = new System.Drawing.Size(58, 24);
            this.lblChuThichOffline.TabIndex = 0;
            this.lblChuThichOffline.Text = "Offline";
            this.lblChuThichOffline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChuThichOnline
            // 
            this.lblChuThichOnline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblChuThichOnline.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblChuThichOnline.ForeColor = System.Drawing.Color.White;
            this.lblChuThichOnline.Location = new System.Drawing.Point(64, 8);
            this.lblChuThichOnline.Margin = new System.Windows.Forms.Padding(0, 8, 6, 0);
            this.lblChuThichOnline.Name = "lblChuThichOnline";
            this.lblChuThichOnline.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblChuThichOnline.Size = new System.Drawing.Size(58, 24);
            this.lblChuThichOnline.TabIndex = 1;
            this.lblChuThichOnline.Text = "Online";
            this.lblChuThichOnline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChuThichBaoTri
            // 
            this.lblChuThichBaoTri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblChuThichBaoTri.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblChuThichBaoTri.ForeColor = System.Drawing.Color.White;
            this.lblChuThichBaoTri.Location = new System.Drawing.Point(128, 8);
            this.lblChuThichBaoTri.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblChuThichBaoTri.Name = "lblChuThichBaoTri";
            this.lblChuThichBaoTri.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblChuThichBaoTri.Size = new System.Drawing.Size(58, 24);
            this.lblChuThichBaoTri.TabIndex = 2;
            this.lblChuThichBaoTri.Text = "Bảo trì";
            this.lblChuThichBaoTri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmChonMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 680);
            this.Controls.Add(this.pnlThan);
            this.Controls.Add(this.pnlTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmChonMay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn máy";
            this.Load += new System.EventHandler(this.frmChonMay_Load);
            this.pnlTieuDe.ResumeLayout(false);
            this.pnlThan.ResumeLayout(false);
            this.pnlMenuKhu.ResumeLayout(false);
            this.pnlKhuVuc.ResumeLayout(false);
            this.pnlChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            this.pnlNutChiTiet.ResumeLayout(false);
            this.pnlChuThich.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Panel pnlThan;
        private System.Windows.Forms.Panel pnlMenuKhu;
        private System.Windows.Forms.Label lblMenuKhu;
        private System.Windows.Forms.Button btnTieuChuan;
        private System.Windows.Forms.Button btnGaming;
        private System.Windows.Forms.Button btnStream;
        private System.Windows.Forms.Button btnThiDau;
        private System.Windows.Forms.Panel pnlKhuVuc;
        private System.Windows.Forms.Label lblTenKhuDangXem;
        private System.Windows.Forms.Label lblGiaKhu;
        private System.Windows.Forms.Label lblCauHinh;
        private System.Windows.Forms.FlowLayoutPanel flpDanhSachMay;
        private System.Windows.Forms.Panel pnlChiTiet;
        private System.Windows.Forms.Label lblChiTietTieuDe;
        private System.Windows.Forms.Label lblTenMayChiTiet;
        private System.Windows.Forms.Label lblTrangThaiMay;
        private System.Windows.Forms.Label lblPhien;
        private System.Windows.Forms.Label lblThoiGianBatDau;
        private System.Windows.Forms.Label lblThoiGianKetThuc;
        private System.Windows.Forms.Label lblTamTinh;
        private System.Windows.Forms.Label lblMonAn;
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.Label lblTongHoaDon;
        private System.Windows.Forms.Panel pnlNutChiTiet;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnTaoHoaDon;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnBatMay;
        private System.Windows.Forms.Button btnTatMay;
        private System.Windows.Forms.FlowLayoutPanel pnlChuThich;
        private System.Windows.Forms.Label lblChuThichOffline;
        private System.Windows.Forms.Label lblChuThichOnline;
        private System.Windows.Forms.Label lblChuThichBaoTri;
    }
}
