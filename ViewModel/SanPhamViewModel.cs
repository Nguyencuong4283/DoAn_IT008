using ShopLink.Model;
using ShopLink.Repository;
using ShopLink.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ShopLink.ViewModel
{
   public class SanPhamViewModel: INotifyPropertyChanged
    {
        private SanPham _sanPham;          // backing field
        public SanPham SanPham             // ⬅ Thuộc tính này được XAML binding
        {
            get => _sanPham;
            set
            {
                _sanPham = value;
                OnPropertyChanged(nameof(SanPham));
            }
        }

        private readonly User _user; // User hiện tại
        private readonly SanPhamRepository _repo;
        public ICommand ChonAnhCommand { get; }

        public ICommand ThemSanPhamCommand { get; }
        public ICommand TangSLCommand { get; }
        public ICommand GiamSLCommand { get; }
        public ICommand HuyCommand { get; }
        public Action CloseAction { get; set; }

        public SanPhamViewModel()
        {
            _repo = new SanPhamRepository();
            SanPham = new SanPham { SoLuong = 1 };
            TangSLCommand = new RelayCommand(TangSoLuong);
            GiamSLCommand = new RelayCommand(GiamSoLuong);// ⬅ Khởi tạo để tránh null khi binding
            ThemSanPhamCommand = new RelayCommand(ThemSanPham, () => SanPham != null);
            ChonAnhCommand = new RelayCommand(ChonAnh);
            HuyCommand = new RelayCommand(Huy);
        }
        private void ChonAnh()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (dialog.ShowDialog() == true)
            {
                // Gán đường dẫn ảnh vào thuộc tính SanPham.HinhAnh
                SanPham.HinhAnh = dialog.FileName;

                // Thông báo UI cập nhật
                OnPropertyChanged(nameof(SanPham));
            }
        }
        private void TangSoLuong()
        {
           SanPham.SoLuong++;
          
        }
        private void GiamSoLuong()
        {
            if(SanPham.SoLuong > 1)
            {
                SanPham.SoLuong--;
               
            }
        }
        private void ThemSanPham()
        {
            try
            {
                _repo.Insert(SanPham);
                MessageBox.Show("Thêm sản phẩm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }
        private void Huy()
        {
            CloseAction?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
