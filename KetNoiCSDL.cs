using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace test
{
    public static class KetNoiCSDL
    {
        public static readonly string ChuoiKetNoi =
            ConfigurationManager.ConnectionStrings["QuanLyQuanGame"]?.ConnectionString
            ?? "Data Source=LAPTOP-B6R69I92\\SQLEXPRESS02;Initial Catalog=QuanLyQuanGame;Integrated Security=True";

        public static DataTable ThucThiTruyVan(string sql, params SqlParameter[] thamSo)
        {
            using (var ketNoi = new SqlConnection(ChuoiKetNoi))
            using (var lenh = new SqlCommand(sql, ketNoi))
            {
                if (thamSo != null && thamSo.Length > 0)
                    lenh.Parameters.AddRange(thamSo);

                var boChuyen = new SqlDataAdapter(lenh);
                var bang = new DataTable();
                boChuyen.Fill(bang);
                return bang;
            }
        }

        public static int ThucThiLenh(string sql, params SqlParameter[] thamSo)
        {
            using (var ketNoi = new SqlConnection(ChuoiKetNoi))
            using (var lenh = new SqlCommand(sql, ketNoi))
            {
                if (thamSo != null && thamSo.Length > 0)
                    lenh.Parameters.AddRange(thamSo);

                ketNoi.Open();
                return lenh.ExecuteNonQuery();
            }
        }

        public static object ThucThiScalar(string sql, params SqlParameter[] thamSo)
        {
            using (var ketNoi = new SqlConnection(ChuoiKetNoi))
            using (var lenh = new SqlCommand(sql, ketNoi))
            {
                if (thamSo != null && thamSo.Length > 0)
                    lenh.Parameters.AddRange(thamSo);

                ketNoi.Open();
                return lenh.ExecuteScalar();
            }
        }
    }
}
