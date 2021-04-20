using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class Garantia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garantias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome_casa = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    tipo_de_produto = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    dia_inicial = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    dia_final = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    casos_cobertos = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    casos_nao_cobertos = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    descricao = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garantias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Visitas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ocorrencia = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    status = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    tecnico = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    dia_pedido = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    dia_visita = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitas", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garantias");

            migrationBuilder.DropTable(
                name: "Visitas");
        }
    }
}
