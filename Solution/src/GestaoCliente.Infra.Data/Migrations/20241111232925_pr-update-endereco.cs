using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoCliente.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class prupdateendereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE OR ALTER PROCEDURE [dbo].[pr_Endereco_Update]
	@id uniqueidentifier,
    @logradouro varchar(500),
    @numero varchar(10) = NULL,
    @complemento varchar(255) = NULL,
    @apelido varchar(50),
    @logradouroId int,
    @clienteId uniqueidentifier
AS

UPDATE dbo.Enderecos
SET
    dbo.Enderecos.Logradouro = @logradouro, -- varchar
    dbo.Enderecos.Numero = @numero, -- varchar
    dbo.Enderecos.Complemento = @complemento, -- varchar
    dbo.Enderecos.Apelido = @apelido, -- varchar
    dbo.Enderecos.LogradouroId = @logradouroId, -- int
    dbo.Enderecos.ClienteId = @clienteId -- uniqueidentifier
WHERE dbo.Enderecos.Id = @id

RETURN @@ROWCOUNT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}