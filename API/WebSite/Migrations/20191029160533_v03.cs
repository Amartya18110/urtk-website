using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSite.Migrations
{
    public partial class v03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NewsCreateTime",
                table: "NewsDomain",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NewsImage",
                table: "NewsDomain",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsCreateTime",
                table: "NewsDomain");

            migrationBuilder.DropColumn(
                name: "NewsImage",
                table: "NewsDomain");
        }
    }
}
