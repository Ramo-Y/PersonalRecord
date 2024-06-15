using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalRecord.Domain.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableMovementRecordItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovementRecordItems",
                columns: table => new
                {
                    MovementRecordID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MvrWeight = table.Column<float>(type: "REAL", nullable: false),
                    MvrReps = table.Column<int>(type: "INTEGER", nullable: false),
                    MvrDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MvrMovementID_FK = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementRecordItems", x => x.MovementRecordID);
                    table.ForeignKey(
                        name: "FK_MovementRecordItems_MovementItems_MvrMovementID_FK",
                        column: x => x.MvrMovementID_FK,
                        principalTable: "MovementItems",
                        principalColumn: "MovementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovementRecordItems_MvrMovementID_FK",
                table: "MovementRecordItems",
                column: "MvrMovementID_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovementRecordItems");
        }
    }
}
