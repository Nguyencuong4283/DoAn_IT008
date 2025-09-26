using ShopLink.Model;
using ShopLink.Repository;
using ShopLink.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShopLink.ViewModel
{
    public class UserViewModel: INotifyPropertyChanged
    {
        public ICommand MoThemSanPhamCommand { get; }
        private readonly SanPhamRepository _repo;
        public ObservableCollection<SanPham> SanPhams { get; set; } = new ObservableCollection<SanPham>();


        public UserViewModel()
        {
            _repo = new SanPhamRepository();
            MoThemSanPhamCommand = new RelayCommand(MoThemSanPham);
            LoadDataAsync();
        }
        private void MoThemSanPham()
        {
            var win = new ShopLink.View.ThemSanPham();
            win.ShowDialog();
        }
        public async void LoadDataAsync()
        {
            try
            {
                // Chạy GetAll() trên background thread
                var list = await Task.Run(() => _repo.GetAll());

                // Cập nhật ObservableCollection trên UI thread
                SanPhams.Clear();
                foreach (var sp in list)
                    SanPhams.Add(sp);
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
