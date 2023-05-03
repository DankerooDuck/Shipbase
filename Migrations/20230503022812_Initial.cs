using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GundamEvolutionDatabase.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Difficulty = table.Column<int>(type: "int", nullable: true),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Health = table.Column<int>(type: "int", nullable: true),
                    DashLimit = table.Column<int>(type: "int", nullable: true),
                    Shield = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitID);
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    AbilityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbilityEffect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ultimate = table.Column<bool>(type: "bit", nullable: true),
                    AbilityAttributeName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbilityAttributeData1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbilityAttributeName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbilityAttributeData2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbilityAttributeName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbilityAttributeData3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.AbilityID);
                    table.ForeignKey(
                        name: "FK_Abilities_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "UnitID");
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    WeaponID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageHead = table.Column<int>(type: "int", nullable: true),
                    DamageBody = table.Column<int>(type: "int", nullable: true),
                    DamageLimb = table.Column<int>(type: "int", nullable: true),
                    MagazineSize = table.Column<int>(type: "int", nullable: true),
                    ReloadTimeStandard = table.Column<int>(type: "int", nullable: true),
                    ReloadTimeAlt = table.Column<int>(type: "int", nullable: true),
                    WeaponSwitchTime = table.Column<int>(type: "int", nullable: true),
                    FallOffDistance = table.Column<int>(type: "int", nullable: true),
                    AbilityAttributeName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbilityAttributeData1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbilityAttributeName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbilityAttributeData2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.WeaponID);
                    table.ForeignKey(
                        name: "FK_Weapons_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "UnitID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_UnitID",
                table: "Abilities",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_UnitID",
                table: "Weapons",
                column: "UnitID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
