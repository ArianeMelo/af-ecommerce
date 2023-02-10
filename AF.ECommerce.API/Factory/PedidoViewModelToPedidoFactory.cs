using AF.ECommerce.API.ViewModel;
using AF.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AF.ECommerce.API.Factory
{
    public static class PedidoViewModelToPedidoFactory
    {
        public static Pedido Criar(PedidoPostViewModel pedidoPostViewModel)
        {
            var pedido = new Pedido(pedidoPostViewModel.ClienteId, pedidoPostViewModel.TipoFrete, pedidoPostViewModel.Observacao);

            pedidoPostViewModel.Itens.ForEach(item =>
            {
                var pedidoItem = new PedidoItem(pedido.Id, item.ProdutoId, item.Quantidade, item.Valor, item.Desconto);

                pedido.AdicionarItem(pedidoItem);

            });

            return pedido;
        }
    }
}
