using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShopLink.ViewModel
{
    public class MainViewModel{

        public ICommand OpenUser { get; }
        public  MainViewModel()
        {
            OpenUser = new RelayCommand(OpenUserPage);
        }
        private void OpenUserPage()
        {
            var userVM = new UserViewModel();
            var userWindow = new View.User()
            {
                DataContext = userVM
            };
            userWindow.Show();
           

           
            // Nếu muốn đóng cửa sổ hiện tại:
            Application.Current.Windows[0]?.Close();
        }
    }
}
