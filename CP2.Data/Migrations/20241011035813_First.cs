using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CP2.Data.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CNPJ = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_vendedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataContratacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ComissaoPercentual = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    MetaMensal = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    FornecedorId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vendedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_vendedor_tb_fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "tb_fornecedor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendedor_FornecedorId",
                table: "tb_vendedor",
                column: "FornecedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_vendedor");

            migrationBuilder.DropTable(
                name: "tb_fornecedor");
        }
    }
}
