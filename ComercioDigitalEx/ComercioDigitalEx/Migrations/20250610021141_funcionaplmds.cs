using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComercioDigitalEx.Migrations
{
    /// <inheritdoc />
    public partial class funcionaplmds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryDisplayOrder", "CategoryName" },
                values: new object[] { 20, 20, "test" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 20);
        }
    }
}
