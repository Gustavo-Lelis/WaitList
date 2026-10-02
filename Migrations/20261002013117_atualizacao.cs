using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaEspera.Migrations
{
    /// <inheritdoc />
    public partial class atualizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "Attendants");

            migrationBuilder.AddColumn<byte[]>(
                name: "HashPassword",
                table: "Attendants",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "SaltPassword",
                table: "Attendants",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashPassword",
                table: "Attendants");

            migrationBuilder.DropColumn(
                name: "SaltPassword",
                table: "Attendants");

            migrationBuilder.AddColumn<string>(
                name: "SenhaHash",
                table: "Attendants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
