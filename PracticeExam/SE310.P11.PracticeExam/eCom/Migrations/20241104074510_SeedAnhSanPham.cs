using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCom.Migrations
{
    /// <inheritdoc />
    public partial class SeedAnhSanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Bột gừng Dace hữu cơ 40g",
                column: "AnhSp",
                value: "25.jpg");

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Cua nâu Ireland - Sống",
                column: "AnhSp",
                value: "24.jpg");

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Đầu rồng An Mộc 300gr",
                column: "AnhSp",
                value: "19.jpg");

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Hộp quà trái cây",
                column: "AnhSp",
                value: "21.jpg");

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Khoai lang mỡ 300gr",
                column: "AnhSp",
                value: "1.jpg");

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Móng giò An Mộc 300gr",
                column: "AnhSp",
                value: "20.jpg");

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Ớt chuông đỏ Organic 300gr",
                column: "AnhSp",
                value: "3.jpg");

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Phi lê cá hồi Organic 200gr",
                column: "AnhSp",
                value: "23.jpg");

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Tôm thẻ con Tôm Rừng 400gr",
                column: "AnhSp",
                value: "22.jpg");

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Xà lách mỡ Organic 300gr",
                column: "AnhSp",
                value: "2.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Bột gừng Dace hữu cơ 40g",
                column: "AnhSp",
                value: null);

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Cua nâu Ireland - Sống",
                column: "AnhSp",
                value: null);

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Đầu rồng An Mộc 300gr",
                column: "AnhSp",
                value: null);

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Hộp quà trái cây",
                column: "AnhSp",
                value: null);

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Khoai lang mỡ 300gr",
                column: "AnhSp",
                value: null);

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Móng giò An Mộc 300gr",
                column: "AnhSp",
                value: null);

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Ớt chuông đỏ Organic 300gr",
                column: "AnhSp",
                value: null);

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Phi lê cá hồi Organic 200gr",
                column: "AnhSp",
                value: null);

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Tôm thẻ con Tôm Rừng 400gr",
                column: "AnhSp",
                value: null);

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "Xà lách mỡ Organic 300gr",
                column: "AnhSp",
                value: null);
        }
    }
}
