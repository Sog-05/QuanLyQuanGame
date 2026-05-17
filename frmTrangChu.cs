using System;
using System.Drawing;
using System.Windows.Forms;

namespace test
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            GiaoDienHelper.ApDungFont(this);
            lblXinChao.Text = "Xin chào, " + (ChuoiTiengViet.ChuanHoa(PhienLamViec.TenNhanVien) ?? "Nhân viên");
            lblTaiKhoan.Text = "Tài khoản: " + (PhienLamViec.TenDangNhap ?? "");
        }



        private static Button TaoNut(string text, Color mau, int x, int y)
        {
            return new Button
            {
                Text = text,
                BackColor = mau,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(180, 48),
                Location = new Point(x, y),
                Cursor = Cursors.Hand
            };
        }

        private static void MoForm<T>() where T : Form, new()
        {
            using (var form = new T())
                form.ShowDialog();
        }

        private void btnQuanLyMonAn_Click(object sender, EventArgs e) => MoForm<frmQuanLyMonAn>();

        private void btnChonMay_Click(object sender, EventArgs e) => MoForm<frmChonMay>();

        private void btnHoaDon_Click(object sender, EventArgs e) => MoForm<frmQuanLyHoaDon>();

        private void btnDanhMuc_Click(object sender, EventArgs e) => MoForm<frmQuanLyMayTinh>();

        private void btnTaiKhoan_Click(object sender, EventArgs e) => MoForm<frmQuanLyTaiKhoan>();

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PhienLamViec.Xoa();
                Close();
            }
        }
    }
}
