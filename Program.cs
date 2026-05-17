using System;
using System.Windows.Forms;

namespace test
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new frmDangNhap();
            GiaoDienHelper.ApDungFont(form);
            Application.Run(form);
        }
    }
}
