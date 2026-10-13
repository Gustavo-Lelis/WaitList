using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaEspera.Migrations
{
    /// <inheritdoc />
    public partial class ModificarColunaWaitListModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionStatus",
                table: "WaitLists");

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "WaitLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "WaitLists");

            migrationBuilder.AddColumn<int>(
                name: "PositionStatus",
                table: "WaitLists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
