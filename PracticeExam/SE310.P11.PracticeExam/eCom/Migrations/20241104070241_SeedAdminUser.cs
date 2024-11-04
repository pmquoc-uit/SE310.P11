using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCom.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Username", "LoaiUser", "Password" },
                values: new object[] { "admin", null, "111111" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Username",
                keyValue: "admin");
        }
    }
}
