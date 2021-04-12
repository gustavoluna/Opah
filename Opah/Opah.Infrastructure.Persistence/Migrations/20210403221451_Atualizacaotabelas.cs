using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Opah.Infrastructure.Persistence.Migrations
{
    public partial class Atualizacaotabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    IdCidade = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.IdCidade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Cod_Empresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Tipo_Endereco = table.Column<string>(nullable: true),
                    IdCidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClienteEndereco",
                columns: table => new
                {
                    IdClienteEndereco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    IdEndereco = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteEndereco", x => x.IdClienteEndereco);
                    table.ForeignKey(
                        name: "FK_ClienteEndereco_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteEndereco_Enderecos_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteEndereco_IdCliente",
                table: "ClienteEndereco",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteEndereco_IdEndereco",
                table: "ClienteEndereco",
                column: "IdEndereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "ClienteEndereco");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
