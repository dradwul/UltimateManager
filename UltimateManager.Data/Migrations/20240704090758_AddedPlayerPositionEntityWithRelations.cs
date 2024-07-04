using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UltimateManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPlayerPositionEntityWithRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerPositionId",
                table: "Players",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlayerPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PositionType = table.Column<string>(type: "text", nullable: true),
                    PositionSpecified = table.Column<string>(type: "text", nullable: true),
                    PositionAlternative = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPosition", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerPosition_PlayerPositionId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PlayerPosition");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerPositionId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerPositionId",
                table: "Players");
        }
    }
}
