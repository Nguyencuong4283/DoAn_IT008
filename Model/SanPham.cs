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
        private string _tenSanPham;
        public string TenSanPham
        {
            get => _tenSanPham;
            set
            {
                if (_tenSanPham != value)
                {
                    _tenSanPham = value;
                    OnPropertyChanged(nameof(TenSanPham));
                }
            }
        }

        private string _moTaSanPham;
        public string MoTaSanPham
        {
            get => _moTaSanPham;
            set
            {
                if (_moTaSanPham != value)
                {
                    _moTaSanPham = value;
                    OnPropertyChanged(nameof(MoTaSanPham));
                }
            }
        }
        private DateTime? _dateOnly;
        public DateTime? NgayHetHan
        {
            get => _dateOnly;
            set
            {
                if (value != _dateOnly)
                {
                    _dateOnly = value;
                    OnPropertyChanged(nameof(NgayHetHan));
                }
            }

        }
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
        public double GiaBan { get; set; }
        private string _hinhAnh;
        public string HinhAnh
        {
            get => _hinhAnh;
            set
            {
                _hinhAnh = value;
                OnPropertyChanged(nameof(HinhAnh));
            }
        }
        private TrangThai _trangThai;
        public TrangThai TrangThai
        {
            get => _trangThai;
            set
            {
                if(_trangThai != value)
                {
                    _trangThai = value;
                    OnPropertyChanged(nameof(TrangThai));
                }
            }
        }
        public string MaStore { get; set;}

        public SanPham() { }

        public SanPham(string t, double g, double km, string ha)
        {
            TenSanPham = t;
            GiaGoc = g;
            KhuyenMai = km;
            MoTaSanPham = ha;
        }
        public SanPham(string tenSanPham, string moTaSanPham, DateTime ngayHetHan, int soLuong, double giaGoc, double khuyenMai, string hinhAnh, TrangThai trangThai)
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

        public SanPham(string ten, string mota, DateTime dateOnly, int sl, double gia, double khuyenMai, string hinhAnh)
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
