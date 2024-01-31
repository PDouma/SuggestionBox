using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace suggestionbox.Migrations
{
    /// <inheritdoc />
    public partial class AddDateRangeRequirementSuggestionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "require_daterange",
                table: "SuggestionType",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "require_daterange",
                table: "SuggestionType");
        }
    }
}
