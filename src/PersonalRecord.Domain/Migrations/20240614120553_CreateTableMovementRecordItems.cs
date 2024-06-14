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
                    PersonalRecordID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    Reps = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MovementID_FK = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementRecordItems", x => x.PersonalRecordID);
                    table.ForeignKey(
                        name: "FK_MovementRecordItems_MovementItems_MovementID_FK",
                        column: x => x.MovementID_FK,
                        principalTable: "MovementItems",
                        principalColumn: "MovementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovementRecordItems_MovementID_FK",
                table: "MovementRecordItems",
                column: "MovementID_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovementRecordItems");
        }
    }
}
