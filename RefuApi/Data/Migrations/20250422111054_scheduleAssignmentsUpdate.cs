using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class scheduleAssignmentsUpdate : Migration
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
                name: "IX_ScheduleAssignments_UserId",
                table: "ScheduleAssignments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ScheduleAssignments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleAssignments",
                table: "ScheduleAssignments",
                columns: new[] { "UserId", "ZoneId", "ScheduleId" });

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
                name: "FK_ScheduleAssignments_Zones_ZoneId",
                table: "ScheduleAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleAssignments",
                table: "ScheduleAssignments");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ScheduleAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleAssignments",
                table: "ScheduleAssignments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleAssignments_UserId",
                table: "ScheduleAssignments",
                column: "UserId");

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
                name: "FK_ScheduleAssignments_Zones_ZoneId",
                table: "ScheduleAssignments",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
