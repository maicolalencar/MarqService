using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MarqService.Migrations
{
    public partial class agendamentoMuitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Agendamentos_Agendamentosid",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_Agendamentosid",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Agendamentosid",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Agendamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ClienteIdCliente",
                table: "Agendamentos",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Cliente_ClienteIdCliente",
                table: "Agendamentos",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Cliente_ClienteIdCliente",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_ClienteIdCliente",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Agendamentos");

            migrationBuilder.AddColumn<int>(
                name: "Agendamentosid",
                table: "Cliente",
                nullable: true);

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
    }
}
