using ShopLink.Model;
using ShopLink.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopLink.Repository;

namespace ShopLink.ViewModel
{
    public class UserViewModel: INotifyPropertyChanged
    {
        public ICommand MoThemSanPhamCommand { get; }
      

        public UserViewModel()
        {
            
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
