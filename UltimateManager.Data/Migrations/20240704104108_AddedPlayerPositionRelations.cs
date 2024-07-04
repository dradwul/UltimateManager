using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltimateManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPlayerPositionRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerPosition_PlayerPositionId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerPositionId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerPosition",
                table: "PlayerPosition");

            migrationBuilder.DropColumn(
                name: "PositionAlternative",
                table: "PlayerPosition");

            migrationBuilder.RenameTable(
                name: "PlayerPosition",
                newName: "PlayerPositions");

            migrationBuilder.AlterColumn<string>(
                name: "PositionType",
                table: "PlayerPositions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PositionSpecified",
                table: "PlayerPositions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerPositions",
                table: "PlayerPositions",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerPositions_PlayerPositionId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PlayerPositionsRelations");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerPositionId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerPositions",
                table: "PlayerPositions");

            migrationBuilder.RenameTable(
                name: "PlayerPositions",
                newName: "PlayerPosition");

            migrationBuilder.AlterColumn<string>(
                name: "PositionType",
                table: "PlayerPosition",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PositionSpecified",
                table: "PlayerPosition",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "PositionAlternative",
                table: "PlayerPosition",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerPosition",
                table: "PlayerPosition",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerPositionId",
                table: "Players",
                column: "PlayerPositionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerPosition_PlayerPositionId",
                table: "Players",
                column: "PlayerPositionId",
                principalTable: "PlayerPosition",
                principalColumn: "Id");
        }
    }
}
