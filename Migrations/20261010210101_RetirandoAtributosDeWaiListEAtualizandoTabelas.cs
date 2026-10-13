using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaEspera.Migrations
{
    /// <inheritdoc />
    public partial class RetirandoAtributosDeWaiListEAtualizandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaitLists_ClassGroups_ClassGroupModelId",
                table: "WaitLists");

            migrationBuilder.DropForeignKey(
                name: "FK_WaitLists_Modalitys_ModalityId",
                table: "WaitLists");

            migrationBuilder.DropIndex(
                name: "IX_WaitLists_ClassGroupModelId",
                table: "WaitLists");

            migrationBuilder.DropColumn(
                name: "ClassGroupModelId",
                table: "WaitLists");

            migrationBuilder.RenameColumn(
                name: "PositionStats",
                table: "WaitLists",
                newName: "PositionStatus");

            migrationBuilder.RenameColumn(
                name: "ModalityId",
                table: "WaitLists",
                newName: "ClassGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_WaitLists_ModalityId",
                table: "WaitLists",
                newName: "IX_WaitLists_ClassGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaitLists_ClassGroups_ClassGroupId",
                table: "WaitLists",
                column: "ClassGroupId",
                principalTable: "ClassGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaitLists_ClassGroups_ClassGroupId",
                table: "WaitLists");

            migrationBuilder.RenameColumn(
                name: "PositionStatus",
                table: "WaitLists",
                newName: "PositionStats");

            migrationBuilder.RenameColumn(
                name: "ClassGroupId",
                table: "WaitLists",
                newName: "ModalityId");

            migrationBuilder.RenameIndex(
                name: "IX_WaitLists_ClassGroupId",
                table: "WaitLists",
                newName: "IX_WaitLists_ModalityId");

            migrationBuilder.AddColumn<int>(
                name: "ClassGroupModelId",
                table: "WaitLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaitLists_ClassGroupModelId",
                table: "WaitLists",
                column: "ClassGroupModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaitLists_ClassGroups_ClassGroupModelId",
                table: "WaitLists",
                column: "ClassGroupModelId",
                principalTable: "ClassGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WaitLists_Modalitys_ModalityId",
                table: "WaitLists",
                column: "ModalityId",
                principalTable: "Modalitys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
