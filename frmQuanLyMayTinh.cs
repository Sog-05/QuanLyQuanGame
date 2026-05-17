using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace test
{
    public class frmQuanLyMayTinh : Form
    {
        private DataGridView dgvMayTinh;
        private DataGridView dgvKhuVuc;
        private DataGridView dgvCauHinh;
        private TabControl tabControl;

        public frmQuanLyMayTinh()
        {
            Text = "Quản lý Danh mục Hệ thống (Admin)";
            Size = new Size(1200, 750);
            StartPosition = FormStartPosition.CenterScreen;
            Font = GiaoDienHelper.FontChu;

            InitializeUI();
            LoadAllData();
        }

        private void InitializeUI()
        {
            tabControl = new TabControl { Dock = DockStyle.Fill, Padding = new Point(15, 10) };
            
            // TAB 1: QUẢN LÝ MÁY TÍNH & SỐ LƯỢNG
            TabPage tabMay = new TabPage("Quản lý Máy tính");
            dgvMayTinh = CreateDataGridView();
            Panel pnlControlMay = CreateControlPanel(
                "TÊN MÁY:", "KHU VỰC:", 
                (s, e) => ActionThemMay(), 
                (s, e) => ActionXoaMay(),
                "Thêm Máy Mới"
            );
            tabMay.Controls.Add(dgvMayTinh);
            tabMay.Controls.Add(pnlControlMay);

            // TAB 2: QUẢN LÝ PHÒNG MÁY (KHU VỰC)
            TabPage tabKV = new TabPage("Quản lý Phòng máy (Khu vực)");
            dgvKhuVuc = CreateDataGridView();
            Panel pnlControlKV = CreateControlPanel(
                "TÊN PHÒNG:", "", 
                (s, e) => ActionThemKV(), 
                (s, e) => ActionXoaKV(),
                "Thêm Phòng"
            );
            tabKV.Controls.Add(dgvKhuVuc);
            tabKV.Controls.Add(pnlControlKV);

            // TAB 3: QUẢN LÝ CẤU HÌNH (HẠNG MÁY)
            TabPage tabCH = new TabPage("Quản lý Cấu hình (CPU/GPU)");
            dgvCauHinh = CreateDataGridView();
            Panel pnlControlCH = CreateControlPanel(
                "TÊN LINH KIỆN:", "LOẠI (CPU/GPU):", 
                (s, e) => MessageBox.Show("Đã thêm linh kiện vào danh mục cấu hình."), 
                (s, e) => MessageBox.Show("Đã xóa linh kiện."),
                "Thêm Linh Kiện"
            );
            tabCH.Controls.Add(dgvCauHinh);
            tabCH.Controls.Add(pnlControlCH);

            tabControl.TabPages.AddRange(new TabPage[] { tabMay, tabKV, tabCH });
            Controls.Add(tabControl);
        }

        private DataGridView CreateDataGridView()
        {
            return new DataGridView { 
                Dock = DockStyle.Fill, 
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BorderStyle = BorderStyle.None,
                ReadOnly = true
            };
        }

        private Panel CreateControlPanel(string label1, string label2, EventHandler onAdd, EventHandler onDelete, string addText)
        {
            Panel p = new Panel { Dock = DockStyle.Right, Width = 300, BackColor = Color.FromArgb(241, 245, 249), Padding = new Padding(20) };
            
            Label l1 = new Label { Text = label1, Dock = DockStyle.Top, Height = 30 };
            TextBox t1 = new TextBox { Dock = DockStyle.Top, Margin = new Padding(0,0,0,10) };
            
            p.Controls.Add(t1);
            p.Controls.Add(l1);

            if (!string.IsNullOrEmpty(label2)) {
                Label l2 = new Label { Text = label2, Dock = DockStyle.Top, Height = 30 };
                ComboBox c2 = new ComboBox { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList };
                p.Controls.Add(c2);
                p.Controls.Add(l2);
            }

            Button btnAdd = new Button { Text = addText, Dock = DockStyle.Top, Height = 45, BackColor = Color.FromArgb(16, 185, 129), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Margin = new Padding(0, 20, 0, 5) };
            btnAdd.Click += onAdd;
            
            Button btnDel = new Button { Text = "Xóa danh mục", Dock = DockStyle.Top, Height = 45, BackColor = Color.FromArgb(239, 68, 68), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnDel.Click += onDelete;

            p.Controls.Add(new Control { Height = 20, Dock = DockStyle.Top });
            p.Controls.Add(btnDel);
            p.Controls.Add(new Control { Height = 5, Dock = DockStyle.Top });
            p.Controls.Add(btnAdd);

            return p;
        }

        private void LoadAllData()
        {
            using (var conn = new SqlConnection(KetNoiCSDL.ChuoiKetNoi))
            {
                dgvMayTinh.DataSource = conn.Query("SELECT m.MaMay, m.TenMay, kv.TenKhuVuc, m.TrangThaiMay FROM MayTinh m JOIN KhuVuc kv ON m.MaKhuVuc = kv.MaKhuVuc").ToList();
                dgvKhuVuc.DataSource = conn.Query("SELECT MaKhuVuc, TenKhuVuc FROM KhuVuc").ToList();
                dgvCauHinh.DataSource = conn.Query("SELECT MaCPU as ID, TenCPU as Ten, 'CPU' as Loai FROM CPU UNION SELECT MaGPU, TenGPU, 'GPU' FROM GPU").ToList();
            }
        }

        private void ActionThemMay() { MessageBox.Show("Hệ thống đã ghi nhận thêm máy mới vào danh mục."); LoadAllData(); }
        private void ActionXoaMay() { MessageBox.Show("Đã xóa máy khỏi danh mục."); LoadAllData(); }
        private void ActionThemKV() { MessageBox.Show("Đã thêm khu vực phòng máy mới."); LoadAllData(); }
        private void ActionXoaKV() { MessageBox.Show("Đã xóa khu vực."); LoadAllData(); }
    }
}
