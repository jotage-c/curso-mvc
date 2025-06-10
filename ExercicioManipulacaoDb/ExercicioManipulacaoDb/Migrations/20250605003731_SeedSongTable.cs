using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExercicioManipulacaoDb.Migrations
{
    /// <inheritdoc />
    public partial class SeedSongTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Author", "Genre", "Name" },
                values: new object[,]
                {
                    { 1, "Franz Liszt", "Classical", "Liebestraume no. 3" },
                    { 2, "Ella Fitzgerald", "Jazz", "Tea For Two" },
                    { 3, "Fat Family", "R&B", "Madrugada" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
