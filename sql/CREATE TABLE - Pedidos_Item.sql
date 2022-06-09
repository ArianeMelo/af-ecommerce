USE [AF_ECommerce]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pedidos_Item](
[Id] [uniqueidentifier] NOT NULL,
[Pedido_Id] [uniqueidentifier] NOT NULL,
[Produto_Id] [uniqueidentifier] NOT NULL,
[Quantidade] [int] NOT NULL,
[Valor] [decimal](18, 2) NOT NULL,
[Desconto] [decimal](18, 2) NOT NULL,

CONSTRAINT [PK_Pedidos_Item] PRIMARY KEY CLUSTERED
(
[Id])WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pedidos_Item] WITH CHECK ADD CONSTRAINT [FK_Pedidos_Item_Pedidos_Pedido_Id] FOREIGN KEY([Pedido_Id])
REFERENCES [dbo].[Pedidos] ([Id])
GO

ALTER TABLE [dbo].[Pedidos_Item] CHECK CONSTRAINT [FK_Pedidos_Item_Pedidos_Pedido_Id]
GO

ALTER TABLE [dbo].[Pedidos_Item] WITH CHECK ADD CONSTRAINT [FK_Pedidos_Item_Produtos_Produto_Id] FOREIGN KEY([Produto_Id])
REFERENCES [dbo].[Produtos] ([Id])
GO

ALTER TABLE [dbo].[Pedidos_Item] CHECK CONSTRAINT [FK_Pedidos_Item_Produtos_Produto_Id]
GO