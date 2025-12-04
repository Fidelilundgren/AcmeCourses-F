using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AcmeCourses.Migrations
{
    /// <inheritdoc />
    public partial class Initialfirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "En kombination utav teknik och programmering.", "Backendutvecklare" },
                    { 2, "En kombination utav användarvänliga och visuella webbplatser.", "Frontendutvecklare" },
                    { 3, "För framtidens dynamiska kommunikationslandskap.", "Digital kommunikatör" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "Description", "EducationId", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, "Programmering C#.NET", "Grundkurs C#.", 1, new DateOnly(2025, 10, 15), new DateOnly(2025, 8, 25) },
                    { 2, "SQL", "Databas och Databasdesign", 1, new DateOnly(2025, 10, 15), new DateOnly(2025, 10, 20) },
                    { 3, "UX", "Grafisk Design", 2, new DateOnly(2026, 10, 15), new DateOnly(2026, 8, 20) },
                    { 4, "AI/ChatGPT", "AI för programmerare", 2, new DateOnly(2026, 12, 11), new DateOnly(2026, 10, 22) },
                    { 5, "Analys och Rapport", "Analysera marknadsdata", 3, new DateOnly(2026, 12, 13), new DateOnly(2026, 10, 20) },
                    { 6, "LIA", "Praktik", 3, new DateOnly(2027, 1, 11), new DateOnly(2026, 12, 15) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "EducationId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "Fideli", "Lundgren" },
                    { 2, 2, "Niklas", "Kääpä" },
                    { 3, 3, "Joakim", "Christiansson" },
                    { 4, 2, "Ruhollah", "Karim" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_EducationId",
                table: "Courses",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_EducationId",
                table: "Students",
                column: "EducationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Educations");
        }
    }
}
