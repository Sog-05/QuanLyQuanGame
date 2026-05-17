using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace test
{
    public partial class frmChonMay : Form
    {
        private const string TrangThaiOnline = "Online";
        private const string TrangThaiOffline = "Offline";
        private const string TrangThaiBaoTri = "Bảo trì";

        private readonly List<MayHienThi> _danhSachMay = new List<MayHienThi>();
        private readonly Dictionary<int, Button> _nutMay = new Dictionary<int, Button>();
        private readonly Dictionary<string, int?> _maKhuTheoMenu = new Dictionary<string, int?>();

        private string _menuKhuDangChon = "Tiêu chuẩn";
        private int? _maMayChon;
        private Button _nutMenuDangChon;

        public frmChonMay()
        {
            InitializeComponent();
        }

        private void frmChonMay_Load(object sender, EventArgs e)
        {
            lblNhanVien.Text = string.Format("Mã NV: {0} | Tên NV: {1}",
                PhienLamViec.MaNhanVien > 0 ? PhienLamViec.MaNhanVien.ToString() : "—",
                ChuoiTiengViet.ChuanHoa(PhienLamViec.TenNhanVien) ?? "—");

            NapAnhXaKhuVuc();
            NapDanhSachMay();
            ChonMenuKhu(btnTieuChuan, "Tiêu chuẩn");
            XoaChiTietMay();
        }

        private void NapAnhXaKhuVuc()
        {
            _maKhuTheoMenu.Clear();
            var bang = KetNoiCSDL.ThucThiTruyVan("SELECT MaKhuVuc, TenKhuVuc FROM KhuVuc");
            ChuoiTiengViet.ChuanHoaBang(bang, "TenKhuVuc");

            _maKhuTheoMenu["Tiêu chuẩn"] = TimMaKhu(bang, "thường", "tiêu chuẩn", "tieu chuan");
            _maKhuTheoMenu["Gaming"] = TimMaKhu(bang, "vip", "gaming", "couple");
            _maKhuTheoMenu["Stream"] = TimMaKhu(bang, "stream");
            _maKhuTheoMenu["Thi đấu"] = TimMaKhu(bang, "thi đấu", "thi dau", "thi");

            if (!_maKhuTheoMenu["Tiêu chuẩn"].HasValue && bang.Rows.Count > 0)
                _maKhuTheoMenu["Tiêu chuẩn"] = Convert.ToInt32(bang.Rows[0]["MaKhuVuc"]);
            if (!_maKhuTheoMenu["Gaming"].HasValue && bang.Rows.Count > 1)
                _maKhuTheoMenu["Gaming"] = Convert.ToInt32(bang.Rows[1]["MaKhuVuc"]);
            if (!_maKhuTheoMenu["Stream"].HasValue && bang.Rows.Count > 2)
                _maKhuTheoMenu["Stream"] = Convert.ToInt32(bang.Rows[2]["MaKhuVuc"]);
            if (!_maKhuTheoMenu["Thi đấu"].HasValue && bang.Rows.Count > 3)
                _maKhuTheoMenu["Thi đấu"] = Convert.ToInt32(bang.Rows[3]["MaKhuVuc"]);
        }

        private static int? TimMaKhu(DataTable bang, params string[] tuKhoa)
        {
            foreach (DataRow dong in bang.Rows)
            {
                string ten = ChuoiTiengViet.ChuanHoa(dong["TenKhuVuc"].ToString()).ToLowerInvariant();
                if (tuKhoa.Any(k => ten.Contains(k)))
                    return Convert.ToInt32(dong["MaKhuVuc"]);
            }
            return null;
        }

        private void NapDanhSachMay()
        {
            const string sql = @"
                SELECT
                    m.MaMay, m.TenMay, m.MaKhuVuc, kv.TenKhuVuc, kv.GiaTheoGio,
                    c.TenCPU, g.TenGPU, r.TenRAM,
                    CASE
                        WHEN EXISTS (
                            SELECT 1 FROM BaoTri bt
                            WHERE bt.MaMay = m.MaMay
                              AND bt.TrangThaiBaoTri IN (N'Đang bảo trì', N'Đang sửa chữa')
                        ) THEN N'Bảo trì'
                        WHEN EXISTS (
                            SELECT 1 FROM PhienSuDung ps
                            WHERE ps.MaMay = m.MaMay AND ps.ThoiGianKetThuc > GETDATE()
                        ) THEN N'Online'
                        ELSE N'Offline'
                    END AS TrangThaiHienThi
                FROM MayTinh m
                INNER JOIN KhuVuc kv ON m.MaKhuVuc = kv.MaKhuVuc
                LEFT JOIN CPU c ON m.MaCPU = c.MaCPU
                LEFT JOIN GPU g ON m.MaGPU = g.MaGPU
                LEFT JOIN RAM r ON m.MaRAM = r.MaRAM
                ORDER BY m.TenMay";

            var bang = KetNoiCSDL.ThucThiTruyVan(sql);
            _danhSachMay.Clear();

            foreach (DataRow dong in bang.Rows)
            {
                _danhSachMay.Add(new MayHienThi
                {
                    MaMay = Convert.ToInt32(dong["MaMay"]),
                    TenMay = ChuoiTiengViet.ChuanHoa(dong["TenMay"].ToString()),
                    MaKhuVuc = Convert.ToInt32(dong["MaKhuVuc"]),
                    TenKhuVuc = ChuoiTiengViet.ChuanHoa(dong["TenKhuVuc"].ToString()),
                    GiaTheoGio = Convert.ToDecimal(dong["GiaTheoGio"]),
                    TenCpu = ChuoiTiengViet.ChuanHoa(dong["TenCPU"]?.ToString()),
                    TenGpu = ChuoiTiengViet.ChuanHoa(dong["TenGPU"]?.ToString()),
                    TenRam = ChuoiTiengViet.ChuanHoa(dong["TenRAM"]?.ToString()),
                    TrangThai = ChuoiTiengViet.ChuanHoa(dong["TrangThaiHienThi"].ToString())
                });
            }
        }

        private void NutKhuVuc_Click(object sender, EventArgs e)
        {
            var nut = (Button)sender;
            string tenMenu = nut.Text;
            ChonMenuKhu(nut, tenMenu);
        }

        private void ChonMenuKhu(Button nut, string tenMenu)
        {
            _menuKhuDangChon = tenMenu;
            if (_nutMenuDangChon != null)
                DatMauNutMenu(_nutMenuDangChon, false);
            _nutMenuDangChon = nut;
            DatMauNutMenu(nut, true);
            HienThiKhuVuc(tenMenu);
        }

        private static void DatMauNutMenu(Button nut, bool dangChon)
        {
            nut.BackColor = dangChon
                ? Color.FromArgb(14, 165, 233)
                : Color.FromArgb(51, 65, 85);
            nut.ForeColor = Color.White;
        }

        private void HienThiKhuVuc(string tenMenu)
        {
            int? maKhu = _maKhuTheoMenu.ContainsKey(tenMenu) ? _maKhuTheoMenu[tenMenu] : null;
            var mayTrongKhu = maKhu.HasValue
                ? _danhSachMay.Where(m => m.MaKhuVuc == maKhu.Value).ToList()
                : new List<MayHienThi>();

            lblTenKhuDangXem.Text = "Khu vực " + tenMenu;
            if (mayTrongKhu.Count > 0)
            {
                var mau = mayTrongKhu[0];
                lblGiaKhu.Text = "Giá: " + mau.GiaTheoGio.ToString("N0") + " đ/giờ";
                lblCauHinh.Text = string.Format("Cấu hình chung: CPU {0} | GPU {1} | RAM {2}",
                    mau.TenCpu ?? "—", mau.TenGpu ?? "—", mau.TenRam ?? "—");
            }
            else
            {
                lblGiaKhu.Text = "Giá: —";
                lblCauHinh.Text = "Cấu hình chung: Chưa có máy trong khu vực này";
            }

            VeNutMay(mayTrongKhu);
        }

        private void VeNutMay(List<MayHienThi> danhSach)
        {
            flpDanhSachMay.Controls.Clear();
            _nutMay.Clear();

            foreach (MayHienThi may in danhSach)
            {
                var nut = new Button
                {
                    Width = 104,
                    Height = 72,
                    Margin = new Padding(8),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    Tag = may.MaMay,
                    Text = may.TenMay + Environment.NewLine + may.TrangThai,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                nut.FlatAppearance.BorderSize = 0;
                ApDungMauNutMay(nut, may.TrangThai, may.MaMay == _maMayChon);
                nut.Click += NutMay_Click;
                _nutMay[may.MaMay] = nut;
                flpDanhSachMay.Controls.Add(nut);
            }
        }

        private void NutMay_Click(object sender, EventArgs e)
        {
            ChonMay(Convert.ToInt32(((Button)sender).Tag));
        }

        private void ChonMay(int maMay)
        {
            _maMayChon = maMay;
            foreach (var cap in _nutMay)
                ApDungMauNutMay(cap.Value, LayMay(cap.Key).TrangThai, cap.Key == maMay);

            MayHienThi may = LayMay(maMay);
            if (may == null) return;

            CapNhatChiTietMay(maMay, false);
        }

        private void CapNhatChiTietMay(int maMay, bool capNhatDayDu)
        {
            MayHienThi may = LayMay(maMay);
            if (may == null) return;

            lblTenMayChiTiet.Text = may.TenMay;
            lblTrangThaiMay.Text = "Trạng thái: " + may.TrangThai;
            lblTrangThaiMay.ForeColor = MauTrangThai(may.TrangThai);

            DataRow phienDangChoi = LayPhienSuDungChuaKetThuc(maMay);
            DataRow phienGanNhat = LayPhienGanNhat(maMay);
            DataRow phienHien = phienDangChoi ?? phienGanNhat;

            if (phienHien == null)
            {
                lblPhien.Text = "Phiên: —";
                lblThoiGianBatDau.Text = "Bắt đầu: —";
                lblThoiGianKetThuc.Text = "Kết thúc: —";
                lblTamTinh.Text = "Tạm tính máy: —";
                lblTongHoaDon.Text = "Tổng hóa đơn: —";
                dgvMonAn.DataSource = null;
            }
            else
            {
                int maPhien = Convert.ToInt32(phienHien["MaPhien"]);
                lblPhien.Text = "Phiên: #" + maPhien;
                lblThoiGianBatDau.Text = "Bắt đầu: " +
                    FormatGio(phienHien["ThoiGianBatDau"]);

                bool dangOnline = phienDangChoi != null;
                if (dangOnline)
                {
                    lblThoiGianKetThuc.Text = "Kết thúc: (đang chơi)";
                    lblTamTinh.Text = "Tạm tính máy: đang tính...";
                }
                else if (capNhatDayDu)
                {
                    DateTime ketThuc = Convert.ToDateTime(phienHien["ThoiGianKetThuc"]);
                    DateTime batDau = Convert.ToDateTime(phienHien["ThoiGianBatDau"]);
                    decimal tamTinh = TinhTienMay(batDau, ketThuc, may.GiaTheoGio);
                    lblThoiGianKetThuc.Text = "Kết thúc: " + FormatGio(ketThuc);
                    lblTamTinh.Text = "Tạm tính máy: " + tamTinh.ToString("N0") + " đ";
                }
                else
                {
                    lblThoiGianKetThuc.Text = "Kết thúc: —";
                    lblTamTinh.Text = "Tạm tính máy: —";
                }

                NapMonAnDat(maPhien);
                NapTongHoaDon(maPhien, may, phienHien, capNhatDayDu && !dangOnline);
            }

            btnBatMay.Enabled = may.TrangThai == TrangThaiOffline;
            btnTatMay.Enabled = may.TrangThai == TrangThaiOnline;
            btnTaoHoaDon.Enabled = may.TrangThai == TrangThaiOnline;
        }

        private void NapMonAnDat(int maPhien)
        {
            const string sql = @"
                SELECT m.TenMon, ct.SoLuong, m.GiaBan,
                       (ct.SoLuong * m.GiaBan) AS ThanhTien
                FROM ChiTietHoaDon ct
                INNER JOIN MonAn m ON ct.MaMon = m.MaMon
                INNER JOIN HoaDon hd ON ct.MaHoaDon = hd.MaHoaDon
                WHERE hd.MaPhien = @MaPhien";

            var bang = KetNoiCSDL.ThucThiTruyVan(sql, new SqlParameter("@MaPhien", maPhien));
            ChuoiTiengViet.ChuanHoaBang(bang, "TenMon");
            dgvMonAn.DataSource = bang;

            if (dgvMonAn.Columns.Count > 0)
            {
                if (dgvMonAn.Columns.Contains("TenMon"))
                    dgvMonAn.Columns["TenMon"].HeaderText = "Món";
                if (dgvMonAn.Columns.Contains("SoLuong"))
                    dgvMonAn.Columns["SoLuong"].HeaderText = "SL";
                if (dgvMonAn.Columns.Contains("GiaBan"))
                {
                    dgvMonAn.Columns["GiaBan"].HeaderText = "Đơn giá";
                    dgvMonAn.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                }
                if (dgvMonAn.Columns.Contains("ThanhTien"))
                {
                    dgvMonAn.Columns["ThanhTien"].HeaderText = "Thành tiền";
                    dgvMonAn.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }
                dgvMonAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void NapTongHoaDon(int maPhien, MayHienThi may, DataRow phien, bool hienTamTinhDayDu)
        {
            object maHd = KetNoiCSDL.ThucThiScalar(
                "SELECT TOP 1 MaHoaDon FROM HoaDon WHERE MaPhien = @MaPhien ORDER BY MaHoaDon DESC",
                new SqlParameter("@MaPhien", maPhien));

            if (maHd == null || maHd == DBNull.Value)
            {
                lblTongHoaDon.Text = "Tổng hóa đơn: (chưa tạo)";
                return;
            }

            decimal tongHd = Convert.ToDecimal(KetNoiCSDL.ThucThiScalar(
                "SELECT ISNULL(TongTien, 0) FROM HoaDon WHERE MaHoaDon = @Ma",
                new SqlParameter("@Ma", maHd)) ?? 0);

            if (tongHd <= 0 && hienTamTinhDayDu)
            {
                DateTime batDau = Convert.ToDateTime(phien["ThoiGianBatDau"]);
                DateTime ketThuc = Convert.ToDateTime(phien["ThoiGianKetThuc"]);
                decimal tienMay = TinhTienMay(batDau, ketThuc, may.GiaTheoGio);
                decimal tienMon = LayTongMonAn(Convert.ToInt32(maHd));
                tongHd = tienMay + tienMon;
            }

            lblTongHoaDon.Text = "Tổng hóa đơn: " + tongHd.ToString("N0") + " đ";
        }

        private static decimal LayTongMonAn(int maHoaDon)
        {
            object kq = KetNoiCSDL.ThucThiScalar(@"
                SELECT ISNULL(SUM(ct.SoLuong * m.GiaBan), 0)
                FROM ChiTietHoaDon ct INNER JOIN MonAn m ON ct.MaMon = m.MaMon WHERE ct.MaHoaDon = @Ma",
                new SqlParameter("@Ma", maHoaDon));
            return Convert.ToDecimal(kq ?? 0);
        }

        private static decimal TinhTienMay(DateTime batDau, DateTime ketThuc, decimal giaGio)
        {
            double phut = (ketThuc - batDau).TotalMinutes;
            if (phut < 1) phut = 1;
            return Math.Round((decimal)(phut / 60.0) * giaGio, 0);
        }

        private DataRow LayPhienSuDungChuaKetThuc(int maMay)
        {
            var bang = KetNoiCSDL.ThucThiTruyVan(@"
                SELECT TOP 1 MaPhien, ThoiGianBatDau, ThoiGianKetThuc, MaKhachHang
                FROM PhienSuDung
                WHERE MaMay = @MaMay AND ThoiGianKetThuc > GETDATE()
                ORDER BY ThoiGianBatDau DESC",
                new SqlParameter("@MaMay", maMay));
            return bang.Rows.Count > 0 ? bang.Rows[0] : null;
        }

        private DataRow LayPhienGanNhat(int maMay)
        {
            var bang = KetNoiCSDL.ThucThiTruyVan(@"
                SELECT TOP 1 MaPhien, ThoiGianBatDau, ThoiGianKetThuc, MaKhachHang
                FROM PhienSuDung
                WHERE MaMay = @MaMay
                ORDER BY ThoiGianBatDau DESC",
                new SqlParameter("@MaMay", maMay));
            return bang.Rows.Count > 0 ? bang.Rows[0] : null;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!_maMayChon.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một máy.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maMay = _maMayChon.Value;
            NapDanhSachMay();
            HienThiKhuVuc(_menuKhuDangChon);
            ChonMay(maMay);
            CapNhatChiTietMay(maMay, true);
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            if (!_maMayChon.HasValue) return;

            DataRow phien = LayPhienSuDungChuaKetThuc(_maMayChon.Value);
            if (phien == null)
            {
                MessageBox.Show("Máy chưa bật hoặc chưa có phiên đang chơi.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhien = Convert.ToInt32(phien["MaPhien"]);
            object daCo = KetNoiCSDL.ThucThiScalar(
                "SELECT MaHoaDon FROM HoaDon WHERE MaPhien = @MaPhien",
                new SqlParameter("@MaPhien", maPhien));

            if (daCo != null && daCo != DBNull.Value)
            {
                MessageBox.Show("Phiên này đã có hóa đơn (mã #" + daCo + ").", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                KetNoiCSDL.ThucThiLenh(@"
                    INSERT INTO HoaDon (LoaiHoaDon, NgayLap, MaNhanVien, TongTien, MaPhien)
                    VALUES (N'Hóa đơn dịch vụ', GETDATE(), @MaNV, 0, @MaPhien)",
                    new SqlParameter("@MaNV", PhienLamViec.MaNhanVien),
                    new SqlParameter("@MaPhien", maPhien));

                MessageBox.Show("Đã tạo hóa đơn cho khách. Tổng tiền sẽ cập nhật khi tắt máy.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CapNhatChiTietMay(_maMayChon.Value, false);
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnBatMay_Click(object sender, EventArgs e)
        {
            if (!_maMayChon.HasValue) return;

            try
            {
                object maKhach = KetNoiCSDL.ThucThiScalar(
                    "SELECT TOP 1 MaKhachHang FROM KhachHang ORDER BY MaKhachHang");
                if (maKhach == null || maKhach == DBNull.Value)
                {
                    MessageBox.Show("Chưa có khách hàng trong CSDL.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                KetNoiCSDL.ThucThiLenh(@"
                    INSERT INTO PhienSuDung (MaMay, MaKhachHang, ThoiGianBatDau, ThoiGianKetThuc)
                    VALUES (@MaMay, @MaKhach, GETDATE(), DATEADD(DAY, 1, GETDATE()))",
                    new SqlParameter("@MaMay", _maMayChon.Value),
                    new SqlParameter("@MaKhach", maKhach));

                KetNoiCSDL.ThucThiLenh(
                    "UPDATE MayTinh SET TrangThaiMay = N'Đang dùng' WHERE MaMay = @MaMay",
                    new SqlParameter("@MaMay", _maMayChon.Value));

                LamMoiSauThaoTac();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnTatMay_Click(object sender, EventArgs e)
        {
            if (!_maMayChon.HasValue) return;

            DataRow phien = LayPhienSuDungChuaKetThuc(_maMayChon.Value);
            if (phien == null)
            {
                MessageBox.Show("Máy không đang online.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maPhien = Convert.ToInt32(phien["MaPhien"]);
                MayHienThi may = LayMay(_maMayChon.Value);
                DateTime batDau = Convert.ToDateTime(phien["ThoiGianBatDau"]);
                DateTime ketThuc = DateTime.Now;
                decimal tienMay = TinhTienMay(batDau, ketThuc, may.GiaTheoGio);

                KetNoiCSDL.ThucThiLenh(@"
                    UPDATE PhienSuDung SET ThoiGianKetThuc = GETDATE(), ChiPhi = @TienMay, ThoiLuong = DATEDIFF(MINUTE, ThoiGianBatDau, GETDATE()) WHERE MaPhien = @MaPhien",
                    new SqlParameter("@TienMay", tienMay),
                    new SqlParameter("@MaPhien", maPhien));

                KetNoiCSDL.ThucThiLenh(
                    "UPDATE MayTinh SET TrangThaiMay = N'Rảnh' WHERE MaMay = @MaMay",
                    new SqlParameter("@MaMay", _maMayChon.Value));

                object maHd = KetNoiCSDL.ThucThiScalar(
                    "SELECT MaHoaDon FROM HoaDon WHERE MaPhien = @MaPhien",
                    new SqlParameter("@MaPhien", maPhien));

                if (maHd != null && maHd != DBNull.Value)
                {
                    decimal tienMon = LayTongMonAn(Convert.ToInt32(maHd));
                    decimal tong = tienMay + tienMon;
                    KetNoiCSDL.ThucThiLenh(
                        "UPDATE HoaDon SET TongTien = @Tong, NgayLap = GETDATE() WHERE MaHoaDon = @Ma",
                        new SqlParameter("@Tong", tong),
                        new SqlParameter("@Ma", maHd));
                }

                LamMoiSauThaoTac();
                CapNhatChiTietMay(_maMayChon.Value, true);
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void LamMoiSauThaoTac()
        {
            int? giu = _maMayChon;
            NapDanhSachMay();
            HienThiKhuVuc(_menuKhuDangChon);
            if (giu.HasValue)
                ChonMay(giu.Value);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void XoaChiTietMay()
        {
            _maMayChon = null;
            lblTenMayChiTiet.Text = "—";
            lblTrangThaiMay.Text = "Trạng thái: —";
            lblPhien.Text = "Phiên: —";
            lblThoiGianBatDau.Text = "Bắt đầu: —";
            lblThoiGianKetThuc.Text = "Kết thúc: —";
            lblTamTinh.Text = "Tạm tính máy: —";
            lblTongHoaDon.Text = "Tổng hóa đơn: —";
            dgvMonAn.DataSource = null;
        }

        private MayHienThi LayMay(int maMay)
        {
            return _danhSachMay.FirstOrDefault(m => m.MaMay == maMay);
        }

        private static void ApDungMauNutMay(Button nut, string trangThai, bool dangChon)
        {
            Color nen;
            Color chu = Color.White;

            if (trangThai == TrangThaiOnline)
                nen = Color.FromArgb(16, 185, 129);
            else if (trangThai == TrangThaiBaoTri)
                nen = Color.FromArgb(100, 116, 139);
            else
            {
                nen = Color.FromArgb(226, 232, 240);
                chu = Color.FromArgb(51, 65, 85);
            }

            if (dangChon)
                nut.FlatAppearance.BorderColor = Color.FromArgb(14, 165, 233);
            nut.FlatAppearance.BorderSize = dangChon ? 3 : 0;
            nut.BackColor = nen;
            nut.ForeColor = chu;
        }

        private static Color MauTrangThai(string trangThai)
        {
            if (trangThai == TrangThaiOnline) return Color.FromArgb(16, 185, 129);
            if (trangThai == TrangThaiBaoTri) return Color.FromArgb(100, 116, 139);
            return Color.FromArgb(100, 116, 139);
        }

        private static string FormatGio(object value)
        {
            if (value == null || value == DBNull.Value) return "—";
            return Convert.ToDateTime(value).ToString("HH:mm dd/MM/yyyy");
        }

        private static void HienLoi(Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private sealed class MayHienThi
        {
            public int MaMay { get; set; }
            public string TenMay { get; set; }
            public int MaKhuVuc { get; set; }
            public string TenKhuVuc { get; set; }
            public decimal GiaTheoGio { get; set; }
            public string TenCpu { get; set; }
            public string TenGpu { get; set; }
            public string TenRam { get; set; }
            public string TrangThai { get; set; }
        }
    }
}
