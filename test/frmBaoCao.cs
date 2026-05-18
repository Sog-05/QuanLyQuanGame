using System;
using System.Drawing;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace test
{
    public class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            Text = "Báo Cáo & Thống Kê";
            Size = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterScreen;
            Font = GiaoDienHelper.FontChu;

            var tabs = new TabControl { Dock = DockStyle.Fill };
            
            var tabDoanhThu = new TabPage("Doanh thu (Tháng)");
            var tabTinhTrang = new TabPage("Tình trạng máy");
            var tabGio = new TabPage("Số giờ hoạt động");

            tabs.TabPages.Add(tabDoanhThu);
            tabs.TabPages.Add(tabTinhTrang);
            tabs.TabPages.Add(tabGio);

            var chartDoanhThu = new LiveCharts.WinForms.CartesianChart { Dock = DockStyle.Fill, Margin = new Padding(20) };
            tabDoanhThu.Controls.Add(chartDoanhThu);

            var chartTinhTrang = new LiveCharts.WinForms.PieChart { Dock = DockStyle.Fill, Margin = new Padding(20) };
            tabTinhTrang.Controls.Add(chartTinhTrang);

            var chartGio = new LiveCharts.WinForms.CartesianChart { Dock = DockStyle.Fill, Margin = new Padding(20) };
            tabGio.Controls.Add(chartGio);

            Controls.Add(tabs);

            LoadData(chartDoanhThu, chartTinhTrang, chartGio);
        }

        private void LoadData(LiveCharts.WinForms.CartesianChart chartDoanhThu, LiveCharts.WinForms.PieChart chartTinhTrang, LiveCharts.WinForms.CartesianChart chartGio)
        {
            try
            {
                using (var conn = new SqlConnection(KetNoiCSDL.ChuoiKetNoi))
                {
                    // 1. Doanh thu theo tháng
                    var doanhThu = conn.Query("SELECT MONTH(NgayLap) as Thang, ISNULL(SUM(TongTien), 0) as Tong FROM HoaDon GROUP BY MONTH(NgayLap)").ToList();
                    var seriesDoanhThu = new ColumnSeries { Title = "Doanh Thu", Values = new ChartValues<decimal>() };
                    var labelsDoanhThu = new System.Collections.Generic.List<string>();
                    foreach (var item in doanhThu)
                    {
                        seriesDoanhThu.Values.Add((decimal)item.Tong);
                        labelsDoanhThu.Add("Tháng " + item.Thang);
                    }
                    chartDoanhThu.Series = new SeriesCollection { seriesDoanhThu };
                    chartDoanhThu.AxisX.Add(new Axis { Title = "Tháng", Labels = labelsDoanhThu });
                    chartDoanhThu.AxisY.Add(new Axis { Title = "VNĐ", LabelFormatter = value => value.ToString("N0") });

                    // 2. Tình trạng máy
                    var tinhTrang = conn.Query("SELECT TrangThaiMay, COUNT(*) as SoLuong FROM MayTinh GROUP BY TrangThaiMay").ToList();
                    var pieSeries = new SeriesCollection();
                    foreach (var item in tinhTrang)
                    {
                        pieSeries.Add(new PieSeries { Title = (string)item.TrangThaiMay, Values = new ChartValues<int> { (int)item.SoLuong }, DataLabels = true });
                    }
                    chartTinhTrang.Series = pieSeries;

                    // 3. Giờ hoạt động
                    var gioHD = conn.Query("SELECT m.TenMay, ISNULL(SUM(ps.ThoiLuong), 0) as TongPhut FROM PhienSuDung ps INNER JOIN MayTinh m ON ps.MaMay = m.MaMay GROUP BY m.TenMay ORDER BY TongPhut DESC").ToList();
                    var seriesGio = new RowSeries { Title = "Giờ hoạt động", Values = new ChartValues<double>() };
                    var labelsGio = new System.Collections.Generic.List<string>();
                    foreach (var item in gioHD)
                    {
                        seriesGio.Values.Add(Math.Round(((int)item.TongPhut) / 60.0, 1));
                        labelsGio.Add((string)item.TenMay);
                    }
                    chartGio.Series = new SeriesCollection { seriesGio };
                    chartGio.AxisY.Add(new Axis { Labels = labelsGio });
                    chartGio.AxisX.Add(new Axis { Title = "Giờ", LabelFormatter = value => value.ToString("N1") });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu báo cáo: " + ex.Message);
            }
        }
    }
}
