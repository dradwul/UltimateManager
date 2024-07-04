using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UltimateManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRelationEntityAndReplaceWithSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerPositions_PlayerPositionId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PlayerPositionsRelations");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerPositionId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerPositionId",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "PlayerPlayerPosition",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    PlayerPositionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPlayerPosition", x => new { x.PlayerId, x.PlayerPositionId });
                    table.ForeignKey(
                        name: "FK_PlayerPlayerPosition_PlayerPositions_PlayerPositionId",
                        column: x => x.PlayerPositionId,
                        principalTable: "PlayerPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerPlayerPosition_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PlayerPositions",
                columns: new[] { "Id", "PositionSpecified", "PositionType" },
                values: new object[,]
                {
                    { 1, "Goal Keeper", "Goalkeeper" },
                    { 2, "Center Back", "Defender" },
                    { 3, "Right Back", "Defender" },
                    { 4, "Left Back", "Defender" },
                    { 5, "Central Midfielder", "Midfielder" },
                    { 6, "Central Defending Midfielder", "Midfielder" },
                    { 7, "Central Attacking Midfielder", "Midfielder" },
                    { 8, "Right Midfielder", "Midfielder" },
                    { 9, "Left Midfielder", "Midfielder" },
                    { 10, "Striker", "Forward" },
                    { 11, "Right Winger", "Forward" },
                    { 12, "Left Winger", "Forward" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPlayerPosition_PlayerPositionId",
                table: "PlayerPlayerPosition",
                column: "PlayerPositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerPlayerPosition");

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.AddColumn<int>(
                name: "PlayerPositionId",
                table: "Players",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlayerPositionsRelations",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    PlayerPositionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPositionsRelations", x => new { x.PlayerId, x.PlayerPositionId });
                    table.ForeignKey(
                        name: "FK_PlayerPositionsRelations_PlayerPositions_PlayerPositionId",
                        column: x => x.PlayerPositionId,
                        principalTable: "PlayerPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerPositionsRelations_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerPositionId",
                table: "Players",
                column: "PlayerPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPositionsRelations_PlayerPositionId",
                table: "PlayerPositionsRelations",
                column: "PlayerPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerPositions_PlayerPositionId",
                table: "Players",
                column: "PlayerPositionId",
                principalTable: "PlayerPositions",
                principalColumn: "Id");
        }
    }
}
