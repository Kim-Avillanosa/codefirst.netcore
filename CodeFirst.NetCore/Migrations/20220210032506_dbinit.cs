using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirst.NetCore.Migrations
{
    public partial class dbinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserGroupId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Phone = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Website = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserGroups",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Suite = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Coordinates = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Address",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Administrator" });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Standard" });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Guest" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone", "UserGroupId", "UserName", "Website" },
                values: new object[] { 1, "kmavillanosa@gmail.com", "Kim", "Avillanosa", "09452873791", 1, "kmavillanosa", "google.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone", "UserGroupId", "UserName", "Website" },
                values: new object[] { 2, "mperalta@gmail.com", "Mark", "Peralta", "09452873791", 2, "mperalta", "google.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone", "UserGroupId", "UserName", "Website" },
                values: new object[] { 3, "erobles@gmail.com", "Elmer", "Robles", "09452873791", 3, "erobles", "google.com" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Coordinates", "Street", "Suite", "UserId", "ZipCode" },
                values: new object[] { 1, "PPC", "{\"Longitude\":\"-7.77832031\",\"Latitude\":\"53.2734\"}", "Manalo Extension", "258-A", 1, "5300" });

            migrationBuilder.CreateIndex(
                name: "Idx_ZipCode",
                table: "Address",
                column: "ZipCode");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_Name",
                table: "UserGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_FirstName",
                table: "Users",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "Idx_LastName",
                table: "Users",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGroupId",
                table: "Users",
                column: "UserGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserGroups");
        }
    }
}
