using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE.TAO
{
    public partial class ChiTietSanPham
    {

        public ChiTietSanPham(string mausac, string kichthuoc, int soluongton, decimal dongia)
        {
            this.MauSac = mausac;
            this.KichThuoc = kichthuoc;
            this.SoLuongTon = soluongton;
            this.DonGia = dongia;
        }
    }
}
