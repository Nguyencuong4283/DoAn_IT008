using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLink.ViewModel
{
    public class MainUserViewModel
    {
        public SanPhamViewModel SanPhamVM { get; set; }
        public UserViewModel UserVM { get; set; }

        public MainUserViewModel()
        {
            SanPhamVM = new SanPhamViewModel();
            UserVM = new UserViewModel();
        }
    }

}
