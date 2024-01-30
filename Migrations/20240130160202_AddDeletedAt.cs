using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace suggestionbox.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_At",
                table: "Suggestion",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted_At",
                table: "Suggestion");
        }
    }
}
