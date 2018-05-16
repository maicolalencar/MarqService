using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MarqService.Migrations
{
    public partial class agendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaDaSemana",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Hora",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "Agendamentosid",
                table: "Cliente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiaDaSemana = table.Column<int>(type: "int", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Agendamentosid",
                table: "Cliente",
                column: "Agendamentosid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Agendamentos_Agendamentosid",
                table: "Cliente",
                column: "Agendamentosid",
                principalTable: "Agendamentos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Agendamentos_Agendamentosid",
                table: "Cliente");

            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_Agendamentosid",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Agendamentosid",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "DiaDaSemana",
                table: "Cliente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Hora",
                table: "Cliente",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
