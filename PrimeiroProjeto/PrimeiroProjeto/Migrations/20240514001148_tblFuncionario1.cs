using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeiroProjeto.Migrations
{
    /// <inheritdoc />
    public partial class tblFuncionario1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Salario",
                table: "Funcionario",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salario",
                table: "Funcionario");
        }
    }
}
