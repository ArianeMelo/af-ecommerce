USE [AF_ECommerce]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Produtos](
[Id] [uniqueidentifier] NOT NULL,
[Categoria_Id] [uniqueidentifier] NOT NULL,
[Codigo] [varchar](20) NOT NULL,
[Descricao] [varchar](100) NOT NULL,
[Valor] [decimal](18, 2) NOT NULL,
[Tipo_Produto] [int] NOT NULL,
[Estoque] [int] NOT NULL,
[Ativo] [bit] NOT NULL,

CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED
(
[Id])WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Produtos] WITH CHECK ADD CONSTRAINT [FK_Produtos_Categorias_Categoria_Id] FOREIGN KEY([Categoria_Id])
REFERENCES [dbo].[Categorias] ([Id])
GO

ALTER TABLE [dbo].[Produtos] CHECK CONSTRAINT [FK_Produtos_Categorias_Categoria_Id]
GO