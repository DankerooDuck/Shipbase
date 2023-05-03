using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GundamEvolutionDatabase.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeasonID",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameModes",
                columns: table => new
                {
                    GameModeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameModes", x => x.GameModeID);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    SeasonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonID);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    MapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeasonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.MapID);
                    table.ForeignKey(
                        name: "FK_Maps_Seasons_SeasonID",
                        column: x => x.SeasonID,
                        principalTable: "Seasons",
                        principalColumn: "SeasonID");
                });

            migrationBuilder.CreateTable(
                name: "GameModeMap",
                columns: table => new
                {
                    GameModesGameModeID = table.Column<int>(type: "int", nullable: false),
                    MapsMapID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameModeMap", x => new { x.GameModesGameModeID, x.MapsMapID });
                    table.ForeignKey(
                        name: "FK_GameModeMap_GameModes_GameModesGameModeID",
                        column: x => x.GameModesGameModeID,
                        principalTable: "GameModes",
                        principalColumn: "GameModeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameModeMap_Maps_MapsMapID",
                        column: x => x.MapsMapID,
                        principalTable: "Maps",
                        principalColumn: "MapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_SeasonID",
                table: "Units",
                column: "SeasonID");

            migrationBuilder.CreateIndex(
                name: "IX_GameModeMap_MapsMapID",
                table: "GameModeMap",
                column: "MapsMapID");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_SeasonID",
                table: "Maps",
                column: "SeasonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Seasons_SeasonID",
                table: "Units",
                column: "SeasonID",
                principalTable: "Seasons",
                principalColumn: "SeasonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Seasons_SeasonID",
                table: "Units");

            migrationBuilder.DropTable(
                name: "GameModeMap");

            migrationBuilder.DropTable(
                name: "GameModes");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Units_SeasonID",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "SeasonID",
                table: "Units");
        }
    }
}
