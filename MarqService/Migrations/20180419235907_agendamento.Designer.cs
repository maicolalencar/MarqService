﻿// <auto-generated />
using MarqService.Data;
using MarqService.enumClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace MarqService.Migrations
{
    [DbContext(typeof(MarqServiceContext))]
    [Migration("20180419235907_agendamento")]
    partial class agendamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MarqService.Models.Agendamentos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DiaDaSemana");

                    b.Property<TimeSpan>("Hora");

                    b.HasKey("id");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("MarqService.Models.Anamnese", b =>
                {
                    b.Property<int>("IdAnamnese")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataAnamnese");

                    b.Property<int>("IdCliente");

                    b.HasKey("IdAnamnese");

                    b.HasIndex("IdCliente");

                    b.ToTable("Anamnese");
                });

            modelBuilder.Entity("MarqService.Models.AnamnesesMedidas", b =>
                {
                    b.Property<int>("IdAnamnese");

                    b.Property<int>("IdMedidas");

                    b.Property<int?>("MedidaIdMedida");

                    b.Property<float>("ValorMedida");

                    b.HasKey("IdAnamnese", "IdMedidas");

                    b.HasIndex("MedidaIdMedida");

                    b.ToTable("AnamnesesMedidas");
                });

            modelBuilder.Entity("MarqService.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Agendamentosid");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Endereco");

                    b.Property<string>("NomeCliente")
                        .IsRequired();

                    b.HasKey("IdCliente");

                    b.HasIndex("Agendamentosid");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("MarqService.Models.Massagens", b =>
                {
                    b.Property<int>("IdMassagem")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataHoraInicio");

                    b.Property<DateTime>("DataHoraTermino");

                    b.Property<int>("IdCliente");

                    b.HasKey("IdMassagem");

                    b.HasIndex("IdCliente");

                    b.ToTable("Massagens");
                });

            modelBuilder.Entity("MarqService.Models.Medida", b =>
                {
                    b.Property<int>("IdMedida")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomeMedida");

                    b.HasKey("IdMedida");

                    b.ToTable("Medida");
                });

            modelBuilder.Entity("MarqService.Models.Pagamentos", b =>
                {
                    b.Property<DateTime>("DataPagamento");

                    b.Property<int>("IdCliente");

                    b.Property<decimal>("Valor");

                    b.HasKey("DataPagamento");

                    b.HasIndex("IdCliente");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("MarqService.Models.Anamnese", b =>
                {
                    b.HasOne("MarqService.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MarqService.Models.AnamnesesMedidas", b =>
                {
                    b.HasOne("MarqService.Models.Anamnese", "Anamnese")
                        .WithMany("AnamnesesMedidas")
                        .HasForeignKey("IdAnamnese")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MarqService.Models.Medida", "Medida")
                        .WithMany("AnamnesesMedidas")
                        .HasForeignKey("MedidaIdMedida");
                });

            modelBuilder.Entity("MarqService.Models.Cliente", b =>
                {
                    b.HasOne("MarqService.Models.Agendamentos", "Agendamentos")
                        .WithMany()
                        .HasForeignKey("Agendamentosid");
                });

            modelBuilder.Entity("MarqService.Models.Massagens", b =>
                {
                    b.HasOne("MarqService.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MarqService.Models.Pagamentos", b =>
                {
                    b.HasOne("MarqService.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
