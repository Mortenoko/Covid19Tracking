using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19Tracking.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Testcentermanagement",
                table: "Testcentermanagement");

            migrationBuilder.DropIndex(
                name: "IX_Testcentermanagement_manageID",
                table: "Testcentermanagement");

            migrationBuilder.AlterColumn<string>(
                name: "SSN",
                table: "TestedAt",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "phoneNum",
                table: "Testcentermanagement",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "SSN",
                table: "CitizenLocation",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "SSN",
                table: "Citizen",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testcentermanagement",
                table: "Testcentermanagement",
                column: "manageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Testcentermanagement",
                table: "Testcentermanagement");

            migrationBuilder.AlterColumn<int>(
                name: "SSN",
                table: "TestedAt",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "phoneNum",
                table: "Testcentermanagement",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "SSN",
                table: "CitizenLocation",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "SSN",
                table: "Citizen",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testcentermanagement",
                table: "Testcentermanagement",
                column: "phoneNum");

            migrationBuilder.CreateIndex(
                name: "IX_Testcentermanagement_manageID",
                table: "Testcentermanagement",
                column: "manageID",
                unique: true);
        }
    }
}
