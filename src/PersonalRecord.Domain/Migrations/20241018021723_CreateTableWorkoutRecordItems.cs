using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalRecord.Domain.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableWorkoutRecordItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkoutRecordItems",
                columns: table => new
                {
                    WorkoutRecordID = table.Column<Guid>(type: "TEXT", nullable: false),
                    WreWorkoutID_FK = table.Column<Guid>(type: "TEXT", nullable: false),
                    WreDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WreTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    WreCompletedRx = table.Column<bool>(type: "INTEGER", nullable: false),
                    WreScaledWeight = table.Column<float>(type: "REAL", nullable: false),
                    WreNotes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutRecordItems", x => x.WorkoutRecordID);
                    table.ForeignKey(
                        name: "FK_WorkoutRecordItems_WorkoutItems_WreWorkoutID_FK",
                        column: x => x.WreWorkoutID_FK,
                        principalTable: "WorkoutItems",
                        principalColumn: "WorkoutID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRecordItems_WreWorkoutID_FK",
                table: "WorkoutRecordItems",
                column: "WreWorkoutID_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutRecordItems");
        }
    }
}
