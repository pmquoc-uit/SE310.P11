using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCom.Migrations
{
    /// <inheritdoc />
    public partial class SeedLoaiSp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LoaiSanPhams",
                columns: new[] { "MaLoai", "TenLoai" },
                values: new object[,]
                {
                    { "Cá", "Cá" },
                    { "Chăm sóc da", "Chăm sóc da" },
                    { "Chăm sóc nhà", "Chăm sóc nhà" },
                    { "Combo tiết kiệm", "Combo tiết kiệm" },
                    { "Củ", "Củ" },
                    { "Đồ khô", "Đồ khô" },
                    { "Gia vị", "Gia vị" },
                    { "Giỏ quà", "Giỏ quà" },
                    { "Hải sản", "Hải sản" },
                    { "Rau", "Rau" },
                    { "Thịt", "Thịt" },
                    { "Trái cây", "Trái cây" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoaiSanPhams",
                keyColumn: "MaLoai",
                keyValue: "Cá");

            migrationBuilder.DeleteData(
                table: "LoaiSanPhams",
                keyColumn: "MaLoai",
                keyValue: "Chăm sóc da");

            migrationBuilder.DeleteData(
                table: "LoaiSanPhams",
                keyColumn: "MaLoai",
                keyValue: "Chăm sóc nhà");

            migrationBuilder.DeleteData(
                table: "LoaiSanPhams",
                keyColumn: "MaLoai",
                keyValue: "Combo tiết kiệm");

            migrationBuilder.DeleteData(
                table: "LoaiSanPhams",
                keyColumn: "MaLoai",
                keyValue: "Củ");

            migrationBuilder.DeleteData(
                table: "LoaiSanPhams",
                keyColumn: "MaLoai",
                keyValue: "Đồ khô");

            migrationBuilder.DeleteData(
                table: "LoaiSanPhams",
                keyColumn: "MaLoai",
                keyValue: "Gia vị");

            migrationBuilder.DeleteData(
                table: "LoaiSanPhams",
                keyColumn: "MaLoai",
                keyValue: "Giỏ quà");

            migrationBuilder.DeleteData(
                table: "LoaiSanPhams",
                keyColumn: "MaLoai",
                keyValue: "Hải sản");

            migrationBuilder.DeleteData(
                table: "LoaiSanPhams",
                keyColumn: "MaLoai",
                keyValue: "Rau");

            migrationBuilder.DeleteData(
                table: "LoaiSanPhams",
                keyColumn: "MaLoai",
                keyValue: "Thịt");

            migrationBuilder.DeleteData(
                table: "LoaiSanPhams",
                keyColumn: "MaLoai",
                keyValue: "Trái cây");
        }
    }
}
