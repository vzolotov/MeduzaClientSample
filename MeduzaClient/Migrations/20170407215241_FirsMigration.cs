using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeduzaClient.Migrations
{
    public partial class FirsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    document_type = table.Column<string>(nullable: true),
                    full = table.Column<bool>(nullable: false),
                    modified_at = table.Column<int>(nullable: false),
                    pub_date = table.Column<string>(nullable: true),
                    published_at = table.Column<int>(nullable: false),
                    url = table.Column<string>(nullable: true),
                    version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentEntity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentEntity");
        }
    }
}
