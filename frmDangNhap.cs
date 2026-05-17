using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dapper;

namespace test
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            GiaoDienHelper.ApDungFont(this);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = string.Empty;
            lblThongBao.ForeColor = Color.FromArgb(220, 53, 69);

            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrEmpty(tenDangNhap))
            {
                lblThongBao.Text = "Vui lòng nhập tên đăng nhập.";
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                lblThongBao.Text = "Vui lòng nhập mật khẩu.";
                txtMatKhau.Focus();
                return;
            }

            try
            {
                const string sql = @"
                    SELECT tk.user_id, tk.username, tk.ma_role
                    FROM NguoiDung tk
                    WHERE LTRIM(RTRIM(tk.username)) = @TenDangNhap
                      AND LTRIM(RTRIM(tk.password_hash)) = @MatKhau";

                string hashedMatKhau = HashHelper.ComputeSha256Hash(matKhau);

                using (var conn = new SqlConnection(KetNoiCSDL.ChuoiKetNoi))
                {
                    var user = conn.QueryFirstOrDefault(sql, new { TenDangNhap = tenDangNhap, MatKhau = hashedMatKhau });

                    if (user == null)
                    {
                        lblThongBao.Text = "Tên đăng nhập hoặc mật khẩu không đúng.";
                        txtMatKhau.Clear();
                        txtMatKhau.Focus();
                        return;
                    }

                    int role = user.ma_role;
                    int userId = user.user_id;
                    string username = user.username;

                    if (role == 1 || role == 2)
                    {
                        var nv = conn.QueryFirstOrDefault("SELECT MaNhanVien, TenNhanVien FROM NhanVien WHERE user_id = @Id", new { Id = userId });
                        if (nv == null)
                        {
                            lblThongBao.Text = "Lỗi: Tài khoản nhân viên không có thông tin chi tiết.";
                            return;
                        }
                        PhienLamViec.MaNguoiDung = userId;
                        PhienLamViec.MaNhanVien = nv.MaNhanVien;
                        PhienLamViec.TenNhanVien = ChuoiTiengViet.ChuanHoa((string)nv.TenNhanVien);
                        PhienLamViec.TenDangNhap = username;

                        Hide();
                        using (var trangChu = new frmTrangChu())
                        {
                            trangChu.ShowDialog();
                        }
                        txtMatKhau.Clear();
                        lblThongBao.Text = string.Empty;
                        Show();
                        txtTenDangNhap.Focus();
                    }
                    else if (role == 3)
                    {
                        lblThongBao.Text = "Tài khoản khách vui lòng liên hệ nhân viên để mở máy.";
                    }
                }
            }
            catch (SqlException ex)
            {
                lblThongBao.Text = "Không kết nối CSDL: " + ex.Message
                    + "\nChạy Database.sql trong SSMS, rồi kiểm tra App.config.";
            }
            catch (Exception ex)
            {
                lblThongBao.Text = "Lỗi: " + ex.Message;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnDangNhap_Click(sender, e);
            }
        }

        private bool ChonMayChoKhach()
        {
            var bang = KetNoiCSDL.ThucThiTruyVan("SELECT MaMay, TenMay FROM MayTinh ORDER BY TenMay");
            if (bang.Rows.Count == 0)
            {
                MessageBox.Show(VanBanGiaoDien.ChuaCoMay, VanBanGiaoDien.ThongBao,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            using (var dlg = new Form())
            {
                dlg.Text = VanBanGiaoDien.ChonMayDangDung;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.ClientSize = new Size(320, 120);
                dlg.Font = GiaoDienHelper.FontChu;
                var cbo = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Location = new Point(24, 24),
                    Size = new Size(272, 25),
                    DisplayMember = "TenMay",
                    ValueMember = "MaMay",
                    DataSource = bang
                };
                var btnOk = new Button
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Location = new Point(120, 64),
                    Size = new Size(80, 32)
                };
                dlg.Controls.Add(cbo);
                dlg.Controls.Add(btnOk);
                dlg.AcceptButton = btnOk;
                if (dlg.ShowDialog() != DialogResult.OK) return false;
                PhienKhach.MaMay = Convert.ToInt32(cbo.SelectedValue);
                PhienKhach.TenMay = cbo.Text;
            }

            object maPhien = KetNoiCSDL.ThucThiScalar(@"
                SELECT TOP 1 MaPhien FROM PhienSuDung
                WHERE MaMay = @May AND MaKhachHang = @Khach AND ThoiGianKetThuc > GETDATE()
                ORDER BY ThoiGianBatDau DESC",
                new SqlParameter("@May", PhienKhach.MaMay),
                new SqlParameter("@Khach", PhienKhach.MaKhachHang));

            PhienKhach.MaPhien = maPhien != null && maPhien != DBNull.Value
                ? Convert.ToInt32(maPhien) : 0;
            return true;
        }

        private void lblPhuDe_Click(object sender, EventArgs e)
        {

        }
    }
}
