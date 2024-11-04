using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCom.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KichThuocSanPhams",
                columns: table => new
                {
                    MaKichThuoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKichThuoc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KichThuocSanPhams", x => x.MaKichThuoc);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPhams",
                columns: table => new
                {
                    MaLoai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPhams", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "MauSacSanPhams",
                columns: table => new
                {
                    MaMauSac = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenMauSac = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSacSanPhams", x => x.MaMauSac);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiUser = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    MaSp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenSp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaLoai = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AnhSp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaSp = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.MaSp);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiSanPhams_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "LoaiSanPhams",
                        principalColumn: "MaLoai");
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKhanhHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiKhachHang = table.Column<byte>(type: "tinyint", nullable: true),
                    UsernameNavigationUsername = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKhanhHang);
                    table.ForeignKey(
                        name: "FK_KhachHangs_User_UsernameNavigationUsername",
                        column: x => x.UsernameNavigationUsername,
                        principalTable: "User",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsernameNavigationUsername = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanViens_User_UsernameNavigationUsername",
                        column: x => x.UsernameNavigationUsername,
                        principalTable: "User",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "AnhSanPhams",
                columns: table => new
                {
                    MaSp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenFileAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSpNavigationMaSp = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnhSanPhams", x => x.MaSp);
                    table.ForeignKey(
                        name: "FK_AnhSanPhams_SanPhams_MaSpNavigationMaSp",
                        column: x => x.MaSpNavigationMaSp,
                        principalTable: "SanPhams",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSanPhams",
                columns: table => new
                {
                    MaChiTietSp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaKichThuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaMauSac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonGia = table.Column<double>(type: "float", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    MaSpNavigationMaSp = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaKichThuocNavigationMaKichThuoc = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaMauSacNavigationMaMauSac = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSanPhams", x => x.MaChiTietSp);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_KichThuocSanPhams_MaKichThuocNavigationMaKichThuoc",
                        column: x => x.MaKichThuocNavigationMaKichThuoc,
                        principalTable: "KichThuocSanPhams",
                        principalColumn: "MaKichThuoc");
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_MauSacSanPhams_MaMauSacNavigationMaMauSac",
                        column: x => x.MaMauSacNavigationMaMauSac,
                        principalTable: "MauSacSanPhams",
                        principalColumn: "MaMauSac");
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_SanPhams_MaSpNavigationMaSp",
                        column: x => x.MaSpNavigationMaSp,
                        principalTable: "SanPhams",
                        principalColumn: "MaSp");
                });

            migrationBuilder.CreateTable(
                name: "AnhChiTietSanPhams",
                columns: table => new
                {
                    MaChiTietSp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenFileAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaChiTietSpNavigationMaChiTietSp = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnhChiTietSanPhams", x => x.MaChiTietSp);
                    table.ForeignKey(
                        name: "FK_AnhChiTietSanPhams_ChiTietSanPhams_MaChiTietSpNavigationMaChiTietSp",
                        column: x => x.MaChiTietSpNavigationMaChiTietSp,
                        principalTable: "ChiTietSanPhams",
                        principalColumn: "MaChiTietSp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnhChiTietSanPhams_MaChiTietSpNavigationMaChiTietSp",
                table: "AnhChiTietSanPhams",
                column: "MaChiTietSpNavigationMaChiTietSp");

            migrationBuilder.CreateIndex(
                name: "IX_AnhSanPhams_MaSpNavigationMaSp",
                table: "AnhSanPhams",
                column: "MaSpNavigationMaSp");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_MaKichThuocNavigationMaKichThuoc",
                table: "ChiTietSanPhams",
                column: "MaKichThuocNavigationMaKichThuoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_MaMauSacNavigationMaMauSac",
                table: "ChiTietSanPhams",
                column: "MaMauSacNavigationMaMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_MaSpNavigationMaSp",
                table: "ChiTietSanPhams",
                column: "MaSpNavigationMaSp");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangs_UsernameNavigationUsername",
                table: "KhachHangs",
                column: "UsernameNavigationUsername");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_UsernameNavigationUsername",
                table: "NhanViens",
                column: "UsernameNavigationUsername");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_MaLoai",
                table: "SanPhams",
                column: "MaLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnhChiTietSanPhams");

            migrationBuilder.DropTable(
                name: "AnhSanPhams");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "ChiTietSanPhams");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "KichThuocSanPhams");

            migrationBuilder.DropTable(
                name: "MauSacSanPhams");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "LoaiSanPhams");
        }
    }
}
