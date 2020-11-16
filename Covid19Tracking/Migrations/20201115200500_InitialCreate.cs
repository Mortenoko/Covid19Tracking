using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19Tracking.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nation",
                columns: table => new
                {
                    nName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nation", x => x.nName);
                });

            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    MunicipalityID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    mName = table.Column<string>(type: "TEXT", nullable: true),
                    nName = table.Column<string>(type: "TEXT", nullable: true),
                    Population = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.MunicipalityID);
                    table.ForeignKey(
                        name: "FK_Municipality_Nation_nName",
                        column: x => x.nName,
                        principalTable: "Nation",
                        principalColumn: "nName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citizen",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    age = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Sex = table.Column<string>(type: "TEXT", nullable: true),
                    MunicipalityID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizen", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Citizen_Municipality_MunicipalityID",
                        column: x => x.MunicipalityID,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Addr = table.Column<string>(type: "TEXT", nullable: false),
                    MunicipalityID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Addr);
                    table.ForeignKey(
                        name: "FK_Location_Municipality_MunicipalityID",
                        column: x => x.MunicipalityID,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Testcenter",
                columns: table => new
                {
                    CenterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hours = table.Column<string>(type: "TEXT", nullable: true),
                    MunicipalityID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testcenter", x => x.CenterId);
                    table.ForeignKey(
                        name: "FK_Testcenter_Municipality_MunicipalityID",
                        column: x => x.MunicipalityID,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitizenLocation",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "INTEGER", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Addr = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenLocation", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_CitizenLocation_Citizen_SSN",
                        column: x => x.SSN,
                        principalTable: "Citizen",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitizenLocation_Location_Addr",
                        column: x => x.Addr,
                        principalTable: "Location",
                        principalColumn: "Addr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Testcentermanagement",
                columns: table => new
                {
                    TesID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    phoneNum = table.Column<int>(type: "INTEGER", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    manageID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testcentermanagement", x => x.TesID);
                    table.ForeignKey(
                        name: "FK_Testcentermanagement_Testcenter_manageID",
                        column: x => x.manageID,
                        principalTable: "Testcenter",
                        principalColumn: "CenterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestedAt",
                columns: table => new
                {
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    result = table.Column<string>(type: "TEXT", nullable: true),
                    SSN = table.Column<int>(type: "INTEGER", nullable: false),
                    TestedAtID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestedAt", x => x.status);
                    table.ForeignKey(
                        name: "FK_TestedAt_Citizen_SSN",
                        column: x => x.SSN,
                        principalTable: "Citizen",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestedAt_Testcenter_TestedAtID",
                        column: x => x.TestedAtID,
                        principalTable: "Testcenter",
                        principalColumn: "CenterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citizen_MunicipalityID",
                table: "Citizen",
                column: "MunicipalityID");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenLocation_Addr",
                table: "CitizenLocation",
                column: "Addr");

            migrationBuilder.CreateIndex(
                name: "IX_Location_MunicipalityID",
                table: "Location",
                column: "MunicipalityID");

            migrationBuilder.CreateIndex(
                name: "IX_Municipality_nName",
                table: "Municipality",
                column: "nName");

            migrationBuilder.CreateIndex(
                name: "IX_Testcenter_MunicipalityID",
                table: "Testcenter",
                column: "MunicipalityID");

            migrationBuilder.CreateIndex(
                name: "IX_Testcentermanagement_manageID",
                table: "Testcentermanagement",
                column: "manageID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestedAt_SSN",
                table: "TestedAt",
                column: "SSN");

            migrationBuilder.CreateIndex(
                name: "IX_TestedAt_TestedAtID",
                table: "TestedAt",
                column: "TestedAtID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitizenLocation");

            migrationBuilder.DropTable(
                name: "Testcentermanagement");

            migrationBuilder.DropTable(
                name: "TestedAt");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Citizen");

            migrationBuilder.DropTable(
                name: "Testcenter");

            migrationBuilder.DropTable(
                name: "Municipality");

            migrationBuilder.DropTable(
                name: "Nation");
        }
    }
}
