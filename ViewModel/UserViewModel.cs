using ShopLink.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopLink.ViewModel
{
    public class UserViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<SanPham> _sanPhams;
        public ObservableCollection<SanPham> SanPhams
        {
            get => _sanPhams;
            set
            {
                _sanPhams = value;
                OnPropertyChanged(nameof(SanPhams));
            }
        }
        public ICommand MoThemSanPhamCommand { get; }

        public UserViewModel()
        {
            // Khởi tạo danh sách sản phẩm mẫu
            SanPhams = new ObservableCollection<SanPham>
        {
            new SanPham
            {
                TenSanPham = "Sản phẩm 1",
                GiaGoc = 120000,
                KhuyenMai = 10,
                HinhAnh = "C:\\Users\\Admin\\source\\repos\\ShopLink\\Asset\\Images\\Demo.jpg"
            } ,
            new SanPham
            {
                TenSanPham = "Sản phẩm 2",
                GiaGoc = 250000,
                KhuyenMai = 20,
                HinhAnh = "C:\\Users\\Admin\\source\\repos\\ShopLink\\Asset\\Images\\Demo.jpg"
            }

        };
            MoThemSanPhamCommand = new RelayCommand(MoThemSanPham);
        }
        private void MoThemSanPham()
        {
            var win = new ShopLink.View.ThemSanPham();
            win.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
