using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LifeBalance.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title1 = table.Column<string>(nullable: false),
                    Title2 = table.Column<string>(nullable: false),
                    Title3 = table.Column<string>(nullable: false),
                    Title4 = table.Column<string>(nullable: false),
                    Title5 = table.Column<string>(nullable: false),
                    Title6 = table.Column<string>(nullable: false),
                    Title7 = table.Column<string>(nullable: false),
                    Title8 = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    DateOfValue = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CoordinatorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Values_users_CoordinatorID",
                        column: x => x.CoordinatorID,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Values_CoordinatorID",
                table: "Values",
                column: "CoordinatorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
