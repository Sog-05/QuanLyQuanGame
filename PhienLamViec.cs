namespace test
{
    public static class PhienLamViec
    {
        public static int MaNguoiDung { get; set; }
        public static int MaNhanVien { get; set; }
        public static string TenNhanVien { get; set; }
        public static string TenDangNhap { get; set; }

        public static void Xoa()
        {
            MaNguoiDung = 0;
            MaNhanVien = 0;
            TenNhanVien = null;
            TenDangNhap = null;
        }
    }
}
