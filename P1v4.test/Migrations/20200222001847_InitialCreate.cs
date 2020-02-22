using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P1v4.test.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Entry",
                columns: table => new
                {
                    EntryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    HE = table.Column<DateTime>(nullable: true),
                    HE_A = table.Column<DateTime>(nullable: true),
                    HS_A = table.Column<DateTime>(nullable: true),
                    HS = table.Column<DateTime>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entry", x => x.EntryID);
                    table.ForeignKey(
                        name: "FK_Entry_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entry_UserID",
                table: "Entry",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entry");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
