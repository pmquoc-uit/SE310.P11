namespace QLSP.UI
{
    public partial class QLSP : Form
    {
        public QLSP()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        List<SP> dssp = new List<SP>();
        private void QLSP_Load(object sender, EventArgs e)
        {
            lvDsSanPham.Columns.Clear();
            lvDsSanPham.Columns.Add("Mã sản phẩm", 100);
            lvDsSanPham.Columns.Add("Tên sản phẩm", 150);
            lvDsSanPham.Columns.Add("Số lượng", 70);
            lvDsSanPham.Columns.Add("Đơn giá", 100);
            lvDsSanPham.Columns.Add("Xuất xứ", 100);
            lvDsSanPham.Columns.Add("Hạn sử dụng", 100);

            lvDSSanphamloc.Columns.Clear();
            lvDSSanphamloc.Columns.Add("Mã Sản Phẩm", 100);
            lvDSSanphamloc.Columns.Add("Tên Sản Phẩm", 150);
            lvDSSanphamloc.Columns.Add("Số Lượng", 100);
            lvDSSanphamloc.Columns.Add("Đơn Giá", 100);
            lvDSSanphamloc.Columns.Add("Xuất Xứ", 100);
            lvDSSanphamloc.Columns.Add("Hạn Sử Dụng", 100);

            dssp.Add(new SP() { Ma = "SP1", Ten = "Ken", Soluong = 15, DonGia = 20000, Xuatxu = "Mỹ", HanDung = new DateTime(2017, 1, 12) });
            dssp.Add(new SP() { Ma = "SP2", Ten = "Bia 333", Soluong = 10, DonGia = 10000, Xuatxu = "viêt Nam", HanDung = new DateTime(2022, 1, 12) });
            dssp.Add(new SP() { Ma = "SP3", Ten = "Tiger", Soluong = 20, DonGia = 15000, Xuatxu = "Mỹ", HanDung = new DateTime(2017, 1, 05) });
            dssp.Add(new SP() { Ma = "SP4", Ten = "colala", Soluong = 50, DonGia = 5000, Xuatxu = "China", HanDung = new DateTime(2030, 1, 11) });
            dssp.Add(new SP() { Ma = "SP6", Ten = "Pepsi", Soluong = 1, DonGia = 11000, Xuatxu = "Mỹ", HanDung = new DateTime(2019, 1, 12) });
            dssp.Add(new SP() { Ma = "SP7", Ten = "Nước Suối", Soluong = 5, DonGia = 6000, Xuatxu = "Mỹ", HanDung = new DateTime(2019, 1, 12) });
            dssp.Add(new SP() { Ma = "SP8", Ten = "Redbull", Soluong = 8, DonGia = 15000, Xuatxu = "China", HanDung = new DateTime(2019, 1, 12) });
            dssp.Add(new SP() { Ma = "SP9", Ten = "7up", Soluong = 3, DonGia = 70000, Xuatxu = "Lào", HanDung = new DateTime(2023, 1, 12) });
            dssp.Add(new SP() { Ma = "SP10", Ten = "Pepsi", Soluong = 25, DonGia = 6000, Xuatxu = "Việt Nam", HanDung = new DateTime(2019, 1, 12) });
            dssp.Add(new SP() { Ma = "SP10", Ten = "Bia Hà Nội", Soluong = 70, DonGia = 12000, Xuatxu = "Mỹ", HanDung = new DateTime(2019, 1, 12) });
            dssp.Add(new SP() { Ma = "SP12", Ten = "Bia Sài Gòn", Soluong = 4, DonGia = 10000, Xuatxu = "Việt nam", HanDung = new DateTime(2023, 1, 12) });

            lvDsSanPham.Items.Clear();
            hienthilistview(dssp, lvDsSanPham);
        }
        void hienthilistview(List<SP> ds, ListView lvsp)
        {
            lvsp.Items.Clear();
            ds.ForEach(x =>
            {
                ListViewItem lvi = new ListViewItem(x.Ma);
                lvi.SubItems.Add(x.Ten);
                lvi.SubItems.Add(x.Soluong + "");
                lvi.SubItems.Add(x.DonGia + "");
                lvi.SubItems.Add(x.Xuatxu);
                lvi.SubItems.Add(x.HanDung.ToString("dd / MM / yyyy"));
                lvsp.Items.Add(lvi);
                if (x.HanDung < DateTime.Now)
                {
                    lvi.ForeColor = Color.Red;
                }
            }
            );
        }
        void xoatext()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtXuatXu.Clear();
            txtMa.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text) ||
                string.IsNullOrWhiteSpace(txtTen.Text) ||
                !int.TryParse(txtSoLuong.Text, out int soLuong) ||
                !int.TryParse(txtDonGia.Text, out int donGia) ||
                string.IsNullOrWhiteSpace(txtXuatXu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hợp lệ.");
                return;
            }
            var existingProduct = dssp
                .FirstOrDefault(sp => sp.Ma.Equals(txtMa.Text, StringComparison.OrdinalIgnoreCase));
            if (existingProduct != null)
            {
                // Cập nhật thông tin sản phẩm đã tồn tại
                existingProduct.Ten = txtTen.Text;
                existingProduct.Soluong = soLuong;
                existingProduct.DonGia = donGia;
                existingProduct.Xuatxu = txtXuatXu.Text;
                existingProduct.HanDung = dtHanDung.Value;
                MessageBox.Show("Sản phẩm đã được cập nhật.");
            }
            else
            {
                // Thêm mới sản phẩm
                SP sp = new SP
                {
                    Ma = txtMa.Text,
                    Ten = txtTen.Text,
                    Soluong = soLuong,
                    DonGia = donGia,
                    Xuatxu = txtXuatXu.Text,
                    HanDung = dtHanDung.Value
                };
                dssp.Add(sp);
                MessageBox.Show("Sản phẩm đã được thêm mới.");
            }
            xoatext();
            hienthilistview(dssp, lvDsSanPham);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDsSanPham.SelectedIndices.Count == 0)
            {
                MessageBox.Show("vui lòng chọn sản phẩm");
                return;
            }
            int spxoa = lvDsSanPham.SelectedIndices[0];
            dssp.RemoveAt(spxoa);
            hienthilistview(dssp, lvDsSanPham);
        }
        private void btnMax_Click(object sender, EventArgs e)
        {
            SP? sp = dssp.OrderByDescending(s => s.DonGia).FirstOrDefault();
            if(sp == null)
            {
                MessageBox.Show(text: "Chưa có sản phẩm");
                return;
            }
            List<SP> dsspmax = new List<SP>() { sp! };
            hienthilistview(dsspmax, lvDSSanphamloc);
        }
        private void btnSPhethan_Click(object sender, EventArgs e)
        {
            // dùng hàm where để lọc sản phẩm hết hạn hiên lên list
            var dssphethan = dssp.Where(x => x.HanDung < DateTime.Now).ToList();
            hienthilistview(dssphethan, lvDSSanphamloc);
        }
        private void btnXuatXu_Click(object sender, EventArgs e)
        {
            string t = txtTimXuatXu.Text;
            var dsxx = dssp.Where(x => x.Xuatxu == t).ToList();
            hienthilistview(dsxx, lvDSSanphamloc);
        }
        private void btnxoaxuxuat_Click(object sender, EventArgs e)
        {
            dssp = dssp.Where(s => !string
                .Equals(s.Xuatxu, txtXoaxx.Text, StringComparison.OrdinalIgnoreCase))
                .ToList();
            hienthilistview(dssp, lvDsSanPham);
        }
        private void btnLocGia_Click(object sender, EventArgs e)
        {
            int min = int.Parse(txtGiatu.Text);
            int max = int.Parse(txtGiaden.Text);
            var dsgialoc = from x in dssp// query syntax
                           where x.DonGia >= min && x.DonGia <= max
                           select x;
            hienthilistview(dsgialoc.ToList(), lvDSSanphamloc);
        }

        private void btnLocGiaNgay_Click(object sender, EventArgs e)
        {
            // findall tìm sản phẩm  theo ngày hết hạn hoặc ngày bán
            DateTime tu = dtNgayTu.Value.Date;
            DateTime den = dtNgayDen.Value.Date;
            var dstimngay = dssp.FindAll(x => x.HanDung >= tu && x.HanDung <= den);
            hienthilistview(dstimngay, lvDSSanphamloc);
        }
        private void btntimsoluong_Click(object sender, EventArgs e)
        {
            int sltu = int.Parse(txtSltu.Text);
            int slden = int.Parse(txtSlden.Text);
            var dstimSoLuong = from x in dssp// query syntax
                               where x.Soluong >= sltu && x.Soluong <= slden
                               select x;
            hienthilistview(dstimSoLuong.ToList(), lvDSSanphamloc);
        }
        private void btnKiemSPquahan_Click(object sender, EventArgs e)
        {
            // dùng any hoặc exits đê kiểm tra tất sản phẩm thõa mãn 1 điều kiện
            bool kqhd = dssp.Any(x => x.HanDung < DateTime.Now);
            if (kqhd)
            {
                MessageBox.Show("Có sản phẩm hết hạn");
            }
            else
            {
                MessageBox.Show("Không có sản phẩm hết hạn");
            }
        }
        private void btnXoatoanboSp_Click(object sender, EventArgs e)
        {
            dssp.Clear();// xóa toàn bộ sản phẩm trong danh sách
            hienthilistview(dssp, lvDsSanPham);// hiện thị lại sản phẩm
        }
        private void btnXoaSPquahan_Click(object sender, EventArgs e)
        {
            // removeAll xóa có điều kiện
            dssp.RemoveAll(x => x.HanDung < DateTime.Now);
            hienthilistview(dssp, lvDsSanPham);
        }
        private void lvDsSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvDsSanPham.SelectedItems.Count > 0)
            {
                var selectedItem = lvDsSanPham.SelectedItems[0];
                txtMa.Text = selectedItem?.SubItems[0].Text;
                txtTen.Text = selectedItem?.SubItems[1].Text;
                txtSoLuong.Text = selectedItem?.SubItems[2].Text;
                txtDonGia.Text = selectedItem?.SubItems[3].Text;
                txtXuatXu.Text = selectedItem?.SubItems[4].Text;
                if (DateTime.TryParse(selectedItem?.SubItems[5].Text, out DateTime hanDung))
                {
                    dtHanDung.Value = hanDung;
                }
            }
        }
    }
}
