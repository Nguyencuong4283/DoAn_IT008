using ShopLink.Model;
using ShopLink.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopLink.View
{
    /// <summary>
    /// Interaction logic for ChiTietSanPham.xaml
    /// </summary>
    public partial class ChiTietSanPham : Window
    {
        public ChiTietSanPham(SanPham sp)
        {
            InitializeComponent();
            DataContext = sp; // hoặc truyền item
        }
    }

}
