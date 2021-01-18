using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19Tracking.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenLocation_Citizen_SSN",
                table: "CitizenLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_CitizenLocation_Location_Addr",
                table: "CitizenLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_TestedAt_Citizen_SSN",
                table: "TestedAt");

            migrationBuilder.DropForeignKey(
                name: "FK_TestedAt_Testcenter_centerName",
                table: "TestedAt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestedAt",
                table: "TestedAt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CitizenLocation",
                table: "CitizenLocation");

            migrationBuilder.RenameTable(
                name: "TestedAt",
                newName: "testedAts");

            migrationBuilder.RenameTable(
                name: "CitizenLocation",
                newName: "citizenLocations");

            migrationBuilder.RenameIndex(
                name: "IX_TestedAt_centerName",
                table: "testedAts",
                newName: "IX_testedAts_centerName");

            migrationBuilder.RenameIndex(
                name: "IX_CitizenLocation_Addr",
                table: "citizenLocations",
                newName: "IX_citizenLocations_Addr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_testedAts",
                table: "testedAts",
                column: "SSN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_citizenLocations",
                table: "citizenLocations",
                column: "SSN");

            migrationBuilder.AddForeignKey(
                name: "FK_citizenLocations_Citizen_SSN",
                table: "citizenLocations",
                column: "SSN",
                principalTable: "Citizen",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_citizenLocations_Location_Addr",
                table: "citizenLocations",
                column: "Addr",
                principalTable: "Location",
                principalColumn: "Addr",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_testedAts_Citizen_SSN",
                table: "testedAts",
                column: "SSN",
                principalTable: "Citizen",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_testedAts_Testcenter_centerName",
                table: "testedAts",
                column: "centerName",
                principalTable: "Testcenter",
                principalColumn: "centerName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_citizenLocations_Citizen_SSN",
                table: "citizenLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_citizenLocations_Location_Addr",
                table: "citizenLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_testedAts_Citizen_SSN",
                table: "testedAts");

            migrationBuilder.DropForeignKey(
                name: "FK_testedAts_Testcenter_centerName",
                table: "testedAts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_testedAts",
                table: "testedAts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_citizenLocations",
                table: "citizenLocations");

            migrationBuilder.RenameTable(
                name: "testedAts",
                newName: "TestedAt");

            migrationBuilder.RenameTable(
                name: "citizenLocations",
                newName: "CitizenLocation");

            migrationBuilder.RenameIndex(
                name: "IX_testedAts_centerName",
                table: "TestedAt",
                newName: "IX_TestedAt_centerName");

            migrationBuilder.RenameIndex(
                name: "IX_citizenLocations_Addr",
                table: "CitizenLocation",
                newName: "IX_CitizenLocation_Addr");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestedAt",
                table: "TestedAt",
                column: "SSN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CitizenLocation",
                table: "CitizenLocation",
                column: "SSN");

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenLocation_Citizen_SSN",
                table: "CitizenLocation",
                column: "SSN",
                principalTable: "Citizen",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenLocation_Location_Addr",
                table: "CitizenLocation",
                column: "Addr",
                principalTable: "Location",
                principalColumn: "Addr",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestedAt_Citizen_SSN",
                table: "TestedAt",
                column: "SSN",
                principalTable: "Citizen",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestedAt_Testcenter_centerName",
                table: "TestedAt",
                column: "centerName",
                principalTable: "Testcenter",
                principalColumn: "centerName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
