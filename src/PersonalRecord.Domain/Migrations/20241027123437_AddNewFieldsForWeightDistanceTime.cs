using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalRecord.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsForWeightDistanceTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "WteExerciseDistance",
                table: "WorkoutToExerciseItems",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "WteExerciseTime",
                table: "WorkoutToExerciseItems",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<float>(
                name: "WteExerciseWeight",
                table: "WorkoutToExerciseItems",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WteExerciseDistance",
                table: "WorkoutToExerciseItems");

            migrationBuilder.DropColumn(
                name: "WteExerciseTime",
                table: "WorkoutToExerciseItems");

            migrationBuilder.DropColumn(
                name: "WteExerciseWeight",
                table: "WorkoutToExerciseItems");
        }
    }
}
