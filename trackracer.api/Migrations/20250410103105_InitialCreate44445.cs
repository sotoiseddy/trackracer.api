using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trackracer.api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate44445 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ByNotUserModel");

            migrationBuilder.DropTable(
                name: "ByUserModel");

            migrationBuilder.DropTable(
                name: "UserModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ByNotUserModel",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    NameofPersonwhoishim = table.Column<string>(type: "TEXT", nullable: false),
                    SecurityPasscodefortheperson = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ByNotUserModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ByUserModel",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    NameofPerson = table.Column<string>(type: "TEXT", nullable: false),
                    SecurityPasscode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ByUserModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Passcode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.ID);
                });
        }
    }
}
