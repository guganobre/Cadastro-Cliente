using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoCliente.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class prdeltecliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE or ALTER PROCEDURE pr_Cliente_Delete
	@id uniqueidentifier
as

DELETE Enderecos WHERE ClienteId =  @id

DELETE Clientes WHERE Id = @id

RETURN @@ROWCOUNT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}