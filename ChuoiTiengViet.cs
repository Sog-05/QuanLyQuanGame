using System.Data;
using System.Text;

namespace test
{
    /// <summary>
    /// Chuẩn hóa tiếng Việt: sửa lỗi mojibake và đảm bảo hiển thị đúng trên WinForms.
    /// </summary>
    public static class ChuoiTiengViet
    {
        public static string ChuanHoa(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            string ketQua = text;

            if (CoLoiMojibake(ketQua))
            {
                try
                {
                    ketQua = Encoding.UTF8.GetString(Encoding.GetEncoding(1252).GetBytes(ketQua));
                }
                catch { /* giữ nguyên */ }
            }

            return SuaLoiDauHoiThuongGap(ketQua);
        }

        public static void ChuanHoaBang(DataTable bang, params string[] tenCot)
        {
            if (bang == null || tenCot == null) return;

            foreach (DataRow dong in bang.Rows)
            {
                foreach (string cot in tenCot)
                {
                    if (!bang.Columns.Contains(cot)) continue;
                    if (dong[cot] is string chuoi && !string.IsNullOrEmpty(chuoi))
                        dong[cot] = ChuanHoa(chuoi);
                }
            }
        }

        private static string SuaLoiDauHoiThuongGap(string text)
        {
            if (string.IsNullOrEmpty(text) || text.IndexOf('?') < 0)
                return text;

            return text
                .Replace("L?i", "Lỗi")
                .Replace("l?i", "lỗi")
                .Replace("Ch?y", "Chạy")
                .Replace("ch?y", "chạy")
                .Replace("v?i", "với")
                .Replace("V?i", "Với")
                .Replace("Th?m", "Thêm")
                .Replace("S?a", "Sửa")
                .Replace("X?a", "Xóa")
                .Replace("m?n", "món")
                .Replace("M?n", "Món")
                .Replace("b?ng", "bảng")
                .Replace("B?ng", "Bảng")
                .Replace("t?o", "tạo")
                .Replace("T?o", "Tạo")
                .Replace("Nh?p", "Nhập")
                .Replace("nh?p", "nhập")
                .Replace("Qu?n", "Quản")
                .Replace("qu?n", "quản")
                .Replace("?? ", "để ")
                .Replace("??", "đ")
                .Replace("c?p", "cập")
                .Replace("C?p", "Cập")
                .Replace("nh?n", "nhân")
                .Replace("Nh?n", "Nhân")
                .Replace("vi?n", "viên")
                .Replace("Vi?n", "Viên")
                .Replace("kh?ch", "khách")
                .Replace("Kh?ch", "Khách")
                .Replace("h?a", "hóa")
                .Replace("H?a", "Hóa")
                .Replace("don", "đơn")
                .Replace("Don", "Đơn")
                .Replace("b?o", "bảo")
                .Replace("B?o", "Bảo")
                .Replace("tr?", "trì")
                .Replace("Tr?", "Trì")
                .Replace("th?c", "thực")
                .Replace("Th?c", "Thực")
                .Replace("d?n", "dẫn")
                .Replace("D?n", "Dẫn")
                .Replace("m?y", "máy")
                .Replace("M?y", "Máy")
                .Replace("ch?", "chủ")
                .Replace("Ch?", "Chủ")
                .Replace("dang", "đang")
                .Replace("Dang", "Đang")
                .Replace("du?c", "được")
                .Replace("Du?c", "Được")
                .Replace("chua", "chưa")
                .Replace("Chua", "Chưa")
                .Replace("gio", "giờ")
                .Replace("Gio", "Giờ")
                .Replace("tien", "tiền")
                .Replace("Tien", "Tiền")
                .Replace("tam", "tạm")
                .Replace("Tam", "Tạm")
                .Replace("tinh", "tính")
                .Replace("Tinh", "Tính");
        }

        private static bool CoLoiMojibake(string text)
        {
            return text.IndexOf('Ã') >= 0
                || text.IndexOf('ï') >= 0
                || text.Contains("á»")
                || text.Contains("áº")
                || text.Contains("Ä")
                || text.Contains("Æ°")
                || text.Contains("ï¿½");
        }
    }
}
