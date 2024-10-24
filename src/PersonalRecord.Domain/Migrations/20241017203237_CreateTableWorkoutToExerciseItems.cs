using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalRecord.Domain.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableWorkoutToExerciseItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkoutToExerciseItems",
                columns: table => new
                {
                    WorkoutToExerciseID = table.Column<Guid>(type: "TEXT", nullable: false),
                    WteWorkoutID_FK = table.Column<Guid>(type: "TEXT", nullable: false),
                    WteExerciseID_FK = table.Column<Guid>(type: "TEXT", nullable: false),
                    WteExerciseRepCount = table.Column<float>(type: "REAL", nullable: false),
                    WteExerciseRepUnit = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutToExerciseItems", x => x.WorkoutToExerciseID);
                    table.ForeignKey(
                        name: "FK_WorkoutToExerciseItems_ExerciseItems_WteExerciseID_FK",
                        column: x => x.WteExerciseID_FK,
                        principalTable: "ExerciseItems",
                        principalColumn: "ExerciseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutToExerciseItems_WorkoutItems_WteWorkoutID_FK",
                        column: x => x.WteWorkoutID_FK,
                        principalTable: "WorkoutItems",
                        principalColumn: "WorkoutID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutToExerciseItems_WteExerciseID_FK",
                table: "WorkoutToExerciseItems",
                column: "WteExerciseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutToExerciseItems_WteWorkoutID_FK",
                table: "WorkoutToExerciseItems",
                column: "WteWorkoutID_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutToExerciseItems");
        }
    }
}
