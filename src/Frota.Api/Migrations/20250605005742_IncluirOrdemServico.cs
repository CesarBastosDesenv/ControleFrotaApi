using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frota.Api.Migrations
{
    /// <inheritdoc />
    public partial class IncluirOrdemServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdemServicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DtServico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoManutencao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefeitoApresentado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Executor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorMaoObra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemServicos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServicos_VeiculoId",
                table: "OrdemServicos",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemServicos");
        }
    }
}
