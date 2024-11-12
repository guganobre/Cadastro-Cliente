using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoCliente.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class prinsertendereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE OR ALTER PROCEDURE pr_Endereco_Insert
    @logradouro varchar(500),
    @numero varchar(10) = NULL,
    @complemento varchar(255) = NULL,
    @apelido varchar(50),
    @logradouroId int,
    @clienteId uniqueidentifier
AS

DECLARE @id uniqueidentifier SET @id = newid();

INSERT INTO dbo.Enderecos
(
    Id,
    Logradouro,
    Numero,
    Complemento,
    Apelido,
    LogradouroId,
    ClienteId
)
VALUES
(
	@id,
    @logradouro, -- Logradouro - varchar
    @numero, -- Numero - varchar
    @complemento, -- Complemento - varchar
    @apelido, -- Apelido - varchar
    @logradouroId, -- LogradouroId - int
    @clienteId -- ClienteId - uniqueidentifier
)

SELECT @id AS Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrEnderecoInsertResponse");
        }
    }
}