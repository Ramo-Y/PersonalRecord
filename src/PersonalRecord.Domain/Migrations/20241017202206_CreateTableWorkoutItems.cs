using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalRecord.Domain.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableWorkoutItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovementWithIntIdItems");

            migrationBuilder.CreateTable(
                name: "WorkoutItems",
                columns: table => new
                {
                    WorkoutID = table.Column<Guid>(type: "TEXT", nullable: false),
                    WokName = table.Column<string>(type: "TEXT", nullable: false),
                    WokNotes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutItems", x => x.WorkoutID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutItems");

            migrationBuilder.CreateTable(
                name: "MovementWithIntIdItems",
                columns: table => new
                {
                    MovementID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementWithIntIdItems", x => x.MovementID);
                });
        }
    }
}
