using Microsoft.EntityFrameworkCore;

namespace eCom.Models
{
    public class EComContext(DbContextOptions<EComContext> options) : DbContext(options)
    {
        public virtual DbSet<AnhChiTietSanPham> AnhChiTietSanPhams { get; set; }
        public virtual DbSet<AnhSanPham> AnhSanPhams { get; set; }
        public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<MauSacSanPham> MauSacSanPhams { get; set; }
        public virtual DbSet<KichThuocSanPham> KichThuocSanPhams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiSanPham>()
                .HasMany(e => e.SanPhams)
                .WithOne(e => e.LoaiSanPham)
                .HasForeignKey(e => e.MaLoai)
                .IsRequired(false);

            modelBuilder.Entity<LoaiSanPham>()
                .HasData(
                new LoaiSanPham { MaLoai = "Cá", TenLoai = "Cá" },
                new LoaiSanPham { MaLoai = "Chăm sóc da", TenLoai = "Chăm sóc da" },
                new LoaiSanPham { MaLoai = "Chăm sóc nhà", TenLoai = "Chăm sóc nhà" },
                new LoaiSanPham { MaLoai = "Combo tiết kiệm", TenLoai = "Combo tiết kiệm" },
                new LoaiSanPham { MaLoai = "Củ", TenLoai = "Củ" },
                new LoaiSanPham { MaLoai = "Đồ khô", TenLoai = "Đồ khô" },
                new LoaiSanPham { MaLoai = "Gia vị", TenLoai = "Gia vị" },
                new LoaiSanPham { MaLoai = "Giỏ quà", TenLoai = "Giỏ quà" },
                new LoaiSanPham { MaLoai = "Hải sản", TenLoai = "Hải sản" },
                new LoaiSanPham { MaLoai = "Rau", TenLoai = "Rau" },
                new LoaiSanPham { MaLoai = "Thịt", TenLoai = "Thịt" },
                new LoaiSanPham { MaLoai = "Trái cây", TenLoai = "Trái cây" }
                );

            modelBuilder.Entity<User>()
                .HasData(
                new User { Username = "admin", Password = "111111" }
                );

            modelBuilder.Entity<SanPham>()
                .HasData(
                new SanPham { MaSp = "Khoai lang mỡ 300gr", TenSp = "Khoai lang mỡ 300gr", AnhSp = "1.jpg", MaLoai ="Củ", GiaSp=24000 },
                new SanPham { MaSp = "Rau cần tây Organic 300gr", TenSp = "Rau cần tây Organic 300gr", MaLoai = "Rau", GiaSp = 40000 },
                new SanPham { MaSp = "Đầu rồng An Mộc 300gr", TenSp = "Đầu rồng An Mộc 300gr", AnhSp = "19.jpg", MaLoai = "Thịt", GiaSp = 60000 },
                new SanPham { MaSp = "Ớt chuông đỏ Organic 300gr", TenSp = "Ớt chuông đỏ Organic 300gr", AnhSp = "3.jpg", MaLoai = "Rau", GiaSp = 28000 },
                new SanPham { MaSp = "Bột gừng Dace hữu cơ 40g", TenSp = "Bột gừng Dace hữu cơ 40g", AnhSp = "25.jpg", MaLoai = "Gia vị", GiaSp = 100000 },
                new SanPham { MaSp = "Xà lách mỡ Organic 300gr", TenSp = "Xà lách mỡ Organic 300gr", AnhSp = "2.jpg", MaLoai = "Rau", GiaSp = 30000 },
                new SanPham { MaSp = "Tôm thẻ con Tôm Rừng 400gr", TenSp = "Tôm thẻ con Tôm Rừng 400gr", AnhSp = "22.jpg", MaLoai = "Hải sản", GiaSp = 150000 },
                new SanPham { MaSp = "Cua nâu Ireland - Sống", TenSp = "Cua nâu Ireland - Sống", AnhSp = "24.jpg", MaLoai = "Hải sản", GiaSp = 1600000 },
                new SanPham { MaSp = "Hộp quà trái cây", TenSp = "Hộp quà trái cây", AnhSp = "21.jpg", MaLoai = "Trái Cây", GiaSp = 600000 },
                new SanPham { MaSp = "Phi lê cá hồi Organic 200gr", TenSp = "Phi lê cá hồi Organic 200gr", AnhSp = "23.jpg", MaLoai = "Cá", GiaSp = 300000 },
                new SanPham { MaSp = "Móng giò An Mộc 300gr", TenSp = "Móng giò An Mộc 300gr", AnhSp = "20.jpg", MaLoai = "Thịt", GiaSp = 80000 }
                );
        }
    }
}