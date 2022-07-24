using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Euvic.StaffTraining.Migrations
{
    public partial class RemoveIdentityFromAttendeAndLecturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrainingAttendeeStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "AllowedHours",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "UserProviderId",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "UserProviderId",
                table: "Attendees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AllowedHours",
                table: "Lecturers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UserProviderId",
                table: "Lecturers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserProviderId",
                table: "Attendees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "TrainingAttendeeStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Declined" });
        }
    }
}
