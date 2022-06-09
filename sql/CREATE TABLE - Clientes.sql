USE [AF_ECommerce]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].Clientes(
[Id] [uniqueidentifier] NOT NULL,
[Nome] [varchar](200) NOT NULL,
[CPF] [varchar](11) NOT NULL,
[RG] [varchar](8) NOT NULL,
[Telefone] [varchar] (11) NOT NULL,
[Endereco] [varchar] (50) NOT NULL,
[Numero] [int] NOT NULL,
[Cidade] [varchar] (50) NOT NULL,
[Estado] [varchar] (20) NOT NULL,
[CEP] [varchar] (20) NOT NULL,
[Data_Cadastro] [datetime2] (7) NOT NULL, 
CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO