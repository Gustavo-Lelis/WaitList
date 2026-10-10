using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaEspera.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoTablesAdicionandoClassGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassTimeTable",
                table: "Modalitys");

            migrationBuilder.AddColumn<int>(
                name: "ClassGroupModelId",
                table: "WaitLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModalityId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Days = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassTimeTable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassGroups_Modalitys_ModalityId",
                        column: x => x.ModalityId,
                        principalTable: "Modalitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaitLists_ClassGroupModelId",
                table: "WaitLists",
                column: "ClassGroupModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassGroups_ModalityId",
                table: "ClassGroups",
                column: "ModalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaitLists_ClassGroups_ClassGroupModelId",
                table: "WaitLists",
                column: "ClassGroupModelId",
                principalTable: "ClassGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaitLists_ClassGroups_ClassGroupModelId",
                table: "WaitLists");

            migrationBuilder.DropTable(
                name: "ClassGroups");

            migrationBuilder.DropIndex(
                name: "IX_WaitLists_ClassGroupModelId",
                table: "WaitLists");

            migrationBuilder.DropColumn(
                name: "ClassGroupModelId",
                table: "WaitLists");

            migrationBuilder.AddColumn<string>(
                name: "ClassTimeTable",
                table: "Modalitys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
