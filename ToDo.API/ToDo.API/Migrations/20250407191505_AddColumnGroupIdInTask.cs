using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.API.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnGroupIdInTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Groups_GrupoId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_GrupoId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Tasks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_GroupId",
                table: "Tasks",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Groups_GroupId",
                table: "Tasks",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Groups_GroupId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_GroupId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "Tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_GrupoId",
                table: "Tasks",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Groups_GrupoId",
                table: "Tasks",
                column: "GrupoId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
