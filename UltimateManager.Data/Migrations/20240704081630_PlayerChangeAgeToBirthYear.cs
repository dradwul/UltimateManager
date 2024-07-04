using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltimateManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlayerChangeAgeToBirthYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Players",
                newName: "BirthYear");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthYear",
                table: "Players",
                newName: "Age");
        }
    }
}
