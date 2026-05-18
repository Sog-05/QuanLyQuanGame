using System.Drawing;
using System.Windows.Forms;

namespace test
{
    public static class GiaoDienHelper
    {
        // Sử dụng font 'Segoe UI' với kích thước 10.5 để trông hiện đại và dễ đọc hơn
        public static readonly Font FontChu = new Font("Segoe UI", 10.5F, FontStyle.Regular);
        public static readonly Font FontTieuDe = new Font("Segoe UI", 12F, FontStyle.Bold);

        public static void ApDungFont(Form form)
        {
            if (form == null) return;
            
            // Áp dụng font cho chính Form
            form.Font = FontChu;
            
            // Đệ quy áp dụng cho tất cả các control bên trong
            ApDungChoControl(form);
        }

        private static void ApDungChoControl(Control cha)
        {
            foreach (Control c in cha.Controls)
            {
                // Nếu là Label tiêu đề (có thể dựa vào Tag hoặc kích thước cũ) thì dùng font lớn hơn
                if (c is Label lbl && (lbl.Font.Size > 11 || lbl.Font.Bold))
                {
                    c.Font = FontTieuDe;
                }
                else
                {
                    c.Font = FontChu;
                }

                // Nếu là DataGridView thì cần chỉnh cả Header và DefaultCellStyle
                if (c is DataGridView dgv)
                {
                    dgv.ColumnHeadersDefaultCellStyle.Font = FontTieuDe;
                    dgv.DefaultCellStyle.Font = FontChu;
                }

                if (c.HasChildren)
                    ApDungChoControl(c);
            }
        }
    }
}
