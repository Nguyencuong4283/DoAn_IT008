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
           
            cmd.Parameters.AddWithValue("@TenSanPham", sp.TenSanPham);
            cmd.Parameters.AddWithValue("@MoTaSanPham", sp.MoTaSanPham);
            cmd.Parameters.AddWithValue("@NgayHetHan",
     sp.NgayHetHan == default
         ? (object)DBNull.Value
         : sp.NgayHetHan.ToDateTime(TimeOnly.MinValue));

            cmd.Parameters.AddWithValue("@SoLuong", sp.SoLuong);
            cmd.Parameters.AddWithValue("@GiaGoc", sp.GiaGoc);
            cmd.Parameters.AddWithValue("@KhuyenMai", sp.KhuyenMai);
            cmd.Parameters.AddWithValue("@HinhAnh", sp.HinhAnh ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@TrangThai", sp.TrangThai.ToString());
         

            conn.Open();
            cmd.ExecuteNonQuery();
        }
       

    }
}
