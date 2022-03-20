using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", nullable: true),
                    HireDate = table.Column<DateTime>(type: "date", nullable: true),
                    LeaveDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "FirstName", "HireDate", "LastName", "LeaveDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Fuat", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aydın", null, "Yazılım geliştirici" },
                    { 2, 1, "Murat", new DateTime(2015, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Odabaş", null, "Yazılım geliştirici" },
                    { 3, 1, "Berna", new DateTime(2014, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Demir", new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım geliştirici" },
                    { 4, 2, "Ali", new DateTime(2014, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turan", null, "İş Analisti" },
                    { 5, 2, "Berker", new DateTime(2014, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aksoy", new DateTime(2015, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "İş analisti" },
                    { 6, 3, "Ayşe", new DateTime(2018, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yıldırım", null, "Grafik tasarımcı" },
                    { 7, 4, "Seda", new DateTime(2010, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kaya", null, " Proje Yöneticisi" },
                    { 8, 4, "Batuhan", new DateTime(2011, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aydın", null, " Ar-ge yöneticisi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
