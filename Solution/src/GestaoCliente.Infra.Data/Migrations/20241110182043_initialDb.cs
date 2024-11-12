using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestaoCliente.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()", comment: "Identificador único do cliente"),
                    Nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "Nome do cliente"),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, comment: "E-mail do cliente, campo único para cada cliente")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Clientes", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                },
                comment: "Armazenamento dos cliente");

            migrationBuilder.CreateTable(
                name: "TiposLogradouro",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Chave da tabela tipo logradouro")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, comment: "Nome identificador do tipo logradouro"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, comment: "Status do tipo logradouro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Logradouros", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                },
                comment: "Tipos de logradouros para cadastro de endereço");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()", comment: "Chave da tabela endereço"),
                    Logradouro = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false, comment: "Campo com o detalhe/nome do logradouro"),
                    Numero = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, comment: "Numero do endereço"),
                    Complemento = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "Campo descritivo para detalhar o endereço"),
                    Apelido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Apelido identificador via sistema do enderço"),
                    LogradouroId = table.Column<int>(type: "int", nullable: false, comment: "Chave da tabela tipo logradouro"),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave da tabela Cliente")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Enderecos", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "Fk_Clientes_Enderecos",
                        column: x => x.ClienteId,
                        principalSchema: "dbo",
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_TiposLogradouro_Enderecos",
                        column: x => x.LogradouroId,
                        principalSchema: "dbo",
                        principalTable: "TiposLogradouro",
                        principalColumn: "Id");
                },
                comment: "Tabela para armazenar os logradouros dos clientes");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TiposLogradouro",
                columns: new[] { "Id", "Ativo", "Nome" },
                values: new object[,]
                {
                    { 1, true, "Rua" },
                    { 2, true, "Avenida" },
                    { 3, true, "Praça" },
                    { 4, true, "Alameda" },
                    { 5, true, "Travessa" },
                    { 6, true, "Estrada" },
                    { 7, true, "Rodovia" },
                    { 8, true, "Largo" },
                    { 9, true, "Vila" },
                    { 10, true, "Beco" },
                    { 11, true, "Quadra" },
                    { 12, true, "Servidão" }
                });

            migrationBuilder.CreateIndex(
                name: "UQ_Cliente_Email",
                schema: "dbo",
                table: "Clientes",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                schema: "dbo",
                table: "Enderecos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_LogradouroId",
                schema: "dbo",
                table: "Enderecos",
                column: "LogradouroId");

            migrationBuilder.CreateIndex(
                name: "UQ_Logradouros_Nome",
                schema: "dbo",
                table: "TiposLogradouro",
                column: "Nome",
                unique: true,
                filter: "[Nome] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TiposLogradouro",
                schema: "dbo");
        }
    }
}
