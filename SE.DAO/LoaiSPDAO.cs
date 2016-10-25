using SE.TAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE.DAO
{
    public class LoaiSPDAO
    {
        private SEDataContext context;

        public LoaiSPDAO()
        {
            this.context = new SEDataContext(Global.ConnectionString);
        }

        public List<LoaiSP> GetDSLoaiSP()
        {
            return this.context.LoaiSPs.ToList();
        }
    }
}
