using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCom.Migrations
{
    /// <inheritdoc />
    public partial class SeedSanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "MaSp", "AnhSp", "GiaSp", "MaLoai", "TenSp" },
                values: new object[,]
                {
                    { "Bột gừng Dace hữu cơ 40g", null, 100000m, "Gia vị", "Bột gừng Dace hữu cơ 40g" },
                    { "Cua nâu Ireland - Sống", null, 1600000m, "Hải sản", "Cua nâu Ireland - Sống" },
                    { "Đầu rồng An Mộc 300gr", null, 60000m, "Thịt", "Đầu rồng An Mộc 300gr" },
                    { "Hộp quà trái cây", null, 600000m, "Trái Cây", "Hộp quà trái cây" },
                    { "Khoai lang mỡ 300gr", null, 24000m, "Củ", "Khoai lang mỡ 300gr" },
                    { "Móng giò An Mộc 300gr", null, 80000m, "Thịt", "Móng giò An Mộc 300gr" },
                    { "Ớt chuông đỏ Organic 300gr", null, 28000m, "Rau", "Ớt chuông đỏ Organic 300gr" },
                    { "Phi lê cá hồi Organic 200gr", null, 300000m, "Cá", "Phi lê cá hồi Organic 200gr" },
                    { "Rau cần tây Organic 300gr", null, 40000m, "Rau", "Rau cần tây Organic 300gr" },
                    { "Tôm thẻ con Tôm Rừng 400gr", null, 150000m, "Hải sản", "Tôm thẻ con Tôm Rừng 400gr" },
                    { "Xà lách mỡ Organic 300gr", null, 30000m, "Rau", "Xà lách mỡ Organic 300gr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Bột gừng Dace hữu cơ 40g");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Cua nâu Ireland - Sống");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Đầu rồng An Mộc 300gr");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Hộp quà trái cây");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Khoai lang mỡ 300gr");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Móng giò An Mộc 300gr");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Ớt chuông đỏ Organic 300gr");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Phi lê cá hồi Organic 200gr");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Rau cần tây Organic 300gr");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Tôm thẻ con Tôm Rừng 400gr");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Xà lách mỡ Organic 300gr");
        }
    }
}
