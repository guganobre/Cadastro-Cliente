using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoCliente.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class pr_updatecliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE or ALTER PROCEDURE pr_Cliente_Update
	@id uniqueidentifier,
	@nome varchar(255) = NULL,
	@email varchar(255)
as

UPDATE dbo.Clientes
SET
    dbo.Clientes.Nome = @nome, -- varchar
    dbo.Clientes.Email = @email -- varchar
WHERE dbo.Clientes.Id = @Id

RETURN @@ROWCOUNT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}