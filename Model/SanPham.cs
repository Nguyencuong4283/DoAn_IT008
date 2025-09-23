using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLink.Model
{
    public class SanPham
    {
        public string MaSanPham { get; set; }
        public string NameSanPham { get; set; }
        public string MoTaSanPham {  set; get; }
        public DateOnly NgayHetHan {  get; set; }
        public int SoLuong { get; set; }
        public double Gia {  get; set; }

        public string MaStore { get; set; }

        public SanPham() { }
        public SanPham(string ten, string mota, DateOnly dateOnly, int sl, int gia)
        {
            NameSanPham = ten;
            MoTaSanPham = mota;
            NgayHetHan = dateOnly;
            SoLuong = sl;
            Gia = gia;
        }
    }
}
