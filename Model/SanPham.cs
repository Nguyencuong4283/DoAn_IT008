using System;

namespace ShopLink.Model
{
    public enum TrangThai
    {
        Private,
        Public
    }
    public class SanPham
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MoTaSanPham { get; set; }
        public DateOnly NgayHetHan { get; set; }
        public int SoLuong { get; set; }
        public double GiaGoc { get; set; }
        public double KhuyenMai { get; set; }
        public string HinhAnh { get; set; }
        public TrangThai TrangThai { get; set; } = TrangThai.Private;
        public string MaStore { get; set;}

        public SanPham() { }

        public SanPham(string t, double g, double km, string ha)
        {
            TenSanPham = t;
            GiaGoc = g;
            KhuyenMai = km;
            MoTaSanPham = ha;
        }

        public SanPham(string ten, string mota, DateOnly dateOnly, int sl, double gia, double khuyenMai, string hinhAnh)
        {
            TenSanPham = ten;
            MoTaSanPham = mota;
            NgayHetHan = dateOnly;
            SoLuong = sl;
            GiaGoc = gia;
            KhuyenMai = khuyenMai;
            HinhAnh = hinhAnh;
        }
    }
}
