using System;
using System.ComponentModel;

namespace ShopLink.Model
{
    public enum TrangThai
    {
        Private,
        Public
    }
    public class SanPham : INotifyPropertyChanged
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MoTaSanPham { get; set; }
        public DateOnly NgayHetHan { get; set; }
        private int _soLuong;
        public int SoLuong
        {
            get => _soLuong;
            set
            {
                if (_soLuong != value)
                {
                    _soLuong = value;
                    OnPropertyChanged(nameof(SoLuong));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
        public SanPham(string tenSanPham, string moTaSanPham, DateOnly ngayHetHan, int soLuong, double giaGoc, double khuyenMai, string hinhAnh, TrangThai trangThai)
        {

            TenSanPham = tenSanPham;
            MoTaSanPham = moTaSanPham;
            NgayHetHan = ngayHetHan;
            SoLuong = soLuong;
            GiaGoc = giaGoc;
            KhuyenMai = khuyenMai;
            HinhAnh = hinhAnh;
            TrangThai = trangThai;
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
