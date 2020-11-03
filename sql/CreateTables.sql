USE PIZZARIA;
GO

CREATE TABLE T_CLIENTE
(
	ID_CLIENTE UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	NM_CLIENTE NVARCHAR(70) NOT NULL,
	NU_TELEFONE NVARCHAR(11) NOT NULL
)	
GO

CREATE TABLE T_ENDERECO
(
	ID_ENDERECO UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	NM_LOGRADOURO NVARCHAR(150) NOT NULL,
	DS_NUMERO_ENDERECO NVARCHAR(10) NOT NULL,
	DS_COMPLEMENTO NVARCHAR(150) NULL,
	DS_BAIRRO NVARCHAR(50) NOT NULL,
	DS_CIDADE NVARCHAR(50) NOT NULL,
	DS_ESTADO NVARCHAR(50) NOT NULL,
	DS_CEP NVARCHAR(8) NOT NULL,
	CD_CLIENTE UNIQUEIDENTIFIER
)
GO

ALTER TABLE T_ENDERECO
ADD CONSTRAINT FK_ENDERECO_CLIENTE FOREIGN KEY (CD_CLIENTE)
REFERENCES T_CLIENTE (ID_CLIENTE)
GO

