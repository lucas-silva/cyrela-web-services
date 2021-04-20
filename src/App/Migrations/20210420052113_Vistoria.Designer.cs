﻿// <auto-generated />
using System;
using App.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Migrations
{
    [DbContext(typeof(BancoDeDados))]
    [Migration("20210420052113_Vistoria")]
    partial class Vistoria
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

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