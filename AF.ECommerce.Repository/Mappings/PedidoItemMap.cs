using AF.ECommerce.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Repository.Mappings
{
    public class PedidoItemMap : DommelEntityMap<PedidoItem>
    {
        public PedidoItemMap()
        {
            ToTable("Pedidos_Item");
            Map(pedidoItem => pedidoItem.Id).ToColumn("Id");
            Map(pedidoItem => pedidoItem.PedidoId).ToColumn("Pedido_Id");
            Map(pedidoItem => pedidoItem.ProdutoId).ToColumn("Produto_Id");
            Map(pedidoItem => pedidoItem.Quantidade).ToColumn("Quantidade");
            Map(pedidoItem => pedidoItem.Valor).ToColumn("Valor");
            Map(peidoItem => peidoItem.Desconto).ToColumn("Desconto");

        }
    }
}
