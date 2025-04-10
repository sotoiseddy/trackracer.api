using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trackracer.api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatModel",
                table: "ChatModel");

            migrationBuilder.RenameTable(
                name: "ChatModel",
                newName: "ChatTB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatTB",
                table: "ChatTB",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatTB",
                table: "ChatTB");

            migrationBuilder.RenameTable(
                name: "ChatTB",
                newName: "ChatModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatModel",
                table: "ChatModel",
                column: "Id");
        }
    }
}
