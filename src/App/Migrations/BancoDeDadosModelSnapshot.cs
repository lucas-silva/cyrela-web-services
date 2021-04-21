﻿// <auto-generated />
using System;
using App.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Migrations
{
    [DbContext(typeof(BancoDeDados))]
    partial class BancoDeDadosModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("App.Dominio.Entidades.Garantia", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("casos_cobertos")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("casos_nao_cobertos")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("dia_final")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("dia_inicial")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("nome_casa")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("tipo_de_produto")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Garantias");
                });

            modelBuilder.Entity("App.Dominio.Entidades.Visita", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("dia_pedido")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("dia_visita")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("hora_visita")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ocorrencia")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("status")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("tecnico")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Visitas");
                });

            modelBuilder.Entity("App.Dominio.Entidades.Vistoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("data_agendamento")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("data_aprovacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("data_cancelamento")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("data_reprovacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("problemas_encontrados")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("status")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Vistorias");
                });
#pragma warning restore 612, 618
        }
    }
}
