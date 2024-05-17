using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeiroProjeto.Migrations
{
    /// <inheritdoc />
    public partial class tblFuncionario3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salario",
                table: "Funcionario");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Funcionario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Funcionario");

            migrationBuilder.AddColumn<double>(
                name: "Salario",
                table: "Funcionario",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
