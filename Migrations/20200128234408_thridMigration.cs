using Microsoft.EntityFrameworkCore.Migrations;

namespace LifeBalance.Migrations
{
    public partial class thridMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating1",
                table: "Values",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating2",
                table: "Values",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating3",
                table: "Values",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating4",
                table: "Values",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating5",
                table: "Values",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating6",
                table: "Values",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating7",
                table: "Values",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating8",
                table: "Values",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating1",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "Rating2",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "Rating3",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "Rating4",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "Rating5",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "Rating6",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "Rating7",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "Rating8",
                table: "Values");
        }
    }
}
