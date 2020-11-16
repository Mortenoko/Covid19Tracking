using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19Tracking.Migrations
{
    public partial class NewCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testcentermanagement_Testcenter_manageID",
                table: "Testcentermanagement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testcentermanagement",
                table: "Testcentermanagement");

            migrationBuilder.RenameColumn(
                name: "manageID",
                table: "Testcentermanagement",
                newName: "centerID");

            migrationBuilder.RenameColumn(
                name: "CenterId",
                table: "Testcenter",
                newName: "centerID");

            migrationBuilder.AlterColumn<int>(
                name: "phoneNum",
                table: "Testcentermanagement",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testcentermanagement",
                table: "Testcentermanagement",
                column: "phoneNum");

            migrationBuilder.CreateIndex(
                name: "IX_Testcentermanagement_centerID",
                table: "Testcentermanagement",
                column: "centerID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Testcentermanagement_Testcenter_centerID",
                table: "Testcentermanagement",
                column: "centerID",
                principalTable: "Testcenter",
                principalColumn: "centerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testcentermanagement_Testcenter_centerID",
                table: "Testcentermanagement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testcentermanagement",
                table: "Testcentermanagement");

            migrationBuilder.DropIndex(
                name: "IX_Testcentermanagement_centerID",
                table: "Testcentermanagement");

            migrationBuilder.RenameColumn(
                name: "centerID",
                table: "Testcentermanagement",
                newName: "manageID");

            migrationBuilder.RenameColumn(
                name: "centerID",
                table: "Testcenter",
                newName: "CenterId");

            migrationBuilder.AlterColumn<int>(
                name: "phoneNum",
                table: "Testcentermanagement",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testcentermanagement",
                table: "Testcentermanagement",
                column: "manageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Testcentermanagement_Testcenter_manageID",
                table: "Testcentermanagement",
                column: "manageID",
                principalTable: "Testcenter",
                principalColumn: "CenterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
