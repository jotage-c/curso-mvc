using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExercicioManipulacaoDb.Migrations
{
    /// <inheritdoc />
    public partial class SeedGameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "LaunchingYear", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "2022", "NieR: Replicant", 249.90000000000001 },
                    { 2, "2025", "The Elder Scrolls IV: Oblivion Remastered", 264.89999999999998 },
                    { 3, "2021", "Elden Ring", 274.5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
