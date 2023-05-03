using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GundamEvolutionDatabase.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DamagePerSecond",
                table: "Weapons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DamagePerSecond",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Units");
        }
    }
}
