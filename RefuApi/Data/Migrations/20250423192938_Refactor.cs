using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleAssignments_Schedules_ScheduleId",
                table: "ScheduleAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleAssignments_Users_UserId",
                table: "ScheduleAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleAssignments_Zones_ZoneId",
                table: "ScheduleAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleAssignments",
                table: "ScheduleAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleAssignments_ZoneId",
                table: "ScheduleAssignments");

            migrationBuilder.DropColumn(
                name: "ZoneId",
                table: "ScheduleAssignments");

            migrationBuilder.AddColumn<string>(
                name: "Report",
                table: "Schedules",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ZoneId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleAssignments",
                table: "ScheduleAssignments",
                columns: new[] { "UserId", "ScheduleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ZoneId",
                table: "Schedules",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleAssignments_Schedules_ScheduleId",
                table: "ScheduleAssignments",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleAssignments_Users_UserId",
                table: "ScheduleAssignments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Zones_ZoneId",
                table: "Schedules",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleAssignments_Schedules_ScheduleId",
                table: "ScheduleAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleAssignments_Users_UserId",
                table: "ScheduleAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Zones_ZoneId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_ZoneId",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleAssignments",
                table: "ScheduleAssignments");

            migrationBuilder.DropColumn(
                name: "Report",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ZoneId",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "ZoneId",
                table: "ScheduleAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleAssignments",
                table: "ScheduleAssignments",
                columns: new[] { "UserId", "ZoneId", "ScheduleId" });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleAssignments_ZoneId",
                table: "ScheduleAssignments",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleAssignments_Schedules_ScheduleId",
                table: "ScheduleAssignments",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleAssignments_Users_UserId",
                table: "ScheduleAssignments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleAssignments_Zones_ZoneId",
                table: "ScheduleAssignments",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
