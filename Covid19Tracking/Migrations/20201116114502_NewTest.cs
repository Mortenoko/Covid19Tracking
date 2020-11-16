using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19Tracking.Migrations
{
    public partial class NewTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipality_Nation_nName",
                table: "Municipality");

            migrationBuilder.RenameColumn(
                name: "nName",
                table: "Nation",
                newName: "NationName");

            migrationBuilder.RenameColumn(
                name: "nName",
                table: "Municipality",
                newName: "NationName");

            migrationBuilder.RenameIndex(
                name: "IX_Municipality_nName",
                table: "Municipality",
                newName: "IX_Municipality_NationName");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipality_Nation_NationName",
                table: "Municipality",
                column: "NationName",
                principalTable: "Nation",
                principalColumn: "NationName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipality_Nation_NationName",
                table: "Municipality");

            migrationBuilder.RenameColumn(
                name: "NationName",
                table: "Nation",
                newName: "nName");

            migrationBuilder.RenameColumn(
                name: "NationName",
                table: "Municipality",
                newName: "nName");

            migrationBuilder.RenameIndex(
                name: "IX_Municipality_NationName",
                table: "Municipality",
                newName: "IX_Municipality_nName");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipality_Nation_nName",
                table: "Municipality",
                column: "nName",
                principalTable: "Nation",
                principalColumn: "nName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
