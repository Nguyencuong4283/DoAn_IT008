using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShopLink.ViewModel
{
    /// <summary>
    /// Lớp ViewModel cơ sở triển khai INotifyPropertyChanged.
    /// Kế thừa lớp này cho các ViewModel khác để giảm lặp code.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gọi phương thức này khi một thuộc tính thay đổi giá trị.
        /// </summary>
        /// <param name="propertyName">Tên thuộc tính (mặc định tự lấy bằng CallerMemberName).</param>
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Cập nhật giá trị của một trường và kích hoạt OnPropertyChanged nếu giá trị thay đổi.
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của trường.</typeparam>
        /// <param name="field">Tham chiếu tới trường backing field.</param>
        /// <param name="value">Giá trị mới.</param>
        /// <param name="propertyName">Tên thuộc tính (tự động lấy nếu để trống).</param>
        /// <returns>True nếu giá trị thay đổi, ngược lại False.</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}

