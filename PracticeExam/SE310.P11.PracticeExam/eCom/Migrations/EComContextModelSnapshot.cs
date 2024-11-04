﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eCom.Models;

#nullable disable

namespace eCom.Migrations
{
    [DbContext(typeof(EComContext))]
    partial class EComContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eCom.Models.AnhChiTietSanPham", b =>
                {
                    b.Property<string>("MaChiTietSp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaChiTietSpNavigationMaChiTietSp")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenFileAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaChiTietSp");

                    b.HasIndex("MaChiTietSpNavigationMaChiTietSp");

                    b.ToTable("AnhChiTietSanPhams");
                });

            modelBuilder.Entity("eCom.Models.AnhSanPham", b =>
                {
                    b.Property<string>("MaSp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaSpNavigationMaSp")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenFileAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSp");

                    b.HasIndex("MaSpNavigationMaSp");

                    b.ToTable("AnhSanPhams");
                });

            modelBuilder.Entity("eCom.Models.ChiTietSanPham", b =>
                {
                    b.Property<string>("MaChiTietSp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("DonGia")
                        .HasColumnType("float");

                    b.Property<string>("MaKichThuoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaKichThuocNavigationMaKichThuoc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaMauSac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaMauSacNavigationMaMauSac")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaSp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaSpNavigationMaSp")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaChiTietSp");

                    b.HasIndex("MaKichThuocNavigationMaKichThuoc");

                    b.HasIndex("MaMauSacNavigationMaMauSac");

                    b.HasIndex("MaSpNavigationMaSp");

                    b.ToTable("ChiTietSanPhams");
                });

            modelBuilder.Entity("eCom.Models.KhachHang", b =>
                {
                    b.Property<string>("MaKhanhHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("LoaiKhachHang")
                        .HasColumnType("tinyint");

                    b.Property<string>("TenKhachHang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsernameNavigationUsername")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MaKhanhHang");

                    b.HasIndex("UsernameNavigationUsername");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("eCom.Models.KichThuocSanPham", b =>
                {
                    b.Property<string>("MaKichThuoc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenKichThuoc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKichThuoc");

                    b.ToTable("KichThuocSanPhams");
                });

            modelBuilder.Entity("eCom.Models.LoaiSanPham", b =>
                {
                    b.Property<string>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenLoai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLoai");

                    b.ToTable("LoaiSanPhams");

                    b.HasData(
                        new
                        {
                            MaLoai = "Cá",
                            TenLoai = "Cá"
                        },
                        new
                        {
                            MaLoai = "Chăm sóc da",
                            TenLoai = "Chăm sóc da"
                        },
                        new
                        {
                            MaLoai = "Chăm sóc nhà",
                            TenLoai = "Chăm sóc nhà"
                        },
                        new
                        {
                            MaLoai = "Combo tiết kiệm",
                            TenLoai = "Combo tiết kiệm"
                        },
                        new
                        {
                            MaLoai = "Củ",
                            TenLoai = "Củ"
                        },
                        new
                        {
                            MaLoai = "Đồ khô",
                            TenLoai = "Đồ khô"
                        },
                        new
                        {
                            MaLoai = "Gia vị",
                            TenLoai = "Gia vị"
                        },
                        new
                        {
                            MaLoai = "Giỏ quà",
                            TenLoai = "Giỏ quà"
                        },
                        new
                        {
                            MaLoai = "Hải sản",
                            TenLoai = "Hải sản"
                        },
                        new
                        {
                            MaLoai = "Rau",
                            TenLoai = "Rau"
                        },
                        new
                        {
                            MaLoai = "Thịt",
                            TenLoai = "Thịt"
                        },
                        new
                        {
                            MaLoai = "Trái cây",
                            TenLoai = "Trái cây"
                        });
                });

            modelBuilder.Entity("eCom.Models.MauSacSanPham", b =>
                {
                    b.Property<string>("MaMauSac")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenMauSac")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaMauSac");

                    b.ToTable("MauSacSanPhams");
                });

            modelBuilder.Entity("eCom.Models.NhanVien", b =>
                {
                    b.Property<string>("MaNhanVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChucVu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNhanVien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsernameNavigationUsername")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MaNhanVien");

                    b.HasIndex("UsernameNavigationUsername");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("eCom.Models.SanPham", b =>
                {
                    b.Property<string>("MaSp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AnhSp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("GiaSp")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MaLoai")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenSp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSp");

                    b.HasIndex("MaLoai");

                    b.ToTable("SanPhams");

                    b.HasData(
                        new
                        {
                            MaSp = "Khoai lang mỡ 300gr",
                            AnhSp = "1.jpg",
                            GiaSp = 24000m,
                            MaLoai = "Củ",
                            TenSp = "Khoai lang mỡ 300gr"
                        },
                        new
                        {
                            MaSp = "Rau cần tây Organic 300gr",
                            GiaSp = 40000m,
                            MaLoai = "Rau",
                            TenSp = "Rau cần tây Organic 300gr"
                        },
                        new
                        {
                            MaSp = "Đầu rồng An Mộc 300gr",
                            AnhSp = "19.jpg",
                            GiaSp = 60000m,
                            MaLoai = "Thịt",
                            TenSp = "Đầu rồng An Mộc 300gr"
                        },
                        new
                        {
                            MaSp = "Ớt chuông đỏ Organic 300gr",
                            AnhSp = "3.jpg",
                            GiaSp = 28000m,
                            MaLoai = "Rau",
                            TenSp = "Ớt chuông đỏ Organic 300gr"
                        },
                        new
                        {
                            MaSp = "Bột gừng Dace hữu cơ 40g",
                            AnhSp = "25.jpg",
                            GiaSp = 100000m,
                            MaLoai = "Gia vị",
                            TenSp = "Bột gừng Dace hữu cơ 40g"
                        },
                        new
                        {
                            MaSp = "Xà lách mỡ Organic 300gr",
                            AnhSp = "2.jpg",
                            GiaSp = 30000m,
                            MaLoai = "Rau",
                            TenSp = "Xà lách mỡ Organic 300gr"
                        },
                        new
                        {
                            MaSp = "Tôm thẻ con Tôm Rừng 400gr",
                            AnhSp = "22.jpg",
                            GiaSp = 150000m,
                            MaLoai = "Hải sản",
                            TenSp = "Tôm thẻ con Tôm Rừng 400gr"
                        },
                        new
                        {
                            MaSp = "Cua nâu Ireland - Sống",
                            AnhSp = "24.jpg",
                            GiaSp = 1600000m,
                            MaLoai = "Hải sản",
                            TenSp = "Cua nâu Ireland - Sống"
                        },
                        new
                        {
                            MaSp = "Hộp quà trái cây",
                            AnhSp = "21.jpg",
                            GiaSp = 600000m,
                            MaLoai = "Trái Cây",
                            TenSp = "Hộp quà trái cây"
                        },
                        new
                        {
                            MaSp = "Phi lê cá hồi Organic 200gr",
                            AnhSp = "23.jpg",
                            GiaSp = 300000m,
                            MaLoai = "Cá",
                            TenSp = "Phi lê cá hồi Organic 200gr"
                        },
                        new
                        {
                            MaSp = "Móng giò An Mộc 300gr",
                            AnhSp = "20.jpg",
                            GiaSp = 80000m,
                            MaLoai = "Thịt",
                            TenSp = "Móng giò An Mộc 300gr"
                        });
                });

            modelBuilder.Entity("eCom.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte?>("LoaiUser")
                        .HasColumnType("tinyint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Username = "admin",
                            Password = "111111"
                        });
                });

            modelBuilder.Entity("eCom.Models.AnhChiTietSanPham", b =>
                {
                    b.HasOne("eCom.Models.ChiTietSanPham", "MaChiTietSpNavigation")
                        .WithMany("AnhChiTietSanPhams")
                        .HasForeignKey("MaChiTietSpNavigationMaChiTietSp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaChiTietSpNavigation");
                });

            modelBuilder.Entity("eCom.Models.AnhSanPham", b =>
                {
                    b.HasOne("eCom.Models.SanPham", "MaSpNavigation")
                        .WithMany("AnhSanPhams")
                        .HasForeignKey("MaSpNavigationMaSp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaSpNavigation");
                });

            modelBuilder.Entity("eCom.Models.ChiTietSanPham", b =>
                {
                    b.HasOne("eCom.Models.KichThuocSanPham", "MaKichThuocNavigation")
                        .WithMany("ChiTietSanPhams")
                        .HasForeignKey("MaKichThuocNavigationMaKichThuoc");

                    b.HasOne("eCom.Models.MauSacSanPham", "MaMauSacNavigation")
                        .WithMany("ChiTietSanPhams")
                        .HasForeignKey("MaMauSacNavigationMaMauSac");

                    b.HasOne("eCom.Models.SanPham", "MaSpNavigation")
                        .WithMany("ChiTietSanPhams")
                        .HasForeignKey("MaSpNavigationMaSp");

                    b.Navigation("MaKichThuocNavigation");

                    b.Navigation("MaMauSacNavigation");

                    b.Navigation("MaSpNavigation");
                });

            modelBuilder.Entity("eCom.Models.KhachHang", b =>
                {
                    b.HasOne("eCom.Models.User", "UsernameNavigation")
                        .WithMany("KhachHangs")
                        .HasForeignKey("UsernameNavigationUsername");

                    b.Navigation("UsernameNavigation");
                });

            modelBuilder.Entity("eCom.Models.NhanVien", b =>
                {
                    b.HasOne("eCom.Models.User", "UsernameNavigation")
                        .WithMany("NhanViens")
                        .HasForeignKey("UsernameNavigationUsername");

                    b.Navigation("UsernameNavigation");
                });

            modelBuilder.Entity("eCom.Models.SanPham", b =>
                {
                    b.HasOne("eCom.Models.LoaiSanPham", "LoaiSanPham")
                        .WithMany("SanPhams")
                        .HasForeignKey("MaLoai");

                    b.Navigation("LoaiSanPham");
                });

            modelBuilder.Entity("eCom.Models.ChiTietSanPham", b =>
                {
                    b.Navigation("AnhChiTietSanPhams");
                });

            modelBuilder.Entity("eCom.Models.KichThuocSanPham", b =>
                {
                    b.Navigation("ChiTietSanPhams");
                });

            modelBuilder.Entity("eCom.Models.LoaiSanPham", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("eCom.Models.MauSacSanPham", b =>
                {
                    b.Navigation("ChiTietSanPhams");
                });

            modelBuilder.Entity("eCom.Models.SanPham", b =>
                {
                    b.Navigation("AnhSanPhams");

                    b.Navigation("ChiTietSanPhams");
                });

            modelBuilder.Entity("eCom.Models.User", b =>
                {
                    b.Navigation("KhachHangs");

                    b.Navigation("NhanViens");
                });
#pragma warning restore 612, 618
        }
    }
}
