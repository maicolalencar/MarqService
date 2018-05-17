using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MarqService.Migrations
{
    public partial class alteracao_pagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Cliente_ClienteIdCliente",
                table: "Agendamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pagamentos",
                table: "Pagamentos");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Pagamentos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteIdCliente",
                table: "Agendamentos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pagamentos",
                table: "Pagamentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Cliente_ClienteIdCliente",
                table: "Agendamentos",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Cliente_ClienteIdCliente",
                table: "Agendamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pagamentos",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pagamentos");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteIdCliente",
                table: "Agendamentos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pagamentos",
                table: "Pagamentos",
                column: "DataPagamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Cliente_ClienteIdCliente",
                table: "Agendamentos",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
