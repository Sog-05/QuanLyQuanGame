using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace test
{
    public partial class frmQuanLyHoaDon : Form
    {
        public frmQuanLyHoaDon()
        {
            InitializeComponent();
        }

        private void frmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            GiaoDienHelper.ApDungFont(this);
            lblTieuDe.Text = VanBanGiaoDien.QLHoaDon;
            lblLoai.Text = VanBanGiaoDien.Loai;
            lblTuNgay.Text = VanBanGiaoDien.TuNgay;
            lblDenNgay.Text = VanBanGiaoDien.DenNgay;
            btnTim.Text = VanBanGiaoDien.Loc;
            lblChiTiet.Text = VanBanGiaoDien.ChiTietMon;
            btnDong.Text = VanBanGiaoDien.Dong;
            Text = VanBanGiaoDien.TitleQLHoaDon;

            cboLoai.Items.Clear();
            cboLoai.Items.AddRange(new object[] { VanBanGiaoDien.TatCa, VanBanGiaoDien.HoaDonDichVu, VanBanGiaoDien.HoaDonBaoTri });
            cboLoai.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;
            NapDanhSach();
        }

        private void NapDanhSach()
        {
            string sql = "EXEC GetBillByDate @ngaybd, @ngaykt";
            var thamSo = new System.Collections.Generic.List<SqlParameter>
            {
                new SqlParameter("@ngaybd", dtpTuNgay.Value.Date),
                new SqlParameter("@ngaykt", dtpDenNgay.Value.Date)
            };

            var bang = KetNoiCSDL.ThucThiTruyVan(sql, thamSo.ToArray());
            
            if (cboLoai.SelectedIndex > 0)
            {
                bang.DefaultView.RowFilter = string.Format("BillingType = '{0}'", cboLoai.SelectedItem.ToString());
                bang = bang.DefaultView.ToTable();
            }

            ChuoiTiengViet.ChuanHoaBang(bang, "BillingType", "EmployeeName");
            dgvHoaDon.DataSource = bang;
            DinhDangLuoiHoaDon();
            dgvChiTiet.DataSource = null;
        }

        private void DinhDangLuoiHoaDon()
        {
            if (dgvHoaDon.Columns.Count == 0) return;
            if (dgvHoaDon.Columns.Contains("MaHoaDon")) dgvHoaDon.Columns["MaHoaDon"].HeaderText = "Mã HD";
            if (dgvHoaDon.Columns.Contains("BillingType")) dgvHoaDon.Columns["BillingType"].HeaderText = "Loại";
            if (dgvHoaDon.Columns.Contains("BillingDate"))
            {
                dgvHoaDon.Columns["BillingDate"].HeaderText = "Ngày lập";
                dgvHoaDon.Columns["BillingDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvHoaDon.Columns.Contains("EmployeeName")) dgvHoaDon.Columns["EmployeeName"].HeaderText = "Nhân viên";
            if (dgvHoaDon.Columns.Contains("SessionCost")) { dgvHoaDon.Columns["SessionCost"].HeaderText = "Tiền máy"; dgvHoaDon.Columns["SessionCost"].DefaultCellStyle.Format = "N0"; }
            if (dgvHoaDon.Columns.Contains("MaintainanceCost")) { dgvHoaDon.Columns["MaintainanceCost"].HeaderText = "Tiền bảo trì"; dgvHoaDon.Columns["MaintainanceCost"].DefaultCellStyle.Format = "N0"; }
            if (dgvHoaDon.Columns.Contains("FoodCost")) { dgvHoaDon.Columns["FoodCost"].HeaderText = "Tiền món ăn"; dgvHoaDon.Columns["FoodCost"].DefaultCellStyle.Format = "N0"; }
            if (dgvHoaDon.Columns.Contains("Amount"))
            {
                dgvHoaDon.Columns["Amount"].HeaderText = "Tổng tiền";
                dgvHoaDon.Columns["Amount"].DefaultCellStyle.Format = "N0";
            }
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maHd = Convert.ToInt32(dgvHoaDon.Rows[e.RowIndex].Cells["MaHoaDon"].Value);
            var bang = KetNoiCSDL.ThucThiTruyVan(@"
                SELECT m.TenMon, ct.SoLuong, m.GiaBan, (ct.SoLuong * m.GiaBan) AS ThanhTien
                FROM ChiTietHoaDon ct INNER JOIN MonAn m ON ct.MaMon = m.MaMon
                WHERE ct.MaHoaDon = @Ma", new SqlParameter("@Ma", maHd));
            ChuoiTiengViet.ChuanHoaBang(bang, "TenMon");
            dgvChiTiet.DataSource = bang;
            if (dgvChiTiet.Columns.Contains("GiaBan")) dgvChiTiet.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            if (dgvChiTiet.Columns.Contains("ThanhTien")) dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.ReadOnly = true;
        }

        private void btnTim_Click(object sender, EventArgs e) => NapDanhSach();
        private void btnDong_Click(object sender, EventArgs e) => Close();
    }
}
