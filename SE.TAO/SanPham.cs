using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE.TAO
{
    public partial class SanPham
    {
        public string GetTenLoaiSP()
        {
            return this.LoaiSP.TenLoai;
        }
    }
}
