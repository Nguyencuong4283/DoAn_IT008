
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLink.Model
{
   public class Users
    {
        public string MaUser {get;set;}
        public string TenUser { get; set; }
        public string PasswordUserHash {get;set; } // Lưu mật khẩu đã hash
        public string SDTUser {get;set;}
        public string DiaChiUser {get;set;}
        public string EmailUser {get;set;}
        
        public Users(string Ten_, string Password_, string SDT_, string DiaChi_, string Email_)
        {
            this.TenUser = Ten_;
            this.PasswordUserHash = Password_;
            this.SDTUser = SDT_;
            this.DiaChiUser = DiaChi_;
            this.EmailUser = Email_;
        }
        public Users() {}
    }
}
