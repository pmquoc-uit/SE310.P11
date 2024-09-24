namespace QLSP.UI
{
    partial class QLSP
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnXoa = new Button();
            btnLuu = new Button();
            dtHanDung = new DateTimePicker();
            txtXuatXu = new TextBox();
            txtDonGia = new TextBox();
            txtSoLuong = new TextBox();
            txtTen = new TextBox();
            txtMa = new TextBox();
            lbHanDung = new Label();
            lbXuatXu = new Label();
            lbDonGia = new Label();
            lbSoLuong = new Label();
            lbTen = new Label();
            lbMa = new Label();
            groupBox2 = new GroupBox();
            txtSlden = new TextBox();
            txtSltu = new TextBox();
            btntimsoluong = new Button();
            dtNgayDen = new DateTimePicker();
            dtNgayTu = new DateTimePicker();
            btnLocGiaNgay = new Button();
            txtTimXuatXu = new TextBox();
            txtXoaxx = new TextBox();
            btnxoaxuxuat = new Button();
            btnXuatXu = new Button();
            txtGiaden = new TextBox();
            txtGiatu = new TextBox();
            btnLocGia = new Button();
            btnKiemSPquahan = new Button();
            btnSPhethan = new Button();
            btnMax = new Button();
            btnXoaSPquahan = new Button();
            btnXoatoanboSp = new Button();
            groupBox3 = new GroupBox();
            lvDsSanPham = new ListView();
            groupBox4 = new GroupBox();
            lvDSSanphamloc = new ListView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(dtHanDung);
            groupBox1.Controls.Add(txtXuatXu);
            groupBox1.Controls.Add(txtDonGia);
            groupBox1.Controls.Add(txtSoLuong);
            groupBox1.Controls.Add(txtTen);
            groupBox1.Controls.Add(txtMa);
            groupBox1.Controls.Add(lbHanDung);
            groupBox1.Controls.Add(lbXuatXu);
            groupBox1.Controls.Add(lbDonGia);
            groupBox1.Controls.Add(lbSoLuong);
            groupBox1.Controls.Add(lbTen);
            groupBox1.Controls.Add(lbMa);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(325, 296);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(168, 245);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(151, 33);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa SP";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(17, 245);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(145, 33);
            btnLuu.TabIndex = 12;
            btnLuu.Text = "Lưu SP";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // dtHanDung
            // 
            dtHanDung.CustomFormat = "";
            dtHanDung.Format = DateTimePickerFormat.Short;
            dtHanDung.Location = new Point(123, 206);
            dtHanDung.Name = "dtHanDung";
            dtHanDung.Size = new Size(196, 23);
            dtHanDung.TabIndex = 11;
            // 
            // txtXuatXu
            // 
            txtXuatXu.Location = new Point(123, 169);
            txtXuatXu.Name = "txtXuatXu";
            txtXuatXu.Size = new Size(196, 23);
            txtXuatXu.TabIndex = 10;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(123, 133);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(196, 23);
            txtDonGia.TabIndex = 9;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(123, 91);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(196, 23);
            txtSoLuong.TabIndex = 8;
            // 
            // txtTen
            // 
            txtTen.Location = new Point(123, 57);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(196, 23);
            txtTen.TabIndex = 7;
            // 
            // txtMa
            // 
            txtMa.Location = new Point(123, 22);
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(196, 23);
            txtMa.TabIndex = 6;
            // 
            // lbHanDung
            // 
            lbHanDung.AutoSize = true;
            lbHanDung.Location = new Point(17, 212);
            lbHanDung.Name = "lbHanDung";
            lbHanDung.Size = new Size(61, 15);
            lbHanDung.TabIndex = 5;
            lbHanDung.Text = "Hạn Dùng";
            // 
            // lbXuatXu
            // 
            lbXuatXu.AutoSize = true;
            lbXuatXu.Location = new Point(18, 169);
            lbXuatXu.Name = "lbXuatXu";
            lbXuatXu.Size = new Size(48, 15);
            lbXuatXu.TabIndex = 4;
            lbXuatXu.Text = "Xuất Xứ";
            // 
            // lbDonGia
            // 
            lbDonGia.AutoSize = true;
            lbDonGia.Location = new Point(18, 133);
            lbDonGia.Name = "lbDonGia";
            lbDonGia.Size = new Size(48, 15);
            lbDonGia.TabIndex = 3;
            lbDonGia.Text = "Đon giá";
            // 
            // lbSoLuong
            // 
            lbSoLuong.AutoSize = true;
            lbSoLuong.Location = new Point(17, 94);
            lbSoLuong.Name = "lbSoLuong";
            lbSoLuong.Size = new Size(57, 15);
            lbSoLuong.TabIndex = 2;
            lbSoLuong.Text = "Số Luọng";
            // 
            // lbTen
            // 
            lbTen.AutoSize = true;
            lbTen.Location = new Point(17, 60);
            lbTen.Name = "lbTen";
            lbTen.Size = new Size(41, 15);
            lbTen.TabIndex = 1;
            lbTen.Text = "Tên SP";
            // 
            // lbMa
            // 
            lbMa.AutoSize = true;
            lbMa.Location = new Point(18, 25);
            lbMa.Name = "lbMa";
            lbMa.Size = new Size(40, 15);
            lbMa.TabIndex = 0;
            lbMa.Text = "Mã SP";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtSlden);
            groupBox2.Controls.Add(txtSltu);
            groupBox2.Controls.Add(btntimsoluong);
            groupBox2.Controls.Add(dtNgayDen);
            groupBox2.Controls.Add(dtNgayTu);
            groupBox2.Controls.Add(btnLocGiaNgay);
            groupBox2.Controls.Add(txtTimXuatXu);
            groupBox2.Controls.Add(txtXoaxx);
            groupBox2.Controls.Add(btnxoaxuxuat);
            groupBox2.Controls.Add(btnXuatXu);
            groupBox2.Controls.Add(txtGiaden);
            groupBox2.Controls.Add(txtGiatu);
            groupBox2.Controls.Add(btnLocGia);
            groupBox2.Controls.Add(btnKiemSPquahan);
            groupBox2.Controls.Add(btnSPhethan);
            groupBox2.Controls.Add(btnMax);
            groupBox2.Controls.Add(btnXoaSPquahan);
            groupBox2.Controls.Add(btnXoatoanboSp);
            groupBox2.Location = new Point(737, 314);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(318, 299);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chọn thao tác";
            // 
            // txtSlden
            // 
            txtSlden.Location = new Point(252, 199);
            txtSlden.Name = "txtSlden";
            txtSlden.Size = new Size(59, 23);
            txtSlden.TabIndex = 17;
            // 
            // txtSltu
            // 
            txtSltu.Location = new Point(175, 199);
            txtSltu.Name = "txtSltu";
            txtSltu.Size = new Size(60, 23);
            txtSltu.TabIndex = 16;
            // 
            // btntimsoluong
            // 
            btntimsoluong.Location = new Point(6, 199);
            btntimsoluong.Name = "btntimsoluong";
            btntimsoluong.Size = new Size(142, 23);
            btntimsoluong.TabIndex = 15;
            btntimsoluong.Text = "Tìm SP theo SL";
            btntimsoluong.UseVisualStyleBackColor = true;
            btntimsoluong.Click += btntimsoluong_Click;
            // 
            // dtNgayDen
            // 
            dtNgayDen.Format = DateTimePickerFormat.Short;
            dtNgayDen.Location = new Point(175, 170);
            dtNgayDen.Name = "dtNgayDen";
            dtNgayDen.Size = new Size(136, 23);
            dtNgayDen.TabIndex = 14;
            // 
            // dtNgayTu
            // 
            dtNgayTu.Format = DateTimePickerFormat.Short;
            dtNgayTu.Location = new Point(6, 170);
            dtNgayTu.Name = "dtNgayTu";
            dtNgayTu.Size = new Size(142, 23);
            dtNgayTu.TabIndex = 13;
            // 
            // btnLocGiaNgay
            // 
            btnLocGiaNgay.Location = new Point(6, 140);
            btnLocGiaNgay.Name = "btnLocGiaNgay";
            btnLocGiaNgay.Size = new Size(305, 23);
            btnLocGiaNgay.TabIndex = 12;
            btnLocGiaNgay.Text = "Tìm SP theo ngày";
            btnLocGiaNgay.UseVisualStyleBackColor = true;
            btnLocGiaNgay.Click += btnLocGiaNgay_Click;
            // 
            // txtTimXuatXu
            // 
            txtTimXuatXu.Location = new Point(175, 52);
            txtTimXuatXu.Name = "txtTimXuatXu";
            txtTimXuatXu.Size = new Size(137, 23);
            txtTimXuatXu.TabIndex = 11;
            // 
            // txtXoaxx
            // 
            txtXoaxx.Location = new Point(175, 80);
            txtXoaxx.Name = "txtXoaxx";
            txtXoaxx.Size = new Size(137, 23);
            txtXoaxx.TabIndex = 10;
            // 
            // btnxoaxuxuat
            // 
            btnxoaxuxuat.Location = new Point(6, 80);
            btnxoaxuxuat.Name = "btnxoaxuxuat";
            btnxoaxuxuat.Size = new Size(142, 23);
            btnxoaxuxuat.TabIndex = 9;
            btnxoaxuxuat.Text = "Xóa SP theo xuất xứ";
            btnxoaxuxuat.UseVisualStyleBackColor = true;
            btnxoaxuxuat.Click += btnxoaxuxuat_Click;
            // 
            // btnXuatXu
            // 
            btnXuatXu.Location = new Point(6, 51);
            btnXuatXu.Name = "btnXuatXu";
            btnXuatXu.Size = new Size(142, 23);
            btnXuatXu.TabIndex = 8;
            btnXuatXu.Text = "Tìm SP theo xuất xứ";
            btnXuatXu.UseVisualStyleBackColor = true;
            btnXuatXu.Click += btnXuatXu_Click;
            // 
            // txtGiaden
            // 
            txtGiaden.Location = new Point(252, 111);
            txtGiaden.Name = "txtGiaden";
            txtGiaden.Size = new Size(60, 23);
            txtGiaden.TabIndex = 7;
            // 
            // txtGiatu
            // 
            txtGiatu.Location = new Point(175, 111);
            txtGiatu.Name = "txtGiatu";
            txtGiatu.Size = new Size(60, 23);
            txtGiatu.TabIndex = 6;
            // 
            // btnLocGia
            // 
            btnLocGia.Location = new Point(6, 111);
            btnLocGia.Name = "btnLocGia";
            btnLocGia.Size = new Size(142, 23);
            btnLocGia.TabIndex = 5;
            btnLocGia.Text = "Lọc giá SP";
            btnLocGia.UseVisualStyleBackColor = true;
            btnLocGia.Click += btnLocGia_Click;
            // 
            // btnKiemSPquahan
            // 
            btnKiemSPquahan.Location = new Point(6, 228);
            btnKiemSPquahan.Name = "btnKiemSPquahan";
            btnKiemSPquahan.Size = new Size(306, 23);
            btnKiemSPquahan.TabIndex = 4;
            btnKiemSPquahan.Text = "Kiểm tra có sản phẩm hết hạn";
            btnKiemSPquahan.UseVisualStyleBackColor = true;
            btnKiemSPquahan.Click += btnKiemSPquahan_Click;
            // 
            // btnSPhethan
            // 
            btnSPhethan.Location = new Point(175, 22);
            btnSPhethan.Name = "btnSPhethan";
            btnSPhethan.Size = new Size(137, 23);
            btnSPhethan.TabIndex = 3;
            btnSPhethan.Text = "Lọc Tìm SP hết hạn";
            btnSPhethan.UseVisualStyleBackColor = true;
            btnSPhethan.Click += btnSPhethan_Click;
            // 
            // btnMax
            // 
            btnMax.Location = new Point(6, 22);
            btnMax.Name = "btnMax";
            btnMax.Size = new Size(142, 23);
            btnMax.TabIndex = 2;
            btnMax.Text = "Tìm SP giá Max";
            btnMax.UseVisualStyleBackColor = true;
            btnMax.Click += btnMax_Click;
            // 
            // btnXoaSPquahan
            // 
            btnXoaSPquahan.Location = new Point(175, 257);
            btnXoaSPquahan.Name = "btnXoaSPquahan";
            btnXoaSPquahan.Size = new Size(137, 38);
            btnXoaSPquahan.TabIndex = 1;
            btnXoaSPquahan.Text = "Xóa toàn bộ SP hết hạn";
            btnXoaSPquahan.UseVisualStyleBackColor = true;
            btnXoaSPquahan.Click += btnXoaSPquahan_Click;
            // 
            // btnXoatoanboSp
            // 
            btnXoatoanboSp.Location = new Point(6, 257);
            btnXoatoanboSp.Name = "btnXoatoanboSp";
            btnXoatoanboSp.Size = new Size(142, 38);
            btnXoatoanboSp.TabIndex = 0;
            btnXoatoanboSp.Text = "Xóa toàn bộ SP Trong kho";
            btnXoatoanboSp.UseVisualStyleBackColor = true;
            btnXoatoanboSp.Click += btnXoatoanboSp_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lvDsSanPham);
            groupBox3.Location = new Point(12, 314);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(709, 299);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách sản phẩm";
            // 
            // lvDsSanPham
            // 
            lvDsSanPham.FullRowSelect = true;
            lvDsSanPham.GridLines = true;
            lvDsSanPham.Location = new Point(6, 22);
            lvDsSanPham.Name = "lvDsSanPham";
            lvDsSanPham.Size = new Size(697, 273);
            lvDsSanPham.TabIndex = 0;
            lvDsSanPham.UseCompatibleStateImageBehavior = false;
            lvDsSanPham.View = View.Details;
            lvDsSanPham.SelectedIndexChanged += lvDsSanPham_SelectedIndexChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lvDSSanphamloc);
            groupBox4.Location = new Point(375, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(680, 296);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Danh sách tìm kiếm";
            // 
            // lvDSSanphamloc
            // 
            lvDSSanphamloc.FullRowSelect = true;
            lvDSSanphamloc.GridLines = true;
            lvDSSanphamloc.Location = new Point(6, 22);
            lvDSSanphamloc.Name = "lvDSSanphamloc";
            lvDSSanphamloc.Size = new Size(668, 268);
            lvDSSanphamloc.TabIndex = 0;
            lvDSSanphamloc.UseCompatibleStateImageBehavior = false;
            lvDSSanphamloc.View = View.Details;
            // 
            // QLSP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 615);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "QLSP";
            Text = "QLSP";
            Load += QLSP_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label lbMa;
        private Label lbHanDung;
        private Label lbXuatXu;
        private Label lbDonGia;
        private Label lbSoLuong;
        private Label lbTen;
        private TextBox txtMa;
        private TextBox txtDonGia;
        private TextBox txtSoLuong;
        private TextBox txtTen;
        private DateTimePicker dtHanDung;
        private TextBox txtXuatXu;
        private ListView lvDsSanPham;
        private ListView lvDSSanphamloc;
        private Button btnXoaSPquahan;
        private Button btnXoatoanboSp;
        private Button btnSPhethan;
        private Button btnMax;
        private Button btnKiemSPquahan;
        private Button btnLocGia;
        private TextBox txtGiaden;
        private TextBox txtGiatu;
        private TextBox txtTimXuatXu;
        private TextBox txtXoaxx;
        private Button btnxoaxuxuat;
        private Button btnXuatXu;
        private Button btnLocGiaNgay;
        private DateTimePicker dtNgayDen;
        private DateTimePicker dtNgayTu;
        private TextBox txtSlden;
        private TextBox txtSltu;
        private Button btntimsoluong;
        private Button btnXoa;
        private Button btnLuu;
    }
}
