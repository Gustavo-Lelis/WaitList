using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaEspera.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarTabelasParaFuturaIntegracaoAzure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashPassword",
                table: "Attendants");

            migrationBuilder.DropColumn(
                name: "SaltPassword",
                table: "Attendants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
