using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MarqService.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaDaSemana = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Medida",
                columns: table => new
                {
                    IdMedida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeMedida = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medida", x => x.IdMedida);
                });

            migrationBuilder.CreateTable(
                name: "Anamnese",
                columns: table => new
                {
                    IdAnamnese = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataAnamnese = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamnese", x => x.IdAnamnese);
                    table.ForeignKey(
                        name: "FK_Anamnese_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Massagens",
                columns: table => new
                {
                    IdMassagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataHoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Massagens", x => x.IdMassagem);
                    table.ForeignKey(
                        name: "FK_Massagens_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.DataPagamento);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnamnesesMedidas",
                columns: table => new
                {
                    IdAnamnese = table.Column<int>(type: "int", nullable: false),
                    IdMedidas = table.Column<int>(type: "int", nullable: false),
                    MedidaIdMedida = table.Column<int>(type: "int", nullable: true),
                    ValorMedida = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnamnesesMedidas", x => new { x.IdAnamnese, x.IdMedidas });
                    table.ForeignKey(
                        name: "FK_AnamnesesMedidas_Anamnese_IdAnamnese",
                        column: x => x.IdAnamnese,
                        principalTable: "Anamnese",
                        principalColumn: "IdAnamnese",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnamnesesMedidas_Medida_MedidaIdMedida",
                        column: x => x.MedidaIdMedida,
                        principalTable: "Medida",
                        principalColumn: "IdMedida",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anamnese_IdCliente",
                table: "Anamnese",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_AnamnesesMedidas_MedidaIdMedida",
                table: "AnamnesesMedidas",
                column: "MedidaIdMedida");

            migrationBuilder.CreateIndex(
                name: "IX_Massagens_IdCliente",
                table: "Massagens",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_IdCliente",
                table: "Pagamentos",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnamnesesMedidas");

            migrationBuilder.DropTable(
                name: "Massagens");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Anamnese");

            migrationBuilder.DropTable(
                name: "Medida");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
