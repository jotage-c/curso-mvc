using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursosSis.Migrations
{
    /// <inheritdoc />
    public partial class EssencialTuda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoursePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CourseType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorWorkPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.ProfessorId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentRegNum = table.Column<int>(type: "int", nullable: false),
                    StudentTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Classes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseCode", "CourseName", "CoursePrice", "CourseType" },
                values: new object[] { 1, "CS-I", "C# - Iniciante", 500m, "EAD" });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "ProfessorId", "ProfessorEmail", "ProfessorName", "ProfessorTel", "ProfessorWorkPeriod" },
                values: new object[] { 1, "prof.juanpablo@gmail.com", "Juan Pablo", "21 09876-5432", "Noite" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "StudentDateOfBirth", "StudentEmail", "StudentName", "StudentRegNum", "StudentTel" },
                values: new object[] { 1, new DateTime(2008, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "maninhodoisdois25@gmail.com", "João Gabriel", 1, "21 09876-5432" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "CourseId", "ProfessorId", "StudentId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CourseId",
                table: "Classes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ProfessorId",
                table: "Classes",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_StudentId",
                table: "Classes",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
