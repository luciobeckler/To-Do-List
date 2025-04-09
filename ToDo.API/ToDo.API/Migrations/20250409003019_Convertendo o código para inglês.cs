using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.API.Migrations
{
    /// <inheritdoc />
    public partial class Convertendoocódigoparainglês : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_fim",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Data_inicio",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Tasks",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Prioridade",
                table: "Tasks",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Groups",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "EndDateTime",
                table: "Tasks",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDateTime",
                table: "Tasks",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tasks",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Tasks",
                newName: "Prioridade");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Groups",
                newName: "Titulo");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Data_fim",
                table: "Tasks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "Data_inicio",
                table: "Tasks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Tasks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "Groups",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
