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
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using static ShopLink.ViewModel.MainViewModel;


namespace ShopLink.ViewModel
{
    public class UserViewModel: INotifyPropertyChanged
    {
        public ICommand MoThemSanPhamCommand { get; }
        public ICommand ThongTinUserCommand {  get; }
        public ICommand DangNhapUserCommand { get; }
        public ICommand TaoTaiKhoanUserCommand { get; }
        private readonly UserRepository _user;
        // Property này để ViewModel có thể đóng Window
        public Action CloseAction { get; set; }
        public SanPhamViewModel SanPhamVM { get; set; } = new SanPhamViewModel();


        private readonly SanPhamRepository _repo;
        private Users _User;
        public Users Users
        {
            get => _User;
            set
            {
                _User = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public ObservableCollection<SanPham> SanPhams { get; set; } = new ObservableCollection<SanPham>();
        private DispatcherTimer _timer;

        public UserViewModel()
        {
            _repo = new SanPhamRepository();
            _user = new UserRepository();

            Users = new Users();
            MoThemSanPhamCommand = new RelayCommand(MoThemSanPham);
            LoadDataAsync();
            ThongTinUserCommand = new RelayCommand(ThongTinU);
            DangNhapUserCommand = new RelayCommand(DangNhapUser);
            TaoTaiKhoanUserCommand = new RelayCommand<object>(TaoTaiKhoanUser);



            // Tải lần đầu
            LoadSanPham();

            // Thiết lập timer 1 giây
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, e) => LoadSanPham();
            _timer.Start();
        }
        //Dùng để mở cửa sổ thêm sản phẩm 
        private void MoThemSanPham()
        {
           
            var win = new ShopLink.View.ThemSanPham();
            win.ShowDialog();
        }
        //Kiểm tra thông tin user , nếu null tạo tài khoản
        private void ThongTinU()
        {
            if(SessionManager.IsLoggedIn == false)
            {

                var result = MessageBox.Show(
                 "Bạn chưa đăng nhập , bạn có muốn tiếp tục?","Xác nhận",
                MessageBoxButton.YesNo,
                 MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes) { 
                    TaoTaiKhoanUser tku = new TaoTaiKhoanUser();
                    tku.ShowDialog();
                }
                else
                {
                    return;
                }

            }
            else
            {
                ThongTinUser ttu = new ThongTinUser();
                ttu.ShowDialog();
            }

        }
        //Mở cửa sổ đăng nhập user
        private void DangNhapUser()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (window != mainWindow)
                {
                    window.Close();
                }
            }
        }
        //Tạo tài khoản user
        private void TaoTaiKhoanUser(object parameter)
        {
            try
            {
                var passwordBox = parameter as PasswordBox;
                if (passwordBox == null)
                {
                    MessageBox.Show("Password chưa nhập!");
                    return;
                }

                Users.PasswordUserHash = passwordBox.Password;

                _user.Insert(Users);
                MessageBox.Show("Tajo tài khảon thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        //Dùng để load lại sanr phẩm khi thêm

        private async void LoadSanPham()
        {
            var list = await Task.Run(() => _repo.GetAll());

            // Cập nhật ObservableCollection trên UI thread
            SanPhams.Clear();
            foreach (var sp in list)
                SanPhams.Add(sp);
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
