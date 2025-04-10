using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trackracer.api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate44444 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ByNotUserModel");
        }
    }
}
