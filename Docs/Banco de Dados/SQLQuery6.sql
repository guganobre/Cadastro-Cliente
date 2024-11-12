
ALTER   PROCEDURE [dbo].[pr_Endereco_Update]
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

SELECT @id AS Id
