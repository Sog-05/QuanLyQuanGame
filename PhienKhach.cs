namespace test
{
    public static class PhienKhach
    {
        public static int MaNguoiDung { get; set; }
        public static int MaKhachHang { get; set; }
        public static string HoTen { get; set; }
        public static string TenDangNhap { get; set; }
        public static int MaMay { get; set; }
        public static string TenMay { get; set; }
        public static int MaPhien { get; set; }
        public static decimal SoDu { get; set; }

        public static void Xoa()
        {
            MaNguoiDung = 0;
            MaKhachHang = 0;
            HoTen = null;
            TenDangNhap = null;
            MaMay = 0;
            TenMay = null;
            MaPhien = 0;
            SoDu = 0;
        }
    }
}
