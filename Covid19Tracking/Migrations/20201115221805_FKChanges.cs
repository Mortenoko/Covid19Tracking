using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19Tracking.Migrations
{
    public partial class FKChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TestedAt",
                table: "TestedAt");

            migrationBuilder.DropIndex(
                name: "IX_TestedAt_SSN",
                table: "TestedAt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testcentermanagement",
                table: "Testcentermanagement");

            migrationBuilder.DropIndex(
                name: "IX_Testcentermanagement_manageID",
                table: "Testcentermanagement");

            migrationBuilder.DropColumn(
                name: "TesID",
                table: "Testcentermanagement");

            migrationBuilder.AlterColumn<bool>(
                name: "result",
                table: "TestedAt",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "TestedAt",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestedAt",
                table: "TestedAt",
                column: "SSN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testcentermanagement",
                table: "Testcentermanagement",
                column: "manageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TestedAt",
                table: "TestedAt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testcentermanagement",
                table: "Testcentermanagement");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "TestedAt",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "result",
                table: "TestedAt",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "TesID",
                table: "Testcentermanagement",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestedAt",
                table: "TestedAt",
                column: "status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testcentermanagement",
                table: "Testcentermanagement",
                column: "TesID");

            migrationBuilder.CreateIndex(
                name: "IX_TestedAt_SSN",
                table: "TestedAt",
                column: "SSN");

            migrationBuilder.CreateIndex(
                name: "IX_Testcentermanagement_manageID",
                table: "Testcentermanagement",
                column: "manageID",
                unique: true);
        }
    }
}
