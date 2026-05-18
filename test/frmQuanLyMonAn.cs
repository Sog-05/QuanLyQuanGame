using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace test
{
    public partial class frmQuanLyMonAn : Form
    {
        private int? _maMonDangChon;

        public frmQuanLyMonAn()
        {
            InitializeComponent();
        }

        private void frmQuanLyMonAn_Load(object sender, EventArgs e)
        {
            NapLoaiMonAn();
            NapDanhSachMon();
        }

        private void NapLoaiMonAn()
        {
            var bang = KetNoiCSDL.ThucThiTruyVan(
                "SELECT MaLoai, TenLoai FROM LoaiMonAn ORDER BY TenLoai");
            ChuoiTiengViet.ChuanHoaBang(bang, "TenLoai");

            cboLoaiMonAn.DisplayMember = "TenLoai";
            cboLoaiMonAn.ValueMember = "MaLoai";
            cboLoaiMonAn.DataSource = bang;
        }

        private void NapDanhSachMon()
        {
            const string sql = @"
                SELECT m.MaMon, m.TenMon, l.TenLoai, m.GiaBan, m.GiaNhap, m.TonKho, m.MaLoai
                FROM MonAn m
                INNER JOIN LoaiMonAn l ON m.MaLoai = l.MaLoai
                ORDER BY m.MaMon";

            var bang = KetNoiCSDL.ThucThiTruyVan(sql);
            ChuoiTiengViet.ChuanHoaBang(bang, "TenMon", "TenLoai");
            dgvMonAn.DataSource = bang;
            DinhDangLuoi();
            _maMonDangChon = null;
        }

        private void DinhDangLuoi()
        {
            if (dgvMonAn.Columns.Count == 0) return;

            dgvMonAn.Columns["MaMon"].HeaderText = "Mã món";
            dgvMonAn.Columns["TenMon"].HeaderText = "Tên món";
            dgvMonAn.Columns["TenLoai"].HeaderText = "Loại món";
            dgvMonAn.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvMonAn.Columns["GiaNhap"].HeaderText = "Giá nhập";
            dgvMonAn.Columns["TonKho"].HeaderText = "Tồn kho";
            dgvMonAn.Columns["MaLoai"].Visible = false;

            dgvMonAn.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            dgvMonAn.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
            dgvMonAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonAn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonAn.ReadOnly = true;
            dgvMonAn.MultiSelect = false;
        }

        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow dong = dgvMonAn.Rows[e.RowIndex];
            _maMonDangChon = Convert.ToInt32(dong.Cells["MaMon"].Value);
            txtTenMon.Text = ChuoiTiengViet.ChuanHoa(dong.Cells["TenMon"].Value?.ToString());
            numGiaBan.Value = ClampNumeric(dong.Cells["GiaBan"].Value, numGiaBan);
            numGiaNhap.Value = ClampNumeric(dong.Cells["GiaNhap"].Value, numGiaNhap);
            numTonKho.Value = ClampNumeric(dong.Cells["TonKho"].Value, numTonKho, true);
            cboLoaiMonAn.SelectedValue = dong.Cells["MaLoai"].Value;
        }

        private static decimal ClampNumeric(object value, NumericUpDown control, bool integerOnly = false)
        {
            decimal so = value == null || value == DBNull.Value ? 0 : Convert.ToDecimal(value);
            if (so < control.Minimum) return control.Minimum;
            if (so > control.Maximum) return control.Maximum;
            return integerOnly ? Math.Truncate(so) : so;
        }

        private bool KiemTraNhapLieu()
        {
            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMon.Focus();
                return false;
            }

            if (cboLoaiMonAn.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại món.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numGiaBan.Value <= 0)
            {
                MessageBox.Show("Giá bán phải lớn hơn 0.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numGiaBan.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhapLieu()) return;

            try
            {
                const string sql = @"
                    INSERT INTO MonAn (TenMon, GiaBan, GiaNhap, TonKho, MaLoai)
                    VALUES (@TenMon, @GiaBan, @GiaNhap, @TonKho, @MaLoai)";

                KetNoiCSDL.ThucThiLenh(sql, TaoThamSoMon());
                MessageBox.Show("Thêm món ăn thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_maMonDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn món cần sửa trên bảng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraNhapLieu()) return;

            try
            {
                const string sql = @"
                    UPDATE MonAn
                    SET TenMon = @TenMon, GiaBan = @GiaBan, GiaNhap = @GiaNhap,
                        TonKho = @TonKho, MaLoai = @MaLoai
                    WHERE MaMon = @MaMon";

                var thamSo = TaoThamSoMon();
                var danhSach = new System.Collections.Generic.List<SqlParameter>(thamSo)
                {
                    new SqlParameter("@MaMon", _maMonDangChon.Value)
                };

                KetNoiCSDL.ThucThiLenh(sql, danhSach.ToArray());
                MessageBox.Show("Cập nhật món ăn thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maMonDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa trên bảng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa món này?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                object coChiTiet = KetNoiCSDL.ThucThiScalar(
                    "SELECT COUNT(*) FROM ChiTietHoaDon WHERE MaMon = @MaMon",
                    new SqlParameter("@MaMon", _maMonDangChon.Value));

                if (Convert.ToInt32(coChiTiet) > 0)
                {
                    MessageBox.Show(
                        "Không thể xóa món đã có trong hóa đơn. Hãy cập nhật tồn kho thay vì xóa.",
                        "Không thể xóa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                KetNoiCSDL.ThucThiLenh(
                    "DELETE FROM MonAn WHERE MaMon = @MaMon",
                    new SqlParameter("@MaMon", _maMonDangChon.Value));

                MessageBox.Show("Xóa món ăn thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            const string sql = @"
                SELECT m.MaMon, m.TenMon, l.TenLoai, m.GiaBan, m.GiaNhap, m.TonKho, m.MaLoai
                FROM MonAn m
                INNER JOIN LoaiMonAn l ON m.MaLoai = l.MaLoai
                WHERE m.TenMon LIKE @TuKhoa OR l.TenLoai LIKE @TuKhoa
                ORDER BY m.MaMon";

            var bang = KetNoiCSDL.ThucThiTruyVan(sql,
                new SqlParameter("@TuKhoa", "%" + txtTimKiem.Text.Trim() + "%"));
            ChuoiTiengViet.ChuanHoaBang(bang, "TenMon", "TenLoai");
            dgvMonAn.DataSource = bang;
            DinhDangLuoi();
        }

        private SqlParameter[] TaoThamSoMon()
        {
            return new[]
            {
                new SqlParameter("@TenMon", txtTenMon.Text.Trim()),
                new SqlParameter("@GiaBan", numGiaBan.Value),
                new SqlParameter("@GiaNhap", numGiaNhap.Value),
                new SqlParameter("@TonKho", (int)numTonKho.Value),
                new SqlParameter("@MaLoai", Convert.ToInt32(cboLoaiMonAn.SelectedValue))
            };
        }

        private void LamMoiForm()
        {
            _maMonDangChon = null;
            txtTenMon.Clear();
            numGiaBan.Value = 0;
            numGiaNhap.Value = 0;
            numTonKho.Value = 0;
            if (cboLoaiMonAn.Items.Count > 0)
                cboLoaiMonAn.SelectedIndex = 0;
            txtTimKiem.Clear();
            NapDanhSachMon();
            txtTenMon.Focus();
        }

        private static void HienLoi(Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

