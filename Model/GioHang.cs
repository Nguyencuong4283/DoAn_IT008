using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLink.Model
{
    public class GioHang : INotifyPropertyChanged
    {
        public string MaGioHang { get; set; }
        public string MaUser { get; set; }
        public string MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public GioHang() { }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
