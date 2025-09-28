using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ShopLink.Model;

namespace ShopLink.Repository
{
    public class SanPhamRepository
    {
        private readonly string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=DoAn ;Integrated Security=True";

        public void Insert(SanPham sp)
        {
            using var conn = new SqlConnection(_connectionString);
            string sql = @"INSERT INTO SanPham 
                          (TenSanPham, MoTaSanPham, NgayHetHan, SoLuong, GiaGoc, KhuyenMai, HinhAnh, TrangThai) 
                          VALUES (@TenSanPham, @MoTaSanPham, @NgayHetHan, @SoLuong, @GiaGoc, @KhuyenMai, @HinhAnh, @TrangThai)";
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@TenSanPham",
     string.IsNullOrEmpty(sp.TenSanPham) ? (object)DBNull.Value : sp.TenSanPham);
            cmd.Parameters.AddWithValue("@MoTaSanPham",
                string.IsNullOrEmpty(sp.MoTaSanPham) ? (object)DBNull.Value : sp.MoTaSanPham);

            cmd.Parameters.AddWithValue("@NgayHetHan",
    sp.NgayHetHan.HasValue
        ? sp.NgayHetHan.Value
        : (object)DBNull.Value);

            cmd.Parameters.AddWithValue("@SoLuong", sp.SoLuong);
            cmd.Parameters.AddWithValue("@GiaGoc", sp.GiaGoc);
            cmd.Parameters.AddWithValue("@KhuyenMai", sp.KhuyenMai);
            cmd.Parameters.AddWithValue("@HinhAnh", sp.HinhAnh ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@TrangThai", sp.TrangThai.ToString());


            conn.Open();
            cmd.ExecuteNonQuery();
        }
     public List<SanPham> GetAll()
        {
            var list = new List<SanPham>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT TenSanPham, GiaGoc, KhuyenMai, HinhAnh,MoTaSanPham FROM SANPHAM", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    double giaGoc = reader.IsDBNull(1) ? 0 : Convert.ToDouble(reader.GetDecimal(1));
                    double khuyenMai = reader.IsDBNull(2) ? 0 : Convert.ToDouble(reader.GetDecimal(2));
                    list.Add(new SanPham
                    {
                        TenSanPham = reader.IsDBNull(0) ? null : reader.GetString(0),
                        
                        GiaGoc = reader.IsDBNull(1) ? 0 : Convert.ToDouble(reader.GetDecimal(1)),

                        KhuyenMai = reader.IsDBNull(2) ? 0 : Convert.ToDouble(reader.GetDecimal(2)),
                        GiaBan = giaGoc - khuyenMai * giaGoc / 100,

                        HinhAnh = reader.IsDBNull(3) ? null : reader.GetString(3),
                        MoTaSanPham = reader.IsDBNull(4) ? null : reader.GetString(4)
                    });
                }

            }
            return list;
        }
    }
}
