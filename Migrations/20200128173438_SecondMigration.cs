using Microsoft.EntityFrameworkCore.Migrations;

namespace LifeBalance.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Values");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Values",
                nullable: false,
                defaultValue: "");
        }
    }
}
