using AF.ECommerce.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.Repository.Mappings
{
    public class PedidoMap : DommelEntityMap<Pedido>
    {
        public PedidoMap()
        {
            ToTable("Pedidos");
            Map(pedido => pedido.Id).ToColumn("Id").IsKey();
            Map(pedido => pedido.ClienteId).ToColumn("Cliente_Id");
            Map(pedido => pedido.DataCadastro).ToColumn("Data_Cadastro");
            Map(pedido => pedido.TipoFrete).ToColumn("Tipo_Frete");
            Map(pedido => pedido.Status).ToColumn("Status");
            Map(pedido => pedido.Valor).ToColumn("Valor");
            Map(pedido => pedido.Observacao).ToColumn("Observacao");
        }
    }
}
