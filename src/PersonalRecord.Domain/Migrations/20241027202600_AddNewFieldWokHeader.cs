using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalRecord.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldWokHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WokHeader",
                table: "WorkoutItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WokHeader",
                table: "WorkoutItems");
        }
    }
}
