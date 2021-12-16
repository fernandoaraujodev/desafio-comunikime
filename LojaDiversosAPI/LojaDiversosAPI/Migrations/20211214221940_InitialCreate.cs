using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaDiversosAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "Text", maxLength: 1024, nullable: false),
                    UrlImage = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()"),
                    ChangeDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
