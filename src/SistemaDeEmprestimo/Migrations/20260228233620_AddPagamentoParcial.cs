using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeEmprestimo.Migrations
{
    /// <inheritdoc />
    public partial class AddPagamentoParcial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Emprestimos",
                newName: "ValorOriginal");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorPago",
                table: "Emprestimos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorPago",
                table: "Emprestimos");

            migrationBuilder.RenameColumn(
                name: "ValorOriginal",
                table: "Emprestimos",
                newName: "Valor");
        }
    }
}
