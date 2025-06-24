using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocacaoVeiculos.Migrations
{
    /// <inheritdoc />
    public partial class errorfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Clients_ClientIdRented",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "ClientIdRented",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Clients_ClientIdRented",
                table: "Vehicles",
                column: "ClientIdRented",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Clients_ClientIdRented",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "ClientIdRented",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Clients_ClientIdRented",
                table: "Vehicles",
                column: "ClientIdRented",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
