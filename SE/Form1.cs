using BrightIdeasSoftware;
using SE.DAO;
using SE.TAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE
{
    public partial class Form1 : Form
    {
        // Declare variables
        private List<LoaiSP> dsLoaiSP;
        private List<SanPham> dsSanPham;
        private List<NhanVien> dsNhanVien;
        private List<HoaDon> dsHoaDon;

        private NhanVien nguoiSuDung;
        
        private int filterStep;

        public Form1()
        {
            InitializeComponent();
            this.filterStep = 0;

            this.dsLoaiSP = new LoaiSPDAO().GetDSLoaiSP();
            this.dsNhanVien = new NhanVienDAO().GetDSNhanVien();
            this.dsSanPham = new SanPhamDAO().GetDSSanPham();
            this.dsHoaDon = new List<HoaDon>()
            {
                new HoaDon()
                {
                    MaHD = 1,
                    NhanVien = this.dsNhanVien[1],
                    TongTien = 2300000,
                    NgayLap = DateTime.Today,
                    DSChiTietHD = new List<ChiTietHoaDon>()
                    {
                        new ChiTietHoaDon()
                        {
                            SanPham = this.dsSanPham[0],
                            DonGia = 120000,
                            SoLuong = 5
                        },
                        new ChiTietHoaDon()
                        {
                            SanPham = this.dsSanPham[1],
                            DonGia = 230000,
                            SoLuong = 3
                        }
                    }
                }
            };


            this.nguoiSuDung = this.dsNhanVien[0];
        }

        private object olvColImageGetter(object obj)
        {
            NhanVien nv = obj as NhanVien;
            if (nv.ChucVu == "Quản lý")
            {
                return 1;
            } else
            {
                return 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstvNhanVien.ShowGroups = true;
            lstvNhanVien.AlwaysGroupByColumn = lstColChucVu;
            lstvNhanVien.SetObjects(this.dsNhanVien);
            lstColMaNV.ImageGetter += new BrightIdeasSoftware.ImageGetterDelegate(olvColImageGetter);

            // QUAN LY SAN PHAM -----------------------------------------------------------------

            foreach (LoaiSP loai in this.dsLoaiSP)
            {
                cbxLoaiSP.Items.Add(loai.TenLoai);
            }
            cbxLoaiSP.SelectedIndex = 0;

            lstvSanPham.ShowGroups = true;
            lstvSanPham_LoaiSP.GroupFormatter += delegate(OLVGroup group, GroupingParameters parms)
            {
                string key = (string)group.Key;
                group.TitleImage = this.dsLoaiSP.FirstOrDefault(x => x.TenLoai.Equals(key)).MaLoai.ToString();
            };
            lstvSanPham.AlwaysGroupByColumn = lstvSanPham_LoaiSP;
            lstvSanPham_TinhTrang.AspectToStringConverter = delegate (object x)
            {
                return String.Empty;
            };
            lstvSanPham.SetObjects(this.dsSanPham);
            lstvSanPham_TinhTrang.ImageGetter = delegate(object x)
            {
                var sp = x as SanPham;
                if (sp.SoLuongTon == 0)
                {
                    return "outofstock";
                }
                else
                {
                    return "available";
                }
            };

            // QUAN LY HOA DON -----------------------------------------------------------------

            lstvHoaDon.SetObjects(this.dsHoaDon);
            cbxNhanVienLap.Items.AddRange(this.dsNhanVien.ToArray());
            lstvHoaDon_MaHD.ImageGetter = delegate(object x)
            {
                return "hoadon";
            };

            lstvHoaDon.CellToolTipShowing += new EventHandler<ToolTipShowingEventArgs>(delegate (object send, ToolTipShowingEventArgs args) {
            args.Title = "Danh sách sản phẩm";
            HoaDon hoadon = args.Model as HoaDon;
            args.StandardIcon = ToolTipControl.StandardIcons.Info;
            args.Font = new Font("Courier new", 8);
            StringBuilder str = new StringBuilder();
            str.AppendLine(string.Format("\n{0,-10}{1,-30}{2,-10}{3,15}", "Mã SP", "Tên SP", "Số lượng", "Đơn giá"));
            str.AppendLine("-----------------------------------------------------------------");
                foreach (var chitiet in hoadon.DSChiTietHD)
                {
                    str.AppendLine(string.Format("{0,-10}{1,-30}{2,-10}{3,15}", chitiet.SanPham.MaSP, chitiet.SanPham.TenSP, chitiet.SoLuong, chitiet.DonGia));
                }
                args.Text = str.ToString();
            });

            // BAN HANG -----------------------------------------------------------------

            lbeMaHoaDon.Text = this.dsHoaDon.Count > 0? (this.dsHoaDon.Max(x => x.MaHD) + 1).ToString() : "1";
            lbeNhanVienLap.Text = this.nguoiSuDung.HoTen;
            lbeNgayLap.Text = DateTime.Today.ToString("dd/MM/yyyy");
            cbxLoaiSP_BanHang.Items.AddRange(this.dsLoaiSP.ToArray());
        }

        private void lstvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NhanVien selected = lstvNhanVien.SelectedObject as NhanVien;
                tbxMaNV.Text = selected.MaNV.ToString();
                if (selected.ChucVu.Equals("Quản lý"))
                {
                    cbxChucVu.SelectedIndex = 0;
                }
                else
                {
                    cbxChucVu.SelectedIndex = 1;
                }
                tbxHoTen.Text = selected.HoTen;
                tbxDiaChi.Text = selected.DiaChi;
                tbxCMND.Text = selected.CMND;
                tbxLuongCB.Text = selected.LuongCB.ToString();
                tbxNoiLamViec.Text = selected.NoiLamViec;
                dtpickNgaySinh.Value = selected.NgaySinh;
                dtpickNgayTD.Value = selected.NgayTD;
            }
            catch (Exception)
            {
                
            }
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            int maNV = int.Parse(tbxMaNV.Text);
            if (this.dsNhanVien.FirstOrDefault(x => x.MaNV == maNV) != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại trong hệ thống!");
                return;
            }
            string chucvu = cbxChucVu.SelectedItem.ToString();
            string tenNV = tbxHoTen.Text;
            DateTime ngaysinh = dtpickNgaySinh.Value;
            string diachi = tbxDiaChi.Text;
            string cmnd = tbxCMND.Text;
            decimal luongCB = decimal.Parse(tbxLuongCB.Text);
            DateTime ngayTD = dtpickNgayTD.Value;
            string noiLV = tbxNoiLamViec.Text;
            NhanVien tmpNhanVien = new NhanVien()
            {
                MaNV = maNV,
                ChucVu = chucvu,
                HoTen = tenNV,
                NgaySinh = ngaysinh,
                DiaChi = diachi,
                CMND = cmnd,
                LuongCB = luongCB,
                NgayTD = ngayTD,
                NoiLamViec = noiLV
            };
            lstvNhanVien.AddObject(tmpNhanVien);
        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            object selected = lstvNhanVien.SelectedObject;
            var result = MessageBox.Show(string.Format("Bạn có chắc chắn muốn xóa nhân viên\n{0}\nkhông?", "a"), "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                lstvNhanVien.RemoveObject(selected);
            }
            Console.Write("");
        }

        private void btnSuaNhanVien_Click(object sender, EventArgs e)
        {
            NhanVien selected = lstvNhanVien.SelectedObject as NhanVien;
            selected.ChucVu = cbxChucVu.SelectedItem.ToString();
            selected.HoTen = tbxHoTen.Text;
            selected.NgaySinh = dtpickNgaySinh.Value;
            selected.DiaChi = tbxDiaChi.Text;
            selected.CMND = tbxCMND.Text;
            selected.LuongCB = decimal.Parse(tbxLuongCB.Text);
            selected.NgayTD = dtpickNgayTD.Value;
            selected.NoiLamViec = tbxNoiLamViec.Text;
            lstvNhanVien.UpdateObject(selected);
        }

        private void lstvSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selected = lstvSanPham.SelectedObject as SanPham;
                lstvChiTietSP.SetObjects(selected.ChiTietSanPhams);
            }
            catch (Exception)
            {
              
            }
        }

        private void cbxLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filterStep = 0;
            cbxKichThuoc.Enabled = true; cbxKichThuoc.Text = "";
            cbxMauSac.Enabled = true; cbxMauSac.Text = "";
            int selectedIndex = cbxLoaiSP.SelectedIndex;
            List<SanPham> resultList;
            if (selectedIndex == 0) {
                resultList = this.dsSanPham;
            }
            else
            {
                resultList = this.dsSanPham.Where(x => x.LoaiSP.MaLoai == this.dsLoaiSP[selectedIndex - 1].MaLoai).ToList();
            }
            var colorSet = new HashSet<string>();
            var sizeSet = new HashSet<string>();
            foreach (var product in resultList)
            {
                product.ChiTietSanPhams.Select(x => x.MauSac).ToList().ForEach(x => colorSet.Add(x));
                product.ChiTietSanPhams.Select(x => x.KichThuoc).ToList().ForEach(x => sizeSet.Add(x));
            }
            cbxMauSac.Items.Clear();
            cbxMauSac.Items.AddRange(colorSet.ToArray());
            cbxKichThuoc.Items.Clear();
            cbxKichThuoc.Items.AddRange(sizeSet.ToArray());
            lstvSanPham.SetObjects(resultList);
            this.filterStep++;
        }

        private void cbxMauSac_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentList = lstvSanPham.Objects.Cast<SanPham>().ToList();
            var resultList = new List<SanPham>();
            foreach (var sp in currentList)
            {
                if (sp.ChiTietSanPhams.Any(x => x.MauSac.Equals(cbxMauSac.SelectedItem.ToString())))
                {
                    resultList.Add(sp);
                }
            }
            lstvSanPham.SetObjects(resultList);
            if (this.filterStep == 1)
            {
                var sizeSet = new HashSet<string>(); ;
                foreach (var sp in resultList)
                {
                    sp.ChiTietSanPhams.Select(x => x.KichThuoc).ToList().ForEach(x => sizeSet.Add(x));
                }
                cbxKichThuoc.Items.Clear();
                cbxKichThuoc.Items.AddRange(sizeSet.ToArray());
            }
            cbxMauSac.Enabled = false;
            this.filterStep++;
        }

        private void cbxKichThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentList = lstvSanPham.Objects.Cast<SanPham>().ToList();
            var resultList = new List<SanPham>();
            foreach (var sp in currentList)
            {
                if (sp.ChiTietSanPhams.Any(x => x.KichThuoc.Equals(cbxKichThuoc.SelectedItem.ToString())))
                {
                    resultList.Add(sp);
                }
            }
            lstvSanPham.SetObjects(resultList);
            if (this.filterStep == 1)
            {
                var colorSet = new HashSet<string>(); ;
                foreach (var sp in resultList)
                {
                    sp.ChiTietSanPhams.Select(x => x.MauSac).ToList().ForEach(x => colorSet.Add(x));
                }
                cbxMauSac.Items.Clear();
                cbxMauSac.Items.AddRange(colorSet.ToArray());
            }
            cbxKichThuoc.Enabled = false;
            this.filterStep++;
        }

        private void tbxTimKiem_TextChanged(object sender, EventArgs e)
        {
            int searchType = cbxThuocTinhTim.SelectedIndex;
            List<SanPham> resultList;
            switch (searchType)
            {
                case 0:
                    resultList = this.dsSanPham.Where(x => x.MaSP.ToString().ToUpper().Contains(tbxTimKiem.Text.ToUpper())).ToList();
                    break;
                case 1:
                    resultList = this.dsSanPham.Where(x => x.TenSP.Contains(tbxTimKiem.Text)).ToList();
                    break;
                default:
                    resultList = new List<SanPham>();
                    break;
            }
            lstvSanPham.SetObjects(resultList);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabMain.SelectedIndex)
            {
                case 0:
                    this.Width = 840;
                    break;
                case 1:
                    this.Width = 740;
                    break;
                case 2:
                    this.Width = 834;
                    break;
                case 3:
                    this.Width = 701;
                    this.Height = 458;
                    break;
                default:
                    break;
            }
        }

        private void lstvHoaDon_HyperlinkClicked(object sender, HyperlinkClickedEventArgs e)
        {
            e.Handled = true;
            tabMain.SelectedIndex = 0;
            NhanVien target = ((HoaDon)e.Model).NhanVien;
            lstvNhanVien.Select();
            lstvNhanVien.SelectObject(target);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            dtpickNgayLap.Value = DateTime.Today;
            cbxNhanVienLap.SelectedIndex = -1;
            cbxNhanVienLap.Text = string.Empty;
            tbxTongTienLonHon.Text = string.Empty;
            tbxTongTienNhoHon.Text = string.Empty;
            lstvHoaDon.SetObjects(this.dsHoaDon);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            var currentList = lstvHoaDon.Objects.Cast<HoaDon>().ToList();
            List<HoaDon> resultList;
            resultList = currentList.Where(x => x.NgayLap == dtpickNgayLap.Value).ToList();
            int maNV = cbxNhanVienLap.SelectedIndex >= 0? ((NhanVien)cbxNhanVienLap.SelectedItem).MaNV : -1;
            resultList = maNV >= 0 ? currentList.Where(x => x.NhanVien.MaNV == maNV).ToList() : resultList;
            decimal minCost = decimal.MaxValue;
            decimal.TryParse(tbxTongTienLonHon.Text,out minCost);
            resultList = currentList.Where(x => x.TongTien >= minCost).ToList();
            double maxCost = 0;
            double.TryParse(tbxTongTienNhoHon.Text, out maxCost);
            resultList = currentList.Where(x => x.TongTien <= minCost).ToList();
            lstvHoaDon.SetObjects(resultList);
        }

        private void cbxLoaiSP_BanHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoaiSP loaiSP = cbxLoaiSP_BanHang.SelectedItem as LoaiSP;
            cbxSanPham_BanHang.Items.AddRange(loaiSP.DanhSachSP.Where(x => x.SoLuongTon > 0).ToArray());
        }

        private void cbxChiTiet_BanHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            SanPham sanpham = cbxSanPham_BanHang.SelectedItem as SanPham;
            cbxChiTiet_BanHang.Items.AddRange(sanpham.ChiTietSanPhams.Where(x => x.SoLuongTon > 0).ToArray());
        }
    }
}
