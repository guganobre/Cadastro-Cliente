-- APAGAR BANCO
--/*
ALTER TABLE Enderecos DROP CONSTRAINT Fk_Clientes_Enderecos;
ALTER TABLE Enderecos DROP CONSTRAINT Fk_Logradouros_Enderecos;
DROP TABLE Clientes;
DROP TABLE Enderecos;
DROP TABLE Logradouros;
--*/




CREATE TABLE Clientes (
  Id    uniqueidentifier DEFAULT newid() NOT NULL, 
  Nome  varchar(255) NULL, 
  Email varchar(255) NOT NULL, 
  CONSTRAINT Pk_Clientes 
    PRIMARY KEY (Id), 
  CONSTRAINT UQ_Cliente_Email 
    UNIQUE (Email));
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Armazenamento dos cliente', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Clientes';
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Identificador único do cliente', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Clientes', 
  @LEVEL2TYPE = N'Column', @LEVEL2NAME = N'Id';
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Nome do cliente', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Clientes', 
  @LEVEL2TYPE = N'Column', @LEVEL2NAME = N'Nome';
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'E-mail do cliente, campo único para cada cliente', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Clientes', 
  @LEVEL2TYPE = N'Column', @LEVEL2NAME = N'Email';
CREATE TABLE Enderecos (
  Id           uniqueidentifier DEFAULT newid() NOT NULL, 
  Nome         varchar(500) NOT NULL, 
  Numero       varchar(10) NULL, 
  Complemento  varchar(255) NULL, 
  Apelido      varchar(50) NOT NULL, 
  LogradouroId int NOT NULL, 
  ClienteId    uniqueidentifier NOT NULL, 
  CONSTRAINT Pk_Enderecos 
    PRIMARY KEY (Id));
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Tabela para armazenas os logradouros dos clientes', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Enderecos';
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Chave da tabela endereço', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Enderecos', 
  @LEVEL2TYPE = N'Column', @LEVEL2NAME = N'Id';
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Campo com o detalhe/nome da rua do endereço', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Enderecos', 
  @LEVEL2TYPE = N'Column', @LEVEL2NAME = N'Nome';
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Numero do endereço', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Enderecos', 
  @LEVEL2TYPE = N'Column', @LEVEL2NAME = N'Numero';
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Campo descritivo para detalhar o endereço', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Enderecos', 
  @LEVEL2TYPE = N'Column', @LEVEL2NAME = N'Complemento';
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Apelido identificador via sistema do enderço', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Enderecos', 
  @LEVEL2TYPE = N'Column', @LEVEL2NAME = N'Apelido';
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Chave da tabela logradouro', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Enderecos', 
  @LEVEL2TYPE = N'Column', @LEVEL2NAME = N'LogradouroId';
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Chave da tabela Cliente', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Enderecos', 
  @LEVEL2TYPE = N'Column', @LEVEL2NAME = N'ClienteId';
CREATE TABLE Logradouros (
  Id    int IDENTITY NOT NULL, 
  Nome  varchar(50) NOT NULL, 
  Ativo bit DEFAULT 1 NOT NULL, 
  CONSTRAINT Pk_Logradouros 
    PRIMARY KEY (Id), 
  CONSTRAINT UQ_Logradouros_Nome 
    UNIQUE (Nome));
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Tipos de logradouros para cadastro de endereço', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Logradouros';
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Chave da tabela logradouro', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Logradouros', 
  @LEVEL2TYPE = N'Column', @LEVEL2NAME = N'Id';
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Nome identificador do logradouro', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Logradouros', 
  @LEVEL2TYPE = N'Column', @LEVEL2NAME = N'Nome';
EXEC sp_addextendedproperty 
  @NAME = N'MS_Description', @VALUE = N'Status do logradouro', 
  @LEVEL0TYPE = N'Schema', @LEVEL0NAME = N'dbo', 
  @LEVEL1TYPE = N'Table', @LEVEL1NAME = N'Logradouros', 
  @LEVEL2TYPE = N'Column', @LEVEL2NAME = N'Ativo';
ALTER TABLE Enderecos ADD CONSTRAINT Fk_Clientes_Enderecos FOREIGN KEY (ClienteId) REFERENCES Clientes (Id);
ALTER TABLE Enderecos ADD CONSTRAINT Fk_Logradouros_Enderecos FOREIGN KEY (LogradouroId) REFERENCES Logradouros (Id);