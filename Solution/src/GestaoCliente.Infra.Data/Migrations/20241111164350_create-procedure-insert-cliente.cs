using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoCliente.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class createprocedureinsertcliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE or ALTER PROCEDURE pr_Cliente_Insert
	@nome varchar(255) = NULL,
	@email varchar(255)
as

DECLARE @id uniqueidentifier SET @id = newid();

INSERT INTO dbo.Clientes
(
	Id,
    Nome,
    Email
)
VALUES
(
    @id, -- Id - uniqueidentifier
    @nome, -- Nome - varchar
    @email -- Email - varchar
)

SELECT @id as Id
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}