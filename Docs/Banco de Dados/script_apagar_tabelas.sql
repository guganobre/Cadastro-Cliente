-- APAGAR BANCO
--/*
IF EXISTS (SELECT 1 
           FROM sys.foreign_keys 
           WHERE name = 'Fk_Clientes_Enderecos' 
           AND parent_object_id = OBJECT_ID('Enderecos'))
BEGIN
    ALTER TABLE Enderecos DROP CONSTRAINT Fk_Clientes_Enderecos;
END;

IF EXISTS (SELECT 1 
           FROM sys.foreign_keys 
           WHERE name = 'Fk_TiposLogradouro_Enderecos' 
           AND parent_object_id = OBJECT_ID('Enderecos'))
BEGIN
    ALTER TABLE Enderecos DROP CONSTRAINT Fk_TiposLogradouro_Enderecos;
END;

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '__EFMigrationsHistory')
BEGIN
    DROP TABLE [dbo].[__EFMigrationsHistory];
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Clientes')
BEGIN
    DROP TABLE [dbo].Clientes;
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Enderecos')
BEGIN
    DROP TABLE [dbo].Enderecos;
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TiposLogradouro')
BEGIN
    DROP TABLE [dbo].TiposLogradouro;
END
--*/

