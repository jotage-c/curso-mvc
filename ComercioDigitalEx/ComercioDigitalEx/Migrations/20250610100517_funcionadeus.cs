using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComercioDigitalEx.Migrations
{
    /// <inheritdoc />
    public partial class funcionadeus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 20);

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryDisplayOrder", "CategoryName" },
                values: new object[] { 20, 20, "test" });
        }
    }
}
