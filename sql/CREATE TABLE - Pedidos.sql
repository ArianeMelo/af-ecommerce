USE [AF_ECommerce]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pedidos](
[Id] [uniqueidentifier] NOT NULL,
[Cliente_Id] [uniqueidentifier] NOT NULL,
[Data_Cadastro] [datetime2] (7) NOT NULL,
[Tipo_Frete] [varchar](15) NOT NULL,
[Status] [bit] NOT NULL,
[Valor] [decimal](18, 2) NOT NULL,
[Observacao] [varchar](255) NOT NULL,

CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED
(
[Id])WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pedidos] WITH CHECK ADD CONSTRAINT [FK_Pedidos_Clientes_Cliente_Id] FOREIGN KEY([Cliente_Id])
REFERENCES [dbo].[Clientes] ([Id])
GO

ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Clientes_Cliente_Id]
GO