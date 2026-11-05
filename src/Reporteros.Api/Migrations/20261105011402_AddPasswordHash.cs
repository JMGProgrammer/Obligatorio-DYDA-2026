using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reporteros.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPFtpYysK++ZyMuQ4lXZGumfPzGNLmx7Rn08JNT8JuT/mj8xjDBo5jgxqN3LjVobpw==");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2L,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPFtpYysK++ZyMuQ4lXZGumfPzGNLmx7Rn08JNT8JuT/mj8xjDBo5jgxqN3LjVobpw==");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3L,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPFtpYysK++ZyMuQ4lXZGumfPzGNLmx7Rn08JNT8JuT/mj8xjDBo5jgxqN3LjVobpw==");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4L,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPFtpYysK++ZyMuQ4lXZGumfPzGNLmx7Rn08JNT8JuT/mj8xjDBo5jgxqN3LjVobpw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Usuarios");
        }
    }
}
