using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE.TAO
{
    public partial class LoaiSP
    {
        public List<SanPham> DanhSachSP { get; set; }

        public override string ToString()
        {
            return this.TenLoai;
        }
    }
}
