using ShopLink.Model;
using ShopLink.Model;
using ShopLink.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private int _soLuong;
        public int SoLuong
        {
            get => _soLuong;
            set
            {
                if (_soLuong != value)
                {
                    _soLuong = value;
                    OnPropertyChanged(nameof(SoLuong)); //Thông báo UI giá trị 1 thuộc tính đã thay đổi
                }
            }
        }

        private readonly SanPhamRepository _repo;

        public ICommand ThemCommand { get; }
        public ICommand TangSLCommand { get; }
        public ICommand GiamSLCommand { get; }


        public SanPhamViewModel()
        {
            _repo = new SanPhamRepository();
            SanPham = new SanPham { SoLuong = 1};
            TangSLCommand = new RelayCommand(TangSoLuong);
            GiamSLCommand = new RelayCommand(GiamSoLuong);// ⬅ Khởi tạo để tránh null khi binding
            ThemCommand = new RelayCommand(() => _repo.Insert(SanPham));
        }
        private void TangSoLuong()
        {
           SanPham.SoLuong++;
            OnPropertyChanged(nameof(SoLuong));
        }
        private void GiamSoLuong()
        {
            if(SanPham.SoLuong > 1)
            {
                SanPham.SoLuong--;
                OnPropertyChanged(nameof(SoLuong));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
