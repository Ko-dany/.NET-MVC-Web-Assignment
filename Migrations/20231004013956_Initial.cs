using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_1_Dahyun_Ko.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    ProgramId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ProgramId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GPA = table.Column<double>(type: "float", nullable: false),
                    GPAScale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramId", "Name" },
                values: new object[,]
                {
                    { "BACS", "Bachelor of Applied Computer Science" },
                    { "CP", "Computer Programming" },
                    { "CPA", "Computer Programming and Analysis" },
                    { "ITID", "IT Innovation and Design" },
                    { "SET", "Software Engineering Technology" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DateOfBirth", "FirstName", "GPA", "GPAScale", "LastName", "ProgramId" },
                values: new object[] { 1, new DateTime(1971, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bart", 2.7000000000000002, "Satisfactory", "Simpson", "CP" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DateOfBirth", "FirstName", "GPA", "GPAScale", "LastName", "ProgramId" },
                values: new object[] { 2, new DateTime(1973, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa", 4.0, "Excellence", "Simpson", "BACS" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DateOfBirth", "FirstName", "GPA", "GPAScale", "LastName", "ProgramId" },
                values: new object[] { 3, new DateTime(1996, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maggie", 3.1000000000000001, "Good", "Simpson", "CPA" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgramId",
                table: "Students",
                column: "ProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Programs");
        }
    }
}
