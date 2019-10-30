using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSite.Migrations
{
    public partial class v05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentDomains",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DocumentName = table.Column<string>(nullable: true),
                    DocumentCaption = table.Column<string>(nullable: true),
                    DocumentCreateTime = table.Column<DateTime>(nullable: false),
                    DocumentLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDomains", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentDomains");
        }
    }
}
