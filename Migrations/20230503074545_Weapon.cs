using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GundamEvolutionDatabase.Migrations
{
    public partial class Weapon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Units_UnitID",
                table: "Weapons");

            migrationBuilder.AlterColumn<int>(
                name: "UnitID",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Units_UnitID",
                table: "Weapons",
                column: "UnitID",
                principalTable: "Units",
                principalColumn: "UnitID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Units_UnitID",
                table: "Weapons");

            migrationBuilder.AlterColumn<int>(
                name: "UnitID",
                table: "Weapons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Units_UnitID",
                table: "Weapons",
                column: "UnitID",
                principalTable: "Units",
                principalColumn: "UnitID");
        }
    }
}
