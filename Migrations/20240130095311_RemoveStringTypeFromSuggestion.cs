using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace suggestionbox.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStringTypeFromSuggestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "Suggestion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "Suggestion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
