using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace suggestionbox.Migrations
{
    /// <inheritdoc />
    public partial class UseSuggestionTypeForSuggestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "suggestionTypeId",
                table: "Suggestion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SuggestionType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuggestionType", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suggestion_suggestionTypeId",
                table: "Suggestion",
                column: "suggestionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suggestion_SuggestionType_suggestionTypeId",
                table: "Suggestion",
                column: "suggestionTypeId",
                principalTable: "SuggestionType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suggestion_SuggestionType_suggestionTypeId",
                table: "Suggestion");

            migrationBuilder.DropTable(
                name: "SuggestionType");

            migrationBuilder.DropIndex(
                name: "IX_Suggestion_suggestionTypeId",
                table: "Suggestion");

            migrationBuilder.DropColumn(
                name: "suggestionTypeId",
                table: "Suggestion");
        }
    }
}
