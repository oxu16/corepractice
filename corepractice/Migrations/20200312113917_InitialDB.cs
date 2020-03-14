using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace corepractice.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    Firstname = table.Column<string>(maxLength: 100, nullable: false),
                    Lastname = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(maxLength: 50, nullable: true),
                    GroupIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "GroupId", "Description", "GroupName" },
                values: new object[,]
                {
                    { 1, "HR Department", "HR" },
                    { 4, "IT Department", "IT" },
                    { 6, "Marketing Department", "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "DateOfBirth", "Email", "Firstname", "GroupIndex", "Lastname", "Mobile", "Password", "Phone", "Username" },
                values: new object[,]
                {
                    { 2, new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test@gmail.com", "partho33332", 1, "paul1112452", "04565465464112312", "test123123123", "256356523", "rwete" },
                    { 3, new DateTime(2200, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test", "test", 1, "test", "56", "sg", "655", "gs" },
                    { 4, new DateTime(2200, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fgdg", "dfgdg", 1, "dgdg", "dfgdg", "dfgd", "dgf", "gs" },
                    { 9, new DateTime(1986, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "aud@gmail.com", "Andrew", 1, "Freeman", "13838383838", "pswd2020", "08268485", "skyfat" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
