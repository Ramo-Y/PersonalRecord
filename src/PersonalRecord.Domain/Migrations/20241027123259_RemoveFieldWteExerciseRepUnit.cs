using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalRecord.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFieldWteExerciseRepUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WteExerciseRepUnit",
                table: "WorkoutToExerciseItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WteExerciseRepUnit",
                table: "WorkoutToExerciseItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
