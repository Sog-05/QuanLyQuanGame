using System;
using System.Drawing;
using System.Windows.Forms;

namespace test
{
    public class frmQuanLyTaiKhoan : Form
    {
        public frmQuanLyTaiKhoan()
        {
            Text = "Quản lý Tài khoản";
            Size = new Size(800, 600);
            StartPosition = FormStartPosition.CenterScreen;
            Font = GiaoDienHelper.FontChu;
            
            var lbl = new Label { Text = "DANH SÁCH TÀI KHOẢN", Dock = DockStyle.Top, Font = new Font("Segoe UI", 16, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Height = 60 };
            var dgv = new DataGridView { Dock = DockStyle.Fill, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, ReadOnly = true, AllowUserToAddRows = false };
            
            Controls.Add(dgv);
            Controls.Add(lbl);

            try
            {
                string sql = "SELECT nd.username AS [Tên đăng nhập], nv.TenNhanVien AS [Họ tên], nv.SoDienThoai AS [SĐT], nv.role AS [Vai trò] FROM NguoiDung nd INNER JOIN NhanVien nv ON nd.user_id = nv.user_id";
                dgv.DataSource = KetNoiCSDL.ThucThiTruyVan(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
    }
}
