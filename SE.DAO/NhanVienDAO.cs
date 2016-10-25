using SE.TAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace SE.DAO
{
    public class NhanVienDAO
    {
        private SEDataContext context;

        public NhanVienDAO()
        {
            this.context = new SEDataContext(Global.ConnectionString);
        }

        public List<NhanVien> GetDSNhanVien()
        {
            return context.NhanViens.ToList();
        }

        public bool AddNhanVien(NhanVien nv)
        {
            if (this.context.NhanViens.Any(x => x.MaNV == nv.MaNV))
            {
                return false;
            }
            this.context.NhanViens.InsertOnSubmit(nv);
            this.context.SubmitChanges();
            return true;
        }

        public bool UpdateNhanVien(NhanVien nv)
        {
            if (this.context.NhanViens.Any(x => x.MaNV == nv.MaNV))
            {
                var nhanvien = this.context.NhanViens.First(x => x.MaNV == nv.MaNV);
                nhanvien.HoTen = nv.HoTen;
                nhanvien.NgaySinh = nv.NgaySinh;
                nhanvien.NgayTD = nv.NgayTD;
                nhanvien.LuongCB = nv.LuongCB;
                nhanvien.NoiLamViec = nv.NoiLamViec;
                nhanvien.DiaChi = nv.DiaChi;
                nhanvien.CMND = nv.CMND;
                nhanvien.ChucVu = nv.ChucVu;
                this.context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool DeleteNhanVien(NhanVien nv)
        {
            if (this.context.NhanViens.Any(x => x.MaNV == nv.MaNV))
            {
                var nhanvien = this.context.NhanViens.First(x => x.MaNV == nv.MaNV);
                this.context.NhanViens.DeleteOnSubmit(nhanvien);
                this.context.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
