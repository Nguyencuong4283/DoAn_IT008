using ShopLink.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ShopLink.Repository
{
    public class UserRepository
    {
        private readonly string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=DoAn ;Integrated Security=True";

        // Thêm user mới (hash mật khẩu trước khi lưu)
        public void Insert(Users us)
        {
            using var conn = new SqlConnection(_connectionString);
            string sql = @"INSERT INTO Users (TenUser, PasswordUserHash, SDTUser, DiaChiUser, EmailUser)
                           VALUES (@TenUser, @PasswordUserHash, @SDTUser, @DiaChiUser, @EmailUser)";
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@TenUser", us.TenUser);
            cmd.Parameters.AddWithValue("@PasswordUserHash", PasswordHelper.HashPassword(us.PasswordUserHash));
            cmd.Parameters.AddWithValue("@SDTUser", us.SDTUser ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@DiaChiUser", us.DiaChiUser ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@EmailUser", us.EmailUser ?? (object)DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        // Kiểm tra đăng nhập
        public bool CheckLogin(string username, string password)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            string sql = "SELECT PasswordUserHash FROM Users WHERE TenUser = @TenUser";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@TenUser", username);

            var dbPassword = cmd.ExecuteScalar() as string;
            if (dbPassword == null) return false;

            // Hash mật khẩu nhập vào để so sánh
            string hashedInput = PasswordHelper.HashPassword(password);
            return dbPassword == hashedInput;
        }
    }

    // Helper để hash password
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
