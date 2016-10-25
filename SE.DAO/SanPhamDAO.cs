using SE.TAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE.DAO
{
    public class SanPhamDAO
    {
        private SEDataContext context;

        public SanPhamDAO()
        {
            this.context = new SEDataContext(Global.ConnectionString);
            DataLoadOptions loadOption = new DataLoadOptions();
            loadOption.LoadWith<SanPham>(x => x.ChiTietSanPhams);
            loadOption.LoadWith<SanPham>(x => x.LoaiSP);
        }

        public List<SanPham> GetDSSanPham()
        {
            return this.context.SanPhams.ToList();
        }
    }
}
